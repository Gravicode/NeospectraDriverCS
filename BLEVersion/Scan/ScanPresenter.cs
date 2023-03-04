package com.gravicode.neospectralib.Scan.Presenter;
using com.gravicode.neospectralib.BluetoothSDK.SWS_P3Packet;
using static;
com.gravicode.neospectralib.Global.GlobalVariables.bluetoothAPI;
public class ScanPresenter {
    
    private String TAG = getClass().getSimpleName();
    
    public void requestSensorReading(int scanTime) {
        bluetoothAPI.setSourceSettings();
        bluetoothAPI.setOpticalSettings();
        bluetoothAPI.sendDefaultPacket(scanTime);
    }
    
    public void requestBackgroundReading(int scanTime) {
        bluetoothAPI.setSourceSettings();
        bluetoothAPI.setOpticalSettings();
        bluetoothAPI.sendBackgroundPacket(scanTime);
    }
    
    public void requestSelfCalibration(int scanTime) {
        bluetoothAPI.setSourceSettings();
        bluetoothAPI.setOpticalSettings();
        bluetoothAPI.sendSelfCalibrationPacket(scanTime);
    }
    
    public void restoreToDefaultSettings() {
        bluetoothAPI.sendRestoreToDefaultPacket();
    }
    
    public void storingSettings() {
        bluetoothAPI.sendStoreGainPacket();
        bluetoothAPI.sendStoreSelfCorrectionPacket();
    }
    
    public void requestGainReading() {
        bluetoothAPI.sendGainAdjustmentPacket();
    }
    
    public void sendCustomPacket(SWS_P3Packet newPacket, String BLE_Service) {
        bluetoothAPI.sendPacket(newPacket.getPacketStream(), newPacket.isInterpolationMode(), BLE_Service);
    }
    
    public void sendOTACommand(SWS_P3Packet newPacket) {
        bluetoothAPI.sendOTAPacket(newPacket.getPacketStream());
    }
}
