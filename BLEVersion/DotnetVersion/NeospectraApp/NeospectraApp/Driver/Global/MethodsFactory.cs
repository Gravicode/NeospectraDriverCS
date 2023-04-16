using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Windows.UI.Popups;

namespace NeospectraApp.Driver
{
    public class MethodsFactory
    {
        public static async void ShowAlertMessage(string title, string message)
        {
            var messageDialog = new MessageDialog(message, title);

            // Show the message dialog
            await messageDialog.ShowAsync();

            //AlertDialog.Builder myAlert = new AlertDialog.Builder(mContext);
            //myAlert.SetTitle(title);
            //myAlert.SetMessage(message);
            //myAlert.SetPositiveButton("OK", (dialogInterface, i) => {
            //    dialogInterface.Dismiss();
            //});
            //myAlert.Show();
        }

        public static void LogMessage(string tag, string message)
        {
            Debug.WriteLine("***Debugging", $"{tag}: {message}");
        }

        public static void SendBroadcast()
        {

            Debug.WriteLine("SEND BROADCAST ");
        }



        public static FileInfo GetFile(string fileDir, string fileName)
        {
            FileInfo fName = null;
            try
            {
                var fPath = new DirectoryInfo(fileDir);
                fName = new FileInfo(Path.Combine(fPath.FullName, fileName));
                if (fPath.Exists && fName.Exists)
                {


                }
                else
                {
                    fPath.Create();
                    File.WriteAllText(fName.FullName, string.Empty);
                    fName = new FileInfo(Path.Combine(fPath.FullName, fileName));
                }
                return fName;
            }
            catch (IOException e)
            {
                Console.WriteLine(e);
            }
            return fName;
        }

        public static bool WriteGraphFile(double[] x, double[] y, string filePath, string fileName, string header)
        {



            try
            {
                var writer = new StreamWriter(Path.Combine(filePath, fileName));

                writer.Write(header);
                writer.Write("\n");
                int length = x.Length < y.Length ? x.Length : y.Length;

                for (int i = 0; i < length; i++)
                {
                    writer.Write($"{x[i]}\t{y[i]}");
                    writer.Write("\n");
                }
                writer.Close();
                return true;

            }
            catch (IOException ex)
            {
                //logger.error(ex.getMessage());
                Console.WriteLine(ex);
                return false;
            }
            finally
            {
               
            }
        }

        public static double[] ConvertDataToT(double[] data)
        {
            double[] TArray = new double[data.Length];
            for (int i = 0; i < TArray.Length; i++)
            {
                TArray[i] = data[i] * 100;
            }
            return TArray;
        }

        public static double[] Switch_NM_CM(double[] data)
        {
            double[] xAxis = new double[data.Length];
            for (int i = 0; i < xAxis.Length; i++)
            {
                xAxis[i] = 10000000 / data[i];
            }
            return xAxis;
        }

        public static string FormatString(string template, params object[] args)
        {
            return string.Format(template, args);
        }
    }
}