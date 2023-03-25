using Newtonsoft.Json;
using SensingKit.Core.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SensingKit.Core
{
    public class ModelRunner
    {
        public delegate void LogDataUpdateHandler(string LogType, string Message);
        public event LogDataUpdateHandler LogData;

        private void OnLogDataUpdate(string LogType, string Message)
        {
            LogData?.Invoke(LogType, Message);
        }
        public static string OutputFile { set; get; } = "output.json";
        string PathToSensorData;
        bool IsReady = false;
        List<string> ListCmd;
        string Arg;
        string WorkingDir;
        public ModelRunner(string WorkingDirectory, string ModelScript, string SensorData, string AnacondaFolder)
        {
            try
            {
                if (!Directory.Exists(WorkingDirectory)) throw new Exception("Working directory is not exists");
                if (!Directory.Exists(AnacondaFolder)) throw new Exception("Anaconda directory is not exists");
                if (!File.Exists(WorkingDirectory + "\\" + ModelScript)) throw new Exception("Model script is not exists");


                ListCmd = new List<string>(new string[] { $"cd {WorkingDirectory}", $"python {ModelScript} {SensorData}" });
                Arg = $"/K {AnacondaFolder}\\Scripts\\activate.bat {AnacondaFolder}";
                WorkingDir = WorkingDirectory;
                PathToSensorData = $"{WorkingDir}\\{SensorData}";
                IsReady = true;
            }
            catch (Exception ex)
            {
                IsReady = false;
                Console.WriteLine(ex);
            }
        }

        public (bool IsSucceed, ModelOutput Result) InferenceModel(bool DeleteInputDataAfterExecution = false, bool DeleteOutputAfterExecution = true)
        {
            if (!IsReady) throw new Exception("Parameter must be correct.");
            Stopwatch sw = new Stopwatch();
            Console.WriteLine("start run python script...");
            sw.Start();
            try
            {
                RunCommands(ListCmd, Arg, WorkingDir);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            sw.Stop();
            Console.WriteLine("model inference process is completed...");
            Console.WriteLine($"total time for model execution: {sw.ElapsedMilliseconds} ms");
            Console.WriteLine("try to read output...");
            var PathToOutput = $"{WorkingDir}\\{OutputFile}";
            if (File.Exists(PathToOutput))
            {
                var InferenceData = File.ReadAllText(PathToOutput);
                Console.WriteLine("hasil inference model:");
                Console.WriteLine(InferenceData);

                var OutputData = JsonConvert.DeserializeObject<ModelOutput>(InferenceData);

                if (DeleteOutputAfterExecution)
                    File.Delete(PathToOutput);
                if (DeleteInputDataAfterExecution && File.Exists(PathToSensorData))
                    File.Delete(PathToSensorData);
                return (true, OutputData);
            }
            else
            {
                Console.WriteLine("output tidak ditemukan, kegagalan eksekusi model");
            }
            Console.WriteLine("end program...");
            return (false, null);
        }
        void RunCommands(List<string> cmds, string CmdArg = "", string workingDirectory = "")
        {
            var process = new Process();
            var psi = new ProcessStartInfo();
            psi.FileName = "cmd.exe";
            psi.RedirectStandardInput = true;
            psi.RedirectStandardOutput = true;
            psi.CreateNoWindow = true;
            psi.RedirectStandardError = true;
            psi.UseShellExecute = false;
            psi.WorkingDirectory = workingDirectory;
            psi.Arguments = CmdArg;
            process.StartInfo = psi;
            process.Start();
            process.OutputDataReceived += (sender, e) => { Console.WriteLine(e.Data); OnLogDataUpdate("Process", e.Data); };
            process.ErrorDataReceived += (sender, e) => { Console.WriteLine(e.Data); OnLogDataUpdate("Error", e.Data); };
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();
            using (StreamWriter sw = process.StandardInput)
            {
                foreach (var cmd in cmds)
                {
                    sw.WriteLine(cmd);
                }
            }
            process.WaitForExit();
        }
    }


}
