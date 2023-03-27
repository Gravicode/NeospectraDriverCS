using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Bluetooth;
using Windows.Devices.Bluetooth.GenericAttributeProfile;
using Windows.Devices.Enumeration;
using Windows.Devices.Geolocation;
using Windows.Devices.Radios;
using Windows.Security.Cryptography;
using Windows.Storage.Streams;
using Windows.UI.Core;
using static NeospectraApp.Driver.GlobalVariables;

namespace NeospectraApp.Driver
{
    public class SWS_P3ConnectionServices
    {
        static private List<SWS_P3BLEDevice> bleDevices;
        private static String TAG = "P3_Connection";
        #region Error Codes
        readonly int E_BLUETOOTH_ATT_WRITE_NOT_PERMITTED = unchecked((int)0x80650003);
        readonly int E_BLUETOOTH_ATT_INVALID_PDU = unchecked((int)0x80650004);
        readonly int E_ACCESSDENIED = unchecked((int)0x80070005);
        readonly int E_DEVICE_NOT_AVAILABLE = unchecked((int)0x800710df); // HRESULT_FROM_WIN32(ERROR_DEVICE_NOT_AVAILABLE)
        #endregion

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



        BLEServiceList ServiceList = null;
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
        public ObservableCollection<BluetoothLEDeviceDisplay> KnownDevices { set; get; } = new ObservableCollection<BluetoothLEDeviceDisplay>();
        public List<DeviceInformation> UnknownDevices { set; get; } = new List<DeviceInformation>();
        public CoreDispatcher Dispatcher { set; get; }
        public DeviceWatcher deviceWatcher { set; get; }
        public bool IsServiceReady()
        {
            return ServiceList != null && ServiceList.IsReady;
        }
        // ============================================================================================================
        // Constructor
        public async void enableBluetooth()
        {
            BluetoothAdapter btAdapter = await BluetoothAdapter.GetDefaultAsync();
            if (btAdapter == null)
                return ;
            if (!btAdapter.IsCentralRoleSupported)
                return ;
            // for UWP
            var radio = await btAdapter.GetRadioAsync();
            // for Desktop, see warning bellow
            var radios = (await Radio.GetRadiosAsync()).FirstOrDefault(r => r.Kind == RadioKind.Bluetooth);
            if (radio == null)
                return ; // probably device just removed
                              // await radio.SetStateAsync(RadioState.On);
            await radio.SetStateAsync(RadioState.On);
        }

        public async void disableBluetooth()
        {
            setConnecting("disableBluetooth()", false);
            BluetoothAdapter btAdapter = await BluetoothAdapter.GetDefaultAsync();
            if (btAdapter == null)
                return;
            if (!btAdapter.IsCentralRoleSupported)
                return;
            // for UWP
            var radio = await btAdapter.GetRadioAsync();
            // for Desktop, see warning bellow
            var radios = (await Radio.GetRadiosAsync()).FirstOrDefault(r => r.Kind == RadioKind.Bluetooth);
            if (radio == null)
                return; // probably device just removed
                        // await radio.SetStateAsync(RadioState.On);
            await radio.SetStateAsync(RadioState.Off);
        }
        public async Task<bool> isBluetoothEnabled()
        {
            BluetoothAdapter btAdapter = await BluetoothAdapter.GetDefaultAsync();
            if (btAdapter == null)
                return false;
            if (!btAdapter.IsCentralRoleSupported)
                return false;
            // for UWP
            var radio = await btAdapter.GetRadioAsync();
            // for Desktop, see warning bellow
            var radios = (await Radio.GetRadiosAsync()).FirstOrDefault(r => r.Kind == RadioKind.Bluetooth);
            if (radio == null)
                return false; // probably device just removed
                             // await radio.SetStateAsync(RadioState.On);
            return radio.State == RadioState.On;
        }

        public void SetWatcher(bool Start = true)
        {
            if (deviceWatcher == null && Start)
            {
                StartBleDeviceWatcher();
            }
            else
            {
                StopBleDeviceWatcher();
            }
        }

        private bool Not(bool value) => !value;

        public async Task<bool> askForLocationPermissions()
        {
            MethodsFactory.LogMessage("bluetooth", "Ask for permission");


            var accessStatus = await Geolocator.RequestAccessAsync();
            return accessStatus == GeolocationAccessStatus.Allowed;
        }
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
        public SWS_P3ConnectionServices(CoreDispatcher dispatcher)
        {
            this.Dispatcher = dispatcher;
            //StartWatcher();
        }

        public BluetoothLEDevice getmRxBleDevice()
        {
            return mRxBleDevice;
        }

        public void setmRxBleDevice(BluetoothLEDevice mRxBleDevice)
        {
            if (this.mRxBleDevice != mRxBleDevice)
            {
                this.mRxBleDevice = mRxBleDevice;
                this.ServiceList = new BLEServiceList(mRxBleDevice);
            }

        }


        // ============================================================================================================

        
    public async Task< List<SWS_P3BLEDevice>> ScanBTDevices()
        {
            DevicesList = new List<SWS_P3BLEDevice>();

            foreach(var item in KnownDevices)
            {
                var device = await BluetoothLEDevice.FromIdAsync(item.Id);
                DevicesList.Add(new SWS_P3BLEDevice(item.Name, "",0, device));
            }
            return DevicesList;
        }


        public bool isConnecting { set; get; }

        public void setConnecting(String from, bool connecting)
        {
            isConnecting = connecting;
        }

        public void ConnectToP3()
        {
            setConnecting("ConnectToP3()", true);
            broadcastNotificationconnected("connection established!"); //heba added

            //StartWatcher(true);
        }

        public void DisconnectFromP3()
        {
            setConnecting("DisconnectFromP3()", false);
            //StartWatcher(false);
            //disconnectTriggerSubject.onNext(true);
        }
        async Task<GattCharacteristic> GetCharacteristic(GattDeviceService service, Guid CharacterUUID)
        {
            var accessStatus = await service.RequestAccessAsync();
            if (accessStatus == DeviceAccessStatus.Allowed)
            {



                var res = await service.GetCharacteristicsForUuidAsync(CharacterUUID);
                if (res.Status == GattCommunicationStatus.Success)
                {
                    var SelectedCharacteristic = res.Characteristics.FirstOrDefault();
                    return SelectedCharacteristic;
                }



            }
            
            Debug.WriteLine($"Characteristic for {CharacterUUID} is not found");
            return default;
        }
        async Task<GattDeviceService> GetGattService(Guid ServiceUUID)
        {
          
            var res = await this.mRxBleDevice.GetGattServicesForUuidAsync(ServiceUUID);
            if (res.Status == GattCommunicationStatus.Success)
            {
                var service = res.Services.FirstOrDefault();
                return service;
            }
            Debug.WriteLine($"GATT Service for {ServiceUUID} is not found");
            return default;
        }

