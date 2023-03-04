package com.gravicode.neospectralib.BluetoothSDK;

import android.Manifest;
import android.app.Activity;
import android.bluetooth.BluetoothAdapter;
import android.bluetooth.BluetoothDevice;
import android.bluetooth.BluetoothGatt;
import android.bluetooth.BluetoothGattCallback;
import android.bluetooth.BluetoothGattCharacteristic;
import android.bluetooth.BluetoothGattService;
import android.bluetooth.BluetoothProfile;
import android.content.Context;
import android.content.Intent;
import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.core.app.ActivityCompat;
import android.util.Log;

import com.polidea.rxandroidble2.RxBleClient;
import com.polidea.rxandroidble2.RxBleConnection;
import com.polidea.rxandroidble2.RxBleDevice;
import com.polidea.rxandroidble2.exceptions.BleDisconnectedException;
import com.polidea.rxandroidble2.internal.RxBleLog;
import com.polidea.rxandroidble2.scan.ScanSettings;
import com.polidea.rxandroidble2.utils.ConnectionSharingAdapter;
//import com.gravicode.neospectralib.Activities.SettingsActivity;
import com.gravicode.neospectralib.Global.GlobalVariables;

import java.nio.ByteBuffer;
import java.nio.ByteOrder;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.UUID;

import io.reactivex.Observable;
import io.reactivex.android.schedulers.AndroidSchedulers;
import io.reactivex.disposables.Disposable;
import io.reactivex.subjects.PublishSubject;

import static com.gravicode.neospectralib.Global.GlobalVariables.MEMORY_CLEAR_REQUEST;
import static com.gravicode.neospectralib.Global.GlobalVariables.MEMORY_GET_SCANS_REQUEST;
import static com.gravicode.neospectralib.Global.GlobalVariables.MEMORY_STATUS_REQUEST;
//import static com.gravicode.neospectralib.Global.GlobalVariables.binaryOTAFileInBytes;
import static com.gravicode.neospectralib.Global.GlobalVariables.SYSTEM_BATTERY_INFO;
import static com.gravicode.neospectralib.Global.GlobalVariables.SYSTEM_BATTERY_REQUEST;
import static com.gravicode.neospectralib.Global.GlobalVariables.SYSTEM_P3_ID_REQUEST;
import static com.gravicode.neospectralib.Global.GlobalVariables.SYSTEM_TEMPERATURE_REQUEST;
import static com.gravicode.neospectralib.Global.GlobalVariables.gIsInterpolationEnabled;
import static com.gravicode.neospectralib.Global.GlobalVariables.isConnecting;
import static com.gravicode.neospectralib.Global.MethodsFactory.logMessage;
import static com.gravicode.neospectralib.Global.MethodsFactory.sendBroadCast;
import static com.gravicode.neospectralib.Global.MethodsFactory.showAlertMessage;

/**
 *
 */

public class SWS_P3ConnectionServices {
    static private List<SWS_P3BLEDevice> bleDevices;
    private static final String TAG = "P3_Connection";
    private Activity MainActivityInstance;
    private Context MainActivityContext, HomeActivityContext;

    boolean mHeaderPacketDone = false;
    private boolean mHeaderMemPacketDone = false;
    private boolean mHeaderSysPacketDone = false;
    private byte[] scanBytes;
    private int scanBytesIterator;
    private int packetsType = 0;
    int mNumberOfPackets = 0;
    int mDataLength = 0;
    int mReceivedPacketsCounter = 0;
    SWS_P3PacketResponse mPacketResponse;
    boolean still_fail = true;
    boolean isConnectedToGatt = false;
    int status;

    // flag to connection process
    public enum ConnectionStatus {
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

    public ConnectionStatus getConnectionStatus() {
        return connectionStatus;
    }

    public void setConnectionStatus(ConnectionStatus connectionStatus) {
        this.connectionStatus = connectionStatus;
    }

    // =====================================================================
    // RxAndroidBLE related variables
    private RxBleClient mRxBleClient;
    private RxBleDevice mRxBleDevice;
    private Disposable scanSubscription;
    private Observable<RxBleConnection> mRxBleConnection;

    @NonNull
    private PublishSubject<Boolean> disconnectTriggerSubject = PublishSubject.create();

    @NonNull
    List<SWS_P3BLEDevice> DevicesList = new ArrayList<>();
    @NonNull
    List<String> DevicesMacAddress = new ArrayList<>();
    List<UUID> serviceUUIDsList = new ArrayList<>();
    List<UUID> characteristicUUIDsList = new ArrayList<>();
    List<UUID> descriptorUUIDsList = new ArrayList<>();

    // ============================================================================================================
    public static int MY_PERMISSIONS_REQUEST_ACCESS_FINE_LOCATION = 1;
    private static final int LOCATION_PERMISSION_REQUEST_CODE = 1;
    // ============================================================================================================

