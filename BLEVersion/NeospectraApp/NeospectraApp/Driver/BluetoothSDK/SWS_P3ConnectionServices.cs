using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Bluetooth;
using Windows.Devices.Enumeration;
using Windows.UI.Core;

namespace NeospectraApp.Driver
{
    public class SWS_P3ConnectionServices
    {
        static private List<SWS_P3BLEDevice> bleDevices;
        private static String TAG = "P3_Connection";


        bool mHeaderPacketDone = false;
        private bool mHeaderMemPacketDone = false;
        private bool mHeaderSysPacketDone = false;
        private byte[] scanBytes;
        private int scanBytesIterator;
        private int packetsType = 0;
        int mNumberOfPackets = 0;
        int mDataLength = 0;
        int mReceivedPacketsCounter = 0;
        SWS_P3PacketResponse mPacketResponse;
        bool still_fail = true;
        bool isConnectedToGatt = false;
        int status;

        // flag to connection process
        public enum ConnectionStatus
        {
            ready,
            findingChannel,
            failedToGetChannel,
            gotChannel,
            connecting,
            failedToConnect,
            connected,
            disconnected
        }

        public ConnectionStatus connectionStatus = ConnectionStatus.ready;

        public ConnectionStatus getConnectionStatus()
        {
            return connectionStatus;
        }

        public void setConnectionStatus(ConnectionStatus connectionStatus)
        {
            this.connectionStatus = connectionStatus;
        }

        // =====================================================================
        // RxAndroidBLE related variables
        //private RxBleClient mRxBleClient;
        private BluetoothLEDevice mRxBleDevice;
        //private Disposable scanSubscription;
        private ObservableCollection<BluetoothLEDeviceDisplay> mRxBleConnection;




        List<SWS_P3BLEDevice> DevicesList = new List<SWS_P3BLEDevice>();

        List<String> DevicesMacAddress = new List<string>();
        List<Guid> serviceGuidsList = new List<Guid>();
        List<Guid> characteristicGuidsList = new List<Guid>();
        List<Guid> descriptorGuidsList = new List<Guid>();

        // ============================================================================================================
        public static int MY_PERMISSIONS_REQUEST_ACCESS_FINE_LOCATION = 1;
        private static readonly int LOCATION_PERMISSION_REQUEST_CODE = 1;
        // ============================================================================================================

        //Macros
        public static readonly Guid TX_POWER_Guid = new Guid("00001804-0000-1000-8000-00805f9b34fb");
        public static readonly Guid TX_POWER_LEVEL_Guid = new Guid("00002a07-0000-1000-8000-00805f9b34fb");
        public static readonly Guid CCCD = new Guid("00002902-0000-1000-8000-00805f9b34fb");
        public static readonly Guid FIRMWARE_REVISON_Guid = new Guid("00002a26-0000-1000-8000-00805f9b34fb");
        public static readonly Guid DIS_Guid = new Guid("0000180a-0000-1000-8000-00805f9b34fb");

        public static readonly Guid P3_SERVICE_Guid = new Guid("6e400001-b5a3-f393-e0a9-e50e24dcca9e");
        public static readonly Guid SYS_STAT_SERVICE_Guid = new Guid("B100B100-B100-B100-B100-B100B100B100");
        public static readonly Guid MEM_SERVICE_Guid = new Guid("C100C100-C100-C100-C100-C100C100C100");
        public static readonly Guid OTA_SERVICE_Guid = new Guid("D100D100-D100-D100-D100-D100D100D100");
        public static readonly Guid BATTERY_SERVICE_Guid = new Guid("E100E100-E100-E100-E100-E100E100E100");

        public static readonly Guid P3_RX_CHAR_Guid = new Guid("6e400002-b5a3-f393-e0a9-e50e24dcca9e");
        public static readonly Guid P3_TX_CHAR_Guid = new Guid("6e400003-b5a3-f393-e0a9-e50e24dcca9e");
        public static readonly Guid SYS_STAT_TX_CHAR_Guid = new Guid("B101B101-B101-B101-B101-B101B101B101");
        public static readonly Guid SYS_STAT_RX_CHAR_Guid = new Guid("B102B102-B102-B102-B102-B102B102B102");
        public static readonly Guid MEM_TX_CHAR_Guid = new Guid("C101C101-C101-C101-C101-C101C101C101");
        public static readonly Guid MEM_RX_CHAR_Guid = new Guid("C102C102-C102-C102-C102-C102C102C102");
        public static readonly Guid OTA_TX_CHAR_Guid = new Guid("D101D101-D101-D101-D101-D101D101D101");
        public static readonly Guid OTA_RX_CHAR_Guid = new Guid("D102D102-D102-D102-D102-D102D102D102");
        // ======================================================= =====================================================
        private ObservableCollection<BluetoothLEDeviceDisplay> KnownDevices = new ObservableCollection<BluetoothLEDeviceDisplay>();
        private List<DeviceInformation> UnknownDevices = new List<DeviceInformation>();
        public CoreDispatcher Dispatcher { set; get; }
        private DeviceWatcher deviceWatcher;

