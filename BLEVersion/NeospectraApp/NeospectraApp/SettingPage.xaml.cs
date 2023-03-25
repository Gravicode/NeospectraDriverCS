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
using System.Reflection.Metadata;
using Windows.Management;
using Windows.System;
using System.Diagnostics;
using Windows.Storage;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace NeospectraApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SettingPage : Page
    {
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

        double numberOfRuns = 0;
        int count = 0;

        private List<string> mOpticalGainList, mInterpolationPoints, mApodizationList, mZeroPaddingList;

        public string opticalGainName;
        public bool isWaitingForSelfCorrection = false;
        public bool isWaitingForGainSettings = false;
        public bool isWaitingForRestoreToDefault = false;
        public bool isWaitingForStoringAllSettings = false;
        private int notifications_count = 0;
        //Settings
        string optical_gain;
        int optical_gain_value;
        bool linear_interpolation_value;
        string interpolation_points;
        string apodization_value;
        string FFT_points;
        bool fft_settings_switch;
        #region UI Code
        public SettingPage()
        {
            this.InitializeComponent();
            if (GlobalVariables.bluetoothAPI == null)
            {
                GlobalVariables.bluetoothAPI = new SWS_P3API(this.Dispatcher);

            }
            loadPreferences();
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

        private void ScanPage_BroadcastReceived(object sender, SWS_P3ConnectionServices.BroadcastEventArgs e)
        {
            var TAG = nameof(ScanPage);
            var intent = e.iGotData;
            var intentName = Convert.ToString(intent["iName"]);
            switch (intentName)
            {


                case "sensorWriting":
                    break;

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

                    notifications_count = 0;
                    isWaitingForGainSettings = false;
                    isWaitingForSelfCorrection = false;
                    isWaitingForRestoreToDefault = false;
                    isWaitingForStoringAllSettings = false;

                    ShowDialog("Error " + (0x000000FF & errorCode) + " occurred during measurement!");
                    enableView();
                    // show progress bar

                    // set button enable or disable
                    //CommonVariables.setScanningState(0);

                    notifications_count = 0;
                    isWaitingForBackGroundReading = false;
                    isWaitingForSensorReading = false;
                    var xmdock = CreateToast("Error " + (0x000000FF & errorCode) + " occurred during measurement!", "Error");
                    var toast = new ToastNotification(xmdock);
                    var notifi = Windows.UI.Notifications.ToastNotificationManager.CreateToastNotifier();
                    notifi.Show(toast);
                    //ShowDialog( "Error", "Error " + String.valueOf(0x000000FF & errorCode) + " occurred during measurement!");
                    break;

                //case "OperationDone":
                //isWaitingForBackGroundReading = false;
                //isScanBG = false;
                //break;
                //Case device is disconnected
                case "Disconnection_Notification":
                    //endActivity();
                    break;

                case "OperationDone":
                    ShowDialog("Preferences has been saved on the scanner successfully.");
                    enableView();
                    break;
                case "Error":
                    errorCode = Convert.ToInt32(intent["data"]);
                    ShowDialog(
                            "Error " + (0x000000FF & errorCode) +
                                    " occurred during measurement!");
                    enableView();
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

            notifications_count++;

            if (notificationReason.Equals("gotData"))
            {
                double[] gain = (double[])intent["data"];

                if (isWaitingForGainSettings)
                {
                    ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;

                    // Save a setting locally on the device
                    localSettings.Values[opticalGainName] = (int)gain[0];
                    //SharedPreferences.Editor editor = preferences.edit();
                    //editor.putInt(opticalGainName, (int)gain[0]);
                    //editor.commit();
                    //preferences.edit().putString(mOpticalGainList.getKey(), mOpticalGainList.getValue());
                    localSettings.Values["mOpticalGainList"] = mOpticalGainListValue;
                    writeToFile();
                    setListPreferenceData(mOpticalGainList);
                    mOpticalGainListValue = (opticalGainName);

                    isWaitingForGainSettings = false;

                    enableView();
                    return;
                }
                else if (isWaitingForRestoreToDefault)
                {
                    MethodsFactory.LogMessage("RestoreToDefault", "Settings has been restored successfully.");
                    ShowDialog("Restore To Default - Settings has been restored successfully.");

                    enableView();
                    isWaitingForRestoreToDefault = false;
                }
                else if (isWaitingForStoringAllSettings && ((notifications_count % 2) == 0))
                {
                    MethodsFactory.LogMessage("StoringAllSettings", "Settings has been stored successfully.");
                    ShowDialog("Storing All Settings - Settings has been stored successfully.");

                    enableView();
                    isWaitingForStoringAllSettings = false;
                }
                else if (isWaitingForSelfCorrection && ((notifications_count % 3) == 0))
                {
                    MethodsFactory.LogMessage("SelfCalibration", "Self Calibration has been finished successfully.");
                    ShowDialog("Run Self Calibration - Self Calibration has been finished successfully.");

                    isWaitingForSelfCorrection = false;
                    enableView();
                }

            }

            else
            {
                return;
            }
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


        #endregion

        string TAG = nameof(SettingPage);

        private void SetVisibility(UIElement element, bool visible)
        {
            element.Visibility = visible ? Visibility.Visible : Visibility.Collapsed;
        }

        int mApodizationListValue = -1;
        int mZeroPaddingListValue = -1;
        int mInterpolationPointsValue = -1;
        string mOpticalGainListValue = string.Empty;
        void CreatePreference()
        {
            ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;



            // Initialize all preferences

            mOpticalGainList = new List<string>() { "Default" };
            mInterpolationPoints = new List<string>() { "65 points", "129 points", "257 points" };
            mApodizationList = new List<string>() { "Boxcar", "Gaussian", "Happ-Genzel", "Lorenz" };
            mZeroPaddingList = new List<string>() { "8k points", "16k points", "32k points" };
            // load a setting that is local to the device
            String localValue = localSettings.Values["test setting"] as string;
            if (mInterpolationPointsValue == -1)
            {
                mInterpolationPointsValue = 2;
            }

            if (mApodizationListValue == -1)
            {
                mApodizationListValue = 0;
            }

            if (mZeroPaddingListValue == -1)
            {
                mZeroPaddingListValue = 0;
            }
        }

        async void ClearOpticalGain()
        {
            ContentDialog confirmDialog = new ContentDialog
            {
                Title = "clear_optical_gain_settings?",
                Content = "Are you sure you want to clear all optical gains?",
                PrimaryButtonText = "Clear",
                CloseButtonText = "Cancel"
            };

            ContentDialogResult result = await confirmDialog.ShowAsync();

            // Delete the file if the user clicked the primary button.
            /// Otherwise, do nothing.
            if (result == ContentDialogResult.Primary)
            {
                // Delete the file.
                clearFile();
                setListPreferenceData(mOpticalGainList);
            }
            else
            {
                // The user clicked the CloseButton, pressed ESC, Gamepad B, or the system back button.
                // Do nothing.
            }
        }

        async void StoreAllSetting()
        {
            ContentDialog confirmDialog = new ContentDialog
            {
                Title = "store_all_Settings?",
                Content = "Start storing all settings?",
                PrimaryButtonText = "Store",
                CloseButtonText = "Cancel"
            };

            ContentDialogResult result = await confirmDialog.ShowAsync();

            // Delete the file if the user clicked the primary button.
            /// Otherwise, do nothing.
            if (result == ContentDialogResult.Primary)
            {
                askForStoringAllSettings();
            }
            else
            {
                // The user clicked the CloseButton, pressed ESC, Gamepad B, or the system back button.
                // Do nothing.
            }
        }

        async void RestoreDefault()
        {
            ContentDialog confirmDialog = new ContentDialog
            {
                Title = "restore_default?",
                Content = "By restoring default settings, all current settings will be cleared." +
            "Are you sure you would like to proceed?",
                PrimaryButtonText = "Restore",
                CloseButtonText = "Cancel"
            };

            ContentDialogResult result = await confirmDialog.ShowAsync();

            // Delete the file if the user clicked the primary button.
            /// Otherwise, do nothing.
            if (result == ContentDialogResult.Primary)
            {
                askForRestoreToDefaultSettings();
            }
            else
            {
                // The user clicked the CloseButton, pressed ESC, Gamepad B, or the system back button.
                // Do nothing.
            }
        }

        async void SetScanTimePreference()
        {
            ContentDialog confirmDialog = new ContentDialog
            {
                Title = "scanTime_preferences?",
                Content = "Scan time will be saved in Scanner = " + scanTime + "S",
                PrimaryButtonText = "Save",
                CloseButtonText = "Cancel"
            };

            ContentDialogResult result = await confirmDialog.ShowAsync();

            // Delete the file if the user clicked the primary button.
            /// Otherwise, do nothing.
            if (result == ContentDialogResult.Primary)
            {

            }
            else
            {
                // The user clicked the CloseButton, pressed ESC, Gamepad B, or the system back button.
                // Do nothing.
            }
        }

        async void AddNewOpticalGain()
        {
            ContentDialog confirmDialog = new ContentDialog
            {
                Title = "add_new_optical_gain_settings?",
                Content = "add_new_optical_gain_settings",
                PrimaryButtonText = "Add",
                CloseButtonText = "Cancel"
            };

            ContentDialogResult result = await confirmDialog.ShowAsync();

            // Delete the file if the user clicked the primary button.
            /// Otherwise, do nothing.
            if (result == ContentDialogResult.Primary)
            {
                setListPreferenceData(mOpticalGainList);

            }
            else
            {
                // The user clicked the CloseButton, pressed ESC, Gamepad B, or the system back button.
                // Do nothing.
            }
        }

        async void WavelengthCorrection()
        {
            ContentDialog confirmDialog = new ContentDialog
            {
                Title = "Run Self Calibration?",
                Content = "Run a smart routine to automatically recalibrate wavelengths shifts with samples that have flat spectral response.",
                PrimaryButtonText = "Proceed",
                CloseButtonText = "Cancel"
            };

            ContentDialogResult result = await confirmDialog.ShowAsync();

            // Delete the file if the user clicked the primary button.
            /// Otherwise, do nothing.
            if (result == ContentDialogResult.Primary)
            {
                sendSelfCorrectionCommand();

            }
            else
            {
                // The user clicked the CloseButton, pressed ESC, Gamepad B, or the system back button.
                // Do nothing.
            }
        }

        async void SaveAllPreference()
        {
            ContentDialog confirmDialog = new ContentDialog
            {
                Title = "save all preference?",
                Content = "Save all preference ?",
                PrimaryButtonText = "Yes",
                CloseButtonText = "Cancel"
            };

            ContentDialogResult result = await confirmDialog.ShowAsync();

            // Delete the file if the user clicked the primary button.
            /// Otherwise, do nothing.
            if (result == ContentDialogResult.Primary)
            {
                savePreferences();

            }
            else
            {
                // The user clicked the CloseButton, pressed ESC, Gamepad B, or the system back button.
                // Do nothing.
            }
        }



        // Request command of selfCorrection from scanner
        private void sendSelfCorrectionCommand()
        {
            Debug.WriteLine("inside sendSelfCorrectionCommand");
            if (isWaitingForSelfCorrection)
            {
                MethodsFactory.LogMessage(TAG, "Still waiting for sensor reading ... ");
                return;
            }
            isWaitingForSelfCorrection = true;

            askForSelfCorrection();
            disableView();
        }

        // Request command of selfCorrection from scanner
        private void askForSelfCorrection()
        {
            if (scanPresenter == null)
            {
                scanPresenter = new ScanPresenter();
            }
            // Don't complete the process if the device not connected
            if (bluetoothAPI == null || !bluetoothAPI.isDeviceConnected())
            {
                ShowDialog(
                        "Please! Ensure that you have a connected device firstly");

                return;
            }

            scanPresenter.requestSelfCalibration(scanTime);
        }

        // Request restore to default settings from scanner
        private void askForRestoreToDefaultSettings()
        {
            if (scanPresenter == null)
            {
                scanPresenter = new ScanPresenter();
            }
            // Don't complete the process if the device not connected
            if (bluetoothAPI == null || !bluetoothAPI.isDeviceConnected())
            {
                ShowDialog("Please! Ensure that you have a connected device firstly");
                return;
            }

            isWaitingForRestoreToDefault = true;
            scanPresenter.restoreToDefaultSettings();
            disableView();
        }

        // Request to sore all setting in the scanner
        private void askForStoringAllSettings()
        {
            if (scanPresenter == null)
            {
                scanPresenter = new ScanPresenter();
            }
            // Don't complete the process if the device not connected
            if (bluetoothAPI == null || !bluetoothAPI.isDeviceConnected())
            {
                ShowDialog(

                        "Please! Ensure that you have a connected device firstly");

                return;
            }

            isWaitingForStoringAllSettings = true;
            scanPresenter.storingSettings();
            disableView();
        }

        protected void setListPreferenceData(List<string> lp)
        {
            //    List<CharSequence> charSequences = new ArrayList<>();
            //    ArrayList<String> opticalGains = readFromFile();
            //    ArrayList<String> newList = new ArrayList<String>();

            //    // Traverse through the first list
            //    for (String element : opticalGains) {
            //    if (!newList.contains(element))
            //    {
            //        newList.add(element);
            //    }
            //}

            //// return the new list
            //charSequences.add("Default");
            //for (int i = 0; i < newList.size(); ++i)
            //{
            //    charSequences.add(newList.get(i));
            //}

            //CharSequence[] charSequenceArray = charSequences.toArray(new
            //        CharSequence[charSequences.size()]);
            //lp.setEntries(charSequenceArray);
            //lp.setEntryValues(charSequenceArray);

            //if (lp.getValue() == null)
            //    lp.setValueIndex(charSequenceArray.length - 1);

            //if (lp.getEntries().length == 1)
            //{
            //    lp.setValueIndex(0);
            //}
        }

        // Read from configuration file
        private List<String> readFromFile()
        {
            List<String> arr = new List<string>();
            try
            {
                var fname = "configurations.txt";
                if (File.Exists(fname))
                {
                    arr = File.ReadLines(fname).ToList();
                }

            }
            catch (FileNotFoundException e)
            {
                Debug.WriteLine("login activity", "File not found: " + e);
            }
            catch (IOException e)
            {
                Debug.WriteLine("login activity", "Can not read file: " + e);
            }

            return arr;
        }




        // Write optical Gain settings to configuration file
        private void writeToFile()
        {
            try
            {
                var fname = "configurations.txt";
                if (File.Exists(fname))
                {
                    File.AppendAllText(fname, opticalGainName);
                    File.AppendAllText(fname, "\n");

                }

            }
            catch (FileNotFoundException e)
            {
                Debug.WriteLine("Exception", "File write failed: " + e);
            }
            catch (IOException e)
            {
                Debug.WriteLine("Exception", "File write failed: " + e);
            }
        }

        // Clear all settings from configuration file
        private void clearFile()
        {
            try
            {
                var fname = "configurations.txt";
                if (File.Exists(fname))
                {
                    File.WriteAllText(fname, string.Empty);
                }
            }
            catch (FileNotFoundException e)
            {
                Debug.WriteLine("Exception", "File write failed: " + e);
            }
            catch (IOException e)
            {
                Debug.WriteLine("Exception", "File write failed: " + e);
            }
        }



        public void onSharedPreferenceChanged(String key)
        {

            if (key.Equals("add_new_optical_gain_settings"))
            {
                ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;

                // load a setting that is local to the device
                String localValue = localSettings.Values["mOpticalGainListValue"] as string;
                //EditTextPreference preference = (EditTextPreference)findPreference(key);
                opticalGainName = localValue;

                if (!opticalGainName.Equals(""))
                {
                    if (bluetoothAPI == null)
                    {
                        bluetoothAPI = new SWS_P3API(this.Dispatcher);
                    }

                    scanPresenter = new ScanPresenter();

                    isWaitingForGainSettings = true;
                    scanPresenter.requestGainReading();
                    disableView();
                }

            }

        }

        private void disableView()
        {
            //((PreferenceCategory)findPreference("category_measurement_parameters")).setEnabled(false);
            //((PreferenceCategory)findPreference("category_data_display")).setEnabled(false);
            //((PreferenceCategory)findPreference("category_fft_settings")).setEnabled(false);
            //((PreferenceCategory)findPreference("category_advanced_settings")).setEnabled(false);
            //((PreferenceCategory)findPreference("category_save_restore")).setEnabled(false);
        }

        private void enableView()
        {
            //((PreferenceCategory)findPreference("category_measurement_parameters")).setEnabled(true);
            //((PreferenceCategory)findPreference("category_data_display")).setEnabled(true);
            //((PreferenceCategory)findPreference("category_fft_settings")).setEnabled(true);
            //((PreferenceCategory)findPreference("category_advanced_settings")).setEnabled(true);
            //((PreferenceCategory)findPreference("category_save_restore")).setEnabled(true);
        }
      


        private void loadPreferences()
        {
            ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;

            optical_gain = localSettings.Values["optical_gain_settings"] == null ? "Default" : Convert.ToString(localSettings.Values["optical_gain_settings"]);
            optical_gain_value = localSettings.Values[optical_gain] == null ? 0 : Convert.ToInt32(localSettings.Values[optical_gain]);
            linear_interpolation_value = localSettings.Values["linear_interpolation_switch"] == null ? false : Convert.ToBoolean(localSettings.Values["linear_interpolation_switch"]);
            fft_settings_switch = localSettings.Values["fft_settings_switch"] == null ? false : Convert.ToBoolean(localSettings.Values["fft_settings_switch"]);
            interpolation_points = localSettings.Values["data_points"] == null ? GlobalVariables.pointsCount.points_257 : Convert.ToString(localSettings.Values["data_points"]);
            apodization_value = localSettings.Values["apodization_function"] == null ? GlobalVariables.apodization.Boxcar : Convert.ToString(localSettings.Values["apodization_function"]);
            FFT_points = localSettings.Values["fft_points"] == null ? GlobalVariables.zeroPadding.points_32k : Convert.ToString(localSettings.Values["fft_points"]);
        }
            // Save all preferences in scanner
            private void savePreferences()
        {
            if (scanPresenter == null)
            {
                scanPresenter = new ScanPresenter();
            }
            ApplicationDataContainer localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;


            byte[] memPreferencePacket = new byte[11];
            memPreferencePacket[0] = (byte)MEMORY_SAVE_DEFAULT_PARAM;
            var buff = new ByteBuffer(4);
            buff.PutInt((scanTime * 1000));
            //ByteBuffer.allocate(4).order(ByteOrder.LITTLE_ENDIAN).putInt(scanTime * 1000).array()
            Array.Copy(
            buff.ToArray(), 0,
            memPreferencePacket, 1, 3);

            //optical_gain = localSettings.Values["optical_gain_settings"] == null ? "Default" : Convert.ToString(localSettings.Values["optical_gain_settings"]);
            //optical_gain_value = localSettings.Values[optical_gain] == null ? 0 : Convert.ToInt32(localSettings.Values[optical_gain]);
            buff = new ByteBuffer(4);
            buff.PutInt(optical_gain_value);
            //ByteBuffer.allocate(4).order(ByteOrder.LITTLE_ENDIAN).putInt(OpticalGainValue).array()
            Array.Copy(buff.ToArray()
            , 0,
            memPreferencePacket, 4, 2);
            //linear_interpolation_value = localSettings.Values["linear_interpolation_switch"] == null ? false : Convert.ToBoolean(localSettings.Values["linear_interpolation_switch"]);
            if (!linear_interpolation_value)
                memPreferencePacket[6] = 0;
            else
            {
                //interpolation_points = localSettings.Values["data_points"] == null ? GlobalVariables.pointsCount.points_257 : Convert.ToString(localSettings.Values["data_points"]);
                //String interpolationPoints = preferences.getString("data_points", GlobalVariables.pointsCount.points_257);

                if (interpolation_points.Equals(GlobalVariables.pointsCount.points_65))
                    memPreferencePacket[6] = 1;
                else if (interpolation_points.Equals(GlobalVariables.pointsCount.points_129))
                    memPreferencePacket[6] = 2;
                else if (interpolation_points.Equals(GlobalVariables.pointsCount.points_257))
                    memPreferencePacket[6] = 3;
                else
                    memPreferencePacket[6] = 0;
            }

            if (optical_gain.Equals("Default"))
                memPreferencePacket[7] = 0;
            else
                memPreferencePacket[7] = 2;
            //apodization_value = localSettings.Values["apodization_function"] == null ? GlobalVariables.apodization.Boxcar : Convert.ToString(localSettings.Values["apodization_function"]);
            // String apodizationSel = preferences.getString("apodization_function", GlobalVariables.apodization.Boxcar);
            if (apodization_value.Equals(GlobalVariables.apodization.Boxcar))
                memPreferencePacket[8] = 0;
            else if (apodization_value.Equals(GlobalVariables.apodization.Gaussian))
                memPreferencePacket[8] = 1;
            else if (apodization_value.Equals(GlobalVariables.apodization.HappGenzel))
                memPreferencePacket[8] = 2;
            else if (apodization_value.Equals(GlobalVariables.apodization.Lorenz))
                memPreferencePacket[8] = 3;
            else
                memPreferencePacket[8] = 0;
            //FFT_points = localSettings.Values["fft_points"] == null ? GlobalVariables.zeroPadding.points_32k : Convert.ToString(localSettings.Values["fft_points"]);
            //String FftPoints = preferences.getString("fft_points", GlobalVariables.zeroPadding.points_8k.toString());
            if (FFT_points.Equals(GlobalVariables.zeroPadding.points_8k))
                memPreferencePacket[9] = 1;
            else if (FFT_points.Equals(GlobalVariables.zeroPadding.points_16k))
                memPreferencePacket[9] = 2;
            else if (FFT_points.Equals(GlobalVariables.zeroPadding.points_32k))
                memPreferencePacket[9] = 3;
            else
                memPreferencePacket[9] = 1;

            memPreferencePacket[10] = 0;     //runMode

            disableView();

            if (bluetoothAPI != null)
            {
                bluetoothAPI.sendPacket(memPreferencePacket, false, "Memory Service");

                // Save a setting locally on the device
              
                localSettings.Values["optical_gain_settings"] = optical_gain;
                localSettings.Values["optical_gain"] = optical_gain_value;
                localSettings.Values["linear_interpolation_switch"] = linear_interpolation_value;
                localSettings.Values["fft_settings_switch"] = fft_settings_switch;
                localSettings.Values["data_points"] = interpolation_points;
                localSettings.Values["apodization_function"] = apodization_value;
                localSettings.Values["fft_points"] = FFT_points;
              
            }
        }
        async void SaveClick()
        {
            savePreferences();
        }
        List<string> ListInterpolationPoints = new List<string>() { GlobalVariables.pointsCount.points_65, GlobalVariables.pointsCount.points_129, GlobalVariables.pointsCount.points_257 };
        List<string> ListApodization = new List<string>() { GlobalVariables.apodization.Boxcar, GlobalVariables.apodization.Gaussian, GlobalVariables.apodization.Lorenz, GlobalVariables.apodization.HappGenzel };
        List<string> ListFftPoints = new List<string>() { GlobalVariables.zeroPadding.points_8k, GlobalVariables.zeroPadding.points_16k, GlobalVariables.zeroPadding.points_32k };
    }

}