    //Macros
    public static final UUID TX_POWER_UUID = UUID.fromString("00001804-0000-1000-8000-00805f9b34fb");
    public static final UUID TX_POWER_LEVEL_UUID = UUID.fromString("00002a07-0000-1000-8000-00805f9b34fb");
    public static final UUID CCCD = UUID.fromString("00002902-0000-1000-8000-00805f9b34fb");
    public static final UUID FIRMWARE_REVISON_UUID = UUID.fromString("00002a26-0000-1000-8000-00805f9b34fb");
    public static final UUID DIS_UUID = UUID.fromString("0000180a-0000-1000-8000-00805f9b34fb");

    public static final UUID P3_SERVICE_UUID = UUID.fromString("6e400001-b5a3-f393-e0a9-e50e24dcca9e");
    public static final UUID SYS_STAT_SERVICE_UUID = UUID.fromString("B100B100-B100-B100-B100-B100B100B100");
    public static final UUID MEM_SERVICE_UUID = UUID.fromString("C100C100-C100-C100-C100-C100C100C100");
    public static final UUID OTA_SERVICE_UUID = UUID.fromString("D100D100-D100-D100-D100-D100D100D100");
    public static final UUID BATTERY_SERVICE_UUID = UUID.fromString("E100E100-E100-E100-E100-E100E100E100");

    public static final UUID P3_RX_CHAR_UUID = UUID.fromString("6e400002-b5a3-f393-e0a9-e50e24dcca9e");
    public static final UUID P3_TX_CHAR_UUID = UUID.fromString("6e400003-b5a3-f393-e0a9-e50e24dcca9e");
    public static final UUID SYS_STAT_TX_CHAR_UUID = UUID.fromString("B101B101-B101-B101-B101-B101B101B101");
    public static final UUID SYS_STAT_RX_CHAR_UUID = UUID.fromString("B102B102-B102-B102-B102-B102B102B102");
    public static final UUID MEM_TX_CHAR_UUID = UUID.fromString("C101C101-C101-C101-C101-C101C101C101");
    public static final UUID MEM_RX_CHAR_UUID = UUID.fromString("C102C102-C102-C102-C102-C102C102C102");
    public static final UUID OTA_TX_CHAR_UUID = UUID.fromString("D101D101-D101-D101-D101-D101D101D101");
    public static final UUID OTA_RX_CHAR_UUID = UUID.fromString("D102D102-D102-D102-D102-D102D102D102");
    // ======================================================= =====================================================


    // ============================================================================================================
    // Constructor
    public SWS_P3ConnectionServices(Activity mMainActivity, Context mMainContext) {
        MainActivityInstance = mMainActivity;
        MainActivityContext = mMainContext;
    }


    // ============================================================================================================
    // Setters and Getters
    public RxBleDevice getmRxBleDevice() {
        return mRxBleDevice;
    }

    public void setmRxBleDevice(RxBleDevice mRxBleDevice) {
        this.mRxBleDevice = mRxBleDevice;
    }


    // ============================================================================================================

    @NonNull
    public List<SWS_P3BLEDevice> ScanBTDevices() {
        mRxBleClient = RxBleClient.create(MainActivityContext);
        RxBleLog.setLogLevel(RxBleLog.VERBOSE);


        scanSubscription = mRxBleClient.scanBleDevices(new ScanSettings.Builder()
                .setScanMode(ScanSettings.SCAN_MODE_LOW_LATENCY)
                .setCallbackType(ScanSettings.CALLBACK_TYPE_ALL_MATCHES)
                .build())
                .observeOn(AndroidSchedulers.mainThread())
                .subscribe(
                        scanResult -> {
                            // handle found results
                            SWS_P3BLEDevice tmp = new SWS_P3BLEDevice(
                                    scanResult.getBleDevice().getName(), scanResult.getBleDevice().getMacAddress(),
                                    scanResult.getRssi(), scanResult.getBleDevice());

                            if (!DevicesMacAddress.contains(scanResult.getBleDevice().getMacAddress()))
                                if (scanResult.getBleDevice().getName() != null) {
                                    {
                                        if (scanResult.getBleDevice().getName().contains("NeoSpectra") ||
                                                scanResult.getBleDevice().getName().contains("NS-")) {
                                            Log.i(getClass().getSimpleName(), "# Added New Element:" + scanResult.getBleDevice().getName());
                                            DevicesList.add(tmp);
                                            DevicesMacAddress.add(scanResult.getBleDevice().getMacAddress());
                                            //SettingsActivity.found_device(DevicesList);
                                            bleDevices = DevicesList;
                                        }
                                    }

                                }

                        },
                        throwable -> {
                            // Handle an error here.
                            Log.i(getClass().getSimpleName(), "Found Problem in Scanning  ... ");
                        }
                );

        while (DevicesList.size() < 1) {
        }
        return DevicesList;
    }


