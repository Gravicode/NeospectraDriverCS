using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Graphics;
using Android.OS;
using Android.Provider;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace com.gravicode.neospectralib.Global
{
    public class MethodsFactory
    {
        public static void ShowAlertMessage(Context mContext, string title, string message)
        {
            AlertDialog.Builder myAlert = new AlertDialog.Builder(mContext);
            myAlert.SetTitle(title);
            myAlert.SetMessage(message);
            myAlert.SetPositiveButton("OK", (dialogInterface, i) => {
                dialogInterface.Dismiss();
            });
            myAlert.Show();
        }

        public static void LogMessage(string tag, string message)
        {
            Log.Debug("***Debugging", $"{tag}: {message}");
        }

        public static void SendBroadcast(Context mContext, Intent intent)
        {
            LocalBroadcastManager.GetInstance(mContext).SendBroadcast(intent);
            Log.Debug("SEND BROADCAST ", $"SendBroadcast {LocalBroadcastManager.GetInstance(mContext)}");
        }

        public static void RotateProgressBar(Context mContext, ProgressBar progressBar)
        {
            /*
            Animation rotation = AnimationUtils.LoadAnimation(mContext,
                    Resource.Animation.clockwise_rotation);

            rotation.RepeatCount = Animation.Infinite;
            progressBar.StartAnimation(rotation);*/
        }

        public static Java.IO.File GetFile(string fileDir, string fileName)
        {
            Java.IO.File file = null;
            try
            {
                file = new Java.IO.File(Environment.ExternalStoragePublicDirectory(fileDir), fileName);
                System.Diagnostics.Debug.WriteLine("************************* Path : " + fileDir);
                if (!file.Exists())
                    file.CreateNewFile();
            }
            catch (IOException e)
            {
                e.PrintStackTrace();
            }
            return file;
        }

        public static bool WriteGraphFile(double[] x, double[] y, string filePath, string fileName, string header)
        {

            Java.IO.BufferedWriter writer = null;

            try
            {
                Java.IO.File file = GetFile(filePath, fileName);
                Java.IO.FileWriter fw = new Java.IO.FileWriter(file.AbsoluteFile);
                writer = new Java.IO.BufferedWriter(fw);
                writer.Write(header);
                writer.Write("\n");
                int length = x.Length < y.Length ? x.Length : y.Length;

                for (int i = 0; i < length; i++)
                {
                    writer.Write($"{x[i]}\t{y[i]}");
                    writer.Write("\n");
                }

                return true;

            }
            catch (IOException ex)
            {
                //logger.error(ex.getMessage());
                ex.PrintStackTrace();
                return false;
            }
            finally
            {
                try
                {
                    writer.Close();
                }
                catch (Exception ex)
                {
                    //  logger.error(ex.getMessage());
                    ex.PrintStackTrace();
                }
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