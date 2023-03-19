using GemBox.Spreadsheet;
using MathNet.Numerics.LinearAlgebra;
using Microsoft.ML.OnnxRuntime.Tensors;
using Microsoft.ML.OnnxRuntime;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NeospectraApp.Model
{
    public class SSKEngine
    {


        static DataTable output;
        static readonly string WorkingDir = GetAbsolutePath(@"../../../../../../TFModel");
        static readonly string InputFile = GetAbsolutePath(@"../../../../../data SSK dan Lab.xls");
        static readonly string InputFileCsv = GetAbsolutePath(@"../../../../../inputtest.csv");
        static readonly string ResultFileCsv = GetAbsolutePath(@"../../../../../result.csv");

        public SSKEngine()
        {
            SpreadsheetInfo.SetLicense("EDWG-SKFA-D7J1-LDQ5");
            Console.WriteLine("evaluate model ssk..");
            //create onnx model
            //ConvertTFLiteToOnnx();
            ExecuteModel();
            Console.WriteLine("evaluation is completed");
            //Console.ReadLine();
        }

        #region convert model
        //pip install tf2onnx
        static void ConvertTFLiteToOnnx()
        {
            List<string> cmds = new List<string>();
            var dir = new DirectoryInfo(WorkingDir);
            if (dir.Exists)
            {
                var files = dir.GetFiles("*.tflite");
                foreach (var file in files)
                {
                    var s = $"python -m tf2onnx.convert --opset 13 --tflite {file.Name} --output {Path.GetFileNameWithoutExtension(file.Name)}.onnx";
                    cmds.Add(s);

                }
                if (cmds.Count > 0)
                {
                    ExecuteCmd(cmds.ToArray());
                }
            }
        }

        static void ExecuteCmd(string[] commands)
        {
            var process = new System.Diagnostics.Process();
            var startInfo = new System.Diagnostics.ProcessStartInfo
            {
                WorkingDirectory = WorkingDir,
                WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal,
                FileName = "cmd.exe",
                RedirectStandardInput = true,
                UseShellExecute = false,
                RedirectStandardOutput = true
            };

            process.StartInfo = startInfo;
            process.Start();

            foreach (var cmd in commands)
            {
                process.StandardInput.WriteLine(cmd);
                //string output = process.StandardOutput.ReadToEnd();
                //Console.WriteLine("output >> "+output);
            }
            process.WaitForExit();

            //process.Close();

        }
        #endregion
        #region inference model

        static bool ExecuteModel()
        {
            //get input from excel
            /*
            int colInput = 23;
            if (!File.Exists(InputFile)) return false;
            //get input data
            var workbook = ExcelFile.Load(InputFile);
            Console.WriteLine("reading input file..");
            // Iterate through all worksheets in an Excel workbook.
            var worksheet = workbook.Worksheets["Data Scan"];
            {
                // Iterate through all rows in an Excel worksheet.
                foreach (var row in worksheet.Rows)
                {
                    if (row.Index > 0)
                    {
                        var dataString = row.Cells[colInput].Value.ToString();
                        var inputFloat = JsonConvert.DeserializeObject<List<float>>(dataString);
                        if (inputFloat != null && inputFloat.Count == 154)
                        {
                            var inputF = PreProcessData(inputFloat);
                            DoInference(inputF);
                        }
                    }
                }
            }*/
            //use csv input
            if (!File.Exists(InputFileCsv)) return false;
            CreateOutputTable();
            var dt = ConvertCSVtoDataTable(InputFileCsv);
            var index = 0;
            int MaxRow = 3;
            foreach (DataRow row in dt.Rows)
            {

                var inputFloat = new List<float>();
                //get input
                foreach (DataColumn dc in dt.Columns)
                {
                    var rowNum = float.Parse(dc.ColumnName);
                    if (rowNum < 2502 && rowNum >= 1350)
                    {
                        inputFloat.Add(Convert.ToSingle(row[dc.ColumnName]));
                    }
                }

                if (inputFloat != null && inputFloat.Count == 154)
                {
                    var inputF = PreProcessData(inputFloat);
                    DoInference(index, inputF);
                }
                index++;
                if (index > MaxRow) break;
            }
            output.AcceptChanges();
            ExportToExcel(ResultFileCsv, "hasil", output);
            return true;
        }
        public static string ExportToExcel(string fPath, string SheetName, DataTable tableData)
        {
            //var fPath = Path.GetTempFileName() + ".xlsx";
            try
            {


                var workbook = new ExcelFile();
                var worksheet = workbook.Worksheets.Add($"{SheetName}");
                var styleHeader2 = new CellStyle();
                styleHeader2.HorizontalAlignment = HorizontalAlignmentStyle.Left;
                styleHeader2.VerticalAlignment = VerticalAlignmentStyle.Center;
                styleHeader2.Font.Weight = ExcelFont.BoldWeight;
                styleHeader2.FillPattern.SetSolid(System.Drawing.Color.LightGreen);

                var styleHeader = new CellStyle();
                styleHeader.HorizontalAlignment = HorizontalAlignmentStyle.Left;
                styleHeader.VerticalAlignment = VerticalAlignmentStyle.Center;
                styleHeader.Font.Weight = ExcelFont.BoldWeight;
                styleHeader.FillPattern.SetSolid(System.Drawing.Color.AliceBlue);
                int Rows = 0;
                int Cols = 0;
                foreach (DataColumn dc in tableData.Columns)
                {
                    worksheet.Cells[Rows, Cols].Value = dc.ColumnName;
                    worksheet.Cells[Rows, Cols].Style = styleHeader;
                    Cols++;
                }
                Rows = 1;
                foreach (DataRow dr in tableData.Rows)
                {

                    Cols = 0;
                    foreach (DataColumn dc in tableData.Columns)
                    {
                        worksheet.Cells[Rows, Cols].Value = dr[dc.ColumnName].ToString();
                        Cols++;
                    }
                    Rows++;
                }

                workbook.Save(fPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error - save to file : {ex.Message}");
                return null;
            }
            return fPath;
        }

        static void CreateOutputTable()
        {
            if (output == null)
            {
                output = new DataTable("evaluation result");
                output.Columns.Add("No");
                var dir = new DirectoryInfo(WorkingDir);
                if (dir.Exists)
                {
                    var files = dir.GetFiles("*.onnx");
                    foreach (var file in files)
                    {
                        var CName = Path.GetFileNameWithoutExtension(file.Name);
                        output.Columns.Add(CName);
                    }
                }
                output.AcceptChanges();
            }
        }
        static void DoInference(int index, float[] inputData)
        {
            var dir = new DirectoryInfo(WorkingDir);
            if (dir.Exists)
            {
                var dr = output.NewRow();
                dr[0] = index;

                var files = dir.GetFiles("*.onnx");
                foreach (var file in files)
                {
                    try
                    {

                        var modelPath = file.FullName;
                        var colName = Path.GetFileNameWithoutExtension(file.Name);
                        using (var session = new InferenceSession(modelPath))
                        {
                            var inputMeta = session.InputMetadata;
                            var container = new List<NamedOnnxValue>();

                            foreach (var name in inputMeta.Keys)
                            {
                                var dim = new int[] { 1, inputMeta[name].Dimensions[1] };
                                var tensor = new DenseTensor<float>(inputData, dim);
                                container.Add(NamedOnnxValue.CreateFromTensor<float>(name, tensor));
                                container.Add(NamedOnnxValue.CreateFromTensor<float>(name, tensor));
                            }

                            // Run the inference
                            using (var results = session.Run(container))
                            {
                                // Get the results
                                foreach (var r in results)
                                {
                                    Console.WriteLine("Output Name: {0}", r.Name);
                                    var prediction = r.AsTensor<float>();
                                    dr[colName] = prediction[0];
                                    Console.WriteLine("Prediction: " + string.Join(",", prediction));
                                }
                            }
                        }
                    }
                    catch (Exception e)
                    {

                        Console.WriteLine(e);
                    }

                }
                output.Rows.Add(dr);
            }



        }
        #endregion
        #region preprocess
        public static DataTable ConvertCSVtoDataTable(string strFilePath)
        {
            StreamReader sr = new StreamReader(strFilePath);
            string[] headers = sr.ReadLine().Split(',');
            DataTable dt = new DataTable();
            foreach (string header in headers)
            {
                dt.Columns.Add(header);
            }
            while (!sr.EndOfStream)
            {
                string[] rows = Regex.Split(sr.ReadLine(), ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");
                DataRow dr = dt.NewRow();
                for (int i = 0; i < headers.Length; i++)
                {
                    dr[i] = rows[i];
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }
        public static string GetAbsolutePath(string relativePath)
        {
            Type t = MethodBase.GetCurrentMethod().DeclaringType;
            FileInfo _dataRoot = new FileInfo(t.Assembly.Location);
            string assemblyFolderPath = _dataRoot.Directory.FullName;

            string fullPath = Path.Combine(assemblyFolderPath, relativePath);

            return fullPath;
        }
        static float[] PreProcessData(List<float> DataReflectance)
        {
            try
            {

                //convert to absorbance

                for (int col = 0; col < DataReflectance.Count; col++)
                {
                    DataReflectance[col] = (float)Math.Log(1f / DataReflectance[col]);
                }


                //sav gol filter
                SavitzkyGolayFilter filter = new SavitzkyGolayFilter(5, 2);

                List<double> rowDatas = new List<double>();
                for (int col = 0; col < DataReflectance.Count; col++)
                {
                    rowDatas.Add(DataReflectance[col]);
                }
                var filteredRow = filter.Process(rowDatas.ToArray());
                for (int col = 0; col < DataReflectance.Count; col++)
                {
                    DataReflectance[col] = (float)filteredRow[col];
                }


                //SNV

                rowDatas = new List<double>();
                for (int col = 0; col < DataReflectance.Count; col++)
                {
                    rowDatas.Add(DataReflectance[col]);
                }
                var mean = rowDatas.Average();
                var stdDev = MathExt.StdDev(rowDatas);
                for (int col = 0; col < DataReflectance.Count; col++)
                {
                    DataReflectance[col] = (float)((DataReflectance[col] - mean) / stdDev);
                }

                return DataReflectance.ToArray();

            }
            catch
            {
                return null;
            }
        }
        #endregion
    }
    #region math
    public class MathExt
    {
        public static double StdDev(IEnumerable<double> values)
        {
            double ret = 0;
            int count = values.Count();
            if (count > 1)
            {
                //Compute the Average
                double avg = values.Average();

                //Perform the Sum of (value-avg)^2
                double sum = values.Sum(d => (d - avg) * (d - avg));

                //Put it all together
                ret = Math.Sqrt(sum / count);
            }
            return ret;
        }
    }
    public class SavitzkyGolayFilter
    {
        private int SidePoints { get; set; }

        private Matrix<double> Coefficients { get; set; }

        public SavitzkyGolayFilter(int sidePoints, int polynomialOrder)
        {
            this.SidePoints = sidePoints;
            this.Design(polynomialOrder);
        }

        /// <summary>
        /// Smoothes the input samples.
        /// </summary>
        /// <param name="samples"></param>
        /// <returns></returns>
        public double[] Process(double[] samples)
        {
            int length = samples.Length;
            double[] output = new double[length];
            int frameSize = (this.SidePoints << 1) + 1;
            double[] frame = new double[frameSize];

            for (int i = 0; i <= this.SidePoints; ++i)
            {
                Array.Copy(samples, frame, frameSize);
                output[i] = this.Coefficients.Column(i).DotProduct(Vector<double>.Build.DenseOfArray(frame));
            }

            for (int n = this.SidePoints + 1; n < length - this.SidePoints; ++n)
            {
                Array.ConstrainedCopy(samples, n - this.SidePoints, frame, 0, frameSize);
                output[n] = this.Coefficients.Column(this.SidePoints + 1).DotProduct(Vector<double>.Build.DenseOfArray(frame));
            }

            for (int i = 0; i <= this.SidePoints; ++i)
            {
                Array.ConstrainedCopy(samples, length - (this.SidePoints << 1), frame, 0, this.SidePoints << 1);
                output[length - 1 - this.SidePoints + i] = this.Coefficients.Column(this.SidePoints + i).DotProduct(Vector<double>.Build.DenseOfArray(frame));
            }

            return output;
        }

        private void Design(int polynomialOrder)
        {
            double[,] a = new double[(this.SidePoints << 1) + 1, polynomialOrder + 1];

            for (int m = -this.SidePoints; m <= this.SidePoints; ++m)
            {
                for (int i = 0; i <= polynomialOrder; ++i)
                {
                    a[m + this.SidePoints, i] = Math.Pow(m, i);
                }
            }

            Matrix<double> s = Matrix<double>.Build.DenseOfArray(a);
            this.Coefficients = s.Multiply(s.TransposeThisAndMultiply(s).Inverse()).Multiply(s.Transpose());
        }
    }
    #endregion
}
