package com.gravicode.neospectralib.BluetoothSDK;
using android.app.Activity;
using android.content.Context;
using android.content.Intent;
using android.graphics.Typeface;
using android.os.AsyncTask;
using android.os.Build;
using android.provider.Settings;
using androidx.annotation.NonNull;
using android.text.TextUtils;
using android.util.Log;
using android.view.View;
using android.widget.Button;
using android.widget.ProgressBar;
using android.widget.TextView;
using com.polidea.rxandroidble2.RxBleDevice;
using com.gravicode.neospectralib.Global.GlobalVariables.apodization;
using com.gravicode.neospectralib.Global.GlobalVariables.command;
using com.gravicode.neospectralib.Global.GlobalVariables.opticalGain;
using com.gravicode.neospectralib.Global.GlobalVariables.pointsCount;
using com.gravicode.neospectralib.Global.GlobalVariables.runMode;
using com.gravicode.neospectralib.Global.GlobalVariables.zeroPadding;
using com.gravicode.neospectralib.R;
using java.nio.ByteBuffer;
using java.nio.ByteOrder;
using java.util.List;
using static;
com.gravicode.neospectralib.Global.GlobalVariables.MEMORY_CLEAR_REQUEST;
using static;
com.gravicode.neospectralib.Global.GlobalVariables.MEMORY_GET_SCANS_REQUEST;
using static;
com.gravicode.neospectralib.Global.GlobalVariables.MEMORY_STATUS_REQUEST;
using static;
com.gravicode.neospectralib.Global.GlobalVariables.SYSTEM_BATTERY_REQUEST;
using static;
com.gravicode.neospectralib.Global.GlobalVariables.SYSTEM_P3_ID_REQUEST;
using static;
com.gravicode.neospectralib.Global.GlobalVariables.SYSTEM_TEMPERATURE_REQUEST;
using static;
com.gravicode.neospectralib.Global.GlobalVariables.bluetoothAPI;
using static;
com.gravicode.neospectralib.Global.GlobalVariables.currentConnectedDevice;
using static;
com.gravicode.neospectralib.Global.GlobalVariables.gApodizationFunction;
using static;
com.gravicode.neospectralib.Global.GlobalVariables.gFftPoints;
using static;
com.gravicode.neospectralib.Global.GlobalVariables.gInterpolationPoints;
using static;
com.gravicode.neospectralib.Global.GlobalVariables.gIsInterpolationEnabled;
using static;
com.gravicode.neospectralib.Global.GlobalVariables.gOpticalGainSettings;
using static;
com.gravicode.neospectralib.Global.GlobalVariables.gOpticalGainValue;
using static;
com.gravicode.neospectralib.Global.GlobalVariables.gRunMode;
using static;
com.gravicode.neospectralib.Global.MethodsFactory.logMessage;
public class SWS_P3API {
    
    //  class members
    private SWS_P3ConnectionServices mP3ConnectionServices;
    
    // private AsyncConnection_old asyncConnection;
    private SWS_P3Packet mP3Packet;
    
    private bool InterpolationEnabled = false;
    
    private bool isConnected = false;
    
    private Context mContext;
    
    private Thread connectionCheckThread;
    
    public SWS_P3ConnectionServices getmP3ConnectionServices() {
        return this.mP3ConnectionServices;
    }
    
    public void setmP3ConnectionServices(SWS_P3ConnectionServices mP3ConnectionServices) {
        this.mP3ConnectionServices = this.mP3ConnectionServices;
    }
    
    public SWS_P3Packet getmP3Packet() {
        return this.mP3Packet;
    }
    
    public void setmP3Packet(SWS_P3Packet mP3Packet) {
        this.mP3Packet = this.mP3Packet;
    }
    
    public bool isInterpolationEnabled() {
        return this.InterpolationEnabled;
    }
    
    public void setInterpolationEnabled(bool interpolationEnabled) {
        this.InterpolationEnabled = interpolationEnabled;
    }
    
    public SWS_P3API(Activity mActivity, Context pContext) {
        this.mContext = pContext;
        this.mP3ConnectionServices = new SWS_P3ConnectionServices(mActivity, pContext);
        this.connectionCheckThread = new Thread(new Runnable());
    }
    
