package com.gravicode.neospectralib.BluetoothSDK;
using android.Manifest;
using android.app.Activity;
using android.bluetooth.BluetoothAdapter;
using android.bluetooth.BluetoothDevice;
using android.bluetooth.BluetoothGatt;
using android.bluetooth.BluetoothGattCallback;
using android.bluetooth.BluetoothGattCharacteristic;
using android.bluetooth.BluetoothGattService;
using android.bluetooth.BluetoothProfile;
using android.content.Context;
using android.content.Intent;
using androidx.annotation.NonNull;
using androidx.annotation.Nullable;
using androidx.core.app.ActivityCompat;
using android.util.Log;
using com.polidea.rxandroidble2.RxBleClient;
using com.polidea.rxandroidble2.RxBleConnection;
using com.polidea.rxandroidble2.RxBleDevice;
using com.polidea.rxandroidble2.exceptions.BleDisconnectedException;
using com.polidea.rxandroidble2.internal.RxBleLog;
using com.polidea.rxandroidble2.scan.ScanSettings;
using com.polidea.rxandroidble2.utils.ConnectionSharingAdapter;
// import com.gravicode.neospectralib.Activities.SettingsActivity;
using com.gravicode.neospectralib.Global.GlobalVariables;
using java.nio.ByteBuffer;
using java.nio.ByteOrder;
using java.util.ArrayList;
using java.util.Arrays;
using java.util.List;
using java.util.UUID;
using io.reactivex.Observable;
using io.reactivex.android.schedulers.AndroidSchedulers;
using io.reactivex.disposables.Disposable;
using io.reactivex.subjects.PublishSubject;
using static;
com.gravicode.neospectralib.Global.GlobalVariables.MEMORY_CLEAR_REQUEST;
using static;
com.gravicode.neospectralib.Global.GlobalVariables.MEMORY_GET_SCANS_REQUEST;
using static;
com.gravicode.neospectralib.Global.GlobalVariables.MEMORY_STATUS_REQUEST;
// import static com.gravicode.neospectralib.Global.GlobalVariables.binaryOTAFileInBytes;
using static;
com.gravicode.neospectralib.Global.GlobalVariables.SYSTEM_BATTERY_INFO;
using static;
com.gravicode.neospectralib.Global.GlobalVariables.SYSTEM_BATTERY_REQUEST;
using static;
com.gravicode.neospectralib.Global.GlobalVariables.SYSTEM_P3_ID_REQUEST;
using static;
com.gravicode.neospectralib.Global.GlobalVariables.SYSTEM_TEMPERATURE_REQUEST;
using static;
com.gravicode.neospectralib.Global.GlobalVariables.gIsInterpolationEnabled;
using static;
com.gravicode.neospectralib.Global.GlobalVariables.isConnecting;
using static;
com.gravicode.neospectralib.Global.MethodsFactory.logMessage;
using static;
com.gravicode.neospectralib.Global.MethodsFactory.sendBroadCast;
using static;
com.gravicode.neospectralib.Global.MethodsFactory.showAlertMessage;
public class SWS_P3ConnectionServices {
    
    private static List<SWS_P3BLEDevice> bleDevices;
    
    private static String TAG = "P3_Connection";
    
    private Activity MainActivityInstance;
    
    private Context MainActivityContext;
    
    private Context HomeActivityContext;
    
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
    
    //  flag to connection process
    public enum ConnectionStatus {
        
        ready,
        
        findingChannel,
        
        failedToGetChannel,
        
        gotChannel,
        
        connecting,
        
        failedToConnect,
        
        connected,
        
        disconnected,
    }
    
    public ConnectionStatus connectionStatus = ConnectionStatus.ready;
    
    public ConnectionStatus getConnectionStatus() {
        return this.connectionStatus;
    }
    
    public void setConnectionStatus(ConnectionStatus connectionStatus) {
        this.connectionStatus = this.connectionStatus;
    }
    
    //  =====================================================================
    //  RxAndroidBLE related variables
    private RxBleClient mRxBleClient;
    
    private RxBleDevice mRxBleDevice;
    
    private Disposable scanSubscription;
    
    private Observable<RxBleConnection> mRxBleConnection;
    
    [NonNull()]
    private PublishSubject<Boolean> disconnectTriggerSubject = PublishSubject.create();
    
    [NonNull()]
    List<SWS_P3BLEDevice> DevicesList = new ArrayList();
    
    [NonNull()]
    List<String> DevicesMacAddress = new ArrayList();
    
    List<UUID> serviceUUIDsList = new ArrayList();
    
    List<UUID> characteristicUUIDsList = new ArrayList();
    
    List<UUID> descriptorUUIDsList = new ArrayList();
    
    //  ============================================================================================================
    public static int MY_PERMISSIONS_REQUEST_ACCESS_FINE_LOCATION = 1;
    
    private static int LOCATION_PERMISSION_REQUEST_CODE = 1;
    