        // ============================================================================================================
        // Constructor
        private void StartWatcher()
        {
            if (deviceWatcher == null)
            {
                StartBleDeviceWatcher();
            }
            else
            {
                StopBleDeviceWatcher();
            }
        }

        private bool Not(bool value) => !value;


        #region Device discovery

        /// <summary>
        /// Starts a device watcher that looks for all nearby Bluetooth devices (paired or unpaired). 
        /// Attaches event handlers to populate the device collection.
        /// </summary>
        private void StartBleDeviceWatcher()
        {
            // Additional properties we would like about the device.
            // Property strings are documented here https://msdn.microsoft.com/en-us/library/windows/desktop/ff521659(v=vs.85).aspx
            string[] requestedProperties = { "System.Devices.Aep.DeviceAddress", "System.Devices.Aep.IsConnected", "System.Devices.Aep.Bluetooth.Le.IsConnectable" };

            // BT_Code: Example showing paired and non-paired in a single query.
            string aqsAllBluetoothLEDevices = "(System.Devices.Aep.ProtocolId:=\"{bb7bb05e-5972-42b5-94fc-76eaa7084d49}\")";

            deviceWatcher =
                    DeviceInformation.CreateWatcher(
                        aqsAllBluetoothLEDevices,
                        requestedProperties,
                        DeviceInformationKind.AssociationEndpoint);

            // Register event handlers before starting the watcher.
            deviceWatcher.Added += DeviceWatcher_Added;
            deviceWatcher.Updated += DeviceWatcher_Updated;
            deviceWatcher.Removed += DeviceWatcher_Removed;
            deviceWatcher.EnumerationCompleted += DeviceWatcher_EnumerationCompleted;
            deviceWatcher.Stopped += DeviceWatcher_Stopped;

            // Start over with an empty collection.
            KnownDevices.Clear();

            // Start the watcher. Active enumeration is limited to approximately 30 seconds.
            // This limits power usage and reduces interference with other Bluetooth activities.
            // To monitor for the presence of Bluetooth LE devices for an extended period,
            // use the BluetoothLEAdvertisementWatcher runtime class. See the BluetoothAdvertisement
            // sample for an example.
            deviceWatcher.Start();
        }

        /// <summary>
        /// Stops watching for all nearby Bluetooth devices.
        /// </summary>
        private void StopBleDeviceWatcher()
        {
            if (deviceWatcher != null)
            {
                // Unregister the event handlers.
                deviceWatcher.Added -= DeviceWatcher_Added;
                deviceWatcher.Updated -= DeviceWatcher_Updated;
                deviceWatcher.Removed -= DeviceWatcher_Removed;
                deviceWatcher.EnumerationCompleted -= DeviceWatcher_EnumerationCompleted;
                deviceWatcher.Stopped -= DeviceWatcher_Stopped;

                // Stop the watcher.
                deviceWatcher.Stop();
                deviceWatcher = null;
            }
        }

        private BluetoothLEDeviceDisplay FindBluetoothLEDeviceDisplay(string id)
        {
            foreach (BluetoothLEDeviceDisplay bleDeviceDisplay in KnownDevices)
            {
                if (bleDeviceDisplay.Id == id)
                {
                    return bleDeviceDisplay;
                }
            }
            return null;
        }

        private DeviceInformation FindUnknownDevices(string id)
        {
            foreach (DeviceInformation bleDeviceInfo in UnknownDevices)
            {
                if (bleDeviceInfo.Id == id)
                {
                    return bleDeviceInfo;
                }
            }
            return null;
        }