        Dictionary<Guid,GattCharacteristic> CharacteristicList = new Dictionary<Guid,GattCharacteristic>();
        async Task<GattCharacteristic> GetCharacteristic(Guid CharacterUUID)
        {
            if (CharacteristicList.ContainsKey(CharacterUUID)) return CharacteristicList[CharacterUUID];
            var serviceuid = this.ServiceList.GetServiceUIDByCharacteristicUID(CharacterUUID);
            if (serviceuid == null) throw new Exception("Service is not exists");
            var res = await this.mRxBleDevice.GetGattServicesForUuidAsync(serviceuid.Value);
            if(res.Status == GattCommunicationStatus.Success)
            {
                
                var service = res.Services.FirstOrDefault();
                var accessStatus = await service.RequestAccessAsync();
                if (accessStatus == DeviceAccessStatus.Allowed)
                {
                   
                    var result = await service.GetCharacteristicsForUuidAsync(CharacterUUID);
                    if (result.Status == GattCommunicationStatus.Success)
                    {
                        var SelectedCharacteristic = result.Characteristics.FirstOrDefault();
                        if (!CharacteristicList.ContainsKey(CharacterUUID)) 
                            CharacteristicList.Add(CharacterUUID, SelectedCharacteristic);
                        return SelectedCharacteristic;
                    }

                }
            }
            Debug.WriteLine($"Characteristic for {CharacterUUID} is not found");
            return default;
        }

        private static ushort ParseHeartRateValue(byte[] data)
        {
            // Heart Rate profile defined flag values
            const byte heartRateValueFormat = 0x01;

            byte flags = data[0];
            bool isHeartRateValueSizeLong = ((flags & heartRateValueFormat) != 0);

            if (isHeartRateValueSizeLong)
            {
                return BitConverter.ToUInt16(data, 1);
            }
            else
            {
                return data[1];
            }
        }

        private string FormatValueByPresentation(GattCharacteristic selectedCharacteristic, IBuffer buffer, GattPresentationFormat format)
        {
            // BT_Code: For the purpose of this sample, this function converts only UInt32 and
            // UTF-8 buffers to readable text. It can be extended to support other formats if your app needs them.
            byte[] data;
            CryptographicBuffer.CopyToByteArray(buffer, out data);
            if (format != null)
            {
                if (format.FormatType == GattPresentationFormatTypes.UInt32 && data.Length >= 4)
                {
                    return BitConverter.ToInt32(data, 0).ToString();
                }
                else if (format.FormatType == GattPresentationFormatTypes.Utf8)
                {
                    try
                    {
                        return Encoding.UTF8.GetString(data);
                    }
                    catch (ArgumentException)
                    {
                        return "(error: Invalid UTF-8 string)";
                    }
                }
                else
                {
                    // Add support for other format types as needed.
                    return "Unsupported format: " + CryptographicBuffer.EncodeToHexString(buffer);
                }
            }
            else if (data != null)
            {
                // We don't know what format to use. Let's try some well-known profiles, or default back to UTF-8.
                if (selectedCharacteristic.Uuid.Equals(GattCharacteristicUuids.HeartRateMeasurement))
                {
                    try
                    {
                        return "Heart Rate: " + ParseHeartRateValue(data).ToString();
                    }
                    catch (ArgumentException)
                    {
                        return "Heart Rate: (unable to parse)";
                    }
                }
                else if (selectedCharacteristic.Uuid.Equals(GattCharacteristicUuids.BatteryLevel))
                {
                    try
                    {
                        // battery level is encoded as a percentage value in the first byte according to
                        // https://www.bluetooth.com/specifications/gatt/viewer?attributeXmlFile=org.bluetooth.characteristic.battery_level.xml
                        return "Battery Level: " + data[0].ToString() + "%";
                    }
                    catch (ArgumentException)
                    {
                        return "Battery Level: (unable to parse)";
                    }
                }
                // This is our custom calc service Result UUID. Format it like an Int
                else if (selectedCharacteristic.Uuid.Equals(Constants.ResultCharacteristicUuid))
                {
                    return BitConverter.ToInt32(data, 0).ToString();
                }
                // No guarantees on if a characteristic is registered for notifications.
                //else if (registeredCharacteristic != null)
                //{
                //    // This is our custom calc service Result UUID. Format it like an Int
                //    if (registeredCharacteristic.Uuid.Equals(Constants.ResultCharacteristicUuid))
                //    {
                //        return BitConverter.ToInt32(data, 0).ToString();
                //    }
                //}
                else
                {
                    try
                    {
                        return "Unknown format: " + Encoding.UTF8.GetString(data);
                    }
                    catch (ArgumentException)
                    {
                        return "Unknown format";
                    }
                }
            }
            else
            {
                return "Empty data received";
            }
            return "Unknown format";
        }

        private async void WriteCharacteristic(GattCharacteristic selectedCharacteristic, string ValueStr)
        {
            if (!String.IsNullOrEmpty(ValueStr))
            {
                var writeBuffer = CryptographicBuffer.ConvertStringToBinary(ValueStr,
                    BinaryStringEncoding.Utf8);

                var writeSuccessful = await WriteBufferToSelectedCharacteristicAsync(selectedCharacteristic, writeBuffer);
            }
            else
            {
                Debug.WriteLine("No data to write to device");
            }
        }

        private async void WriteCharacteristicInt(GattCharacteristic selectedCharacteristic, int ValueInt)
        {


            var writer = new DataWriter();
            writer.ByteOrder = ByteOrder.LittleEndian;
            writer.WriteInt32(ValueInt);

            var writeSuccessful = await WriteBufferToSelectedCharacteristicAsync(selectedCharacteristic, writer.DetachBuffer());


        } 
        