    public boolean isConnecting(String from) {
        logMessage("bluetooth", "get is connecting from: " + from + ", Value: " + isConnecting);
        return isConnecting;
    }

    public void setConnecting(String from, boolean connecting) {
        isConnecting = connecting;
    }

    public void ConnectToP3() {
        setConnecting("ConnectToP3()", true);


        mRxBleConnection = prepareConnectionObservable();

        mRxBleConnection
                .flatMapSingle(RxBleConnection::discoverServices)
                .observeOn(AndroidSchedulers.mainThread())
                .doOnSubscribe(disposable -> {
                            Log.i(getClass().getSimpleName(), "We're Good Man!");
                        }
                )
                .subscribe(
                        characteristic -> {
                            Log.i(getClass().getSimpleName(), "Hey, connection has been established!");

                            setConnecting("connection established!", false);

                            broadcastNotificationconnected("connection established!"); //heba added

                        },
                        this::onConnectionFailure,
                        this::onConnectionFinished
                );
    }

    public void DisconnectFromP3() {
        setConnecting("DisconnectFromP3()", false);
        disconnectTriggerSubject.onNext(true);
    }

    private void onConnectionFailure(Throwable throwable) {
        setConnecting("onConnectionFailure()", false);
        Log.i(getClass().getSimpleName(), "Connection error: " + throwable);
    }

    private void onConnectionFinished() {
        setConnecting("onConnectionFinished()", false);

    }

    public void ReadFromP3() {
        if (isConnected()) {
            mRxBleConnection
                    .firstOrError()
                    .flatMap(rxBleConnection -> rxBleConnection.readCharacteristic(P3_TX_CHAR_UUID))
                    .observeOn(AndroidSchedulers.mainThread())
                    .subscribe(this::onReadSuccess, this::onReadFailure);
        } else {
            showAlertMessage(getMainActivityContext(),
                    "Device not connected",
                    "Please! Ensure that you have a connected device firstly");
        }
    }


    private void onReadFailure(Throwable throwable) {
        Log.i(getClass().getSimpleName(), "Read error: " + throwable);
        broadcastNotificationFailure(throwable.getMessage() + " onReadFailure", "read_failure", 0);
    }

    private void onReadSuccess(byte[] bytes) {
        Log.i(getClass().getSimpleName(), "Read Success!");

    }

    public void WriteToP3(@NonNull byte[] byteArray) {
        if (isConnected()) {
            mRxBleConnection
                    .firstOrError()
                    .flatMap(rxBleConnection -> rxBleConnection.writeCharacteristic(P3_RX_CHAR_UUID, byteArray))
                    .observeOn(AndroidSchedulers.mainThread())
                    .subscribe(
                            bytes -> onWriteSuccess(),
                            this::onWriteFailure
                    );
        }
    }

    public interface BLEAction {
        void onDisconnect();

        void onConnect();

        void onRead(BluetoothGatt gatt, BluetoothGattCharacteristic characteristic, int status);

        void onWrite(BluetoothGatt gatt, BluetoothGattCharacteristic characteristic, int status);

        void onNotification(BluetoothGatt gatt, BluetoothGattCharacteristic characteristic);
    }

    private ArrayList<BLEAction> listeners = new ArrayList<BLEAction>();

    public void addListener(BLEAction toAdd) {
        listeners.add(toAdd);
    }

    public void removeListener(BLEAction toDel) {
        listeners.remove(toDel);
    }

    public void raiseonNotification(BluetoothGatt gatt, BluetoothGattCharacteristic characteristic) {
        // Notify everybody that may be interested.
        for (BLEAction listener : listeners)
            listener.onNotification(gatt, characteristic);
    }

    public void raiseonRead(BluetoothGatt gatt, BluetoothGattCharacteristic characteristic, int status) {
        // Notify everybody that may be interested.
        for (BLEAction listener : listeners)
            listener.onRead(gatt, characteristic, status);
    }

    public void raiseonWrite(BluetoothGatt gatt, BluetoothGattCharacteristic characteristic, int status) {
        // Notify everybody that may be interested.
        for (BLEAction listener : listeners)
            listener.onWrite(gatt, characteristic, status);
    }

    public void raiseonDisconnect() {
        // Notify everybody that may be interested.
        for (BLEAction listener : listeners)
            listener.onDisconnect();
    }

    public void raiseonConnect() {
        // Notify everybody that may be interested.
        for (BLEAction listener : listeners)
            listener.onConnect();
    }

