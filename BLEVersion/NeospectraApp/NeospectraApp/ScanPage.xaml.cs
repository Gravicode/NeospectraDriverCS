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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace NeospectraApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ScanPage : Page
    {
      
        private MainPage rootPage = MainPage.Current;
        int scanTime = 2;
        private BluetoothLEDevice bluetoothLeDevice = null;
  ScanPresenter scanPresenter = null;

        #region Error Codes
        readonly int E_BLUETOOTH_ATT_WRITE_NOT_PERMITTED = unchecked((int)0x80650003);
        readonly int E_BLUETOOTH_ATT_INVALID_PDU = unchecked((int)0x80650004);
        readonly int E_ACCESSDENIED = unchecked((int)0x80070005);
        readonly int E_DEVICE_NOT_AVAILABLE = unchecked((int)0x800710df); // HRESULT_FROM_WIN32(ERROR_DEVICE_NOT_AVAILABLE)
        #endregion

        #region UI Code
        public ScanPage()
        {
            this.InitializeComponent();
            if(GlobalVariables.bluetoothAPI  == null)
            {
                GlobalVariables.bluetoothAPI = new SWS_P3API(this.Dispatcher);
            }
        }


        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            SelectedDeviceRun.Text = rootPage.SelectedBleDeviceName;
            if (string.IsNullOrEmpty(rootPage.SelectedBleDeviceId))
            {
                ConnectButton.IsEnabled = false;
            }
        }

        protected override async void OnNavigatedFrom(NavigationEventArgs e)
        {
            var success = await ClearBluetoothLEDeviceAsync();
            if (!success)
            {
                rootPage.NotifyUser("Error: Unable to reset app state", NotifyType.ErrorMessage);
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
                scanPresenter.requestBackgroundReading(scanTime);
            }
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
                

              

            }
            ConnectButton.IsEnabled = true;
            Panel1.Visibility = Visibility.Visible;
        }

        public double[] getReflectance()
        {
            int gsize =  GlobalVariables.gAllSpectra.Count;

            dbReading sensorReading = GlobalVariables.gAllSpectra[gsize - 1];
            List<DataPoint> dataPoints = new List<DataPoint>();
            List<double> dataY = new  List<double>();
            if (sensorReading != null)
            {
                if ((sensorReading.getXReading().Length != 0) && (sensorReading.getYReading().Length != 0))
                {
                    double[] xVals = sensorReading.getXReading();
                    double[] yVals = sensorReading.getYReading();
                    List<double> xData = new List<double> ();
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
                    var scaler = new MonotoneCubicSplineInterpolation();
                    scaler.createMonotoneCubicSpline(xData, yData);
                    for (int ax = 2500; ax > 1350; ax -= 5)
                    {
                        double x = ax;
                        double y = scaler.Interpolate(x);
                        Console.WriteLine(x + "," + y);
                        dataPoints.Add(new DataPoint(x, y));
                        dataY.Add(y);
                    }
                    
                    var dataArrY = dataY.ToArray();
                    //double[] finalData = Stream.of(dataArrY).mapToDouble(Double::doubleValue).toArray();

                    return dataArrY;
                }
            }

            return null;
        }
        #endregion



        private void SetVisibility(UIElement element, bool visible)
        {
            element.Visibility = visible ? Visibility.Visible : Visibility.Collapsed;
        }

     
    }
    public class MonotoneCubicSplineInterpolation
    {
        private double[] xs { set; get; }
        private double[] ys { set; get; }
        private double[] m { set; get; }
        public double Interpolate(double x)
        {
            if(xs == null || ys == null || m == null)
            {
                throw new Exception("please create spline first.");
            }
            int i;
            for (i = xs.Length - 2; i >= 0; --i)
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