        private async Task<bool> WriteCharacteristicBytes(GattCharacteristic selectedCharacteristic, byte[] ValueBytes)
        {
            try
            {
                var writer = new DataWriter();
                writer.ByteOrder = ByteOrder.LittleEndian;
                writer.WriteBytes(ValueBytes);

                var writeSuccessful = await WriteBufferToSelectedCharacteristicAsync(selectedCharacteristic, writer.DetachBuffer());
                return writeSuccessful;

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return false;
            }

           

        }

        private async Task<bool> WriteBufferToSelectedCharacteristicAsync(GattCharacteristic selectedCharacteristic, IBuffer buffer)
        {
            try
            {
                // BT_Code: Writes the value from the buffer to the characteristic.
                var result = await selectedCharacteristic.WriteValueWithResultAsync(buffer);

                if (result.Status == GattCommunicationStatus.Success)
                {
                    Debug.WriteLine("Successfully wrote value to device");
                    return true;
                }
                else
                {
                    Debug.WriteLine($"Write failed: {result.Status}");
                    return false;
                }
            }
            catch (Exception ex) when (ex.HResult == E_BLUETOOTH_ATT_INVALID_PDU)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
            catch (Exception ex) when (ex.HResult == E_BLUETOOTH_ATT_WRITE_NOT_PERMITTED || ex.HResult == E_ACCESSDENIED)
            {
                // This usually happens when a device reports that it support writing, but it actually doesn't.
                Debug.WriteLine(ex.Message);
                return false;
            }
        }

        public async void ReadFromP3()
        {
            if (isConnected())
            {
                var item = await GetCharacteristic(P3_TX_CHAR_Guid);
                var res = await item.ReadValueAsync();
                if(res.Status == GattCommunicationStatus.Success)
                {
                    GattPresentationFormat presentationFormat = null;
                    if (item.PresentationFormats.Count > 0)
                    {

                        if (item.PresentationFormats.Count.Equals(1))
                        {
                            // Get the presentation format since there's only one way of presenting it
                            presentationFormat = item.PresentationFormats[0];
                        }
                        else
                        {
                            // It's difficult to figure out how to split up a characteristic and encode its different parts properly.
                            // In this case, we'll just encode the whole thing to a string to make it easy to print out.
                        }
                    }
                    FormatValueByPresentation(item, res.Value, presentationFormat);
                    onReadSuccess(res.Value.ToArray());
                }
                else
                {
                    onReadFailure("P3 Read Error => " + res.Status.ToString());
                }
                //mRxBleConnection
                //        .firstOrError()
                //        .flatMap(rxBleConnection->rxBleConnection.readCharacteristic(P3_TX_CHAR_UUID))
                //        .observeOn(AndroidSchedulers.mainThread())
                //        .subscribe(this::onReadSuccess, this::onReadFailure);
            }
            else
            {
                Debug.WriteLine("Please! Ensure that you have a connected device firstly");
            }
        }


        private void onReadFailure(string throwable)
        {
            Debug.WriteLine( "Read error: " + throwable);
            broadcastNotificationFailure(throwable + " onReadFailure", "read_failure", 0);
        }

        private void onReadSuccess(byte[] bytes)
        {
            Debug.WriteLine("P3 Read => Read Success!");

        }

        public async void WriteToP3( byte[] byteArray)
        {
            if (isConnected())
            {
                var item = await GetCharacteristic(P3_RX_CHAR_Guid);
                var res = await WriteCharacteristicBytes(item, byteArray);
                Debug.WriteLine($"Write to P3_RX_CHAR_Guid => {res}");
            }
            else
            {
                Debug.WriteLine("Please! Ensure that you have a connected device firstly");
            }
            //if (isConnected())
            //{
            //    mRxBleConnection
            //            .firstOrError()
            //            .flatMap(rxBleConnection->rxBleConnection.writeCharacteristic(P3_RX_CHAR_UUID, byteArray))
            //            .observeOn(AndroidSchedulers.mainThread())
            //            .subscribe(
            //                    bytes->onWriteSuccess(),
            //                    this::onWriteFailure
            //            );
            //}
        }
        public bool isConnected()
        {
            if (mRxBleDevice == null)
            {
                return false;
            }

            setConnecting("isConnected()", false);
            return mRxBleDevice.ConnectionStatus == BluetoothConnectionStatus.Connected;
        }

        public async void writeData(byte[] data)
        {

            if (isConnected())
            {
                var myGatService = await GetGattService(OTA_SERVICE_Guid);

                
                if (myGatService != null)
                {
                    Debug.WriteLine( "* Getting gatt Characteristic. UUID: " + OTA_RX_CHAR_Guid);

                    var myGatChar = await GetCharacteristic (myGatService, OTA_RX_CHAR_Guid /*Consts.UUID_START_HEARTRATE_CONTROL_POINT*/);
                    if (myGatChar != null)
                    {
                        Debug.WriteLine( "* Writing trigger");
                       
                        var res = await WriteCharacteristicBytes(myGatChar, data);
                        Debug.WriteLine($"Write to OTA_RX_CHAR_Guid => {res}");
                        //boolean status = myGatBand.writeCharacteristic(myGatChar);
                       Debug.WriteLine(TAG + "* Writting trigger status :" + res);
                    }
                }              
            }
            else
            {
                Debug.WriteLine("Please! Ensure that you have a connected device firstly");
            }
        }

        public async void WriteToMemoryService( byte[] byteArray)
        {
            if (isConnected())
            {
                var item = await GetCharacteristic(MEM_RX_CHAR_Guid);
                var res = await WriteCharacteristicBytes(item, byteArray);
                Debug.WriteLine($"Write to MEM_RX_CHAR_Guid => {res}");
            }
            else
            {
                Debug.WriteLine("Please! Ensure that you have a connected device firstly");
            }
           
        }

        public async void WriteToSystemService( byte[] byteArray)
        {
            if (isConnected())
            {
                var item = await GetCharacteristic(SYS_STAT_RX_CHAR_Guid);
                var res = await WriteCharacteristicBytes(item, byteArray);
                Debug.WriteLine($"Write to SYS_STAT_RX_CHAR_Guid => {res}");
            }
            else
            {
                Debug.WriteLine("Please! Ensure that you have a connected device firstly");
            }
          
        }
        public async void WriteOTAService( byte[] byteArray)
        {
            if (isConnected())
            {
                var item = await GetCharacteristic(OTA_RX_CHAR_Guid);
                var res = await WriteCharacteristicBytes(item, byteArray);
                Debug.WriteLine($"Write to OTA_RX_CHAR_Guid => {res}");
            }
            else
            {
                Debug.WriteLine("Please! Ensure that you have a connected device firstly");
            }

        }
        GattPresentationFormat notificationFormat;
        bool SubscribeNotification = false;
        private void broadcastWriteFailure(String msg)
        {
            Dictionary<string, object> iWriteData = new Dictionary<string, object>();
            //iWriteData.setAction(GlobalVariables.INTENT_ACTION);
            iWriteData.Add("iName", "sensorWriting");
            iWriteData.Add("isWriteSuccess", false);
            iWriteData.Add("err", msg);
            BroadcastReceived?.Invoke(this, new BroadcastEventArgs() { Created = DateTime.Now, iGotData = iWriteData });

        }