    private BluetoothGattCallback myGattCallback = new BluetoothGattCallback() {
        @Override
        public void onServicesDiscovered(BluetoothGatt gatt, int status) {
            if (status == BluetoothGatt.GATT_SUCCESS) {

            }
            Log.d(TAG, "Service discovered with status " + status);
        }

        @Override
        public void onConnectionStateChange(BluetoothGatt gatt, int status, int newState) {
            switch (newState) {
                case BluetoothProfile.STATE_CONNECTED:
                    Log.d(TAG, "Gatt state: connected");
                    gatt.discoverServices();
                    isConnectedToGatt = true;
                    raiseonConnect();
                    break;
                default:
                    Log.d(TAG, "Gatt state: not connected");
                    isConnectedToGatt = false;
                    raiseonDisconnect();
                    break;
            }
        }

        @Override
        public void onCharacteristicWrite(BluetoothGatt gatt, BluetoothGattCharacteristic characteristic, int status) {
            Log.d(TAG, "Write successful: " + Arrays.toString(characteristic.getValue()));
            raiseonWrite(gatt, characteristic, status);
            super.onCharacteristicWrite(gatt, characteristic, status);
        }

        @Override
        public void onCharacteristicRead(BluetoothGatt gatt, BluetoothGattCharacteristic characteristic, int status) {
            Log.d(TAG, "Read successful: " + Arrays.toString(characteristic.getValue()));
            raiseonRead(gatt, characteristic, status);
            super.onCharacteristicRead(gatt, characteristic, status);
        }

        @Override
        public void onCharacteristicChanged(BluetoothGatt gatt, BluetoothGattCharacteristic characteristic) {
            Log.d(TAG, " - Notifiaction UUID: " + characteristic.getUuid().toString());
            Log.d(TAG, " - Notifiaction value: " + Arrays.toString(characteristic.getValue()));
            raiseonNotification(gatt, characteristic);
            super.onCharacteristicChanged(gatt, characteristic);
        }


    };


    public void writeData(byte[] data) {

        BluetoothDevice activeDevice = null;
        BluetoothGatt myGatBand = null;

        //Log.d(TAG, "(*) Initialising Bluetooth connection for device: " + filter);

        if (BluetoothAdapter.getDefaultAdapter().isEnabled()) {
            for (BluetoothDevice pairedDevice : BluetoothAdapter.getDefaultAdapter().getBondedDevices()) {
                if (pairedDevice.getName().contains(mRxBleDevice.getName())) {
                    Log.d(TAG, "\tDevice Name: " + pairedDevice.getName());
                    Log.d(TAG, "\tDevice MAC: " + pairedDevice.getAddress());

                    activeDevice = pairedDevice;
                    break;
                }
            }
        }

        if (activeDevice != null) {
            // GATT is Just another specification:
            // https://www.bluetooth.com/specifications/gatt/services
            Log.d(TAG, "(*) Establishing connection to gatt");
            myGatBand = activeDevice.connectGatt(MainActivityContext, true, myGattCallback);
        } else {
            Log.d(TAG, "(*) Cant Establish connection to gatt, device is null");
        }


        if (!isConnectedToGatt || myGatBand == null) {
            Log.d(TAG, "Cant read from BLE, not initialized.");
            return;
        }

        Log.d(TAG, "* Getting gatt service, UUID:" + OTA_SERVICE_UUID);
        BluetoothGattService myGatService =
                myGatBand.getService(OTA_SERVICE_UUID);
        if (myGatService != null) {
            Log.d(TAG, "* Getting gatt Characteristic. UUID: " + OTA_RX_CHAR_UUID);

            BluetoothGattCharacteristic myGatChar
                    = myGatService.getCharacteristic(OTA_RX_CHAR_UUID /*Consts.UUID_START_HEARTRATE_CONTROL_POINT*/);
            if (myGatChar != null) {
                Log.d(TAG, "* Writing trigger");
                myGatChar.setValue(data /*Consts.BYTE_NEW_HEART_RATE_SCAN*/);

                boolean status = myGatBand.writeCharacteristic(myGatChar);
                Log.d(TAG, "* Writting trigger status :" + status);
            }
        }
    }

    public void WriteToMemoryService(@NonNull byte[] byteArray) {
        if (isConnected()) {
            mRxBleConnection
                    .firstOrError()
                    .flatMap(rxBleConnection -> rxBleConnection.writeCharacteristic(MEM_RX_CHAR_UUID, byteArray))
                    .observeOn(AndroidSchedulers.mainThread())
                    .subscribe(
                            bytes -> onWriteSuccess(),
                            this::onWriteFailure
                    );
        }
    }