    //  ============================================================================================================
    // Macros
    public static UUID TX_POWER_UUID = UUID.fromString("00001804-0000-1000-8000-00805f9b34fb");
    
    public static UUID TX_POWER_LEVEL_UUID = UUID.fromString("00002a07-0000-1000-8000-00805f9b34fb");
    
    public static UUID CCCD = UUID.fromString("00002902-0000-1000-8000-00805f9b34fb");
    
    public static UUID FIRMWARE_REVISON_UUID = UUID.fromString("00002a26-0000-1000-8000-00805f9b34fb");
    
    public static UUID DIS_UUID = UUID.fromString("0000180a-0000-1000-8000-00805f9b34fb");
    
    public static UUID P3_SERVICE_UUID = UUID.fromString("6e400001-b5a3-f393-e0a9-e50e24dcca9e");
    
    public static UUID SYS_STAT_SERVICE_UUID = UUID.fromString("B100B100-B100-B100-B100-B100B100B100");
    
    public static UUID MEM_SERVICE_UUID = UUID.fromString("C100C100-C100-C100-C100-C100C100C100");
    
    public static UUID OTA_SERVICE_UUID = UUID.fromString("D100D100-D100-D100-D100-D100D100D100");
    
    public static UUID BATTERY_SERVICE_UUID = UUID.fromString("E100E100-E100-E100-E100-E100E100E100");
    
    public static UUID P3_RX_CHAR_UUID = UUID.fromString("6e400002-b5a3-f393-e0a9-e50e24dcca9e");
    
    public static UUID P3_TX_CHAR_UUID = UUID.fromString("6e400003-b5a3-f393-e0a9-e50e24dcca9e");
    
    public static UUID SYS_STAT_TX_CHAR_UUID = UUID.fromString("B101B101-B101-B101-B101-B101B101B101");
    
    public static UUID SYS_STAT_RX_CHAR_UUID = UUID.fromString("B102B102-B102-B102-B102-B102B102B102");
    
    public static UUID MEM_TX_CHAR_UUID = UUID.fromString("C101C101-C101-C101-C101-C101C101C101");
    
    public static UUID MEM_RX_CHAR_UUID = UUID.fromString("C102C102-C102-C102-C102-C102C102C102");
    
    public static UUID OTA_TX_CHAR_UUID = UUID.fromString("D101D101-D101-D101-D101-D101D101D101");
    
    public static UUID OTA_RX_CHAR_UUID = UUID.fromString("D102D102-D102-D102-D102-D102D102D102");
    
    //  ======================================================= =====================================================
    //  ============================================================================================================
    //  Constructor
    public SWS_P3ConnectionServices(Activity mMainActivity, Context mMainContext) {
        this.MainActivityInstance = mMainActivity;
        this.MainActivityContext = mMainContext;
    }
    
    //  ============================================================================================================
    //  Setters and Getters
    public RxBleDevice getmRxBleDevice() {
        return this.mRxBleDevice;
    }
    
    public void setmRxBleDevice(RxBleDevice mRxBleDevice) {
        this.mRxBleDevice = this.mRxBleDevice;
    }
    