        private void broadcastWriteSuccess()
        {
            Dictionary<string, object> iWriteData = new Dictionary<string, object>();
            //iWriteData.setAction(GlobalVariables.INTENT_ACTION);
            iWriteData.Add("iName", "sensorWriting");
            iWriteData.Add("isWriteSuccess", true);
            BroadcastReceived?.Invoke(this, new BroadcastEventArgs() { Created = DateTime.Now, iGotData = iWriteData });

        }

        public async Task<bool> SetNotificationOnTXInP3()
        {
            if (isConnected())
            {
                var NotificationCharacteristic = await GetCharacteristic(P3_TX_CHAR_Guid);
                if (SubscribeNotification)
                {
                    // Need to clear the CCCD from the remote device so we stop receiving notifications
                    var result = await NotificationCharacteristic.WriteClientCharacteristicConfigurationDescriptorAsync(GattClientCharacteristicConfigurationDescriptorValue.None);
                    if (result != GattCommunicationStatus.Success)
                    {
                        return false;
                    }
                    else
                    {
                        NotificationCharacteristic.ValueChanged -= Notification_ValueChanged;
                        
                    }
                }
                var selectedCharacteristic = NotificationCharacteristic;
                GattCommunicationStatus status = GattCommunicationStatus.Unreachable;
                var cccdValue = GattClientCharacteristicConfigurationDescriptorValue.None;
                if (selectedCharacteristic.CharacteristicProperties.HasFlag(GattCharacteristicProperties.Indicate))
                {
                    cccdValue = GattClientCharacteristicConfigurationDescriptorValue.Indicate;
                }
                else if (selectedCharacteristic.CharacteristicProperties.HasFlag(GattCharacteristicProperties.Notify))
                {
                    cccdValue = GattClientCharacteristicConfigurationDescriptorValue.Notify;
                }

                try
                {
                    // BT_Code: Must write the CCCD in order for server to send indications.
                    // We receive them in the ValueChanged event handler.
                    status = await selectedCharacteristic.WriteClientCharacteristicConfigurationDescriptorAsync(cccdValue);

                    if (status == GattCommunicationStatus.Success)
                    {

                        SubscribeNotification = true;
                        NotificationCharacteristic.ValueChanged += Notification_ValueChanged;
                        notificationFormat = null;
                        if (NotificationCharacteristic.PresentationFormats.Count > 0)
                        {

                            if (NotificationCharacteristic.PresentationFormats.Count.Equals(1))
                            {
                                // Get the presentation format since there's only one way of presenting it
                                notificationFormat = NotificationCharacteristic.PresentationFormats[0];
                            }
                            else
                            {
                                // It's difficult to figure out how to split up a characteristic and encode its different parts properly.
                                // In this case, we'll just encode the whole thing to a string to make it easy to print out.
                            }
                        }
                       
                        MethodsFactory.LogMessage("Successfully subscribed P3 for value changes", "Status");
                        return true;

                        //rootPage.NotifyUser("Successfully subscribed for value changes", NotifyType.StatusMessage);
                    }
                    else
                    {
                        MethodsFactory.LogMessage($"Error registering P3 for value changes: {status}", "ErrorMessage");
                        //rootPage.NotifyUser($"Error registering for value changes: {status}", NotifyType.ErrorMessage);
                    }
                }
                catch (UnauthorizedAccessException ex)
                {
                    // This usually happens when a device reports that it support indicate, but it actually doesn't.
                    //rootPage.NotifyUser(ex.Message, NotifyType.ErrorMessage);
                    MethodsFactory.LogMessage(ex.Message, "ErrorMessage");
                }
               
                //mRxBleConnection
                //        .flatMap(rxBleConnection->rxBleConnection.setupNotification(P3_TX_CHAR_UUID))
                //        .doOnNext(notificationObservable->MainActivityInstance.runOnUiThread(this::notificationHasBeenSetUp))
                //        .doOnError(setupThrowable->MainActivityInstance.runOnUiThread(this::dataNotificationSetupError))
                //        .flatMap(notificationObservable->notificationObservable)
                //        .retryWhen(errors->errors.flatMap(error-> {
                //    if (error instanceof BleDisconnectedException) {
                //        Log.d("Retry", "Retrying");
                //        return Observable.just(null);
                //    }
                //    return Observable.error(error);
                //}))
                //    .observeOn(AndroidSchedulers.mainThread())
                //    .subscribe(this::onNotificationReceived,
                //            this::onNotificationSetupFailure);
            }
            return false;
        }