    public void WriteToSystemService(@NonNull byte[] byteArray) {
        if (isConnected()) {
            mRxBleConnection
                    .firstOrError()
                    .flatMap(rxBleConnection -> rxBleConnection.writeCharacteristic(SYS_STAT_RX_CHAR_UUID, byteArray))
                    .observeOn(AndroidSchedulers.mainThread())
                    .subscribe(
                            bytes -> onWriteSuccess(),
                            this::onWriteFailure
                    );
        }
    }




    public void WriteOTAService(@NonNull byte[] byteArray) {

        if (isConnected()) {
            mRxBleConnection
                    .firstOrError()
                    .flatMap(rxBleConnection -> rxBleConnection.writeCharacteristic(OTA_RX_CHAR_UUID, byteArray))
                    .observeOn(AndroidSchedulers.mainThread())
                    .subscribe(
                            bytes -> onWriteSuccess(),
                            this::onWriteFailure
                    );
        }
    }

    private void onWriteFailure(Throwable throwable) {
        Log.i(getClass().getSimpleName(), "Write error: " + throwable);
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
        return mRxBleDevice
                .establishConnection(false)
                .takeUntil(disconnectTriggerSubject)
                .compose(new ConnectionSharingAdapter());
    }

    public void SetNotificationOnTXInP3() {
        if (isConnected()) {
            mRxBleConnection
                    .flatMap(rxBleConnection -> rxBleConnection.setupNotification(P3_TX_CHAR_UUID))
                    .doOnNext(notificationObservable -> MainActivityInstance.runOnUiThread(this::notificationHasBeenSetUp))
                    .doOnError(setupThrowable -> MainActivityInstance.runOnUiThread(this::dataNotificationSetupError))
                    .flatMap(notificationObservable -> notificationObservable)
                    .retryWhen(errors -> errors.flatMap(error -> {
                        if (error instanceof BleDisconnectedException) {
                            Log.d("Retry", "Retrying");
                            return Observable.just(null);
                        }
                        return Observable.error(error);
                    }))
                    .observeOn(AndroidSchedulers.mainThread())
                    .subscribe(this::onNotificationReceived,
                            this::onNotificationSetupFailure);
        }
    }

    public void SetNotificationOnMemTx() {
        if (isConnected()) {
            mRxBleConnection
                    .flatMap(rxBleConnection -> rxBleConnection.setupNotification(MEM_TX_CHAR_UUID))
                    .doOnNext(notificationObservable -> MainActivityInstance.runOnUiThread(this::notificationHasBeenSetUp))
                    .doOnError(setupThrowable -> MainActivityInstance.runOnUiThread(this::dataNotificationSetupError))
                    .flatMap(notificationObservable -> notificationObservable)
                    .retryWhen(errors -> errors.flatMap(error -> {
                        if (error instanceof BleDisconnectedException) {
                            Log.d("Retry", "Retrying");
                            return Observable.just(null);
                        }
                        return Observable.error(error);
                    }))
                    .observeOn(AndroidSchedulers.mainThread())
                    .subscribe(this::onMemNotificationReceived,
                            this::onNotificationSetupFailure);
        }
    }

    public void SetNotificationOnBatTx() {
        if (isConnected()) {
            mRxBleConnection
                    .flatMap(rxBleConnection -> rxBleConnection.setupNotification(SYS_STAT_TX_CHAR_UUID))
                    .doOnNext(notificationObservable -> MainActivityInstance.runOnUiThread(this::notificationHasBeenSetUp))
                    .doOnError(setupThrowable -> MainActivityInstance.runOnUiThread(this::dataNotificationSetupError))
                    .flatMap(notificationObservable -> notificationObservable)
                    .retryWhen(errors -> errors.flatMap(error -> {
                        if (error instanceof BleDisconnectedException) {
                            Log.d("Retry", "Retrying");
                            return Observable.just(null);
                        }
                        return Observable.error(error);
                    }))
                    .observeOn(AndroidSchedulers.mainThread())
                    .subscribe(this::onSystemNotificationReceived,
                            this::onNotificationSetupFailure);
        }
    }

    public void setHomeActivityContext(Context context)
    {
        HomeActivityContext = context;
    }