    [Deprecated()]
    public bool connectToDevice(RxBleDevice mRxBleDevice) {
        this.mP3ConnectionServices.setmRxBleDevice(mRxBleDevice);
        this.mP3ConnectionServices.ConnectToP3();
        return this.mP3ConnectionServices.isConnected();
    }
    
    public bool isDeviceConnected() {
        return this.mP3ConnectionServices.isConnected();
    }
    
    public bool disconnectFromDevice() {
        this.mP3ConnectionServices.DisconnectFromP3();
        //  Empty the current device
        if ((currentConnectedDevice != null)) {
            currentConnectedDevice = null;
        }
        
        logMessage("bluetooth", "The device has been disconnected");
        return true;
    }
    
    public bool sendPacket(byte[] mPacketContent, bool mInterpolationStatus, String BLE_Service) {
        switch (BLE_Service) {
            case "P3 Service":
                this.mP3ConnectionServices.WriteToP3(mPacketContent);
                break;
            case "Memory Service":
                this.mP3ConnectionServices.WriteToMemoryService(mPacketContent);
                break;
            case "Battery Service":
                this.mP3ConnectionServices.WriteToSystemService(mPacketContent);
                break;
            default:
                this.mP3ConnectionServices.WriteToP3(mPacketContent);
                break;
        }
        return true;
    }
    
    public bool sendPacket(byte[] mPacketContent, bool mInterpolationStatus) {
        this.mP3ConnectionServices.WriteToP3(mPacketContent);
        return true;
    }
    
    //     public boolean sendOTAPacket(int indexOfFile) {
    //         //mP3ConnectionServices.setmInterpolationEnabled(mInterpolationStatus);
    //         mP3ConnectionServices.WriteOTAService(indexOfFile);
    //         //mP3ConnectionServices.writeData(Arrays.copyOfRange(binaryOTAFileInBytes, indexOfFile * OTA_MAX_TRANSMISSION_UNIT, (indexOfFile+1)* OTA_MAX_TRANSMISSION_UNIT));
    //         return true;
    //     }
    public bool sendOTAPacket(byte[] packetStream) {
        this.mP3ConnectionServices.WriteOTAService(packetStream);
        return true;
    }
    
    public bool setSourceSettings() {
        byte[] packetStream = new byte[20];
        for (int i = 0; (i < 20); i++) {
            packetStream[i] = ((byte)(0));
        }
        
        packetStream[0] = ((byte)(22));
        packetStream[1] = ((byte)(2));
        packetStream[2] = ((byte)(0));
        packetStream[3] = ((byte)(0));
        packetStream[4] = ((byte)(0));
        packetStream[5] = ((byte)(14));
        packetStream[6] = ((byte)(2));
        packetStream[7] = ((byte)(0));
        packetStream[8] = ((byte)(0));
        packetStream[9] = ((byte)(5));
        packetStream[10] = ((byte)(35));
        packetStream[11] = ((byte)(10));
        this.mP3ConnectionServices.WriteToP3(packetStream);
        return true;
    }
    
    public bool setOpticalSettings() {
        byte[] packetStream = new byte[20];
        for (int i = 0; (i < 20); i++) {
            packetStream[i] = ((byte)(0));
        }
        
        packetStream[0] = ((byte)(27));
        int gain = gOpticalGainValue;
        packetStream[1] = ((byte)((255 & gain)));
        packetStream[2] = ((byte)((255 
                    & (gain + 8))));
        this.mP3ConnectionServices.WriteToP3(packetStream);
        return true;
    }
    
    public void setNotifications() {
        this.mP3ConnectionServices.SetNotificationOnTXInP3();
        this.mP3ConnectionServices.SetNotificationOnMemTx();
        this.mP3ConnectionServices.SetNotificationOnBatTx();
    }
    
    public void getDVKReading() {
        this.mP3ConnectionServices.ReadFromP3();
        logMessage("bluetooth", "testing");
    }
    
    public SWS_P3ConnectionServices.ConnectionStatus getConnectionStatus() {
        return this.mP3ConnectionServices.getConnectionStatus();
    }
    
    public bool getCurrentConnectionStatus() {
        return this.mP3ConnectionServices.isConnected();
    }
    
