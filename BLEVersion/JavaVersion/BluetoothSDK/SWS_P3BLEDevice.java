package com.gravicode.neospectralib.BluetoothSDK;

import android.bluetooth.BluetoothDevice;
import android.bluetooth.BluetoothGatt;

import com.polidea.rxandroidble2.RxBleDevice;

/**
 *
 */

public class SWS_P3BLEDevice {

    private String DeviceName;
    private String DeviceMacAddress;
    private int DeviceRSSI;
    private RxBleDevice DeviceInstance;
    public boolean connected=false;


    private BluetoothDevice gattDeviceInstance = null; // The mi band
    private boolean isConnectedToGatt = false; // the gatt connection
    private BluetoothGatt myGatBand = null;

    SWS_P3BLEDevice(String mName, String mMacAddress, int mRSSI, RxBleDevice mInstance)
    {
        DeviceName          = mName;
        DeviceMacAddress    = mMacAddress;
        DeviceRSSI          = mRSSI;
        DeviceInstance      = mInstance;
    }

    SWS_P3BLEDevice(String mName, String mMacAddress, int mRSSI, BluetoothDevice mInstance)
    {
        DeviceName          = mName;
        DeviceMacAddress    = mMacAddress;
        DeviceRSSI          = mRSSI;
        gattDeviceInstance  = mInstance;
        isConnectedToGatt   = false;
    }

    public String getDeviceName() {
        return DeviceName;
    }

    public void setDeviceName(String deviceName) {
        DeviceName = deviceName;
    }

    public String getDeviceMacAddress() {
        return DeviceMacAddress;
    }

    public void setDeviceMacAddress(String deviceMacAddress) {
        DeviceMacAddress = deviceMacAddress;
    }

    public int getDeviceRSSI() {
        return DeviceRSSI;
    }

    public void setDeviceRSSI(int deviceRSSI) {
        DeviceRSSI = deviceRSSI;
    }

    public RxBleDevice getDeviceInstance() {
        return DeviceInstance;
    }

    public void setDeviceInstance(RxBleDevice deviceInstance) {
        DeviceInstance = deviceInstance;
    }

    public BluetoothDevice getGattDeviceInstance() {
        return gattDeviceInstance;
    }

    public void setGattDeviceInstance(BluetoothDevice gattDeviceInstance) {
        this.gattDeviceInstance = gattDeviceInstance;
    }
    public BluetoothGatt getMyGatBand() {
        return myGatBand;
    }

    public void setMyGatBand(BluetoothGatt myGatBand) {
        this.myGatBand = myGatBand;
    }

    public boolean isConnectedToGatt() {
        return isConnectedToGatt;
    }

    public void setConnectedToGatt(boolean connectedToGatt) {
        isConnectedToGatt = connectedToGatt;
    }

}