    private void onNotificationReceived(@NonNull byte[] bytes) {
        if (!mHeaderPacketDone) {
            // get the error code and check its value
            if (bytes[0] == 0) {
                Log.i(getClass().getSimpleName(), "%--> NO Error in Received Packet.");

                int doublesCount = 0;
                // No Error, compute the length of the frame
                int length1 = 0x000000FF & (bytes[1]);
                int length2 = 0x000000FF & (bytes[2]);
                mDataLength = (length1) + ((length2) << 8);

                Log.i(getClass().getSimpleName(), "%--> Length: " + mDataLength + "  mInterpolationEnabled = " + gIsInterpolationEnabled);

                if (mDataLength == 1 || mDataLength == 2) {
                    mNumberOfPackets = 1;
                } else {
                    if (gIsInterpolationEnabled) {
                        mNumberOfPackets = (int) Math.ceil((mDataLength + 2) * 8.0 / 20);
                    } else {
                        mNumberOfPackets = (int) Math.ceil((mDataLength * 2) * 8.0 / 20);
                    }

                }

                Log.i(getClass().getSimpleName(), "%--> Packets: " + mNumberOfPackets);


                // create a new response packet
                mPacketResponse = new SWS_P3PacketResponse(mNumberOfPackets, mDataLength, gIsInterpolationEnabled);

                // initialize the packet response
                mPacketResponse.prepareArraySize();

                // set iteration parameters
                mHeaderPacketDone = true;
            } else {
                // Error
                Log.i(getClass().getSimpleName(), "#--> Error in Received Packet.");
                broadcastNotificationFailure("#--> Error in Received Packet.", "packet_failure", (int)bytes[0]);
            }
        } else {

            // send the received bytes to the packet response instance
            mPacketResponse.addNewResponse(bytes);

            // increment the received packets counter
            mReceivedPacketsCounter++;

            Log.i(getClass().getSimpleName(), "#--> Received packets: " + mReceivedPacketsCounter);

            System.out.println("mDataLength = " + mDataLength + ", mNumberOfPackets = " + mNumberOfPackets);
            if (mNumberOfPackets == mReceivedPacketsCounter) {
                mReceivedPacketsCounter = 0;
                Log.i(getClass().getSimpleName(), "#--> Received packets: Done !!");
                Log.i(getClass().getSimpleName(), "-------------------------------------------------------------------------------------");

                // initiate the interpretation process
                mPacketResponse.interpretByteStream();

                double[] mRecDoubles = mPacketResponse.getmInterpretedPacketResponse();

                broadcastNotificationData(mRecDoubles, mPacketResponse.convertByteArrayToString());
                logMessage(TAG, "A PACKET IS BROADCASTED");
                // fix iterator parameters for next packet
                mHeaderPacketDone = false;
            }
        }

        Log.i(getClass().getSimpleName(), "Notification Received - " + String.valueOf(bytes.length));
    }

    private void onMemNotificationReceived(@NonNull byte[] bytes) {
        if(!mHeaderMemPacketDone)
        {
            status = bytes[0];


            mDataLength = ((bytes[1] & 0xFF) << 0) | ((bytes[2] & 0xFF) << 8);

            scanBytes = new byte[mDataLength];
            scanBytesIterator = 0;

            mHeaderMemPacketDone = true;
        }
        else {

            if(mDataLength == 1 && status == 0)
            {
                broadcastHomeNotification(0, "OperationDone");
                mHeaderMemPacketDone = false;
                return;
            }
            else if (mDataLength == 1 && status != 0)
            {
                broadcastHomeNotification((long)bytes[0], "Error");
                mHeaderMemPacketDone = false;
                return;
            }

            if(scanBytesIterator == 0)
            {
                long type = ((bytes[0] & 0xFFL) << 0) |
                        ((bytes[1] & 0xFFL) << 8)  |
                        ((bytes[2] & 0xFFL) << 16) |
                        ((bytes[3] & 0xFFL) << 24);                //long to support 32-bin unsigned
                packetsType = (int)type;
            }

            switch(packetsType)
            {
                case MEMORY_STATUS_REQUEST:

                    long memory = ((bytes[4] & 0xFFL) << 0) |
                            ((bytes[5] & 0xFFL) << 8)  |
                            ((bytes[6] & 0xFFL) << 16) |
                            ((bytes[7] & 0xFFL) << 24);                //long to support 32-bin unsigned

                    long FWVersion = ((bytes[8] & 0xFFL) << 0) |
                            ((bytes[9] & 0xFFL) << 8) |
                            ((bytes[10] & 0xFFL) << 16)|
                            ((bytes[11] & 0xFFL) << 24);              //long to support 32-bin unsigned

                    broadcastHomeNotification(memory, "Memory");
                    broadcastHomeNotification(FWVersion, "FWVersion");

                    mHeaderMemPacketDone = false;
                    break;

                case MEMORY_GET_SCANS_REQUEST:
                    if(scanBytesIterator == 0) {
                        System.arraycopy(bytes, 4, scanBytes, scanBytesIterator, 16);
                        scanBytesIterator = scanBytesIterator + 16;
                    }
                    else if(scanBytesIterator + 20 > (mDataLength - 4)) {
                        System.arraycopy(bytes, 0, scanBytes, scanBytesIterator,
                                mDataLength - scanBytesIterator - 4);
                        scanBytesIterator = mDataLength - 4;
                    }
                    else {
                        System.arraycopy(bytes, 0, scanBytes, scanBytesIterator, 20);
                        scanBytesIterator = scanBytesIterator + 20;
                    }

                    if(scanBytesIterator == ( mDataLength - 4))
                    {
                        ByteBuffer buffer = ByteBuffer.wrap(scanBytes);
                        buffer.order(ByteOrder.LITTLE_ENDIAN);
                        double[] doubleValues = new double[scanBytes.length / 8];
                        for(int i = 0; i < scanBytes.length / 16; i++) {
                            doubleValues[i] = buffer.getLong(i * 8) / Math.pow(2, 33);
                            doubleValues[i + doubleValues.length/2] =
                                    buffer.getLong((i + doubleValues.length/2) * 8) /
                                            Math.pow(2, 30);
                        }
                        mHeaderMemPacketDone = false;
                        broadcastNotificationMemoryData(doubleValues);
                    }
                    break;

                case MEMORY_CLEAR_REQUEST:
                    break;
            }
            long Fnum = ((bytes[0] & 0xFFL) << 0) |
                    ((bytes[1] & 0xFFL) << 8)  |
                    ((bytes[2] & 0xFFL) << 16) |
                    ((bytes[3] & 0xFFL) << 24);
            System.out.println("===========" + Fnum + "=========" + scanBytesIterator + "==========");

        }

        Log.i(getClass().getSimpleName(), "Notification Received - " + String.valueOf(bytes.length));
    }