    public List<SWS_P3BLEDevice> scanAvailableDevices() {
        return this.mP3ConnectionServices.ScanBTDevices();
    }
    
    public bool isBluetoothEnabled() {
        return this.mP3ConnectionServices.isBluetoothEnabled();
    }
    
    public void disableBluetooth() {
        this.mP3ConnectionServices.disableBluetooth();
    }
    
    public Intent enableBluetooth() {
        return this.mP3ConnectionServices.enableBluetooth();
    }
    
    public void getLocationPermissions() {
        logMessage("bluetooth", "getLocationPermissions()");
        this.mP3ConnectionServices.askForLocationPermissions();
    }
    
    public bool isLocationEnabled() {
    }
    
    int locationMode = 0;
    
    String locationProviders;
}
catchSettings.SettingNotFoundException;
e;
Unknown{e.printStackTrace();
return false;
Unknownreturn (locationMode != Settings.Secure.LOCATION_MODE_OFF);
Unknownelse{locationProviders = Settings.Secure.getString(mContext.getContentResolver(), Settings.Secure.LOCATION_PROVIDERS_ALLOWED);
return !TextUtils.isEmpty(locationProviders);
UnknownUnknownUnknown
    
    public void sendDefaultPacket() {
        //  create a new packet instance
        SWS_P3Packet newPacket = new SWS_P3Packet();
        //  Set run PSD operation ID.
        newPacket.setSWS_P3Packet_Command(command.Run_PSD.toString());
        newPacket.setSWS_P3Packet_ScanTime("2000");
        //  according to ISlam
        newPacket.setSWS_P3Packet_PointsCount(pointsCount.disable.toString());
        newPacket.setSWS_P3Packet_OpticalGain(opticalGain.UseSettingsSavedonDVK.toString());
        newPacket.setSWS_P3Packet_Apodization(apodization.Boxcar.toString());
        newPacket.setSWS_P3Packet_ZeroPadding(zeroPadding.points_32k.toString());
        newPacket.setSWS_P3Packet_RunMode(runMode.Single_Mode.toString());
        // printing the content received to the debug window
        Log.d("SWS DEBUG:", newPacket.getSWS_P3Packet_Command());
        Log.d("SWS DEBUG:", newPacket.getSWS_P3Packet_ScanTime());
        Log.d("SWS DEBUG:", newPacket.getSWS_P3Packet_PointsCount());
        Log.d("SWS DEBUG:", newPacket.getSWS_P3Packet_OpticalGain());
        Log.d("SWS DEBUG:", newPacket.getSWS_P3Packet_Apodization());
        Log.d("SWS DEBUG:", newPacket.getSWS_P3Packet_ZeroPadding());
        Log.d("SWS DEBUG:", newPacket.getSWS_P3Packet_RunMode());
        //  prepare the packet to be sent over the uart
        newPacket.preparePacketContent();
        //  send the values to the lowLevelInterface for sending
        bluetoothAPI.sendPacket(newPacket.getPacketStream(), newPacket.isInterpolationMode());
    }
    
    public void sendDefaultPacket(int scanTime) {
        //  create a new packet instance
        SWS_P3Packet newPacket = new SWS_P3Packet();
        //  Set run absorbance operation ID.
        newPacket.setSWS_P3Packet_Command(command.Run_Absorbance.toString());
        newPacket.setSWS_P3Packet_ScanTime(Integer.toString((scanTime * 1000)));
        //  according to ISlam
        if (gIsInterpolationEnabled) {
            newPacket.setSWS_P3Packet_PointsCount(gInterpolationPoints);
        }
        else {
            newPacket.setSWS_P3Packet_PointsCount(pointsCount.disable.toString());
        }
        
        if (((gOpticalGainSettings == null) 
                    || (gOpticalGainSettings.equals("") || gOpticalGainSettings.equals("Default")))) {
            newPacket.setSWS_P3Packet_OpticalGain(opticalGain.UseSettingsSavedonDVK.toString());
        }
        else {
            newPacket.setSWS_P3Packet_OpticalGain(opticalGain.UseExternalSettings.toString());
        }
        
        if ((gApodizationFunction == null)) {
            newPacket.setSWS_P3Packet_Apodization(apodization.Boxcar.toString());
        }
        else {
            newPacket.setSWS_P3Packet_Apodization(gApodizationFunction);
        }
        
        if ((gFftPoints == null)) {
            newPacket.setSWS_P3Packet_ZeroPadding(zeroPadding.points_8k.toString());
        }
        else {
            newPacket.setSWS_P3Packet_ZeroPadding(gFftPoints);
        }
        
        if ((gRunMode == null)) {
            newPacket.setSWS_P3Packet_RunMode(runMode.Single_Mode.toString());
        }
        else {
            newPacket.setSWS_P3Packet_RunMode(gRunMode);
        }
        
        // printing the content received to the debug window
        Log.d("SWS DEBUG:", newPacket.getSWS_P3Packet_Command());
        Log.d("SWS DEBUG:", newPacket.getSWS_P3Packet_ScanTime());
        Log.d("SWS DEBUG:", newPacket.getSWS_P3Packet_PointsCount());
        Log.d("SWS DEBUG:", newPacket.getSWS_P3Packet_OpticalGain());
        Log.d("SWS DEBUG:", newPacket.getSWS_P3Packet_Apodization());
        Log.d("SWS DEBUG:", newPacket.getSWS_P3Packet_ZeroPadding());
        Log.d("SWS DEBUG:", newPacket.getSWS_P3Packet_RunMode());
        //  prepare the packet to be sent over the uart
        newPacket.preparePacketContent();
        //  send the values to the lowLevelInterface for sending
        bluetoothAPI.sendPacket(newPacket.getPacketStream(), newPacket.isInterpolationMode());
    }
    
    public void sendBackgroundPacket() {
        //  create a new packet instance
        SWS_P3Packet newPacket = new SWS_P3Packet();
        //  Set run background operation ID.
        newPacket.setSWS_P3Packet_Command(command.Run_Background.toString());
        newPacket.setSWS_P3Packet_ScanTime("2000");
        //  according to ISlam
        newPacket.setSWS_P3Packet_PointsCount(pointsCount.disable.toString());
        newPacket.setSWS_P3Packet_OpticalGain(opticalGain.UseSettingsSavedonDVK.toString());
        newPacket.setSWS_P3Packet_Apodization(apodization.Boxcar.toString());
        newPacket.setSWS_P3Packet_ZeroPadding(zeroPadding.points_32k.toString());
        newPacket.setSWS_P3Packet_RunMode(runMode.Single_Mode.toString());
        // printing the content received to the debug window
        Log.d("SWS DEBUG:", newPacket.getSWS_P3Packet_Command());
        Log.d("SWS DEBUG:", newPacket.getSWS_P3Packet_ScanTime());
        Log.d("SWS DEBUG:", newPacket.getSWS_P3Packet_PointsCount());
        Log.d("SWS DEBUG:", newPacket.getSWS_P3Packet_OpticalGain());
        Log.d("SWS DEBUG:", newPacket.getSWS_P3Packet_Apodization());
        Log.d("SWS DEBUG:", newPacket.getSWS_P3Packet_ZeroPadding());
        Log.d("SWS DEBUG:", newPacket.getSWS_P3Packet_RunMode());
        //  prepare the packet to be sent over the uart
        newPacket.preparePacketContent();
        //  send the values to the lowLevelInterface for sending
        bluetoothAPI.sendPacket(newPacket.getPacketStream(), newPacket.isInterpolationMode());
    }
    
    public void sendBackgroundPacket(int scanTime) {
        //  create a new packet instance
        SWS_P3Packet newPacket = new SWS_P3Packet();
        //  Set run background operation ID.
        newPacket.setSWS_P3Packet_Command(command.Run_Background.toString());
        newPacket.setSWS_P3Packet_ScanTime(Integer.toString((scanTime * 1000)));
        //  according to ISlam
        if (gIsInterpolationEnabled) {
            newPacket.setSWS_P3Packet_PointsCount(gInterpolationPoints);
        }
        else {
            newPacket.setSWS_P3Packet_PointsCount(pointsCount.disable.toString());
        }
        
        if (((gOpticalGainSettings == null) 
                    || (gOpticalGainSettings.equals("") || gOpticalGainSettings.equals("Default")))) {
            newPacket.setSWS_P3Packet_OpticalGain(opticalGain.UseSettingsSavedonDVK.toString());
        }
        else {
            newPacket.setSWS_P3Packet_OpticalGain(opticalGain.UseExternalSettings.toString());
        }
        
        if ((gApodizationFunction == null)) {
            newPacket.setSWS_P3Packet_Apodization(apodization.Boxcar.toString());
        }
        else {
            newPacket.setSWS_P3Packet_Apodization(gApodizationFunction);
        }
        
        if ((gFftPoints == null)) {
            newPacket.setSWS_P3Packet_ZeroPadding(zeroPadding.points_8k.toString());
        }
        else {
            newPacket.setSWS_P3Packet_ZeroPadding(gFftPoints);
        }
        
        if ((gRunMode == null)) {
            newPacket.setSWS_P3Packet_RunMode(runMode.Single_Mode.toString());
        }
        else {
            newPacket.setSWS_P3Packet_RunMode(gRunMode);
        }
        
        // printing the content received to the debug window
        Log.d("SWS DEBUG:", newPacket.getSWS_P3Packet_Command());
        Log.d("SWS DEBUG:", newPacket.getSWS_P3Packet_ScanTime());
        Log.d("SWS DEBUG:", newPacket.getSWS_P3Packet_PointsCount());
        Log.d("SWS DEBUG:", newPacket.getSWS_P3Packet_OpticalGain());
        Log.d("SWS DEBUG:", newPacket.getSWS_P3Packet_Apodization());
        Log.d("SWS DEBUG:", newPacket.getSWS_P3Packet_ZeroPadding());
        Log.d("SWS DEBUG:", newPacket.getSWS_P3Packet_RunMode());
        //  prepare the packet to be sent over the uart
        newPacket.preparePacketContent();
        //  send the values to the lowLevelInterface for sending
        bluetoothAPI.sendPacket(newPacket.getPacketStream(), newPacket.isInterpolationMode());
    }
    
    public void sendSelfCalibrationPacket(int scanTime) {
        //  create a new packet instance
        SWS_P3Packet newPacket = new SWS_P3Packet();
        //  Set selfCorrection operation ID.
        newPacket.setSWS_P3Packet_Command(command.Run_SelfCorrection.toString());
        newPacket.setSWS_P3Packet_ScanTime(Integer.toString((scanTime * 1000)));
        //  according to ISlam
        if (gIsInterpolationEnabled) {
            newPacket.setSWS_P3Packet_PointsCount(gInterpolationPoints);
        }
        else {
            newPacket.setSWS_P3Packet_PointsCount(pointsCount.disable.toString());
        }
        
        if (((gOpticalGainSettings == null) 
                    || (gOpticalGainSettings.equals("") || gOpticalGainSettings.equals("Default")))) {
            newPacket.setSWS_P3Packet_OpticalGain(opticalGain.UseSettingsSavedonDVK.toString());
        }
        else {
            newPacket.setSWS_P3Packet_OpticalGain(opticalGain.UseExternalSettings.toString());
        }
        
        if ((gApodizationFunction == null)) {
            newPacket.setSWS_P3Packet_Apodization(apodization.Boxcar.toString());
        }
        else {
            newPacket.setSWS_P3Packet_Apodization(gApodizationFunction);
        }
        
        if ((gFftPoints == null)) {
            newPacket.setSWS_P3Packet_ZeroPadding(zeroPadding.points_8k.toString());
        }
        else {
            newPacket.setSWS_P3Packet_ZeroPadding(gFftPoints);
        }
        
        newPacket.setSWS_P3Packet_RunMode(runMode.Single_Mode.toString());
        // printing the content received to the debug window
        Log.d("SWS DEBUG:", newPacket.getSWS_P3Packet_Command());
        Log.d("SWS DEBUG:", newPacket.getSWS_P3Packet_ScanTime());
        Log.d("SWS DEBUG:", newPacket.getSWS_P3Packet_PointsCount());
        Log.d("SWS DEBUG:", newPacket.getSWS_P3Packet_OpticalGain());
        Log.d("SWS DEBUG:", newPacket.getSWS_P3Packet_Apodization());
        Log.d("SWS DEBUG:", newPacket.getSWS_P3Packet_ZeroPadding());
        //  Log.d("SWS DEBUG:", newPacket.getSWS_P3Packet_RunMode());
        //  prepare the packet to be sent over the uart
        newPacket.preparePacketContent();
        //  send the values to the lowLevelInterface for sending
        bluetoothAPI.sendPacket(newPacket.getPacketStream(), newPacket.isInterpolationMode());
    }
    
    public void sendRestoreToDefaultPacket() {
        //  create a new packet instance
        SWS_P3Packet newPacket = new SWS_P3Packet();
        //  Set restore to defaults operation ID.
        newPacket.setSWS_P3Packet_Command(command.Restore_Defaults.toString());
        newPacket.setSWS_P3Packet_ScanTime(Integer.toString(2000));
        //  according to ISlam
        if (gIsInterpolationEnabled) {
            newPacket.setSWS_P3Packet_PointsCount(gInterpolationPoints);
        }
        else {
            newPacket.setSWS_P3Packet_PointsCount(pointsCount.disable.toString());
        }
        
        if (((gOpticalGainSettings == null) 
                    || (gOpticalGainSettings.equals("") || gOpticalGainSettings.equals("Default")))) {
            newPacket.setSWS_P3Packet_OpticalGain(opticalGain.UseSettingsSavedonDVK.toString());
        }
        else {
            newPacket.setSWS_P3Packet_OpticalGain(opticalGain.UseExternalSettings.toString());
        }
        
        if ((gApodizationFunction == null)) {
            newPacket.setSWS_P3Packet_Apodization(apodization.Boxcar.toString());
        }
        else {
            newPacket.setSWS_P3Packet_Apodization(gApodizationFunction);
        }
        
        if ((gFftPoints == null)) {
            newPacket.setSWS_P3Packet_ZeroPadding(zeroPadding.points_8k.toString());
        }
        else {
            newPacket.setSWS_P3Packet_ZeroPadding(gFftPoints);
        }
        
        if ((gRunMode == null)) {
            newPacket.setSWS_P3Packet_RunMode(runMode.Single_Mode.toString());
        }
        else {
            newPacket.setSWS_P3Packet_RunMode(gRunMode);
        }
        
        // printing the content received to the debug window
        Log.d("SWS DEBUG:", newPacket.getSWS_P3Packet_Command());
        Log.d("SWS DEBUG:", newPacket.getSWS_P3Packet_ScanTime());
        Log.d("SWS DEBUG:", newPacket.getSWS_P3Packet_PointsCount());
        Log.d("SWS DEBUG:", newPacket.getSWS_P3Packet_OpticalGain());
        Log.d("SWS DEBUG:", newPacket.getSWS_P3Packet_Apodization());
        Log.d("SWS DEBUG:", newPacket.getSWS_P3Packet_ZeroPadding());
        Log.d("SWS DEBUG:", newPacket.getSWS_P3Packet_RunMode());
        //  prepare the packet to be sent over the uart
        newPacket.preparePacketContent();
        //  send the values to the lowLevelInterface for sending
        bluetoothAPI.sendPacket(newPacket.getPacketStream(), newPacket.isInterpolationMode());
    }
    
    public void sendStoreGainPacket() {
        //  create a new packet instance
        SWS_P3Packet newPacket = new SWS_P3Packet();
        //  Set restore to defaults operation ID.
        newPacket.setSWS_P3Packet_Command(command.Burn_Gain.toString());
        newPacket.setSWS_P3Packet_ScanTime(Integer.toString(2000));
        //  according to ISlam
        if (gIsInterpolationEnabled) {
            newPacket.setSWS_P3Packet_PointsCount(gInterpolationPoints);
        }
        else {
            newPacket.setSWS_P3Packet_PointsCount(pointsCount.disable.toString());
        }
        
        if (((gOpticalGainSettings == null) 
                    || (gOpticalGainSettings.equals("") || gOpticalGainSettings.equals("Default")))) {
            newPacket.setSWS_P3Packet_OpticalGain(opticalGain.UseSettingsSavedonDVK.toString());
        }
        else {
            newPacket.setSWS_P3Packet_OpticalGain(opticalGain.UseExternalSettings.toString());
        }
        
        if ((gApodizationFunction == null)) {
            newPacket.setSWS_P3Packet_Apodization(apodization.Boxcar.toString());
        }
        else {
            newPacket.setSWS_P3Packet_Apodization(gApodizationFunction);
        }
        
        if ((gFftPoints == null)) {
            newPacket.setSWS_P3Packet_ZeroPadding(zeroPadding.points_8k.toString());
        }
        else {
            newPacket.setSWS_P3Packet_ZeroPadding(gFftPoints);
        }
        
        if ((gRunMode == null)) {
            newPacket.setSWS_P3Packet_RunMode(runMode.Single_Mode.toString());
        }
        else {
            newPacket.setSWS_P3Packet_RunMode(gRunMode);
        }
        
        // printing the content received to the debug window
        Log.d("SWS DEBUG:", newPacket.getSWS_P3Packet_Command());
        Log.d("SWS DEBUG:", newPacket.getSWS_P3Packet_ScanTime());
        Log.d("SWS DEBUG:", newPacket.getSWS_P3Packet_PointsCount());
        Log.d("SWS DEBUG:", newPacket.getSWS_P3Packet_OpticalGain());
        Log.d("SWS DEBUG:", newPacket.getSWS_P3Packet_Apodization());
        Log.d("SWS DEBUG:", newPacket.getSWS_P3Packet_ZeroPadding());
        Log.d("SWS DEBUG:", newPacket.getSWS_P3Packet_RunMode());
        //  prepare the packet to be sent over the uart
        newPacket.preparePacketContent();
        //  send the values to the lowLevelInterface for sending
        bluetoothAPI.sendPacket(newPacket.getPacketStream(), newPacket.isInterpolationMode());
    }
    
    public void sendStoreSelfCorrectionPacket() {
        //  create a new packet instance
        SWS_P3Packet newPacket = new SWS_P3Packet();
        //  Set restore to defaults operation ID.
        newPacket.setSWS_P3Packet_Command(command.Burn_Self.toString());
        newPacket.setSWS_P3Packet_ScanTime(Integer.toString(2000));
        //  according to ISlam
        if (gIsInterpolationEnabled) {
            newPacket.setSWS_P3Packet_PointsCount(gInterpolationPoints);
        }
        else {
            newPacket.setSWS_P3Packet_PointsCount(pointsCount.disable.toString());
        }
        
        if (((gOpticalGainSettings == null) 
                    || (gOpticalGainSettings.equals("") || gOpticalGainSettings.equals("Default")))) {
            newPacket.setSWS_P3Packet_OpticalGain(opticalGain.UseSettingsSavedonDVK.toString());
        }
        else {
            newPacket.setSWS_P3Packet_OpticalGain(opticalGain.UseExternalSettings.toString());
        }
        
        if ((gApodizationFunction == null)) {
            newPacket.setSWS_P3Packet_Apodization(apodization.Boxcar.toString());
        }
        else {
            newPacket.setSWS_P3Packet_Apodization(gApodizationFunction);
        }
        
        if ((gFftPoints == null)) {
            newPacket.setSWS_P3Packet_ZeroPadding(zeroPadding.points_8k.toString());
        }
        else {
            newPacket.setSWS_P3Packet_ZeroPadding(gFftPoints);
        }
        
        if ((gRunMode == null)) {
            newPacket.setSWS_P3Packet_RunMode(runMode.Single_Mode.toString());
        }
        else {
            newPacket.setSWS_P3Packet_RunMode(gRunMode);
        }
        
        // printing the content received to the debug window
        Log.d("SWS DEBUG:", newPacket.getSWS_P3Packet_Command());
        Log.d("SWS DEBUG:", newPacket.getSWS_P3Packet_ScanTime());
        Log.d("SWS DEBUG:", newPacket.getSWS_P3Packet_PointsCount());
        Log.d("SWS DEBUG:", newPacket.getSWS_P3Packet_OpticalGain());
        Log.d("SWS DEBUG:", newPacket.getSWS_P3Packet_Apodization());
        Log.d("SWS DEBUG:", newPacket.getSWS_P3Packet_ZeroPadding());
        Log.d("SWS DEBUG:", newPacket.getSWS_P3Packet_RunMode());
        //  prepare the packet to be sent over the uart
        newPacket.preparePacketContent();
        //  send the values to the lowLevelInterface for sending
        bluetoothAPI.sendPacket(newPacket.getPacketStream(), newPacket.isInterpolationMode());
    }
    
    public void sendGainAdjustmentPacket() {
        //  create a new packet instance
        SWS_P3Packet newPacket = new SWS_P3Packet();
        //  gather information from different fields, according to Hossam.
        newPacket.setSWS_P3Packet_Command(command.Run_GainAdjustment.toString());
        newPacket.setSWS_P3Packet_ScanTime("2000");
        //  according to Islam
        newPacket.setSWS_P3Packet_PointsCount(pointsCount.disable.toString());
        newPacket.setSWS_P3Packet_OpticalGain(opticalGain.UseSettingsSavedonDVK.toString());
        newPacket.setSWS_P3Packet_Apodization(apodization.Boxcar.toString());
        newPacket.setSWS_P3Packet_ZeroPadding(zeroPadding.points_32k.toString());
        newPacket.setSWS_P3Packet_RunMode(runMode.Single_Mode.toString());
        // printing the content received to the debug window
        Log.d("SWS DEBUG:", newPacket.getSWS_P3Packet_Command());
        Log.d("SWS DEBUG:", newPacket.getSWS_P3Packet_ScanTime());
        Log.d("SWS DEBUG:", newPacket.getSWS_P3Packet_PointsCount());
        Log.d("SWS DEBUG:", newPacket.getSWS_P3Packet_OpticalGain());
        Log.d("SWS DEBUG:", newPacket.getSWS_P3Packet_Apodization());
        Log.d("SWS DEBUG:", newPacket.getSWS_P3Packet_ZeroPadding());
        Log.d("SWS DEBUG:", newPacket.getSWS_P3Packet_RunMode());
        //  prepare the packet to be sent over the uart
        newPacket.preparePacketContent();
        //  send the values to the lowLevelInterface for sending
        bluetoothAPI.sendPacket(newPacket.getPacketStream(), newPacket.isInterpolationMode());
    }
    
    public void setScannerID(long value) {
        ByteBuffer buffer = ByteBuffer.allocate((Long.BYTES + 1));
        buffer.order(ByteOrder.LITTLE_ENDIAN);
        buffer.put(((byte)(35)));
        buffer.putLong(value);
        mP3ConnectionServices.WriteToMemoryService(buffer.array());
    }
    
    public void sendP3_ID_Request() {
        byte[] byteArray = new byte[1];
        byteArray[0] = ((byte)(SYSTEM_P3_ID_REQUEST));
        mP3ConnectionServices.WriteToSystemService(byteArray);
    }
    
    public void sendTemperatureRequest() {
        byte[] byteArray = new byte[1];
        byteArray[0] = ((byte)(SYSTEM_TEMPERATURE_REQUEST));
        mP3ConnectionServices.WriteToSystemService(byteArray);
    }
    
    public void sendMemoryRequest() {
        byte[] byteArray = new byte[1];
        byteArray[0] = MEMORY_STATUS_REQUEST;
        mP3ConnectionServices.WriteToMemoryService(byteArray);
    }
    
    public void sendScansHistoryRequest(int fileNum) {
        byte[] byteArray = new byte[2];
        byteArray[0] = MEMORY_GET_SCANS_REQUEST;
        byteArray[1] = ((byte)(fileNum));
        mP3ConnectionServices.WriteToMemoryService(byteArray);
    }
    
    public void sendClearMemoryRequest() {
        byte[] byteArray = new byte[1];
        byteArray[0] = MEMORY_CLEAR_REQUEST;
        mP3ConnectionServices.WriteToMemoryService(byteArray);
    }
    
    public void sendBatRequest() {
        byte[] byteArray = new byte[1];
        byteArray[0] = ((byte)(SYSTEM_BATTERY_REQUEST));
        mP3ConnectionServices.WriteToSystemService(byteArray);
    }
    
    public void setHomeContext(Context context) {
        mP3ConnectionServices.setHomeActivityContext(context);
    }