        private async void Notification_ValueChanged(GattCharacteristic sender, GattValueChangedEventArgs args)
        {
            byte[] data;
            CryptographicBuffer.CopyToByteArray(args.CharacteristicValue, out data);
            onNotificationReceived(data);
        }
        private void onNotificationReceived( byte[] bytes)
        {
            if (!mHeaderPacketDone)
            {
                // get the error code and check its value
                if (bytes[0] == 0)
                {
                    Debug.WriteLine( "%--> NO Error in Received Packet.");

                    int doublesCount = 0;
                    // No Error, compute the length of the frame
                    int length1 = 0x000000FF & (bytes[1]);
                    int length2 = 0x000000FF & (bytes[2]);
                    mDataLength = (length1) + ((length2) << 8);

                    Debug.WriteLine("%--> Length: " + mDataLength + "  mInterpolationEnabled = " + gIsInterpolationEnabled);

                    if (mDataLength == 1 || mDataLength == 2)
                    {
                        mNumberOfPackets = 1;
                    }
                    else
                    {
                        if (gIsInterpolationEnabled)
                        {
                            mNumberOfPackets = (int)Math.Ceiling((mDataLength + 2) * 8.0 / 20);
                        }
                        else
                        {
                            mNumberOfPackets = (int)Math.Ceiling((mDataLength * 2) * 8.0 / 20);
                        }

                    }

                    Debug.WriteLine("%--> Packets: " + mNumberOfPackets);


                    // create a new response packet
                    mPacketResponse = new SWS_P3PacketResponse(mNumberOfPackets, mDataLength, gIsInterpolationEnabled);

                    // initialize the packet response
                    mPacketResponse.PrepareArraySize();

                    // set iteration parameters
                    mHeaderPacketDone = true;
                }
                else
                {
                    // Error
                    Debug.WriteLine( "#--> Error in Received Packet.");
                    broadcastNotificationFailure("#--> Error in Received Packet.", "packet_failure", (int)bytes[0]);
                }
            }
            else
            {

                // send the received bytes to the packet response instance
                mPacketResponse.AddNewResponse(bytes);

                // increment the received packets counter
                mReceivedPacketsCounter++;

                Debug.WriteLine("#--> Received packets: " + mReceivedPacketsCounter);

                Debug.WriteLine("mDataLength = " + mDataLength + ", mNumberOfPackets = " + mNumberOfPackets);
                if (mNumberOfPackets == mReceivedPacketsCounter)
                {
                    mReceivedPacketsCounter = 0;
                    Debug.WriteLine("#--> Received packets: Done !!");
                    Debug.WriteLine("-------------------------------------------------------------------------------------");

                    // initiate the interpretation process
                    mPacketResponse.InterpretByteStream();

                    double[] mRecDoubles = mPacketResponse.GetInterpretedPacketResponse();

                    broadcastNotificationData(mRecDoubles, mPacketResponse.ConvertByteArrayToString());
                    Debug.WriteLine("A PACKET IS BROADCASTED");
                    // fix iterator parameters for next packet
                    mHeaderPacketDone = false;
                }
            }

            Debug.WriteLine("Notification Received - " + bytes.Length);
        }
        GattPresentationFormat MemTxFormat;
        bool SubscribeMemTx = false;
        public async Task<bool> SetNotificationOnMemTx()
        {
            if (isConnected())
            {
                var MemTxCharacteristic = await GetCharacteristic(MEM_TX_CHAR_Guid);
                if (SubscribeMemTx)
                {
                    // Need to clear the CCCD from the remote device so we stop receiving notifications
                    var result = await MemTxCharacteristic.WriteClientCharacteristicConfigurationDescriptorAsync(GattClientCharacteristicConfigurationDescriptorValue.None);
                    if (result != GattCommunicationStatus.Success)
                    {
                        return false;
                    }
                    else
                    {
                        MemTxCharacteristic.ValueChanged -= MemTx_ValueChanged;

                    }
                }
                var selectedCharacteristic = MemTxCharacteristic;
                GattCommunicationStatus status = GattCommunicationStatus.Unreachable;
                var cccdValue = GattClientCharacteristicConfigurationDescriptorValue.None;
                if (selectedCharacteristic.CharacteristicProperties.HasFlag(GattCharacteristicProperties.Indicate))
                {
                    cccdValue = GattClientCharacteristicConfigurationDescriptorValue.Indicate;
                }
                else if (selectedCharacteristic.CharacteristicProperties.HasFlag(GattCharacteristicProperties.Notify))
                {
                    cccdValue = GattClientCharacteristicConfigurationDescriptorValue.Notify;
                }

                try
                {
                    // BT_Code: Must write the CCCD in order for server to send indications.
                    // We receive them in the ValueChanged event handler.
                    status = await selectedCharacteristic.WriteClientCharacteristicConfigurationDescriptorAsync(cccdValue);

                    if (status == GattCommunicationStatus.Success)
                    {
                        SubscribeMemTx = true;
                        MemTxCharacteristic.ValueChanged += MemTx_ValueChanged;
                        MemTxFormat = null;
                        if (MemTxCharacteristic.PresentationFormats.Count > 0)
                        {

                            if (MemTxCharacteristic.PresentationFormats.Count.Equals(1))
                            {
                                // Get the presentation format since there's only one way of presenting it
                                MemTxFormat = MemTxCharacteristic.PresentationFormats[0];
                            }
                            else
                            {
                                // It's difficult to figure out how to split up a characteristic and encode its different parts properly.
                                // In this case, we'll just encode the whole thing to a string to make it easy to print out.
                            }
                        }
                       
                        MethodsFactory.LogMessage("Successfully subscribed MemTX for value changes", "Status");
                        return true;

                        //rootPage.NotifyUser("Successfully subscribed for value changes", NotifyType.StatusMessage);
                    }
                    else
                    {
                        MethodsFactory.LogMessage($"Error registering MemTX for value changes: {status}", "ErrorMessage");
                        //rootPage.NotifyUser($"Error registering for value changes: {status}", NotifyType.ErrorMessage);
                    }
                }
                catch (UnauthorizedAccessException ex)
                {
                    // This usually happens when a device reports that it support indicate, but it actually doesn't.
                    //rootPage.NotifyUser(ex.Message, NotifyType.ErrorMessage);
                    MethodsFactory.LogMessage(ex.Message, "ErrorMessage");
                }
                
                //if (isConnected())
                //{
                //    mRxBleConnection
                //            .flatMap(rxBleConnection->rxBleConnection.setupNotification(MEM_TX_CHAR_UUID))
                //            .doOnNext(notificationObservable->MainActivityInstance.runOnUiThread(this::notificationHasBeenSetUp))
                //            .doOnError(setupThrowable->MainActivityInstance.runOnUiThread(this::dataNotificationSetupError))
                //            .flatMap(notificationObservable->notificationObservable)
                //            .retryWhen(errors->errors.flatMap(error-> {
                //        if (error instanceof BleDisconnectedException) {
                //            Log.d("Retry", "Retrying");
                //            return Observable.just(null);
                //        }
                //        return Observable.error(error);
                //    }))
                //        .observeOn(AndroidSchedulers.mainThread())
                //        .subscribe(this::onMemNotificationReceived,
                //                this::onNotificationSetupFailure);
                //}
            }
            return false;
        }
        private async void MemTx_ValueChanged(GattCharacteristic sender, GattValueChangedEventArgs args)
        {
            byte[] data;
            CryptographicBuffer.CopyToByteArray(args.CharacteristicValue, out data);
            onMemNotificationReceived(data);
        }
        private void onMemNotificationReceived(byte[] bytes)
        {
            if (!mHeaderMemPacketDone)
            {
                status = bytes[0];


                mDataLength = ((bytes[1] & 0xFF) << 0) | ((bytes[2] & 0xFF) << 8);

                scanBytes = new byte[mDataLength];
                scanBytesIterator = 0;

                mHeaderMemPacketDone = true;
            }
            else
            {

                if (mDataLength == 1 && status == 0)
                {
                    broadcastHomeNotification(0, "OperationDone");
                    mHeaderMemPacketDone = false;
                    return;
                }
                else if (mDataLength == 1 && status != 0)
                {
                    broadcastHomeNotification(0, "Error");
                    mHeaderMemPacketDone = false;
                    return;
                }

                if (scanBytesIterator == 0)
                {
                    long type = ((bytes[0] & 0xFFL) << 0) |
                            ((bytes[1] & 0xFFL) << 8) |
                            ((bytes[2] & 0xFFL) << 16) |
                            ((bytes[3] & 0xFFL) << 24);                //long to support 32-bin unsigned
                    packetsType = (int)type;
                }

                switch (packetsType)
                {
                    case MEMORY_STATUS_REQUEST:

                        long memory = ((bytes[4] & 0xFFL) << 0) |
                                ((bytes[5] & 0xFFL) << 8) |
                                ((bytes[6] & 0xFFL) << 16) |
                                ((bytes[7] & 0xFFL) << 24);                //long to support 32-bin unsigned

                        long FWVersion = ((bytes[8] & 0xFFL) << 0) |
                                ((bytes[9] & 0xFFL) << 8) |
                                ((bytes[10] & 0xFFL) << 16) |
                                ((bytes[11] & 0xFFL) << 24);              //long to support 32-bin unsigned

                        broadcastHomeNotification(memory, "Memory");
                        broadcastHomeNotification(FWVersion, "FWVersion");

                        mHeaderMemPacketDone = false;
                        break;

                    case MEMORY_GET_SCANS_REQUEST:
                        if (scanBytesIterator == 0)
                        {
                            Array.Copy(bytes, 4, scanBytes, scanBytesIterator, 16);
                            scanBytesIterator = scanBytesIterator + 16;
                        }
                        else if (scanBytesIterator + 20 > (mDataLength - 4))
                        {
                            Array.Copy(bytes, 0, scanBytes, scanBytesIterator,
                                    mDataLength - scanBytesIterator - 4);
                            scanBytesIterator = mDataLength - 4;
                        }
                        else
                        {
                            Array.Copy(bytes, 0, scanBytes, scanBytesIterator, 20);
                            scanBytesIterator = scanBytesIterator + 20;
                        }

                        if (scanBytesIterator == (mDataLength - 4))
                        {
                            /*
                            ByteBuffer buffer = ByteBuffer.wrap(scanBytes);
                            buffer.order(ByteOrder.LITTLE_ENDIAN);
                            double[] doubleValues = new double[scanBytes.length / 8];
                            for(int i = 0; i < scanBytes.length / 16; i++) {
                                doubleValues[i] = buffer.getLong(i * 8) / Math.pow(2, 33);
                                doubleValues[i + doubleValues.length/2] =
                                        buffer.getLong((i + doubleValues.length/2) * 8) /
                                                Math.pow(2, 30);
                            }
                            */
                            ByteBuffer buffer = new ByteBuffer(scanBytes);
                            double[] doubleValues = new double[scanBytes.Length / 8];
                            for (int i = 0; i < scanBytes.Length / 16; i++)
                            {
                              
                                doubleValues[i] = buffer.GetLong(i * 8) / Math.Pow(2, 33);
                                doubleValues[i + doubleValues.Length / 2] =
                                        buffer.GetLong((i + doubleValues.Length / 2) * 8) /
                                                Math.Pow(2, 30);
                            }
                            mHeaderMemPacketDone = false;
                            broadcastNotificationMemoryData(doubleValues);
                        }
                        break;

                    case MEMORY_CLEAR_REQUEST:
                        break;
                }
                long Fnum = ((bytes[0] & 0xFFL) << 0) |
                        ((bytes[1] & 0xFFL) << 8) |
                        ((bytes[2] & 0xFFL) << 16) |
                        ((bytes[3] & 0xFFL) << 24);
                Debug.WriteLine("===========" + Fnum + "=========" + scanBytesIterator + "==========");

            }

            Debug.WriteLine("Notification Received - " + (bytes.Length));
        }