        private async void DeviceWatcher_Added(DeviceWatcher sender, DeviceInformation deviceInfo)
        {
            // We must update the collection on the UI thread because the collection is databound to a UI element.
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                lock (this)
                {
                    Debug.WriteLine(String.Format("Added {0}{1}", deviceInfo.Id, deviceInfo.Name));

                    // Protect against race condition if the task runs after the app stopped the deviceWatcher.
                    if (sender == deviceWatcher)
                    {
                        // Make sure device isn't already present in the list.
                        if (FindBluetoothLEDeviceDisplay(deviceInfo.Id) == null)
                        {
                            if (deviceInfo.Name != string.Empty)
                            {
                                // If device has a friendly name display it immediately.
                                KnownDevices.Add(new BluetoothLEDeviceDisplay(deviceInfo));
                            }
                            else
                            {
                                // Add it to a list in case the name gets updated later. 
                                UnknownDevices.Add(deviceInfo);
                            }
                        }

                    }
                }
            });
        }

        private async void DeviceWatcher_Updated(DeviceWatcher sender, DeviceInformationUpdate deviceInfoUpdate)
        {
            // We must update the collection on the UI thread because the collection is databound to a UI element.
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                lock (this)
                {
                    Debug.WriteLine(String.Format("Updated {0}{1}", deviceInfoUpdate.Id, ""));

                    // Protect against race condition if the task runs after the app stopped the deviceWatcher.
                    if (sender == deviceWatcher)
                    {
                        BluetoothLEDeviceDisplay bleDeviceDisplay = FindBluetoothLEDeviceDisplay(deviceInfoUpdate.Id);
                        if (bleDeviceDisplay != null)
                        {
                            // Device is already being displayed - update UX.
                            bleDeviceDisplay.Update(deviceInfoUpdate);
                            return;
                        }

                        DeviceInformation deviceInfo = FindUnknownDevices(deviceInfoUpdate.Id);
                        if (deviceInfo != null)
                        {
                            deviceInfo.Update(deviceInfoUpdate);
                            // If device has been updated with a friendly name it's no longer unknown.
                            if (deviceInfo.Name != String.Empty)
                            {
                                KnownDevices.Add(new BluetoothLEDeviceDisplay(deviceInfo));
                                UnknownDevices.Remove(deviceInfo);
                            }
                        }
                    }
                }
            });
        }

        private async void DeviceWatcher_Removed(DeviceWatcher sender, DeviceInformationUpdate deviceInfoUpdate)
        {
            // We must update the collection on the UI thread because the collection is databound to a UI element.
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                lock (this)
                {
                    Debug.WriteLine(String.Format("Removed {0}{1}", deviceInfoUpdate.Id, ""));

                    // Protect against race condition if the task runs after the app stopped the deviceWatcher.
                    if (sender == deviceWatcher)
                    {
                        // Find the corresponding DeviceInformation in the collection and remove it.
                        BluetoothLEDeviceDisplay bleDeviceDisplay = FindBluetoothLEDeviceDisplay(deviceInfoUpdate.Id);
                        if (bleDeviceDisplay != null)
                        {
                            KnownDevices.Remove(bleDeviceDisplay);
                        }

                        DeviceInformation deviceInfo = FindUnknownDevices(deviceInfoUpdate.Id);
                        if (deviceInfo != null)
                        {
                            UnknownDevices.Remove(deviceInfo);
                        }
                    }
                }
            });
        }

        private async void DeviceWatcher_EnumerationCompleted(DeviceWatcher sender, object e)
        {
            // We must update the collection on the UI thread because the collection is databound to a UI element.
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                // Protect against race condition if the task runs after the app stopped the deviceWatcher.
                if (sender == deviceWatcher)
                {
                    //rootPage.NotifyUser($"{KnownDevices.Count} devices found. Enumeration completed.",
                    //    NotifyType.StatusMessage);
                }
            });
        }

        private async void DeviceWatcher_Stopped(DeviceWatcher sender, object e)
        {
            // We must update the collection on the UI thread because the collection is databound to a UI element.
            await Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                // Protect against race condition if the task runs after the app stopped the deviceWatcher.
                if (sender == deviceWatcher)
                {
                    //rootPage.NotifyUser($"No longer watching for devices.",
                    //        sender.Status == DeviceWatcherStatus.Aborted ? NotifyType.ErrorMessage : NotifyType.StatusMessage);
                }
            });
        }
        #endregion

        #region Pairing

        private bool isBusy = false;

        private async void PairDevice(BluetoothLEDeviceDisplay bleDeviceDisplay)
        {
            // Do not allow a new Pair operation to start if an existing one is in progress.
            if (isBusy)
            {
                return;
            }

            isBusy = true;

            //rootPage.NotifyUser("Pairing started. Please wait...", NotifyType.StatusMessage);

            // For more information about device pairing, including examples of
            // customizing the pairing process, see the DeviceEnumerationAndPairing sample.

            // Capture the current selected item in case the user changes it while we are pairing.
            //var bleDeviceDisplay = ResultsListView.SelectedItem as BluetoothLEDeviceDisplay;

            // BT_Code: Pair the currently selected device.
            DevicePairingResult result = await bleDeviceDisplay.DeviceInformation.Pairing.PairAsync();
            Debug.WriteLine($"Pairing result = {result.Status}",
                result.Status == DevicePairingResultStatus.Paired || result.Status == DevicePairingResultStatus.AlreadyPaired
                    ? NotifyType.StatusMessage
                    : NotifyType.ErrorMessage);

            isBusy = false;
        }

        #endregion
        public SWS_P3ConnectionServices()
        {
            StartWatcher();
        }
    }
}
