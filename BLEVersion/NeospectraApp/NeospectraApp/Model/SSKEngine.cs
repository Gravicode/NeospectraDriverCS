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
using Windows.AI.MachineLearning;
using System.Diagnostics;

namespace NeospectraApp.Model
{
    public class SSKEngine
    {
        static readonly string[] onnxs = new string[]{ "Bray1_P2O5.onnx","Ca.onnx",
"CLAY.onnx",
"C_N.onnx",
"HCl25_K2O.onnx",
"HCl25_P2O5.onnx",
"Jumlah.onnx",
"K.onnx",
"KB_adjusted.onnx",
"KJELDAHL_N.onnx",
"KTK.onnx",
"Mg.onnx",
"Morgan_K2O.onnx",
"Na.onnx",
"Olsen_P2O5.onnx",
"PH_H2O.onnx",
"PH_KCL.onnx",
"RetensiP.onnx",
"SAND.onnx",
"SILT.onnx",
"WBC.onnx"};
        public static readonly float[] WaveFreq = new float[] { 2501.982414f, 2488.121682f, 2474.413679f, 2460.855893f, 2447.445869f, 2434.181205f, 2421.059549f, 2408.078601f, 2395.23611f, 2382.529873f, 2369.957732f, 2357.517576f, 2345.207338f, 2333.024993f, 2320.968557f, 2309.03609f, 2297.225689f, 2285.535489f, 2273.963667f, 2262.508432f, 2251.168031f, 2239.940747f, 2228.824895f, 2217.818825f, 2206.920917f, 2196.129586f, 2185.443276f, 2174.860461f, 2164.379645f, 2153.999359f, 2143.718166f, 2133.534652f, 2123.447432f, 2113.455147f, 2103.556462f, 2093.750069f, 2084.034683f, 2074.409043f, 2064.871912f, 2055.422073f, 2046.058334f, 2036.779523f, 2027.584491f, 2018.472107f, 2009.441263f, 2000.490869f, 1991.619854f, 1982.827168f, 1974.111777f, 1965.472667f, 1956.90884f, 1948.419317f, 1940.003134f, 1931.659347f, 1923.387023f, 1915.18525f, 1907.053129f, 1898.989776f, 1890.994322f, 1883.065913f, 1875.20371f, 1867.406887f, 1859.674631f, 1852.006145f, 1844.400641f, 1836.857348f, 1829.375506f, 1821.954366f, 1814.593192f, 1807.291262f, 1800.047862f, 1792.862291f, 1785.73386f, 1778.66189f, 1771.645713f, 1764.684671f, 1757.778116f, 1750.925412f, 1744.125931f, 1737.379056f, 1730.684178f, 1724.040698f, 1717.448027f, 1710.905585f, 1704.412798f, 1697.969105f, 1691.573951f, 1685.226788f, 1678.927079f, 1672.674295f, 1666.467911f, 1660.307414f, 1654.192297f, 1648.12206f, 1642.096211f, 1636.114265f, 1630.175743f, 1624.280176f, 1618.427097f, 1612.61605f, 1606.846583f, 1601.118252f, 1595.430619f, 1589.78325f, 1584.175721f, 1578.607611f, 1573.078506f, 1567.587997f, 1562.135681f, 1556.721163f, 1551.344049f, 1546.003954f, 1540.700496f, 1535.433301f, 1530.201996f, 1525.006217f, 1519.845603f, 1514.719799f, 1509.628452f, 1504.571218f, 1499.547754f, 1494.557722f, 1489.600791f, 1484.676633f, 1479.784922f, 1474.92534f, 1470.097571f, 1465.301304f, 1460.536231f, 1455.802049f, 1451.098459f, 1446.425165f, 1441.781875f, 1437.168301f, 1432.584159f, 1428.029169f, 1423.503052f, 1419.005535f, 1414.536349f, 1410.095225f, 1405.681902f, 1401.296118f, 1396.937616f, 1392.606143f, 1388.301449f, 1384.023285f, 1379.771406f, 1375.545573f, 1371.345545f, 1367.171087f, 1363.021967f, 1358.897955f, 1354.798823f, 1350.724346f };
        static DataTable output;
        static readonly string WorkingDir = GetAbsolutePath(@"../../../../../../TFModel");
        static readonly string InputFile = GetAbsolutePath(@"../../../../../data SSK dan Lab.xls");
        static readonly string InputFileCsv = (@"InputTest.csv");
        static readonly string ResultFileCsv = GetAbsolutePath(@"../../../../../result.csv");
        public int CurrentIndex { get; set; }
        public SSKEngine()
        {
            SpreadsheetInfo.SetLicense("EDWG-SKFA-D7J1-LDQ5");
            CreateOutputTable();
            CurrentIndex = 0;
            
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
        public void Reset()
        {
            CurrentIndex = 0;
            output.Rows.Clear();
            output.AcceptChanges();
        }

        public DataTable GetResultTable()
        {
            return output;
        }
        public async Task<bool> ExecuteModel(List<float> inputFloat)
        {
            try
            {
                //CreateOutputTable();
                CurrentIndex++;

                if (inputFloat != null && inputFloat.Count == 154)
                {
                    var inputF = PreProcessData(inputFloat);
                    await DoInference2(CurrentIndex, inputF);
                }
                output.AcceptChanges();
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            return false;
           
        }
        public async Task<bool> TestModel()
        {
            
            //use csv input
            var FPath = System.IO.Path.Combine(
           Windows.ApplicationModel.Package.Current.InstalledLocation.Path,
           $"Assets\\{InputFileCsv}");
            if (!File.Exists(FPath)) return false;
            //CreateOutputTable();
            var dt = ConvertCSVtoDataTable(FPath);
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
                    await DoInference2(index, inputF);
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

                foreach (var file in onnxs)
                {
                    var CName = file.Replace(".onnx", string.Empty);
                    output.Columns.Add(CName);
                }

                output.AcceptChanges();
            }
        }
        async Task DoInference2(int index, float[] inputData)
        {


            var dr = output.NewRow();
            dr[0] = index;

            foreach (var file in onnxs)
            {
                try
                {
                    var colName = file.Replace(".onnx", string.Empty);
                    float result = 0f;
                    switch (colName)
                    {
                        case "Bray1_P2O5":
                            {
                                var model = await Bray1_P2O5Model.LoadModelAsync(file);
                                var valout = await model.EvaluateAsync(new Bray1_P2O5Input() { serving_default_input_1200 = TensorFloat.CreateFromArray(new long[] { -1, 154 }, inputData) });
                                result = await model.ProcessOutputAsync(valout);
                            }
                            break;
                        case "Ca":
                            {
                                var model = await CaModel.LoadModelAsync(file);
                                var valout = await model.EvaluateAsync(new CaInput() { serving_default_input_1500 = TensorFloat.CreateFromArray(new long[] { -1, 154 }, inputData) });
                                result = await model.ProcessOutputAsync(valout);
                            }
                            break;
                        case "CLAY":
                            {
                                var model = await CLAYModel.LoadModelAsync(file);
                                var valout = await model.EvaluateAsync(new CLAYInput() { serving_default_input_300 = TensorFloat.CreateFromArray(new long[] { -1, 154 }, inputData) });
                                result = await model.ProcessOutputAsync(valout);
                            }
                            break;
                        case "C_N":
                            {
                                var model = await C_NModel.LoadModelAsync(file);
                                var valout = await model.EvaluateAsync(new C_NInput() { serving_default_input_800 = TensorFloat.CreateFromArray(new long[] { -1, 154 }, inputData) });
                                result = await model.ProcessOutputAsync(valout);
                            }
                            break;
                        case "HCl25_K2O":
                            {
                                var model = await HCl25_K2OModel.LoadModelAsync(file);
                                var valout = await model.EvaluateAsync(new HCl25_K2OInput() { serving_default_input_1000 = TensorFloat.CreateFromArray(new long[] { -1, 154 }, inputData) });
                                result = await model.ProcessOutputAsync(valout);
                            }
                            break;
                        case "HCl25_P2O5":
                            {
                                var model = await HCl25_P2O5Model.LoadModelAsync(file);
                                var valout = await model.EvaluateAsync(new HCl25_P2O5Input() { serving_default_input_900 = TensorFloat.CreateFromArray(new long[] { -1, 154 }, inputData) });
                                result = await model.ProcessOutputAsync(valout);
                            }
                            break;
                        case "Jumlah":
                            {
                                var model = await JumlahModel.LoadModelAsync(file);
                                var valout = await model.EvaluateAsync(new JumlahInput() { serving_default_input_1900 = TensorFloat.CreateFromArray(new long[] { -1, 154 }, inputData) });
                                result = await model.ProcessOutputAsync(valout);
                            }
                            break;
                        case "K":
                            {
                                var model = await KModel.LoadModelAsync(file);
                                var valout = await model.EvaluateAsync(new KInput() { serving_default_input_1700 = TensorFloat.CreateFromArray(new long[] { -1, 154 }, inputData) });
                                result = await model.ProcessOutputAsync(valout);
                            }
                            break;
                        case "KB_adjusted":
                            {
                                var model = await KB_adjustedModel.LoadModelAsync(file);
                                var valout = await model.EvaluateAsync(new KB_adjustedInput() { serving_default_input_2100 = TensorFloat.CreateFromArray(new long[] { -1, 154 }, inputData) });
                                result = await model.ProcessOutputAsync(valout);
                            }
                            break;
                        case "Mg":
                            {
                                var model = await MgModel.LoadModelAsync(file);
                                var valout = await model.EvaluateAsync(new MgInput() { serving_default_input_1600 = TensorFloat.CreateFromArray(new long[] { -1, 154 }, inputData) });
                                result = await model.ProcessOutputAsync(valout);
                            }
                            break;
                        case "KJELDAHL_N":
                            {
                                var model = await KJELDAHL_NModel.LoadModelAsync(file);
                                var valout = await model.EvaluateAsync(new KJELDAHL_NInput() { serving_default_input_700 = TensorFloat.CreateFromArray(new long[] { -1, 154 }, inputData) });
                                result = await model.ProcessOutputAsync(valout);
                            }
                            break;
                        case "KTK":
                            {
                                var model = await KTKModel.LoadModelAsync(file);
                                var valout = await model.EvaluateAsync(new KTKInput() { serving_default_input_2000 = TensorFloat.CreateFromArray(new long[] { -1, 154 }, inputData) });
                                result = await model.ProcessOutputAsync(valout);
                            }
                            break;
                        case "Morgan_K2O":
                            {
                                var model = await Morgan_K2OModel.LoadModelAsync(file);
                                var valout = await model.EvaluateAsync(new Morgan_K2OInput() { serving_default_input_1300 = TensorFloat.CreateFromArray(new long[] { -1, 154 }, inputData) });
                                result = await model.ProcessOutputAsync(valout);
                            }
                            break;
                        case "Na":
                            {
                                var model = await NaModel.LoadModelAsync(file);
                                var valout = await model.EvaluateAsync(new NaInput() { serving_default_input_1800 = TensorFloat.CreateFromArray(new long[] { -1, 154 }, inputData) });
                                result = await model.ProcessOutputAsync(valout);
                            }
                            break;
                        case "Olsen_P2O5":
                            {
                                var model = await Olsen_P2O5Model.LoadModelAsync(file);
                                var valout = await model.EvaluateAsync(new Olsen_P2O5Input() { serving_default_input_1100 = TensorFloat.CreateFromArray(new long[] { -1, 154 }, inputData) });
                                result = await model.ProcessOutputAsync(valout);
                            }
                            break;
                        case "PH_H2O":
                            {
                                var model = await PH_H2OModel.LoadModelAsync(file);
                                var valout = await model.EvaluateAsync(new PH_H2OInput() { serving_default_input_400 = TensorFloat.CreateFromArray(new long[] { -1, 154 }, inputData) });
                                result = await model.ProcessOutputAsync(valout);
                            }
                            break;
                        case "PH_KCL":
                            {
                                var model = await PH_KCLModel.LoadModelAsync(file);
                                var valout = await model.EvaluateAsync(new PH_KCLInput() { serving_default_input_500 = TensorFloat.CreateFromArray(new long[] { -1, 154 }, inputData) });
                                result = await model.ProcessOutputAsync(valout);
                            }
                            break;
                        case "RetensiP":
                            {
                                var model = await RetensiPModel.LoadModelAsync(file);
                                var valout = await model.EvaluateAsync(new RetensiPInput() { serving_default_input_1400 = TensorFloat.CreateFromArray(new long[] { -1, 154 }, inputData) });
                                result = await model.ProcessOutputAsync(valout);
                            }
                            break;
                        case "SAND":
                            {
                                var model = await SANDModel.LoadModelAsync(file);
                                var valout = await model.EvaluateAsync(new SANDInput() { serving_default_input_100 = TensorFloat.CreateFromArray(new long[] { -1, 154 }, inputData) });
                                result = await model.ProcessOutputAsync(valout);
                            }
                            break;
                        case "SILT":
                            {
                                var model = await SILTModel.LoadModelAsync(file);
                                var valout = await model.EvaluateAsync(new SILTInput() { serving_default_input_200 = TensorFloat.CreateFromArray(new long[] { -1, 154 }, inputData) });
                                result = await model.ProcessOutputAsync(valout);
                            }
                            break;
                        case "WBC":
                            {
                                var model = await WBCModel.LoadModelAsync(file);
                                var valout = await model.EvaluateAsync(new WBCInput() { serving_default_input_600 = TensorFloat.CreateFromArray(new long[] { -1, 154 }, inputData) });
                                result = await model.ProcessOutputAsync(valout);
                            }
                            break;

                    }

                    dr[colName] = result;
                    output.Rows.Add(dr);
                }
                catch (Exception e)
                {

                    Console.WriteLine(e);
                }

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