        GattPresentationFormat BatTxFormat;
        bool SubscribeBatTx = false;
        public async Task<bool> SetNotificationOnBatTx()
        {
            if (isConnected())
            {
                var BatTxCharacteristic = await GetCharacteristic(SYS_STAT_TX_CHAR_Guid);
                if (SubscribeBatTx)
                {
                    // Need to clear the CCCD from the remote device so we stop receiving notifications
                    var result = await BatTxCharacteristic.WriteClientCharacteristicConfigurationDescriptorAsync(GattClientCharacteristicConfigurationDescriptorValue.None);
                    if (result != GattCommunicationStatus.Success)
                    {
                        return false;
                    }
                    else
                    {
                        BatTxCharacteristic.ValueChanged -= BatTx_ValueChanged;

                    }
                }
                // initialize status
                var selectedCharacteristic = BatTxCharacteristic;
                GattCommunicationStatus status = GattCommunicationStatus.Unreachable;
                var cccdValue = GattClientCharacteristicConfigurationDescriptorValue.None;
                if (selectedCharacteristic.CharacteristicProperties.HasFlag(GattCharacteristicProperties.Indicate))
                {
                    cccdValue = GattClientCharacteristicConfigurationDescriptorValue.Indicate;
                }
                else if (selectedCharacteristic.CharacteristicProperties.HasFlag(GattCharacteristicProperties.Notify))
                {
                    cccdValue = GattClientCharacteristicConfigurationDescriptorValue.Notify;
                }

                try
                {
                    // BT_Code: Must write the CCCD in order for server to send indications.
                    // We receive them in the ValueChanged event handler.
                    status = await selectedCharacteristic.WriteClientCharacteristicConfigurationDescriptorAsync(cccdValue);

                    if (status == GattCommunicationStatus.Success)
                    {
                        SubscribeBatTx = true;
                        BatTxCharacteristic.ValueChanged += BatTx_ValueChanged;
                        BatTxFormat = null;
                        if (BatTxCharacteristic.PresentationFormats.Count > 0)
                        {

                            if (BatTxCharacteristic.PresentationFormats.Count.Equals(1))
                            {
                                // Get the presentation format since there's only one way of presenting it
                                BatTxFormat = BatTxCharacteristic.PresentationFormats[0];
                            }
                            else
                            {
                                // It's difficult to figure out how to split up a characteristic and encode its different parts properly.
                                // In this case, we'll just encode the whole thing to a string to make it easy to print out.
                            }
                        }
                        MethodsFactory.LogMessage("Successfully subscribed BatTx for value changes", "Status");
                        return true;

                        //rootPage.NotifyUser("Successfully subscribed for value changes", NotifyType.StatusMessage);
                    }
                    else
                    {
                        MethodsFactory.LogMessage($"Error registering BatTx for value changes: {status}", "ErrorMessage");
                        //rootPage.NotifyUser($"Error registering for value changes: {status}", NotifyType.ErrorMessage);
                    }
                }
                catch (UnauthorizedAccessException ex)
                {
                    // This usually happens when a device reports that it support indicate, but it actually doesn't.
                    //rootPage.NotifyUser(ex.Message, NotifyType.ErrorMessage);
                    MethodsFactory.LogMessage(ex.Message, "ErrorMessage");
                }

                //mRxBleConnection
                //       .flatMap(rxBleConnection->rxBleConnection.setupNotification(SYS_STAT_TX_CHAR_UUID))
                //       .doOnNext(notificationObservable->MainActivityInstance.runOnUiThread(this::notificationHasBeenSetUp))
                //       .doOnError(setupThrowable->MainActivityInstance.runOnUiThread(this::dataNotificationSetupError))
                //       .flatMap(notificationObservable->notificationObservable)
                //       .retryWhen(errors->errors.flatMap(error-> {
                //    if (error instanceof BleDisconnectedException) {
                //        Log.d("Retry", "Retrying");
                //        return Observable.just(null);
                //    }
                //    return Observable.error(error);
                //}))
                //    .observeOn(AndroidSchedulers.mainThread())
                //    .subscribe(this::onSystemNotificationReceived,
                //            this::onNotificationSetupFailure);
            }
            return false;

        }

