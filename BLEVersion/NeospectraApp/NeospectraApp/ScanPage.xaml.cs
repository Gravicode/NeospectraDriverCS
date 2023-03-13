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
        #endregion

       

        private void SetVisibility(UIElement element, bool visible)
        {
            element.Visibility = visible ? Visibility.Visible : Visibility.Collapsed;
        }

     
    }
}
