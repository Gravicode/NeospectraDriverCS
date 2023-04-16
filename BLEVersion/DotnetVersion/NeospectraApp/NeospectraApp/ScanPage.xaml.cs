using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Bluetooth.GenericAttributeProfile;
using Windows.Devices.Bluetooth;
using Windows.Devices.Enumeration;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Security.Cryptography;
using Windows.Storage.Streams;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using NeospectraApp.Driver;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Notifications;
using System.Xml.Linq;
using System.Threading;
using Windows.UI.Xaml.Automation.Peers;
using NeospectraApp.Model;
using System.Data;
using System.ServiceModel.Channels;
using static NeospectraApp.Driver.GlobalVariables;
using Windows.Storage;
using NeospectraApp.MathHelper;
using System.Diagnostics;
using GemBox.Spreadsheet.Charts;
using WinRTXamlToolkit.Controls.DataVisualization.Charting;
using System.Collections.ObjectModel;
using System.ComponentModel;
// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace NeospectraApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ScanPage : Page
    {
        ObservableCollection<ChartItem> ChartItems = new ObservableCollection<ChartItem>();
        IEnumerable<dynamic> ResultTable { get; set; }
        SSKEngine engine;
        private MainPage rootPage = MainPage.Current;
        int scanTime = 2;
        int backgroundScanTime = 2;
        private BluetoothLEDevice bluetoothLeDevice = null;
        ScanPresenter scanPresenter = null;

        #region Error Codes
        readonly int E_BLUETOOTH_ATT_WRITE_NOT_PERMITTED = unchecked((int)0x80650003);
        readonly int E_BLUETOOTH_ATT_INVALID_PDU = unchecked((int)0x80650004);
        readonly int E_ACCESSDENIED = unchecked((int)0x80070005);
        readonly int E_DEVICE_NOT_AVAILABLE = unchecked((int)0x800710df); // HRESULT_FROM_WIN32(ERROR_DEVICE_NOT_AVAILABLE)
        #endregion

        bool isStopEnabled = false;
        bool isScanBG = false;
        bool isWaitingForBackGroundReading = false;
        bool isWaitingForSensorReading = false;
        int notifications_count = 0;
        double numberOfRuns = 1;
        int count = 1;
        private double maxValue = 0;
        #region UI Code
        public ScanPage()
        {
            this.InitializeComponent();
            ChartItems.Add(new ChartItem() { Ax = "item 1", Ay=10 });
            ChartItems.Add(new ChartItem() { Ax = "item 2", Ay=20 });
            ChartItems.Add(new ChartItem() { Ax = "item 3", Ay=30 });
          
            loadPreferences();
            if (GlobalVariables.bluetoothAPI == null)
            {
                GlobalVariables.bluetoothAPI = new SWS_P3API(this.Dispatcher);

            }
            if (engine == null) engine = new SSKEngine();
            ResultTable = engine.GetResultTable().ToExpandoObjectList();
        }
        async void ShowDialog(string Message)
        {
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, async () =>
            {
                //UI code here
                // Create the message dialog and set its content
                var messageDialog = new MessageDialog(Message);


                // Set the command that will be invoked by default
                messageDialog.DefaultCommandIndex = 0;

                // Set the command to be invoked when escape is pressed
                messageDialog.CancelCommandIndex = 1;

                // Show the message dialog
                await messageDialog.ShowAsync();
            });

        }

        void loadPreferences()
        {
            ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;

            //localSettings.Values["optical_gain_settings"] == null ? "Default" : Convert.ToString(localSettings.Values["optical_gain_settings"]);

            GlobalVariables.gRunMode = localSettings.Values["run_mode"] == null ? GlobalVariables.runMode.Single_Mode : Convert.ToString(localSettings.Values["run_mode"]);
            //preferences.getString("run_mode", GlobalVariables.runMode.Single_Mode.toString());
            GlobalVariables.gIsInterpolationEnabled = localSettings.Values["linear_interpolation_switch"] == null ? false : Convert.ToBoolean(localSettings.Values["linear_interpolation_switch"]);
            //preferences.getBoolean("linear_interpolation_switch", false);
            GlobalVariables.gInterpolationPoints = localSettings.Values["data_points"] == null ? GlobalVariables.pointsCount.points_257 : Convert.ToString(localSettings.Values["data_points"]);
            //preferences.getString("data_points", GlobalVariables.pointsCount.points_257.toString());
            GlobalVariables.gIsFftEnabled = localSettings.Values["fft_settings_switch"] == null ? false : Convert.ToBoolean(localSettings.Values["fft_settings_switch"]);
            //preferences.getBoolean("fft_settings_switch", false);
            GlobalVariables.gApodizationFunction = localSettings.Values["apodization_function"] == null ? GlobalVariables.apodization.Boxcar : Convert.ToString(localSettings.Values["apodization_function"]);
            //preferences.getString("apodization_function", GlobalVariables.apodization.Boxcar.toString());
            GlobalVariables.gFftPoints = localSettings.Values["fft_points"] == null ? GlobalVariables.zeroPadding.points_32k : Convert.ToString(localSettings.Values["fft_points"]);
            //preferences.getString("fft_points", GlobalVariables.zeroPadding.points_8k.toString());
            GlobalVariables.gOpticalGainSettings = localSettings.Values["optical_gain_settings"] == null ? "Default" : Convert.ToString(localSettings.Values["optical_gain_settings"]);
            //preferences.getString("optical_gain_settings", "Default");
            GlobalVariables.gOpticalGainValue = localSettings.Values[gOpticalGainSettings] == null ? 0 : Convert.ToInt32(localSettings.Values[gOpticalGainSettings]);
            //preferences.getInt(gOpticalGainSettings, 0);
            GlobalVariables.gCorrectionMode = localSettings.Values["wavelength_correction"] == null ? GlobalVariables.wavelengthCorrection.Self_Calibration : Convert.ToString(localSettings.Values["wavelength_correction"]);
            //preferences.getString("wavelength_correction", GlobalVariables.wavelengthCorrection.Self_Calibration.toString());

        }

        private void ScanPage_BroadcastReceived(object sender, SWS_P3ConnectionServices.BroadcastEventArgs e)
        {
            var TAG = nameof(ScanPage);
            var intent = e.iGotData;
            var intentName = Convert.ToString(intent["iName"]);
            switch (intentName)
            {
                //Case data is received successfully
                case "sensorNotification_data":
                    gotSensorReading(intent);
                    MethodsFactory.LogMessage(TAG, "Intent Received:\n" +
                            "Name: " + Convert.ToString(intent["iName"]) + "\n" +
                            "Success: " + Convert.ToBoolean(intent["isNotificationSuccess"]) + "\n" +
                            "Reason: " + Convert.ToString(intent["reason"]) + "\n" +
                            "Error: " + Convert.ToString(intent.ContainsKey("err") ? intent["err"] : string.Empty) + "\n" +
                            "data : " + string.Join(',', (double[])intent["data"]) + "\n");
                    break;
                // Case sensor notification with failure
                case "sensorNotification_failure":
                    gotSensorReading(intent);
                    MethodsFactory.LogMessage(TAG, "Intent Received:\n" +
                            "Name: " + Convert.ToString(intent["iName"]) + "\n" +
                            "Success: " + Convert.ToBoolean(intent["isNotificationSuccess"]) + "\n" +
                            "Reason: " + Convert.ToString(intent["reason"]) + "\n" +
                            "Error: " + Convert.ToString(intent["err"]) + "\n" +
                            "data : " + Convert.ToInt32(intent["data"]) + "\n");
                    int errorCode = Convert.ToInt32(intent["data"]);

                    // show progress bar

                    // set button enable or disable
                    CommonVariables.setScanningState(0);

                    notifications_count = 0;
                    isWaitingForBackGroundReading = false;
                    isWaitingForSensorReading = false;
                    var xmdock = CreateToast("Error " + (0x000000FF & errorCode) + " occurred during measurement!", "Error");
                    var toast = new ToastNotification(xmdock);
                    var notifi = Windows.UI.Notifications.ToastNotificationManager.CreateToastNotifier();
                    notifi.Show(toast);
                    //showAlertMessage(mContext, "Error", "Error " + String.valueOf(0x000000FF & errorCode) + " occurred during measurement!");
                    break;
                case "sensorWriting":

                    break;
                //case "OperationDone":
                //isWaitingForBackGroundReading = false;
                //isScanBG = false;
                //break;
                //Case device is disconnected
                case "Disconnection_Notification":
                    //endActivity();
                    break;

                default:
                    MethodsFactory.LogMessage(TAG + "intent", $"Got unknown broadcast intent: {intentName}");
                    break;
            }
        }
        private void gotSensorReading(Dictionary<string, object> intent)
        {
            var TAG = nameof(ScanPage);
            bool isNotificationSuccessful = Convert.ToBoolean(intent["isNotificationSuccess"]);
            var notificationReason = Convert.ToString(intent["reason"]);  //intent.getStringExtra("reason");
            var errorMessage = Convert.ToString(intent.ContainsKey("err") ? intent["err"] : string.Empty);//intent.getStringExtra("err");

            /* If the notification is unsuccessful */
            if (!isNotificationSuccessful)
            {


                MethodsFactory.LogMessage(notificationReason, errorMessage);
                return;
            }

            /* If an error occured */
            if (!notificationReason.Equals("gotData"))
            {

                CommonVariables.setScanningState(1);
                //SetView();
                notifications_count = 0;
                return;
            }

            // Number of the received notifications
            notifications_count++;

            if (isScanBG)
            {
                if ((notifications_count % 3) == 0)
                {

                    CommonVariables.setScanningState(1);
                    //SetView();

                    isWaitingForBackGroundReading = false;
                    MethodsFactory.LogMessage(TAG, "BACKGROUND SCAN IS COMPLETE");
                    ShowDialog("BACKGROUND SCAN IS COMPLETE");

                }
                return;
            }

            // Get readings
            double[] reading = (double[])intent["data"]; //intent.getDoubleArrayExtra("data");

            if (reading == null)
            {
                MethodsFactory.LogMessage(TAG, "Reading is NULL.");

                CommonVariables.setScanningState(0);
                //SetView();

                notifications_count = 0;
                return;
            }

            // The array constructed from two arrays have the same length, Y, then X.
            int middleOfArray = reading.Length / 2;
            double[] x_reading = new double[middleOfArray],
                    y_reading = new double[middleOfArray];
            // split the main array to two arrays, Y & X
            for (int i = 0; i < middleOfArray; i++)
            {
                //Added this fix for the inconsistency in size of received data
                y_reading[i] = reading[i];
                x_reading[i] = reading[middleOfArray + i];
            }

            // Prepare the data to get ArrayRealVector with length 314 item,
            // and set its value to the singleton sensor reading model.
            if ((y_reading.Length > 0) && (x_reading.Length > 0))
            {
                dbReading newReading = new dbReading();
                newReading.setReading(y_reading, x_reading);
                // Add the taken read to global ArrayList which holds all the taken readings
                GlobalVariables.gAllSpectra.Add(newReading);

                CommonVariables.setScanningState(1);
                //SetView();

                isWaitingForSensorReading = false;

                double numberOfRuns = this.numberOfRuns;

                // Enable Stop action button in case there are a multiple number of runs
                if (count < numberOfRuns)
                {
                    if (isStopEnabled)
                    {
                        count = 1;
                        //tv_progressCount.setEnabled(false);
                        //tv_progressCount.setText("");
                        //pbProgressBar.setVisibility(View.INVISIBLE);
                        isStopEnabled = false;
                        return;
                    }
                    count++;

                    // Press scan button again as it is a continues mode
                    SensorScanClick();
                }
                else// Handle only one run
                {

                    count = 1;
                    //Toast.makeText(mContext, "Scan is complete", Toast.LENGTH_LONG).show();
                    MethodsFactory.LogMessage(TAG, "SCAN IS COMPLETE");

                    ShowDialog("SCAN IS COMPLETE");
                    //do inference
                    DoInference();
                    CommonVariables.setScanningState(2);
                    //SetView();

                    //displayGraph();
                }
            }

            MethodsFactory.LogMessage(TAG, "Sensor Reading Length = " + reading.Length);

        }

        async void DoInference()
        {
            var input = getReflectance();
            List<float> inputFloat = new List<float>();
            for (int i = 0; i < input.Length; i++)
            {
                inputFloat.Add((float)input[i]);
            }

            var res = await engine.ExecuteModel(inputFloat);
            //await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, async () => {
            //UI code here
            ResultTable = engine.GetResultTable().ToExpandoObjectList();

            //});

        }
        public static Windows.Data.Xml.Dom.XmlDocument CreateToast(string Message, string Title = "Info")
        {
            var xDoc = new XDocument(
               new XElement("toast",
               new XElement("visual",
               new XElement("binding", new XAttribute("template", "ToastGeneric"),
               new XElement("text", Title),
               new XElement("text", Message)
            )
            ),// actions    
            new XElement("actions",
            new XElement("action", new XAttribute("activationType", "background"),
            new XAttribute("content", "Yes"), new XAttribute("arguments", "yes")),
            new XElement("action", new XAttribute("activationType", "background"),
            new XAttribute("content", "No"), new XAttribute("arguments", "no"))
            )
            )
            );

            var xmlDoc = new Windows.Data.Xml.Dom.XmlDocument();
            xmlDoc.LoadXml(xDoc.ToString());
            return xmlDoc;
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            SelectedDeviceRun.Text = rootPage.SelectedBleDeviceName;
            if (string.IsNullOrEmpty(rootPage.SelectedBleDeviceId))
            {
                ConnectButton.IsEnabled = false;
            }
            if (GlobalVariables.bluetoothAPI != null)
            {
                GlobalVariables.bluetoothAPI.getmP3ConnectionServices().BroadcastReceived += ScanPage_BroadcastReceived;
            }
        }

        protected override async void OnNavigatedFrom(NavigationEventArgs e)
        {
            var success = await ClearBluetoothLEDeviceAsync();
            if (!success)
            {
                rootPage.NotifyUser("Error: Unable to reset app state", NotifyType.ErrorMessage);
            }
            if (GlobalVariables.bluetoothAPI != null)
            {
                GlobalVariables.bluetoothAPI.getmP3ConnectionServices().BroadcastReceived -= ScanPage_BroadcastReceived;
            }
        }
        #endregion

        #region Enumerating Services
        private async Task<bool> ClearBluetoothLEDeviceAsync()
        {

            bluetoothLeDevice?.Dispose();
            bluetoothLeDevice = null;
            return true;
        }

        async void BackgroundScanClick()
        {
            isScanBG = true;
            backgroundScanTime = scanTime;
            CommonVariables.setScanningState(99);

            if (scanPresenter == null)
            {
                scanPresenter = new ScanPresenter();
            }
            // Don't complete the process if the device not connected
            if (GlobalVariables.bluetoothAPI == null || !GlobalVariables.bluetoothAPI.isDeviceConnected())
            {
                var messageDialog = new MessageDialog("Please! Ensure that you have a connected device firstly", "Device not connected"
                       );



                // Show the message dialog
                await messageDialog.ShowAsync();
                return;
            }
            else
            {
                isWaitingForBackGroundReading = true;
                scanPresenter.requestBackgroundReading(scanTime);
            }
        }
        async void InferenceClick()
        {

            var res = await engine.TestModel();
        }
        async void ClearMemoryClick()
        {
            if (GlobalVariables.bluetoothAPI != null)
                GlobalVariables.bluetoothAPI.sendClearMemoryRequest();
            else
            {
                rootPage.NotifyUser("Failed to connect to device.", NotifyType.ErrorMessage);
            }
        }
        async void SensorScanClick()
        {
            var TAG = nameof(ScanPage);
            CommonVariables.setScanningState(99);
            if (backgroundScanTime < scanTime)
            {
                MethodsFactory.LogMessage(TAG, "Material Scan time is greater than reference material scan time ");
                return;
            }
            isScanBG = false;
            if (numberOfRuns > 1)
                if (numberOfRuns > 1)
                {
                    // handle loading when number of runs more than 1
                }
            if (count == 1)
            {
                // handle loading when count more than 1
            }
            if (isWaitingForSensorReading)
            {
                MethodsFactory.LogMessage(TAG, "Still waiting for sensor reading ... ");
                return;
            }
            isWaitingForSensorReading = true;
            if (scanPresenter == null)
            {
                scanPresenter = new ScanPresenter();
            }
            // Don't complete the process if the device not connected
            if (GlobalVariables.bluetoothAPI == null || !GlobalVariables.bluetoothAPI.isDeviceConnected())
            {
                var messageDialog = new MessageDialog("Please! Ensure that you have a connected device firstly", "Device not connected");

                // Show the message dialog
                await messageDialog.ShowAsync();
                return;
            }
            else
            {
                scanPresenter.requestSensorReading(scanTime);
            }
        }

        private async void ConnectButton_Click()
        {
            ConnectButton.IsEnabled = false;

            if (!await ClearBluetoothLEDeviceAsync())
            {
                rootPage.NotifyUser("Error: Unable to reset state, try again.", NotifyType.ErrorMessage);
                ConnectButton.IsEnabled = true;
                return;
            }

            try
            {
                // BT_Code: BluetoothLEDevice.FromIdAsync must be called from a UI thread because it may prompt for consent.
                bluetoothLeDevice = await BluetoothLEDevice.FromIdAsync(rootPage.SelectedBleDeviceId);

                if (bluetoothLeDevice == null)
                {
                    rootPage.NotifyUser("Failed to connect to device.", NotifyType.ErrorMessage);
                }
            }
            catch (Exception ex) when (ex.HResult == E_DEVICE_NOT_AVAILABLE)
            {
                rootPage.NotifyUser("Bluetooth radio is not on.", NotifyType.ErrorMessage);
            }

            if (bluetoothLeDevice != null)
            {
                if (!GlobalVariables.bluetoothAPI.isDeviceConnected())
                {
                    GattDeviceServicesResult result = await bluetoothLeDevice.GetGattServicesAsync(BluetoothCacheMode.Uncached);

                    if (result.Status == GattCommunicationStatus.Success)
                    {
                        GlobalVariables.bluetoothAPI.connectToDevice(bluetoothLeDevice);

                    }
                    else
                    {
                        rootPage.NotifyUser("Device unreachable", NotifyType.ErrorMessage);
                    }

                }
                else
                {
                    GlobalVariables.bluetoothAPI.connectToDevice(bluetoothLeDevice);
                }




            }
            ConnectButton.IsEnabled = true;
            Panel1.Visibility = Visibility.Visible;
        }

        public double[] getReflectance()
        {
            int gsize = GlobalVariables.gAllSpectra.Count;

            dbReading sensorReading = GlobalVariables.gAllSpectra[gsize - 1];
            List<Driver.DataPoint> dataPoints = new List<Driver.DataPoint>();
            List<double> dataY = new List<double>();
            if (sensorReading != null)
            {
                if ((sensorReading.getXReading().Length != 0) && (sensorReading.getYReading().Length != 0))
                {
                    double[] xVals = sensorReading.getXReading();
                    double[] yVals = sensorReading.getYReading();
                    List<double> xData = new List<double>();
                    List<double> yData = new List<double>();

                    for (int ax = xVals.Length - 1; ax >= 0; --ax)
                    {
                        double xx = 1e7 / xVals[ax];
                        double yy = yVals[ax] * 100;
                        xData.Add(xx);
                        yData.Add(yy);
                    }
                    /*
                    SplineInterpolator2 scaler = SplineInterpolator2.createMonotoneCubicSpline(xData, yData);
                    */
                    //var scaler = new SplineInterpolation(xData.ToArray(), yData.ToArray());
                    var scaler = new MonotoneCubicSplineInterpolation();
                    scaler.createMonotoneCubicSpline(xData, yData);
                    /*
                    for (int ax = 2500; ax > 1350; ax -= 5)
                    {
                        double x = ax;
                        double y = scaler.Interpolate(x);
                        Console.WriteLine(x + "," + y);
                        dataPoints.Add(new DataPoint(x, y));
                        dataY.Add(y);
                    }*/
                    foreach (var x in SSKEngine.WaveFreq)
                    {

                        double y = scaler.Interpolate(x);
                        Debug.WriteLine(x + "," + y);
                        dataPoints.Add(new Driver.DataPoint(x, y));
                        dataY.Add(y);
                       
                    }
                    ShowChart(dataPoints);
                    var dataArrY = dataY.ToArray();
                    //double[] finalData = Stream.of(dataArrY).mapToDouble(Double::doubleValue).toArray();

                    return dataArrY;
                }
            }

            return null;
        }
        #endregion

        #region chart
        async void ShowChart(List<Driver.DataPoint> datas)
        {
            await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () => {
                ChartItems = new ObservableCollection<ChartItem>();
                foreach (var item in datas)
                {
                    ChartItems.Add(new ChartItem() { Ax = item.X.ToString(), Ay = (int)item.Y });
                }
            });
           
        }
        #endregion

        private void SetVisibility(UIElement element, bool visible)
        {
            element.Visibility = visible ? Visibility.Visible : Visibility.Collapsed;
        }


    }
    public class ChartItem : INotifyPropertyChanged
    {
        private int _ay;

        public string Ax { get; set; }
        public int Ay
        {
            get
            {
                return _ay;
            }
            set
            {
                if (_ay != value)
                {
                    _ay = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Ay)));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
    
    public class MonotoneCubicSplineInterpolation
    {
        private double[] xs { set; get; }
        private double[] ys { set; get; }
        private double[] m { set; get; }
        public double Interpolate(double x)
        {
            if (xs == null || ys == null || m == null)
            {
                throw new Exception("please create spline first.");
            }
            int i;
            for (i = xs.Length - 2; i > 0; --i)
            {
                if (xs[i] <= x)
                {
                    break;
                }
            }
            var h = xs[i + 1] - xs[i];
            var t = (x - xs[i]) / h;
            var t2 = Math.Pow(t, 2);
            var t3 = Math.Pow(t, 3);
            var h00 = 2 * t3 - 3 * t2 + 1;
            var h10 = t3 - 2 * t2 + t;
            var h01 = -2 * t3 + 3 * t2;
            var h11 = t3 - t2;
            var y_interp = h00 * ys[i] + h10 * h * m[i] + h01 * ys[i + 1] + h11 * h * m[i + 1];

            return y_interp;
        }
        public void createMonotoneCubicSpline(List<double> xs, List<double> ys)
        {
            var length = xs.Count;

            // Deal with length issues
            if (length != ys.Count)
            {
                //IPDevLoggerWrapper.Error("Need an equal count of xs and ys");
                throw new Exception("Need an equal count of xs and ys");
            }
            if (length == 0)
            {
                return;
            }
            /*
            if (length == 1)
            {
                return new double[] { ys[0] };
            }
            */
            this.xs = xs.ToArray();
            this.ys = ys.ToArray();
            // Get consecutive differences and slopes
            var delta = new double[length - 1];
            var m = new double[length];

            for (int i = 0; i < length - 1; i++)
            {
                delta[i] = (ys[i + 1] - ys[i]) / (xs[i + 1] - xs[i]);
                if (i > 0)
                {
                    m[i] = (delta[i - 1] + delta[i]) / 2;
                }
            }
            var toFix = new List<int>();
            for (int i = 1; i < length - 1; i++)
            {
                if ((delta[i] > 0 && delta[i - 1] < 0) || (delta[i] < 0 && delta[i - 1] > 0))
                {
                    toFix.Add(i);
                }
            }
            foreach (var val in toFix)
            {
                m[val] = 0;
            }

            m[0] = delta[0];
            m[length - 1] = delta[length - 2];

            toFix.Clear();
            for (int i = 0; i < length - 1; i++)
            {
                if (delta[i] == 0)
                {
                    toFix.Add(i);
                }
            }
            foreach (var val in toFix)
            {
                m[val] = 0;
                m[val + 1] = 0;
            }

            var alpha = new double[length - 1];
            var beta = new double[length - 1];
            var dist = new double[length - 1];
            var tau = new double[length - 1];
            for (int i = 0; i < length - 1; i++)
            {
                alpha[i] = m[i] / delta[i];
                beta[i] = m[i + 1] / delta[i];
                dist[i] = Math.Pow(alpha[i], 2) + Math.Pow(beta[i], 2);
                tau[i] = 3 / Math.Sqrt(dist[i]);
            }

            toFix.Clear();
            for (int i = 0; i < length - 1; i++)
            {
                if (dist[i] > 9)
                {
                    toFix.Add(i);
                }
            }

            foreach (var val in toFix)
            {
                m[val] = tau[val] * alpha[val] * delta[val];
                m[val + 1] = tau[val] * beta[val] * delta[val];
            }

            this.m = m;
        }


    }
}