        private async void BatTx_ValueChanged(GattCharacteristic sender, GattValueChangedEventArgs args)
        {
            byte[] data;
            CryptographicBuffer.CopyToByteArray(args.CharacteristicValue, out data);
            onSystemNotificationReceived(data);
        }

        private void onSystemNotificationReceived(byte[] bytes)
        {
            if (!mHeaderSysPacketDone)
            {
                //ToDo: Check the status
                mHeaderSysPacketDone = true;
            }
            else
            {
                long type = ((bytes[0] & 0xFFL) << 0) |
                            ((bytes[1] & 0xFFL) << 8) |
                            ((bytes[2] & 0xFFL) << 16) |
                            ((bytes[3] & 0xFFL) << 24);

                switch ((int)type)
                {
                    case SYSTEM_BATTERY_REQUEST:
                        {
                            long capacity = ((bytes[4] & 0xFFL) << 0) |
                                            ((bytes[5] & 0xFFL) << 8) |
                                            ((bytes[6] & 0xFFL) << 16) |
                                            ((bytes[7] & 0xFFL) << 24);                //long to support 32-bin unsigned

                            int charging = ((bytes[8] & 0xFF) << 0);

                            broadcastHomeNotification(capacity, "BatCapacity");
                            broadcastHomeNotification((long)charging, "ChargingStatus");
                            break;
                        }
                    case SYSTEM_P3_ID_REQUEST:
                        {
                            long P3ID = ((bytes[4] & 0xFFL) << 0) |
                                        ((bytes[5] & 0xFFL) << 8) |
                                        ((bytes[6] & 0xFFL) << 16) |
                                        ((bytes[7] & 0xFFL) << 24) |
                                        ((bytes[8] & 0xFFL) << 32) |
                                        ((bytes[9] & 0xFFL) << 40) |
                                        ((bytes[10] & 0xFFL) << 48) |
                                        ((bytes[11] & 0xFFL) << 56);
                            broadcastHomeNotification(P3ID, "P3_ID");

                            break;
                        }
                    case SYSTEM_TEMPERATURE_REQUEST:
                        {
                            long temperature = ((bytes[4] & 0xFFL) << 0) |
                                    ((bytes[5] & 0xFFL) << 8) |
                                    ((bytes[6] & 0xFFL) << 16) |
                                    ((bytes[7] & 0xFFL) << 24);
                            broadcastHomeNotification(temperature, "Temperature");

                            break;
                        }
                    case SYSTEM_BATTERY_INFO:
                        {
                            int v = ((bytes[4] & 0xFF) << 0) |
                                    ((bytes[5] & 0xFF) << 8);
                            int i = ((bytes[6] & 0xFF) << 0) |
                                    ((bytes[7] & 0xFF) << 8);
                            int c = ((bytes[8] & 0xFF) << 0) |
                                    ((bytes[9] & 0xFF) << 8);
                            int fcc = ((bytes[10] & 0xFF) << 0) |
                                    ((bytes[11] & 0xFF) << 8);
                            int t = ((bytes[12] & 0xFF) << 0) |
                                    ((bytes[13] & 0xFF) << 8);
                            int v1 = ((bytes[14] & 0xFF) << 0) |
                                    ((bytes[15] & 0xFF) << 8);
                            int v2 = ((bytes[16] & 0xFF) << 0) |
                                    ((bytes[17] & 0xFF) << 8);
                            int cc = ((bytes[18] & 0xFF) << 0) |
                                    ((bytes[19] & 0xFF) << 8);

                            String batteryInfo = "Battery Voltage =  " + v + " mv" +
                                                 "\nBattery Current =  " + i + " mA" +
                                                 "\nBattery ChargingCurrent =  " + cc + " mA" +
                                                 "\nBattery Capacity =  " + c + " mAhr" +
                                                 "\nBattery Full Capacity =  " + fcc + " mAhr" +
                                                 "\nBattery Temperature =  " + t + " cel" +
                                                 "\nBattery CellVoltage1 =  " + v1 + " mv" +
                                                 "\nBattery CellVoltage2 =  " + v2 + " mv";


                            broadcastHomeNotification(batteryInfo, "Battery_info");

                            break;
                        }
                }

                mHeaderSysPacketDone = false;
            }

            Debug.WriteLine("Notification Received - " + (bytes.Length));
        }