    //  ============================================================================================================
    [NonNull()]
    public List<SWS_P3BLEDevice> ScanBTDevices() {
        this.mRxBleClient = RxBleClient.create(this.MainActivityContext);
        RxBleLog.setLogLevel(RxBleLog.VERBOSE);
        this.scanSubscription = this.mRxBleClient.scanBleDevices((new ScanSettings.Builder() + setScanMode(ScanSettings.SCAN_MODE_LOW_LATENCY).setCallbackType(ScanSettings.CALLBACK_TYPE_ALL_MATCHES).build())).observeOn(AndroidSchedulers.mainThread()).subscribe(scanResult, -, Greater, { handle found results, SWS_P3BLEDevice, tmp=newSWS_P3BLEDevice(scanResult.getBleDevice(Unknown.getName(Unknown,scanResult.getBleDevice(Unknown.getMacAddress(Unknown,scanResult.getRssi(Unknown,scanResult.getBleDevice(UnknownUnknown);
        if (!this.DevicesMacAddress.contains(scanResult.getBleDevice().getMacAddress())) {
            if ((scanResult.getBleDevice().getName() != null)) {
                if ((scanResult.getBleDevice().getName().contains("NeoSpectra") || scanResult.getBleDevice().getName().contains("NS-"))) {
                    Log.i(getClass().getSimpleName(), ("# Added New Element:" + scanResult.getBleDevice().getName()));
                    this.DevicesList.add(tmp);
                    this.DevicesMacAddress.add(scanResult.getBleDevice().getMacAddress());
                    // SettingsActivity.found_device(DevicesList);
                    bleDevices = this.DevicesList;
                }
                
            }
            
        }
        
    }
}
Unknownwhile ((DevicesList.size() < 1)) {
    
}

return DevicesList;
UnknownUnknown.subscribe(characteristic, -, Greater, {, Log.i(getClass().getSimpleName(), "Hey, connection has been established!"));
setConnecting("connection established!", false);
broadcastNotificationconnected("connection established!");
// heba added
Unknown,this;
::onConnectionFailure;
,this;
::onConnectionFinished;
UnknownUnknownNonNull;
byte[] byteArray;
Unknown{if (isConnected()) {
    mRxBleConnection.firstOrError().flatMap(rxBleConnection, -, Greater, rxBleConnection.writeCharacteristic(P3_RX_CHAR_UUID, byteArray)).observeOn(AndroidSchedulers.mainThread()).subscribe(bytes, -, Greater, onWriteSuccess(), this, :, :, onWriteFailure);
}

Unknownpublic interface BLEAction {
    
    void onDisconnect();
    
    void onConnect();
    
    void onRead(BluetoothGatt gatt, BluetoothGattCharacteristic characteristic, int status);
    
    void onWrite(BluetoothGatt gatt, BluetoothGattCharacteristic characteristic, int status);
    
    void onNotification(BluetoothGatt gatt, BluetoothGattCharacteristic characteristic);
}
NonNull;
byte[] byteArray;
Unknown{if (isConnected()) {
    mRxBleConnection.firstOrError().flatMap(rxBleConnection, -, Greater, rxBleConnection.writeCharacteristic(MEM_RX_CHAR_UUID, byteArray)).observeOn(AndroidSchedulers.mainThread()).subscribe(bytes, -, Greater, onWriteSuccess(), this, :, :, onWriteFailure);
}

UnknownNonNull;
byte[] byteArray;
Unknown{if (isConnected()) {
    mRxBleConnection.firstOrError().flatMap(rxBleConnection, -, Greater, rxBleConnection.writeCharacteristic(SYS_STAT_RX_CHAR_UUID, byteArray)).observeOn(AndroidSchedulers.mainThread()).subscribe(bytes, -, Greater, onWriteSuccess(), this, :, :, onWriteFailure);
}

UnknownNonNull;
byte[] byteArray;
Unknown{if (isConnected()) {
    mRxBleConnection.firstOrError().flatMap(rxBleConnection, -, Greater, rxBleConnection.writeCharacteristic(OTA_RX_CHAR_UUID, byteArray)).observeOn(AndroidSchedulers.mainThread()).subscribe(bytes, -, Greater, onWriteSuccess(), this, :, :, onWriteFailure);
}

UnknownUnknownUnknown.observeOn(AndroidSchedulers.mainThread()).subscribe(this, :, :, onNotificationReceived, this, :, :, onNotificationSetupFailure);
UnknownUnknownUnknownUnknown.observeOn(AndroidSchedulers.mainThread()).subscribe(this, :, :, onMemNotificationReceived, this, :, :, onNotificationSetupFailure);
UnknownUnknownUnknownUnknown.observeOn(AndroidSchedulers.mainThread()).subscribe(this, :, :, onSystemNotificationReceived, this, :, :, onNotificationSetupFailure);
UnknownUnknownNonNull;
byte[] bytes;
Unknown{if (!mHeaderPacketDone) {
    //  get the error code and check its value
    if ((bytes[0] == 0)) {
        Log.i(getClass().getSimpleName(), "%--> NO Error in Received Packet.");
        int doublesCount = 0;
        //  No Error, compute the length of the frame
        int length1 = (255 & bytes[1]);
        int length2 = (255 & bytes[2]);
        mDataLength = (length1 
                    + (length2 + 8));
        Log.i(getClass().getSimpleName(), ("%--> Length: " 
                        + (mDataLength + ("  mInterpolationEnabled = " + gIsInterpolationEnabled))));
        if (((mDataLength == 1) 
                    || (mDataLength == 2))) {
            mNumberOfPackets = 1;
        }
        else if (gIsInterpolationEnabled) {
            mNumberOfPackets = ((int)(Math.ceil(((mDataLength + 2) * (8 / 20)))));
        }
        else {
            mNumberOfPackets = ((int)(Math.ceil(((mDataLength * 2) * (8 / 20)))));
        }
        
        Log.i(getClass().getSimpleName(), ("%--> Packets: " + mNumberOfPackets));
        //  create a new response packet
        mPacketResponse = new SWS_P3PacketResponse(mNumberOfPackets, mDataLength, gIsInterpolationEnabled);
        //  initialize the packet response
        mPacketResponse.prepareArraySize();
        //  set iteration parameters
        mHeaderPacketDone = true;
    }
    else {
        //  Error
        Log.i(getClass().getSimpleName(), "#--> Error in Received Packet.");
        broadcastNotificationFailure("#--> Error in Received Packet.", "packet_failure", ((int)(bytes[0])));
    }
    
}
else {
    //  send the received bytes to the packet response instance
    mPacketResponse.addNewResponse(bytes);
    //  increment the received packets counter
    mReceivedPacketsCounter++;
    Log.i(getClass().getSimpleName(), ("#--> Received packets: " + mReceivedPacketsCounter));
    System.out.println(("mDataLength = " 
                    + (mDataLength + (", mNumberOfPackets = " + mNumberOfPackets))));
    if ((mNumberOfPackets == mReceivedPacketsCounter)) {
        mReceivedPacketsCounter = 0;
        Log.i(getClass().getSimpleName(), "#--> Received packets: Done !!");
        Log.i(getClass().getSimpleName(), "-------------------------------------------------------------------------------------");
        //  initiate the interpretation process
        mPacketResponse.interpretByteStream();
        double[] mRecDoubles = mPacketResponse.getmInterpretedPacketResponse();
        broadcastNotificationData(mRecDoubles, mPacketResponse.convertByteArrayToString());
        logMessage(TAG, "A PACKET IS BROADCASTED");
        //  fix iterator parameters for next packet
        mHeaderPacketDone = false;
    }
    
}

Log.i(getClass().getSimpleName(), ("Notification Received - " + String.valueOf(bytes.length)));
UnknownNonNull;
byte[] bytes;
Unknown{if (!mHeaderMemPacketDone) {
    status = bytes[0];
    mDataLength = (((bytes[1] & 255) 
                + 0) 
                | ((bytes[2] & 255) 
                + 8));
    scanBytes = new byte[mDataLength];
    scanBytesIterator = 0;
    mHeaderMemPacketDone = true;
}
else {
    if (((mDataLength == 1) 
                && (status == 0))) {
        broadcastHomeNotification(0, "OperationDone");
        mHeaderMemPacketDone = false;
        return;
    }
    else if (((mDataLength == 1) 
                && (status != 0))) {
        broadcastHomeNotification(((long)(bytes[0])), "Error");
        mHeaderMemPacketDone = false;
        return;
    }
    
    if ((scanBytesIterator == 0)) {
        long type;
        0;
        8;
        16;
        24;
        // long to support 32-bin unsigned
        packetsType = ((int)(type));
    }
    
    switch (packetsType) {
        case MEMORY_STATUS_REQUEST:
            long memory;
            0;
            8;
            16;
            24;
            
            // long to support 32-bin unsigned
            long FWVersion;
            0;
            8;
            16;
            24;
            
            // long to support 32-bin unsigned
            broadcastHomeNotification(memory, "Memory");
            broadcastHomeNotification(FWVersion, "FWVersion");
            mHeaderMemPacketDone = false;
            break;
        case MEMORY_GET_SCANS_REQUEST:
            if ((scanBytesIterator == 0)) {
                System.arraycopy(bytes, 4, scanBytes, scanBytesIterator, 16);
                scanBytesIterator = (scanBytesIterator + 16);
            }
            else if ((scanBytesIterator + (20 
                        > (mDataLength - 4)))) {
                System.arraycopy(bytes, 0, scanBytes, scanBytesIterator, (mDataLength 
                                - (scanBytesIterator - 4)));
                scanBytesIterator = (mDataLength - 4);
            }
            else {
                System.arraycopy(bytes, 0, scanBytes, scanBytesIterator, 20);
                scanBytesIterator = (scanBytesIterator + 20);
            }
            
            if ((scanBytesIterator 
                        == (mDataLength - 4))) {
                ByteBuffer buffer = ByteBuffer.wrap(scanBytes);
                buffer.order(ByteOrder.LITTLE_ENDIAN);
                double[] doubleValues = new double[(scanBytes.length / 8)];
                for (int i = 0; (i 
                            < (scanBytes.length / 16)); i++) {
                    doubleValues[i] = (buffer.getLong((i * 8)) / Math.pow(2, 33));
                    doubleValues[(i 
                                + (doubleValues.length / 2))] = (buffer.getLong(((i 
                                    + (doubleValues.length / 2)) 
                                    * 8)) / Math.pow(2, 30));
                }
                
                mHeaderMemPacketDone = false;
                broadcastNotificationMemoryData(doubleValues);
            }
            
            break;
        case MEMORY_CLEAR_REQUEST:
            break;
    }
    long Fnum;
    0;
    8;
    16;
    24;
    System.out.println(("===========" 
                    + (Fnum + ("=========" 
                    + (scanBytesIterator + "==========")))));
}

Log.i(getClass().getSimpleName(), ("Notification Received - " + String.valueOf(bytes.length)));
UnknownNonNull;
byte[] bytes;
Unknown{if (!mHeaderSysPacketDone) {
    // ToDo: Check the status
    mHeaderSysPacketDone = true;
}
else {
    long type;
    0;
    8;
    16;
    24;
    switch (((int)(type))) {
        case SYSTEM_BATTERY_REQUEST:
            long capacity;
            0;
            8;
            16;
            24;
            // long to support 32-bin unsigned
            int charging = ((bytes[8] & 255) 
                        + 0);
            broadcastHomeNotification(capacity, "BatCapacity");
            broadcastHomeNotification(((long)(charging)), "ChargingStatus");
            break;
            break;
        case SYSTEM_P3_ID_REQUEST:
            long P3ID;
            0;
            8;
            16;
            24;
            32;
            40;
            48;
            56;
            broadcastHomeNotification(P3ID, "P3_ID");
            break;
            break;
        case SYSTEM_TEMPERATURE_REQUEST:
            long temperature;
            0;
            8;
            16;
            24;
            broadcastHomeNotification(temperature, "Temperature");
            break;
            break;
        case SYSTEM_BATTERY_INFO:
            int v = (((bytes[4] & 255) 
                        + 0) 
                        | ((bytes[5] & 255) 
                        + 8));
            int i = (((bytes[6] & 255) 
                        + 0) 
                        | ((bytes[7] & 255) 
                        + 8));
            int c = (((bytes[8] & 255) 
                        + 0) 
                        | ((bytes[9] & 255) 
                        + 8));
            int fcc = (((bytes[10] & 255) 
                        + 0) 
                        | ((bytes[11] & 255) 
                        + 8));
            int t = (((bytes[12] & 255) 
                        + 0) 
                        | ((bytes[13] & 255) 
                        + 8));
            int v1 = (((bytes[14] & 255) 
                        + 0) 
                        | ((bytes[15] & 255) 
                        + 8));
            int v2 = (((bytes[16] & 255) 
                        + 0) 
                        | ((bytes[17] & 255) 
                        + 8));
            int cc = (((bytes[18] & 255) 
                        + 0) 
                        | ((bytes[19] & 255) 
                        + 8));
            String batteryInfo = ("Battery Voltage =  " 
                        + (v + (" mv" + ("\nBattery Current =  " 
                        + (i + (" mA" + ("\nBattery ChargingCurrent =  " 
                        + (cc + (" mA" + ("\nBattery Capacity =  " 
                        + (c + (" mAhr" + ("\nBattery Full Capacity =  " 
                        + (fcc + (" mAhr" + ("\nBattery Temperature =  " 
                        + (t + (" cel" + ("\nBattery CellVoltage1 =  " 
                        + (v1 + (" mv" + ("\nBattery CellVoltage2 =  " 
                        + (v2 + " mv")))))))))))))))))))))));
            broadcastHomeNotification(batteryInfo, "Battery_info");
            break;
            break;
    }
    mHeaderSysPacketDone = false;
}

Log.i(getClass().getSimpleName(), ("Notification Received - " + String.valueOf(bytes.length)));
UnknownNullable String;
iName;
Unknown{logMessage(TAG, "INSIDE BROADCAST NOTIFICATION DATA");
iGotData.setAction(GlobalVariables.HOME_INTENT_ACTION);
iGotData.putExtra("iName", iName);
iGotData.putExtra("isNotificationSuccess", true);
// false heba change
iGotData.putExtra("data", data);
iGotData.putExtra("reason", "gotData");
iGotData.putExtra("from", "broadcastHomeNotification");
sendBroadCast(this.HomeActivityContext, iGotData);
UnknownNullable String;
iName;
Unknown{logMessage(TAG, "INSIDE BROADCAST NOTIFICATION DATA");
iGotData.setAction(GlobalVariables.HOME_INTENT_ACTION);
iGotData.putExtra("iName", iName);
iGotData.putExtra("isNotificationSuccess", true);
// false heba change
iGotData.putExtra("data", input);
iGotData.putExtra("reason", "gotData");
iGotData.putExtra("from", "broadcastHomeNotification");
sendBroadCast(this.HomeActivityContext, iGotData);
UnknownNullable String;
streamByte;
Unknown{logMessage(TAG, "INSIDE BROADCAST NOTIFICATION DATA");
iGotData.setAction(GlobalVariables.INTENT_ACTION);
iGotData.putExtra("iName", "sensorNotification_data");
iGotData.putExtra("isNotificationSuccess", true);
// false heba change
iGotData.putExtra("data", mDoubles);
iGotData.putExtra("stream", streamByte);
iGotData.putExtra("reason", "gotData");
iGotData.putExtra("from", "broadcastNotificationData");
sendBroadCast(getMainActivityContext(), iGotData);
UnknownNullable BluetoothGattCharacteristic;
characteristic;
,int property;
Unknown{return ((characteristic != null) 
            && ((characteristic.getProperties() & property) 
            > 0));
Unknown//  =============================================================================================
//  Callback
//  =============================================================================================
Unknown
    
    public bool isConnecting(String from) {
        logMessage("bluetooth", ("get is connecting from: " 
                        + (from + (", Value: " + isConnecting))));
        return isConnecting;
    }
    
    public void setConnecting(String from, bool connecting) {
        isConnecting = connecting;
    }
    
    public void ConnectToP3() {
        setConnecting("ConnectToP3()", true);
        mRxBleConnection = prepareConnectionObservable();
        mRxBleConnection.flatMapSingle(RxBleConnection: RxBleConnection:, :, discoverServices).observeOn(AndroidSchedulers.mainThread()).doOnSubscribe(disposable, -, Greater, {, Log.i(getClass().getSimpleName(), "We\'re Good Man!"));
    }
    
    public void DisconnectFromP3() {
        setConnecting("DisconnectFromP3()", false);
        disconnectTriggerSubject.onNext(true);
    }
    
    private void onConnectionFailure(Throwable throwable) {
        setConnecting("onConnectionFailure()", false);
        Log.i(getClass().getSimpleName(), ("Connection error: " + throwable));
    }
    
    private void onConnectionFinished() {
        setConnecting("onConnectionFinished()", false);
    }
    
    public void ReadFromP3() {
        if (isConnected()) {
            mRxBleConnection.firstOrError().flatMap(rxBleConnection, -, Greater, rxBleConnection.readCharacteristic(P3_TX_CHAR_UUID)).observeOn(AndroidSchedulers.mainThread()).subscribe(this, :, :, onReadSuccess, this, :, :, onReadFailure);
        }
        else {
            showAlertMessage(getMainActivityContext(), "Device not connected", "Please! Ensure that you have a connected device firstly");
        }
        
    }
    
    private void onReadFailure(Throwable throwable) {
        Log.i(getClass().getSimpleName(), ("Read error: " + throwable));
        broadcastNotificationFailure((throwable.getMessage() + " onReadFailure"), "read_failure", 0);
    }
    
    private void onReadSuccess(byte[] bytes) {
        Log.i(getClass().getSimpleName(), "Read Success!");
    }
    
    public void WriteToP3() {
    }
    
    private ArrayList<BLEAction> listeners = new ArrayList<BLEAction>();
    
    public void addListener(BLEAction toAdd) {
        listeners.add(toAdd);
    }
    
    public void removeListener(BLEAction toDel) {
        listeners.remove(toDel);
    }
    
    public void raiseonNotification(BluetoothGatt gatt, BluetoothGattCharacteristic characteristic) {
        //  Notify everybody that may be interested.
        foreach (BLEAction listener in listeners) {
            listener.onNotification(gatt, characteristic);
        }
        
    }
    
    public void raiseonRead(BluetoothGatt gatt, BluetoothGattCharacteristic characteristic, int status) {
        //  Notify everybody that may be interested.
        foreach (BLEAction listener in listeners) {
            listener.onRead(gatt, characteristic, status);
        }
        
    }
    
    public void raiseonWrite(BluetoothGatt gatt, BluetoothGattCharacteristic characteristic, int status) {
        //  Notify everybody that may be interested.
        foreach (BLEAction listener in listeners) {
            listener.onWrite(gatt, characteristic, status);
        }
        
    }
    
    public void raiseonDisconnect() {
        //  Notify everybody that may be interested.
        foreach (BLEAction listener in listeners) {
            listener.onDisconnect();
        }
        
    }
    
    public void raiseonConnect() {
        //  Notify everybody that may be interested.
        foreach (BLEAction listener in listeners) {
            listener.onConnect();
        }
        
    }
    
    private BluetoothGattCallback myGattCallback = new BluetoothGattCallback();
    
    public void writeData(byte[] data) {
        BluetoothDevice activeDevice = null;
        BluetoothGatt myGatBand = null;
        // Log.d(TAG, "(*) Initialising Bluetooth connection for device: " + filter);
        if (BluetoothAdapter.getDefaultAdapter().isEnabled()) {
            foreach (BluetoothDevice pairedDevice in BluetoothAdapter.getDefaultAdapter().getBondedDevices()) {
                if (pairedDevice.getName().contains(mRxBleDevice.getName())) {
                    Log.d(TAG, ("\tDevice Name: " + pairedDevice.getName()));
                    Log.d(TAG, ("\tDevice MAC: " + pairedDevice.getAddress()));
                    activeDevice = pairedDevice;
                    break;
                }
                
            }
            
        }
        
        if ((activeDevice != null)) {
            //  GATT is Just another specification:
            //  https://www.bluetooth.com/specifications/gatt/services
            Log.d(TAG, "(*) Establishing connection to gatt");
            myGatBand = activeDevice.connectGatt(MainActivityContext, true, myGattCallback);
        }
        else {
            Log.d(TAG, "(*) Cant Establish connection to gatt, device is null");
        }
        
        if ((!isConnectedToGatt 
                    || (myGatBand == null))) {
            Log.d(TAG, "Cant read from BLE, not initialized.");
            return;
        }
        
        Log.d(TAG, ("* Getting gatt service, UUID:" + OTA_SERVICE_UUID));
        BluetoothGattService myGatService = myGatBand.getService(OTA_SERVICE_UUID);
        if ((myGatService != null)) {
            Log.d(TAG, ("* Getting gatt Characteristic. UUID: " + OTA_RX_CHAR_UUID));
            BluetoothGattCharacteristic myGatChar = myGatService.getCharacteristic(OTA_RX_CHAR_UUID);
            if ((myGatChar != null)) {
                Log.d(TAG, "* Writing trigger");
                myGatChar.setValue(data);
                bool status = myGatBand.writeCharacteristic(myGatChar);
                Log.d(TAG, ("* Writting trigger status :" + status));
            }
            
        }
        
    }
    
    public void WriteToMemoryService() {
    }
    
    public void WriteToSystemService() {
    }
    
    public void WriteOTAService() {
    }
    
    private void onWriteFailure(Throwable throwable) {
        Log.i(getClass().getSimpleName(), ("Write error: " + throwable));
        broadcastWriteFailure(throwable.getMessage());
    }
    
    private void onWriteSuccess() {
        Log.i(getClass().getSimpleName(), "Write success");
        broadcastWriteSuccess();
    }
    
    private void broadcastWriteFailure(String msg) {
        Intent iWriteData = new Intent();
        iWriteData.setAction(GlobalVariables.INTENT_ACTION);
        iWriteData.putExtra("iName", "sensorWriting");
        iWriteData.putExtra("isWriteSuccess", false);
        iWriteData.putExtra("err", msg);
    }
    
    private void broadcastWriteSuccess() {
        Intent iWriteData = new Intent();
        iWriteData.setAction(GlobalVariables.INTENT_ACTION);
        iWriteData.putExtra("iName", "sensorWriting");
        iWriteData.putExtra("isWriteSuccess", true);
    }
    
    private Observable<RxBleConnection> prepareConnectionObservable() {
        return mRxBleDevice.establishConnection(false).takeUntil(disconnectTriggerSubject).compose(new ConnectionSharingAdapter());
    }
    
    public void SetNotificationOnTXInP3() {
        if (isConnected()) {
            mRxBleConnection.flatMap(rxBleConnection, -, Greater, rxBleConnection.setupNotification(P3_TX_CHAR_UUID)).doOnNext(notificationObservable, -, Greater, MainActivityInstance.runOnUiThread(this, :, :, notificationHasBeenSetUp)).doOnError(setupThrowable, -, Greater, MainActivityInstance.runOnUiThread(this, :, :, dataNotificationSetupError)).flatMap(notificationObservable, -, Greater, notificationObservable).retryWhen(errors, -, Greater, errors.flatMap(error, -, Greater, {, if, (error is BleDisconnectedException), {, Log.d("Retry", "Retrying")));
            return Observable.just(null);
        }
        
        return Observable.error(error);
    }
    
    public void SetNotificationOnMemTx() {
        if (isConnected()) {
            mRxBleConnection.flatMap(rxBleConnection, -, Greater, rxBleConnection.setupNotification(MEM_TX_CHAR_UUID)).doOnNext(notificationObservable, -, Greater, MainActivityInstance.runOnUiThread(this, :, :, notificationHasBeenSetUp)).doOnError(setupThrowable, -, Greater, MainActivityInstance.runOnUiThread(this, :, :, dataNotificationSetupError)).flatMap(notificationObservable, -, Greater, notificationObservable).retryWhen(errors, -, Greater, errors.flatMap(error, -, Greater, {, if, (error is BleDisconnectedException), {, Log.d("Retry", "Retrying")));
            return Observable.just(null);
        }
        
        return Observable.error(error);
    }
    
    public void SetNotificationOnBatTx() {
        if (isConnected()) {
            mRxBleConnection.flatMap(rxBleConnection, -, Greater, rxBleConnection.setupNotification(SYS_STAT_TX_CHAR_UUID)).doOnNext(notificationObservable, -, Greater, MainActivityInstance.runOnUiThread(this, :, :, notificationHasBeenSetUp)).doOnError(setupThrowable, -, Greater, MainActivityInstance.runOnUiThread(this, :, :, dataNotificationSetupError)).flatMap(notificationObservable, -, Greater, notificationObservable).retryWhen(errors, -, Greater, errors.flatMap(error, -, Greater, {, if, (error is BleDisconnectedException), {, Log.d("Retry", "Retrying")));
            return Observable.just(null);
        }
        
        return Observable.error(error);
    }
    
    public void setHomeActivityContext(Context context) {
        HomeActivityContext = context;
    }
    
    private void onNotificationReceived() {
    }
    
    private void onMemNotificationReceived() {
    }
    
    private void onSystemNotificationReceived() {
    }
    
    private void onNotificationSetupFailure(Throwable throwable) {
        Log.i(getClass().getSimpleName(), "Notifications Error");
    }
    
    private void notificationHasBeenSetUp() {
        Log.i(getClass().getSimpleName(), "Notifications has been set up");
        still_fail = false;
    }
    
    private void dataNotificationSetupError() {
        Log.i(getClass().getSimpleName(), "dataNotificationSetupError");
    }
    
    private void broadcastHomeNotification(long data) {
    }
    
    Intent iGotData = new Intent();
    
    private void broadcastHomeNotification(String input) {
    }
    
    Intent iGotData = new Intent();
    
    private void broadcastNotificationData(double[] mDoubles) {
    }
    
    Intent iGotData = new Intent();
    
    private void broadcastNotificationMemoryData(double[] mDoubles) {
        logMessage(TAG, "INSIDE BROADCAST NOTIFICATION Memory DATA");
        Intent iGotData = new Intent();
        iGotData.setAction(GlobalVariables.HOME_INTENT_ACTION);
        iGotData.putExtra("iName", "MemoryScanData");
        iGotData.putExtra("isNotificationSuccess", true);
        // false heba change
        iGotData.putExtra("data", mDoubles);
        iGotData.putExtra("reason", "gotData");
        iGotData.putExtra("from", "broadcastNotificationData");
        sendBroadCast(this.HomeActivityContext, iGotData);
    }
    
    private void broadcastNotificationFailure(String msg, String reason, int errorCode) {
        System.out.println("inside broadcastNotificationFailure");
        Intent iGotData = new Intent();
        iGotData.setAction(GlobalVariables.INTENT_ACTION);
        iGotData.putExtra("iName", "sensorNotification_failure");
        iGotData.putExtra("isNotificationSuccess", false);
        iGotData.putExtra("err", msg);
        iGotData.putExtra("reason", reason);
        iGotData.putExtra("data", errorCode);
        sendBroadCast(getMainActivityContext(), iGotData);
    }
    
    private void broadcastNotificationconnected(String msg) {
        System.out.println(("inside broadcastNotificationconnected " + msg));
        Intent iGotData = new Intent();
        iGotData.setAction(GlobalVariables.INTENT_ACTION);
        iGotData.putExtra("iName", "sensorNotification_connection");
        iGotData.putExtra("isNotificationSuccess", true);
        iGotData.putExtra("err", msg);
        iGotData.putExtra("reason", "connected");
        sendBroadCast(getMainActivityContext(), iGotData);
    }
    
    public void broadcastdisconnectionNotification() {
        System.out.println("inside broadcastdisconnectionNotification");
        Intent iGotData = new Intent();
        iGotData.setAction(GlobalVariables.INTENT_ACTION);
        iGotData.putExtra("iName", "Disconnection_Notification");
        iGotData.putExtra("reason", "disconnected");
        sendBroadCast(getMainActivityContext(), iGotData);
        iGotData = new Intent();
        iGotData.setAction(GlobalVariables.HOME_INTENT_ACTION);
        iGotData.putExtra("iName", "Disconnection_Notification");
        iGotData.putExtra("reason", "disconnected");
        sendBroadCast(this.HomeActivityContext, iGotData);
    }
    
    private void updateUI(BluetoothGattCharacteristic characteristic) {
        
    }
    
    private bool hasProperty() {
    }
    
    public bool isConnected() {
        if ((mRxBleDevice == null)) {
            return false;
        }
        
        setConnecting("isConnected()", false);
        return (mRxBleDevice.getConnectionState() == RxBleConnection.RxBleConnectionState.CONNECTED);
    }
    
    public bool isBluetoothEnabled() {
        BluetoothAdapter mBluetoothAdapter = BluetoothAdapter.getDefaultAdapter();
        return mBluetoothAdapter.isEnabled();
    }
    
    [NonNull()]
    public Intent enableBluetooth() {
        Intent enableBtIntent = new Intent(BluetoothAdapter.ACTION_REQUEST_ENABLE);
        return enableBtIntent;
    }
    
    public void disableBluetooth() {
        setConnecting("disableBluetooth()", false);
        BluetoothAdapter mBluetoothAdapter = BluetoothAdapter.getDefaultAdapter();
        if (mBluetoothAdapter.isEnabled()) {
            mBluetoothAdapter.disable();
        }
        
    }
    
    public void askForLocationPermissions() {
        logMessage("bluetooth", "Ask for permission");
        if (ActivityCompat.shouldShowRequestPermissionRationale(MainActivityInstance, Manifest.permission.ACCESS_FINE_LOCATION)) {
            ActivityCompat.requestPermissions(MainActivityInstance, new String[][][] {
                        Manifest.permission.ACCESS_FINE_LOCATION}, LOCATION_PERMISSION_REQUEST_CODE);
            show();
            //  Show an explanation to the user *asynchronously* -- don't block
            //  this thread waiting for the user's response! After the user
            //  sees the explanation, try again to request the permission.
        }
        else {
            //  No explanation needed, we can request the permission.
            ActivityCompat.requestPermissions(MainActivityInstance, new String[][][] {
                        Manifest.permission.ACCESS_FINE_LOCATION}, LOCATION_PERMISSION_REQUEST_CODE);
            //  MY_PERMISSIONS_REQUEST_ACCESS_FINE_LOCATION is an
            //  app-defined int constant. The callback method gets the
            //  result of the request.
        }
        
    }
    
    //  =============================================================================================
    //  Setters and Getters
    //  =============================================================================================
    public Activity getMainActivityInstance() {
        return MainActivityInstance;
    }
    
    public void setMainActivityInstance(Activity mainActivityInstance) {
        MainActivityInstance = mainActivityInstance;
    }
    
    public Context getMainActivityContext() {
        return MainActivityContext;
    }
    
    public void setMainActivityContext(Context mainActivityContext) {
        MainActivityContext = mainActivityContext;
    }