    private void onSystemNotificationReceived(@NonNull byte[] bytes) {
        if(!mHeaderSysPacketDone)
        {
            //ToDo: Check the status
            mHeaderSysPacketDone = true;
        }
        else {
            long type = ((bytes[0] & 0xFFL) << 0) |
                        ((bytes[1] & 0xFFL) << 8)  |
                        ((bytes[2] & 0xFFL) << 16) |
                        ((bytes[3] & 0xFFL) << 24);

            switch ((int)type) {
                case SYSTEM_BATTERY_REQUEST: {
                    long capacity = ((bytes[4] & 0xFFL) << 0) |
                                    ((bytes[5] & 0xFFL) << 8) |
                                    ((bytes[6] & 0xFFL) << 16)|
                                    ((bytes[7] & 0xFFL) << 24);                //long to support 32-bin unsigned

                    int charging = ((bytes[8] & 0xFF) << 0);

                    broadcastHomeNotification(capacity, "BatCapacity");
                    broadcastHomeNotification((long) charging, "ChargingStatus");
                    break;
                }
                case SYSTEM_P3_ID_REQUEST:{
                    long P3ID =((bytes[4] & 0xFFL) << 0) |
                                ((bytes[5] & 0xFFL) << 8) |
                                ((bytes[6] & 0xFFL) << 16)|
                                ((bytes[7] & 0xFFL) << 24)|
                                ((bytes[8] & 0xFFL) << 32) |
                                ((bytes[9] & 0xFFL) << 40) |
                                ((bytes[10] & 0xFFL) << 48)|
                                ((bytes[11] & 0xFFL) << 56);
                    broadcastHomeNotification(P3ID, "P3_ID");

                    break;
                }
                case SYSTEM_TEMPERATURE_REQUEST:{
                    long temperature = ((bytes[4] & 0xFFL) << 0) |
                            ((bytes[5] & 0xFFL) << 8) |
                            ((bytes[6] & 0xFFL) << 16)|
                            ((bytes[7] & 0xFFL) << 24);
                    broadcastHomeNotification(temperature, "Temperature");

                    break;
                }
                case SYSTEM_BATTERY_INFO:{
                    int v = ((bytes[4] & 0xFF) << 0) |
                            ((bytes[5] & 0xFF) << 8) ;
                    int i = ((bytes[6] & 0xFF) << 0) |
                            ((bytes[7] & 0xFF) << 8) ;
                    int c = ((bytes[8] & 0xFF) << 0) |
                            ((bytes[9] & 0xFF) << 8) ;
                    int fcc = ((bytes[10] & 0xFF) << 0) |
                            ((bytes[11] & 0xFF) << 8) ;
                    int t = ((bytes[12] & 0xFF) << 0) |
                            ((bytes[13] & 0xFF) << 8) ;
                    int v1 = ((bytes[14] & 0xFF) << 0) |
                            ((bytes[15] & 0xFF) << 8) ;
                    int v2 = ((bytes[16] & 0xFF) << 0) |
                            ((bytes[17] & 0xFF) << 8) ;
                    int cc = ((bytes[18] & 0xFF) << 0) |
                            ((bytes[19] & 0xFF) << 8) ;

                    String batteryInfo = "Battery Voltage =  " + v  + " mv" +
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

        Log.i(getClass().getSimpleName(), "Notification Received - " + String.valueOf(bytes.length));
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


    private void broadcastHomeNotification(long data, @Nullable String iName) {
        logMessage(TAG, "INSIDE BROADCAST NOTIFICATION DATA");
        Intent iGotData = new Intent();
        iGotData.setAction(GlobalVariables.HOME_INTENT_ACTION);
        iGotData.putExtra("iName", iName);
        iGotData.putExtra("isNotificationSuccess", true);  //false heba change
        iGotData.putExtra("data", data);
        iGotData.putExtra("reason", "gotData");
        iGotData.putExtra("from","broadcastHomeNotification");
        sendBroadCast(this.HomeActivityContext, iGotData);
    }

    private void broadcastHomeNotification(String input, @Nullable String iName) {
        logMessage(TAG, "INSIDE BROADCAST NOTIFICATION DATA");
        Intent iGotData = new Intent();
        iGotData.setAction(GlobalVariables.HOME_INTENT_ACTION);
        iGotData.putExtra("iName", iName);
        iGotData.putExtra("isNotificationSuccess", true);  //false heba change
        iGotData.putExtra("data", input);
        iGotData.putExtra("reason", "gotData");
        iGotData.putExtra("from","broadcastHomeNotification");
        sendBroadCast(this.HomeActivityContext, iGotData);
    }

    private void broadcastNotificationData(double[] mDoubles, @Nullable String streamByte) {
        logMessage(TAG, "INSIDE BROADCAST NOTIFICATION DATA");
        Intent iGotData = new Intent();
        iGotData.setAction(GlobalVariables.INTENT_ACTION);
        iGotData.putExtra("iName", "sensorNotification_data");
        iGotData.putExtra("isNotificationSuccess", true);  //false heba change
        iGotData.putExtra("data", mDoubles);
        iGotData.putExtra("stream", streamByte);
        iGotData.putExtra("reason", "gotData");
        iGotData.putExtra("from","broadcastNotificationData");
        sendBroadCast(getMainActivityContext(), iGotData);
    }

    private void broadcastNotificationMemoryData(double[] mDoubles) {
        logMessage(TAG, "INSIDE BROADCAST NOTIFICATION Memory DATA");
        Intent iGotData = new Intent();
        iGotData.setAction(GlobalVariables.HOME_INTENT_ACTION);
        iGotData.putExtra("iName", "MemoryScanData");
        iGotData.putExtra("isNotificationSuccess", true);  //false heba change
        iGotData.putExtra("data", mDoubles);
        iGotData.putExtra("reason", "gotData");
        iGotData.putExtra("from","broadcastNotificationData");
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
        System.out.println("inside broadcastNotificationconnected " + msg);
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

    private boolean hasProperty(@Nullable BluetoothGattCharacteristic characteristic, int property) {
        return characteristic != null && (characteristic.getProperties() & property) > 0;
    }

    public boolean isConnected() {
        if (mRxBleDevice == null) {
            return false;
        }

        setConnecting("isConnected()", false);
        return mRxBleDevice.getConnectionState() == RxBleConnection.RxBleConnectionState.CONNECTED;
    }

    public boolean isBluetoothEnabled() {
        BluetoothAdapter mBluetoothAdapter = BluetoothAdapter.getDefaultAdapter();
        return mBluetoothAdapter.isEnabled();
    }

    @NonNull
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

        if (ActivityCompat.shouldShowRequestPermissionRationale(MainActivityInstance,
                Manifest.permission.ACCESS_FINE_LOCATION)) {

            new androidx.appcompat.app.AlertDialog.Builder(MainActivityInstance)
                    .setTitle("Location permissions needed")
                    .setMessage("you need to allow this permission!")
                    .setPositiveButton("Sure", (dialog, which) ->
                            ActivityCompat.requestPermissions(MainActivityInstance,
                                    new String[]{Manifest.permission.ACCESS_FINE_LOCATION},
                                    LOCATION_PERMISSION_REQUEST_CODE))
                    .setNegativeButton("Not now", (dialog, which) -> {

                    })
                    .show();

            // Show an explanation to the user *asynchronously* -- don't block
            // this thread waiting for the user's response! After the user
            // sees the explanation, try again to request the permission.

        } else {

            // No explanation needed, we can request the permission.
            ActivityCompat.requestPermissions(MainActivityInstance,
                    new String[]{Manifest.permission.ACCESS_FINE_LOCATION},
                    LOCATION_PERMISSION_REQUEST_CODE);

            // MY_PERMISSIONS_REQUEST_ACCESS_FINE_LOCATION is an
            // app-defined int constant. The callback method gets the
            // result of the request.
        }
    }

    // =============================================================================================
    // Setters and Getters
    // =============================================================================================
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

    // =============================================================================================
    // Callback
    // =============================================================================================

}