        public event EventHandler<BroadcastEventArgs> BroadcastReceived;
        public class BroadcastEventArgs : EventArgs
        {
            public Dictionary<string, object> iGotData { get; set; }
            public DateTime Created { get; set; }
        }
        private void broadcastHomeNotification(long data, String iName)
        {
            Debug.WriteLine(TAG + "INSIDE BROADCAST NOTIFICATION DATA");
            Dictionary<string, object> iGotData = new Dictionary<string, object>();
            //iGotData.setAction(GlobalVariables.HOME_INTENT_ACTION);
            iGotData.Add("iName", iName);
            iGotData.Add("isNotificationSuccess", true);  //false heba change
            iGotData.Add("data", data);
            iGotData.Add("reason", "gotData");
            iGotData.Add("from", "broadcastHomeNotification");
            BroadcastReceived?.Invoke(this, new BroadcastEventArgs() { Created = DateTime.Now, iGotData = iGotData });
            //sendBroadCast(this.HomeActivityContext, iGotData);
        }
        private void broadcastHomeNotification(String input, String iName)
        {
            Debug.WriteLine(TAG+ "INSIDE BROADCAST NOTIFICATION DATA");
            Dictionary<string, object> iGotData = new Dictionary<string, object>();
            //Intent iGotData = new Intent();
            //iGotData.setAction(GlobalVariables.HOME_INTENT_ACTION);
            iGotData.Add("iName", iName);
            iGotData.Add("isNotificationSuccess", true);  //false heba change
            iGotData.Add("data", input);
            iGotData.Add("reason", "gotData");
            iGotData.Add("from", "broadcastHomeNotification");
            BroadcastReceived?.Invoke(this, new BroadcastEventArgs() { Created = DateTime.Now, iGotData = iGotData });
            //sendBroadCast(this.HomeActivityContext, iGotData);
        }
        
        private void broadcastNotificationData(double[] mDoubles, string streamByte)
        {
            Debug.WriteLine(TAG + "INSIDE BROADCAST NOTIFICATION DATA");
           
            Dictionary<string, object> iGotData = new Dictionary<string, object>();
            //iGotData.setAction(GlobalVariables.INTENT_ACTION);
            iGotData.Add("iName", "sensorNotification_data");
            iGotData.Add("isNotificationSuccess", true);  //false heba change
            iGotData.Add("data", mDoubles);
            iGotData.Add("stream", streamByte);
            iGotData.Add("reason", "gotData");
            iGotData.Add("from", "broadcastNotificationData");
            BroadcastReceived?.Invoke(this, new BroadcastEventArgs() { Created = DateTime.Now, iGotData = iGotData });
            //sendBroadCast(getMainActivityContext(), iGotData);
        }

        private void broadcastNotificationMemoryData(double[] mDoubles)
        {
            Debug.WriteLine(TAG+ "INSIDE BROADCAST NOTIFICATION Memory DATA");
            //Intent iGotData = new Intent();
            Dictionary<string, object> iGotData = new Dictionary<string, object>();
            //iGotData.setAction(GlobalVariables.HOME_INTENT_ACTION);
            iGotData.Add("iName", "MemoryScanData");
            iGotData.Add("isNotificationSuccess", true);  //false heba change
            iGotData.Add("data", mDoubles);
            iGotData.Add("reason", "gotData");
            iGotData.Add("from", "broadcastNotificationData");
            BroadcastReceived?.Invoke(this, new BroadcastEventArgs() { Created = DateTime.Now, iGotData = iGotData });
            //sendBroadCast(this.HomeActivityContext, iGotData);
        }
        private void broadcastNotificationFailure(String msg, String reason, int errorCode)
        {
            Debug.WriteLine(TAG + "inside broadcastNotificationFailure");
            Dictionary<string, object> iGotData = new Dictionary<string, object>();
            //iGotData.setAction(GlobalVariables.INTENT_ACTION);
            iGotData.Add("iName", "sensorNotification_failure");
            iGotData.Add("isNotificationSuccess", false);
            iGotData.Add("err", msg);
            iGotData.Add("reason", reason);
            iGotData.Add("data", errorCode);
            BroadcastReceived?.Invoke(this, new BroadcastEventArgs() { Created = DateTime.Now, iGotData = iGotData });
            //sendBroadCast(getMainActivityContext(), iGotData);
        }

        private void broadcastNotificationconnected(String msg)
        {
            Debug.WriteLine(TAG + "inside broadcastNotificationconnected " + msg);
            Dictionary<string, object> iGotData = new Dictionary<string, object>();
            //iGotData.Addn(GlobalVariables.INTENT_ACTION);
            iGotData.Add("iName", "sensorNotification_connection");
            iGotData.Add("isNotificationSuccess", true);
            iGotData.Add("err", msg);
            iGotData.Add("reason", "connected");
            BroadcastReceived?.Invoke(this, new BroadcastEventArgs() { Created = DateTime.Now, iGotData = iGotData });
            //sendBroadCast(getMainActivityContext(), iGotData);
        }

        public void broadcastdisconnectionNotification()
        {
            Debug.WriteLine(TAG + "inside broadcastdisconnectionNotification");
            //System.out.println("inside broadcastdisconnectionNotification");
            //Intent iGotData = new Intent();
            Dictionary<string, object> iGotData = new Dictionary<string, object>();
            //iGotData.setAction(GlobalVariables.INTENT_ACTION);
            iGotData.Add("iName", "Disconnection_Notification");
            iGotData.Add("reason", "disconnected");
            BroadcastReceived?.Invoke(this, new BroadcastEventArgs() { Created = DateTime.Now, iGotData = iGotData });
            //sendBroadCast(getMainActivityContext(), iGotData);

            iGotData = new Dictionary<string, object>();
            //iGotData.setAction(GlobalVariables.HOME_INTENT_ACTION);
            iGotData.Add("iName", "Disconnection_Notification");
            iGotData.Add("reason", "disconnected");
            BroadcastReceived?.Invoke(this, new BroadcastEventArgs() { Created = DateTime.Now, iGotData = iGotData });
            //sendBroadCast(this.HomeActivityContext, iGotData);
        }
       
       
    }


}
