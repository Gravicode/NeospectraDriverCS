package com.gravicode.neospectralib.BluetoothSDK;
using android.bluetooth.BluetoothDevice;
using android.bluetooth.BluetoothGatt;
using com.polidea.rxandroidble2.RxBleDevice;
public class SWS_P3BLEDevice {
    
    private String DeviceName;
    
    private String DeviceMacAddress;
    
    private int DeviceRSSI;
    
    private RxBleDevice DeviceInstance;
    
    public bool connected = false;
    
    private BluetoothDevice gattDeviceInstance = null;
    
    //  The mi band
    private bool isConnectedToGatt = false;
    
    //  the gatt connection
    private BluetoothGatt myGatBand = null;
    
    SWS_P3BLEDevice(String mName, String mMacAddress, int mRSSI, RxBleDevice mInstance) {
        this.DeviceName = mName;
        this.DeviceMacAddress = mMacAddress;
        this.DeviceRSSI = mRSSI;
        this.DeviceInstance = mInstance;
    }
    
    SWS_P3BLEDevice(String mName, String mMacAddress, int mRSSI, BluetoothDevice mInstance) {
        this.DeviceName = mName;
        this.DeviceMacAddress = mMacAddress;
        this.DeviceRSSI = mRSSI;
        this.gattDeviceInstance = mInstance;
        this.isConnectedToGatt = false;
    }
    
    public String getDeviceName() {
        return this.DeviceName;
    }
    
    public void setDeviceName(String deviceName) {
        this.DeviceName = deviceName;
    }
    
    public String getDeviceMacAddress() {
        return this.DeviceMacAddress;
    }
    
    public void setDeviceMacAddress(String deviceMacAddress) {
        this.DeviceMacAddress = deviceMacAddress;
    }
    
    public int getDeviceRSSI() {
        return this.DeviceRSSI;
    }
    
    public void setDeviceRSSI(int deviceRSSI) {
        this.DeviceRSSI = deviceRSSI;
    }
    
    public RxBleDevice getDeviceInstance() {
        return this.DeviceInstance;
    }
    
    public void setDeviceInstance(RxBleDevice deviceInstance) {
        this.DeviceInstance = deviceInstance;
    }
    
    public BluetoothDevice getGattDeviceInstance() {
        return this.gattDeviceInstance;
    }
    
    public void setGattDeviceInstance(BluetoothDevice gattDeviceInstance) {
        this.gattDeviceInstance = this.gattDeviceInstance;
    }
    
    public BluetoothGatt getMyGatBand() {
        return this.myGatBand;
    }
    
    public void setMyGatBand(BluetoothGatt myGatBand) {
        this.myGatBand = this.myGatBand;
    }
    
    public bool isConnectedToGatt() {
        return this.isConnectedToGatt;
    }
    
    public void setConnectedToGatt(bool connectedToGatt) {
        this.isConnectedToGatt = connectedToGatt;
    }
}
