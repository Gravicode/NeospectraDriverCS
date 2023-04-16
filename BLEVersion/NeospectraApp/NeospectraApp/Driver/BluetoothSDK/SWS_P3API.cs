using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static NeospectraApp.Driver.GlobalVariables;
using Windows.Storage.Streams;
using Windows.UI;
using Windows.UI.Core;
using System.Diagnostics;
using Windows.Devices.Bluetooth;
using Windows.Devices.Geolocation;

namespace NeospectraApp.Driver
{
    public class SWS_P3API
    {

        // class members
        private SWS_P3ConnectionServices mP3ConnectionServices;
        //private AsyncConnection_old asyncConnection;
        private SWS_P3Packet mP3Packet;
        private bool InterpolationEnabled = false;
        private bool isConnected = false;
        //private Context mContext;
        private Thread connectionCheckThread;

        public SWS_P3ConnectionServices getmP3ConnectionServices()
        {
            return mP3ConnectionServices;
        }

        public void setmP3ConnectionServices(SWS_P3ConnectionServices mP3ConnectionServices)
        {
            this.mP3ConnectionServices = mP3ConnectionServices;
        }

        public SWS_P3Packet getmP3Packet()
        {
            return mP3Packet;
        }

        public void setmP3Packet(SWS_P3Packet mP3Packet)
        {
            this.mP3Packet = mP3Packet;
        }

        public bool isInterpolationEnabled()
        {
            return InterpolationEnabled;
        }

        public void setInterpolationEnabled(bool interpolationEnabled)
        {
            InterpolationEnabled = interpolationEnabled;
        }

        public SWS_P3API(CoreDispatcher dispatcher)
        {
            //this.mContext = pContext;
            mP3ConnectionServices = new SWS_P3ConnectionServices(dispatcher);

            connectionCheckThread = new Thread(() =>
            {
                while (true)
                {
                    try
                    {
                        Thread.Sleep(1000);
                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine(e);
                    }

                    if (mP3ConnectionServices == null)
                        return;

                    if (!mP3ConnectionServices.isConnected())
                    {
                        mP3ConnectionServices.broadcastdisconnectionNotification();
                        return;
                    }
                }

            });
        }

        public bool IsReady()
        {
            return mP3ConnectionServices.IsServiceReady();
        }
        //@Deprecated
        public bool connectToDevice(BluetoothLEDevice mRxBleDevice)
        {
            mP3ConnectionServices.setmRxBleDevice(mRxBleDevice);
            mP3ConnectionServices.ConnectToP3();
            return mP3ConnectionServices.isConnected();
        }
        /*
            public bool connectToDevice(SWS_P3BLEDevice swsDevice, ProgressBar progressBar, Button btn, TextView devicenam) {
                asyncConnection = new AsyncConnection_old(swsDevice, progressBar, btn, devicenam);
                asyncConnection.execute(swsDevice);
                return getCurrentConnectionStatus();
            }
        */
        public bool isDeviceConnected()
        {
            return mP3ConnectionServices.isConnected();
        }

        public bool disconnectFromDevice()
        {
            mP3ConnectionServices.DisconnectFromP3();
            /*
            if (asyncConnection != null) {
                asyncConnection.cancel(true);
            }*/
            // Empty the current device
            if (GlobalVariables.currentConnectedDevice != null) GlobalVariables.currentConnectedDevice = null;
            MethodsFactory.LogMessage("bluetooth", "The device has been disconnected");
            return true;
        }

        public bool sendPacket(byte[] mPacketContent, bool mInterpolationStatus, String BLE_Service)
        {
            switch (BLE_Service)
            {
                case "P3 Service":
                    mP3ConnectionServices.WriteToP3(mPacketContent);
                    break;
                case "Memory Service":
                    mP3ConnectionServices.WriteToMemoryService(mPacketContent);
                    break;
                case "Battery Service":
                    mP3ConnectionServices.WriteToSystemService(mPacketContent);
                    break;
                default:
                    mP3ConnectionServices.WriteToP3(mPacketContent);
                    break;
            }

            return true;
        }

        public bool sendPacket(byte[] mPacketContent, bool mInterpolationStatus)
        {
            mP3ConnectionServices.WriteToP3(mPacketContent);
            return true;
        }

        //public bool sendOTAPacket(int indexOfFile)
        //{
        //    //mP3ConnectionServices.setmInterpolationEnabled(mInterpolationStatus);
        //    mP3ConnectionServices.WriteOTAService(indexOfFile);
        //    //mP3ConnectionServices.writeData(Arrays.copyOfRange(binaryOTAFileInBytes, indexOfFile * OTA_MAX_TRANSMISSION_UNIT, (indexOfFile+1)* OTA_MAX_TRANSMISSION_UNIT));
        //    return true;
        //}


        public bool sendOTAPacket(byte[] packetStream)
        {
            mP3ConnectionServices.WriteOTAService(packetStream);
            return true;
        }

        public bool setSourceSettings()
        {
            byte[] packetStream = new byte[20];
            for (int i = 0; i < 20; i++)
            {
                packetStream[i] = (byte)0;
            }
            packetStream[0] = (byte)22;
            packetStream[1] = (byte)2;
            packetStream[2] = (byte)0;
            packetStream[3] = (byte)0;
            packetStream[4] = (byte)0;
            packetStream[5] = (byte)14;
            packetStream[6] = (byte)2;
            packetStream[7] = (byte)0;
            packetStream[8] = (byte)0;
            packetStream[9] = (byte)5;
            packetStream[10] = (byte)35;
            packetStream[11] = (byte)10;
            mP3ConnectionServices.WriteToP3(packetStream);
            return true;
        }

        public bool setOpticalSettings()
        {
            byte[] packetStream = new byte[20];
            for (int i = 0; i < 20; i++)
            {
                packetStream[i] = (byte)0;
            }
            packetStream[0] = (byte)27;
            int gain = gOpticalGainValue;
            packetStream[1] = (byte)(0xFF & gain);
            packetStream[2] = (byte)(0xFF & (gain >> 8));

            mP3ConnectionServices.WriteToP3(packetStream);
            return true;
        }

        public async Task<bool> setNotifications()
        {
            var res = await mP3ConnectionServices.SetNotificationOnTXInP3();
            var res2 = await mP3ConnectionServices.SetNotificationOnMemTx();
            var res3 = await mP3ConnectionServices.SetNotificationOnBatTx();
            return res && res2 && res3;
        }

        public void getDVKReading()
        {
            mP3ConnectionServices.ReadFromP3();
            MethodsFactory.LogMessage("bluetooth", "testing");
        }

        public SWS_P3ConnectionServices.ConnectionStatus getConnectionStatus()
        {

            return mP3ConnectionServices.getConnectionStatus();
        }

        public bool getCurrentConnectionStatus()
        {
            return mP3ConnectionServices.isConnected();
        }

        public async Task<List<SWS_P3BLEDevice>> scanAvailableDevices()
        {
            return await mP3ConnectionServices.ScanBTDevices();
        }

        public async Task<bool> isBluetoothEnabled()
        {
            return await mP3ConnectionServices.isBluetoothEnabled();
        }

        public void disableBluetooth()
        {
            mP3ConnectionServices.disableBluetooth();

        }

        public void enableBluetooth()
        {
            mP3ConnectionServices.enableBluetooth();
        }

        public async void getLocationPermissions()
        {
            MethodsFactory.LogMessage("bluetooth", "getLocationPermissions()");
            var res = await mP3ConnectionServices.askForLocationPermissions();
        }

        public async Task<bool> isLocationEnabled()
        {

            var accessStatus = await Geolocator.RequestAccessAsync();
            return accessStatus == GeolocationAccessStatus.Allowed;
        }

        public void sendDefaultPacket()
        {

            // create a new packet instance
            SWS_P3Packet newPacket = new SWS_P3Packet();

            // Set run PSD operation ID.
            newPacket.setSWS_P3Packet_Command(command.Run_PSD);
            newPacket.setSWS_P3Packet_ScanTime("2000"); // according to ISlam
            newPacket.setSWS_P3Packet_PointsCount(pointsCount.disable);
            newPacket.setSWS_P3Packet_OpticalGain(opticalGain.UseSettingsSavedonDVK);
            newPacket.setSWS_P3Packet_Apodization(apodization.Boxcar);
            newPacket.setSWS_P3Packet_ZeroPadding(zeroPadding.points_32k);
            newPacket.setSWS_P3Packet_RunMode(runMode.Single_Mode);

            //printing the content received to the debug window
            Debug.WriteLine("SWS DEBUG:" + newPacket.getSWS_P3Packet_Command());
            Debug.WriteLine("SWS DEBUG:" + newPacket.getSWS_P3Packet_ScanTime());
            Debug.WriteLine("SWS DEBUG:" + newPacket.getSWS_P3Packet_PointsCount());
            Debug.WriteLine("SWS DEBUG:" + newPacket.getSWS_P3Packet_OpticalGain());
            Debug.WriteLine("SWS DEBUG:" + newPacket.getSWS_P3Packet_Apodization());
            Debug.WriteLine("SWS DEBUG:" + newPacket.getSWS_P3Packet_ZeroPadding());
            Debug.WriteLine("SWS DEBUG:" + newPacket.getSWS_P3Packet_RunMode());

            // prepare the packet to be sent over the uart
            newPacket.preparePacketContent();

            // send the values to the lowLevelInterface for sending
            GlobalVariables.bluetoothAPI.sendPacket(newPacket.getPacketStream(), newPacket.isInterpolationMode());

        }

        public void sendDefaultPacket(int scanTime)
        {


            // create a new packet instance
            SWS_P3Packet newPacket = new SWS_P3Packet();

            // Set run absorbance operation ID.
            newPacket.setSWS_P3Packet_Command(command.Run_Absorbance);

            newPacket.setSWS_P3Packet_ScanTime((scanTime * 1000).ToString()); // according to ISlam

            if (gIsInterpolationEnabled)
                newPacket.setSWS_P3Packet_PointsCount(gInterpolationPoints);
            else
                newPacket.setSWS_P3Packet_PointsCount(pointsCount.disable);

            if ((gOpticalGainSettings == null) || (gOpticalGainSettings.Equals("")) || (gOpticalGainSettings.Equals("Default")))
                newPacket.setSWS_P3Packet_OpticalGain(opticalGain.UseSettingsSavedonDVK);
            else
                newPacket.setSWS_P3Packet_OpticalGain(opticalGain.UseExternalSettings);

            if (gApodizationFunction == null)
                newPacket.setSWS_P3Packet_Apodization(apodization.Boxcar);
            else
                newPacket.setSWS_P3Packet_Apodization(gApodizationFunction);


            if (gFftPoints == null)
                newPacket.setSWS_P3Packet_ZeroPadding(zeroPadding.points_8k);
            else
                newPacket.setSWS_P3Packet_ZeroPadding(gFftPoints);


            if (gRunMode == null)
                newPacket.setSWS_P3Packet_RunMode(runMode.Single_Mode);
            else
                newPacket.setSWS_P3Packet_RunMode(gRunMode);

            //printing the content received to the debug window
            Debug.WriteLine("SWS DEBUG:" + newPacket.getSWS_P3Packet_Command());
            Debug.WriteLine("SWS DEBUG:" + newPacket.getSWS_P3Packet_ScanTime());
            Debug.WriteLine("SWS DEBUG:" + newPacket.getSWS_P3Packet_PointsCount());
            Debug.WriteLine("SWS DEBUG:" + newPacket.getSWS_P3Packet_OpticalGain());
            Debug.WriteLine("SWS DEBUG:" + newPacket.getSWS_P3Packet_Apodization());
            Debug.WriteLine("SWS DEBUG:" + newPacket.getSWS_P3Packet_ZeroPadding());
            Debug.WriteLine("SWS DEBUG:" + newPacket.getSWS_P3Packet_RunMode());

            // prepare the packet to be sent over the uart
            newPacket.preparePacketContent();

            // send the values to the lowLevelInterface for sending
            bluetoothAPI.sendPacket(newPacket.getPacketStream(), newPacket.isInterpolationMode());
        }

        public void sendBackgroundPacket()
        {

            // create a new packet instance
            SWS_P3Packet newPacket = new SWS_P3Packet();

            // Set run background operation ID.
            newPacket.setSWS_P3Packet_Command(command.Run_Background);
            newPacket.setSWS_P3Packet_ScanTime("2000"); // according to ISlam
            newPacket.setSWS_P3Packet_PointsCount(pointsCount.disable);
            newPacket.setSWS_P3Packet_OpticalGain(opticalGain.UseSettingsSavedonDVK);
            newPacket.setSWS_P3Packet_Apodization(apodization.Boxcar);
            newPacket.setSWS_P3Packet_ZeroPadding(zeroPadding.points_32k);
            newPacket.setSWS_P3Packet_RunMode(runMode.Single_Mode);

            //printing the content received to the debug window
            Debug.WriteLine("SWS DEBUG:", newPacket.getSWS_P3Packet_Command());
            Debug.WriteLine("SWS DEBUG:", newPacket.getSWS_P3Packet_ScanTime());
            Debug.WriteLine("SWS DEBUG:", newPacket.getSWS_P3Packet_PointsCount());
            Debug.WriteLine("SWS DEBUG:", newPacket.getSWS_P3Packet_OpticalGain());
            Debug.WriteLine("SWS DEBUG:", newPacket.getSWS_P3Packet_Apodization());
            Debug.WriteLine("SWS DEBUG:", newPacket.getSWS_P3Packet_ZeroPadding());
            Debug.WriteLine("SWS DEBUG:", newPacket.getSWS_P3Packet_RunMode());

            // prepare the packet to be sent over the uart
            newPacket.preparePacketContent();

            // send the values to the lowLevelInterface for sending
            bluetoothAPI.sendPacket(newPacket.getPacketStream(), newPacket.isInterpolationMode());
        }

        public void sendBackgroundPacket(int scanTime)
        {

            // create a new packet instance
            SWS_P3Packet newPacket = new SWS_P3Packet();

            // Set run background operation ID.
            newPacket.setSWS_P3Packet_Command(command.Run_Background);
            newPacket.setSWS_P3Packet_ScanTime((scanTime * 1000).ToString()); // according to ISlam

            if (gIsInterpolationEnabled)
                newPacket.setSWS_P3Packet_PointsCount(gInterpolationPoints);
            else
                newPacket.setSWS_P3Packet_PointsCount(pointsCount.disable);

            if (gOpticalGainSettings == null || gOpticalGainSettings.Equals("") || gOpticalGainSettings.Equals("Default"))
                newPacket.setSWS_P3Packet_OpticalGain(opticalGain.UseSettingsSavedonDVK);
            else
                newPacket.setSWS_P3Packet_OpticalGain(opticalGain.UseExternalSettings);

            if (gApodizationFunction == null)
                newPacket.setSWS_P3Packet_Apodization(apodization.Boxcar);
            else
                newPacket.setSWS_P3Packet_Apodization(gApodizationFunction);


            if (gFftPoints == null)
                newPacket.setSWS_P3Packet_ZeroPadding(zeroPadding.points_8k);
            else
                newPacket.setSWS_P3Packet_ZeroPadding(gFftPoints);


            if (gRunMode == null)
                newPacket.setSWS_P3Packet_RunMode(runMode.Single_Mode);
            else
                newPacket.setSWS_P3Packet_RunMode(gRunMode);

            //printing the content received to the debug window
            Debug.WriteLine("SWS DEBUG:" + newPacket.getSWS_P3Packet_Command());
            Debug.WriteLine("SWS DEBUG:" + newPacket.getSWS_P3Packet_ScanTime());
            Debug.WriteLine("SWS DEBUG:" + newPacket.getSWS_P3Packet_PointsCount());
            Debug.WriteLine("SWS DEBUG:" + newPacket.getSWS_P3Packet_OpticalGain());
            Debug.WriteLine("SWS DEBUG:" + newPacket.getSWS_P3Packet_Apodization());
            Debug.WriteLine("SWS DEBUG:" + newPacket.getSWS_P3Packet_ZeroPadding());
            Debug.WriteLine("SWS DEBUG:" + newPacket.getSWS_P3Packet_RunMode());

            // prepare the packet to be sent over the uart
            newPacket.preparePacketContent();

            // send the values to the lowLevelInterface for sending
            bluetoothAPI.sendPacket(newPacket.getPacketStream(), newPacket.isInterpolationMode());
        }

        public void sendSelfCalibrationPacket(int scanTime)
        {

            // create a new packet instance
            SWS_P3Packet newPacket = new SWS_P3Packet();

            // Set selfCorrection operation ID.
            newPacket.setSWS_P3Packet_Command(command.Run_SelfCorrection);
            newPacket.setSWS_P3Packet_ScanTime((scanTime * 1000).ToString()); // according to ISlam

            if (gIsInterpolationEnabled)
                newPacket.setSWS_P3Packet_PointsCount(gInterpolationPoints);
            else
                newPacket.setSWS_P3Packet_PointsCount(pointsCount.disable);

            if (gOpticalGainSettings == null || gOpticalGainSettings.Equals("") || gOpticalGainSettings.Equals("Default"))
                newPacket.setSWS_P3Packet_OpticalGain(opticalGain.UseSettingsSavedonDVK);
            else
                newPacket.setSWS_P3Packet_OpticalGain(opticalGain.UseExternalSettings);

            if (gApodizationFunction == null)
                newPacket.setSWS_P3Packet_Apodization(apodization.Boxcar);
            else
                newPacket.setSWS_P3Packet_Apodization(gApodizationFunction);


            if (gFftPoints == null)
                newPacket.setSWS_P3Packet_ZeroPadding(zeroPadding.points_8k);
            else
                newPacket.setSWS_P3Packet_ZeroPadding(gFftPoints);



            newPacket.setSWS_P3Packet_RunMode(runMode.Single_Mode);


            //printing the content received to the debug window
            Debug.WriteLine("SWS DEBUG:" + newPacket.getSWS_P3Packet_Command());
            Debug.WriteLine("SWS DEBUG:" + newPacket.getSWS_P3Packet_ScanTime());
            Debug.WriteLine("SWS DEBUG:" + newPacket.getSWS_P3Packet_PointsCount());
            Debug.WriteLine("SWS DEBUG:" + newPacket.getSWS_P3Packet_OpticalGain());
            Debug.WriteLine("SWS DEBUG:" + newPacket.getSWS_P3Packet_Apodization());
            Debug.WriteLine("SWS DEBUG:" + newPacket.getSWS_P3Packet_ZeroPadding());
            // Debug.WriteLine("SWS DEBUG:", newPacket.getSWS_P3Packet_RunMode());

            // prepare the packet to be sent over the uart
            newPacket.preparePacketContent();

            // send the values to the lowLevelInterface for sending
            bluetoothAPI.sendPacket(newPacket.getPacketStream(), newPacket.isInterpolationMode());
        }


        public void sendRestoreToDefaultPacket()
        {

            // create a new packet instance
            SWS_P3Packet newPacket = new SWS_P3Packet();

            // Set restore to defaults operation ID.
            newPacket.setSWS_P3Packet_Command(command.Restore_Defaults);
            newPacket.setSWS_P3Packet_ScanTime((2000).ToString()); // according to ISlam

            if (gIsInterpolationEnabled)
                newPacket.setSWS_P3Packet_PointsCount(gInterpolationPoints);
            else
                newPacket.setSWS_P3Packet_PointsCount(pointsCount.disable);

            if (gOpticalGainSettings == null || gOpticalGainSettings.Equals("") || gOpticalGainSettings.Equals("Default"))
                newPacket.setSWS_P3Packet_OpticalGain(opticalGain.UseSettingsSavedonDVK);
            else
                newPacket.setSWS_P3Packet_OpticalGain(opticalGain.UseExternalSettings);

            if (gApodizationFunction == null)
                newPacket.setSWS_P3Packet_Apodization(apodization.Boxcar);
            else
                newPacket.setSWS_P3Packet_Apodization(gApodizationFunction);


            if (gFftPoints == null)
                newPacket.setSWS_P3Packet_ZeroPadding(zeroPadding.points_8k);
            else
                newPacket.setSWS_P3Packet_ZeroPadding(gFftPoints);


            if (gRunMode == null)
                newPacket.setSWS_P3Packet_RunMode(runMode.Single_Mode);
            else
                newPacket.setSWS_P3Packet_RunMode(gRunMode);

            //printing the content received to the debug window
            Debug.WriteLine("SWS DEBUG:" + newPacket.getSWS_P3Packet_Command());
            Debug.WriteLine("SWS DEBUG:" + newPacket.getSWS_P3Packet_ScanTime());
            Debug.WriteLine("SWS DEBUG:" + newPacket.getSWS_P3Packet_PointsCount());
            Debug.WriteLine("SWS DEBUG:" + newPacket.getSWS_P3Packet_OpticalGain());
            Debug.WriteLine("SWS DEBUG:" + newPacket.getSWS_P3Packet_Apodization());
            Debug.WriteLine("SWS DEBUG:" + newPacket.getSWS_P3Packet_ZeroPadding());
            Debug.WriteLine("SWS DEBUG:" + newPacket.getSWS_P3Packet_RunMode());

            // prepare the packet to be sent over the uart
            newPacket.preparePacketContent();

            // send the values to the lowLevelInterface for sending
            bluetoothAPI.sendPacket(newPacket.getPacketStream(), newPacket.isInterpolationMode());
        }


        public void sendStoreGainPacket()
        {

            // create a new packet instance
            SWS_P3Packet newPacket = new SWS_P3Packet();

            // Set restore to defaults operation ID.
            newPacket.setSWS_P3Packet_Command(command.Burn_Gain);
            newPacket.setSWS_P3Packet_ScanTime((2000).ToString()); // according to ISlam

            if (gIsInterpolationEnabled)
                newPacket.setSWS_P3Packet_PointsCount(gInterpolationPoints);
            else
                newPacket.setSWS_P3Packet_PointsCount(pointsCount.disable);

            if (gOpticalGainSettings == null || gOpticalGainSettings.Equals("") || gOpticalGainSettings.Equals("Default"))
                newPacket.setSWS_P3Packet_OpticalGain(opticalGain.UseSettingsSavedonDVK);
            else
                newPacket.setSWS_P3Packet_OpticalGain(opticalGain.UseExternalSettings);

            if (gApodizationFunction == null)
                newPacket.setSWS_P3Packet_Apodization(apodization.Boxcar);
            else
                newPacket.setSWS_P3Packet_Apodization(gApodizationFunction);


            if (gFftPoints == null)
                newPacket.setSWS_P3Packet_ZeroPadding(zeroPadding.points_8k);
            else
                newPacket.setSWS_P3Packet_ZeroPadding(gFftPoints);


            if (gRunMode == null)
                newPacket.setSWS_P3Packet_RunMode(runMode.Single_Mode);
            else
                newPacket.setSWS_P3Packet_RunMode(gRunMode);

            //printing the content received to the debug window
            Debug.WriteLine("SWS DEBUG:" + newPacket.getSWS_P3Packet_Command());
            Debug.WriteLine("SWS DEBUG:" + newPacket.getSWS_P3Packet_ScanTime());
            Debug.WriteLine("SWS DEBUG:" + newPacket.getSWS_P3Packet_PointsCount());
            Debug.WriteLine("SWS DEBUG:" + newPacket.getSWS_P3Packet_OpticalGain());
            Debug.WriteLine("SWS DEBUG:" + newPacket.getSWS_P3Packet_Apodization());
            Debug.WriteLine("SWS DEBUG:" + newPacket.getSWS_P3Packet_ZeroPadding());
            Debug.WriteLine("SWS DEBUG:" + newPacket.getSWS_P3Packet_RunMode());

            // prepare the packet to be sent over the uart
            newPacket.preparePacketContent();

            // send the values to the lowLevelInterface for sending
            bluetoothAPI.sendPacket(newPacket.getPacketStream(), newPacket.isInterpolationMode());
        }

        public void sendStoreSelfCorrectionPacket()
        {

            // create a new packet instance
            SWS_P3Packet newPacket = new SWS_P3Packet();

            // Set restore to defaults operation ID.
            newPacket.setSWS_P3Packet_Command(command.Burn_Self);
            newPacket.setSWS_P3Packet_ScanTime(2000.ToString()); // according to ISlam

            if (gIsInterpolationEnabled)
                newPacket.setSWS_P3Packet_PointsCount(gInterpolationPoints);
            else
                newPacket.setSWS_P3Packet_PointsCount(pointsCount.disable);

            if (gOpticalGainSettings == null || gOpticalGainSettings.Equals("") || gOpticalGainSettings.Equals("Default"))
                newPacket.setSWS_P3Packet_OpticalGain(opticalGain.UseSettingsSavedonDVK);
            else
                newPacket.setSWS_P3Packet_OpticalGain(opticalGain.UseExternalSettings);

            if (gApodizationFunction == null)
                newPacket.setSWS_P3Packet_Apodization(apodization.Boxcar);
            else
                newPacket.setSWS_P3Packet_Apodization(gApodizationFunction);


            if (gFftPoints == null)
                newPacket.setSWS_P3Packet_ZeroPadding(zeroPadding.points_8k);
            else
                newPacket.setSWS_P3Packet_ZeroPadding(gFftPoints);


            if (gRunMode == null)
                newPacket.setSWS_P3Packet_RunMode(runMode.Single_Mode);
            else
                newPacket.setSWS_P3Packet_RunMode(gRunMode);

            //printing the content received to the debug window
            Debug.WriteLine("SWS DEBUG:" + newPacket.getSWS_P3Packet_Command());
            Debug.WriteLine("SWS DEBUG:" + newPacket.getSWS_P3Packet_ScanTime());
            Debug.WriteLine("SWS DEBUG:" + newPacket.getSWS_P3Packet_PointsCount());
            Debug.WriteLine("SWS DEBUG:" + newPacket.getSWS_P3Packet_OpticalGain());
            Debug.WriteLine("SWS DEBUG:" + newPacket.getSWS_P3Packet_Apodization());
            Debug.WriteLine("SWS DEBUG:" + newPacket.getSWS_P3Packet_ZeroPadding());
            Debug.WriteLine("SWS DEBUG:" + newPacket.getSWS_P3Packet_RunMode());

            // prepare the packet to be sent over the uart
            newPacket.preparePacketContent();

            // send the values to the lowLevelInterface for sending
            bluetoothAPI.sendPacket(newPacket.getPacketStream(), newPacket.isInterpolationMode());
        }

        public void sendGainAdjustmentPacket()
        {

            // create a new packet instance
            SWS_P3Packet newPacket = new SWS_P3Packet();

            // gather information from different fields, according to Hossam.
            newPacket.setSWS_P3Packet_Command(command.Run_GainAdjustment);
            newPacket.setSWS_P3Packet_ScanTime("2000"); // according to Islam
            newPacket.setSWS_P3Packet_PointsCount(pointsCount.disable);
            newPacket.setSWS_P3Packet_OpticalGain(opticalGain.UseSettingsSavedonDVK);
            newPacket.setSWS_P3Packet_Apodization(apodization.Boxcar);
            newPacket.setSWS_P3Packet_ZeroPadding(zeroPadding.points_32k);
            newPacket.setSWS_P3Packet_RunMode(runMode.Single_Mode);

            //printing the content received to the debug window
            Debug.WriteLine("SWS DEBUG:" + newPacket.getSWS_P3Packet_Command());
            Debug.WriteLine("SWS DEBUG:" + newPacket.getSWS_P3Packet_ScanTime());
            Debug.WriteLine("SWS DEBUG:" + newPacket.getSWS_P3Packet_PointsCount());
            Debug.WriteLine("SWS DEBUG:" + newPacket.getSWS_P3Packet_OpticalGain());
            Debug.WriteLine("SWS DEBUG:" + newPacket.getSWS_P3Packet_Apodization());
            Debug.WriteLine("SWS DEBUG:" + newPacket.getSWS_P3Packet_ZeroPadding());
            Debug.WriteLine("SWS DEBUG:" + newPacket.getSWS_P3Packet_RunMode());

            // prepare the packet to be sent over the uart
            newPacket.preparePacketContent();

            // send the values to the lowLevelInterface for sending
            bluetoothAPI.sendPacket(newPacket.getPacketStream(), newPacket.isInterpolationMode());
        }

        public void setScannerID(long value)
        {
            ByteBuffer buffer = new ByteBuffer(sizeof(long) + 1);
            buffer.Put((byte)0x23);
            buffer.PutLong(value);
            mP3ConnectionServices.WriteToMemoryService(buffer.ToArray());
            /*
            ByteBuffer buffer = ByteBuffer.allocate(Long.BYTES + 1);
            buffer.order(ByteOrder.LITTLE_ENDIAN);
            buffer.put((byte)0x23);
            buffer.putLong(value);
            mP3ConnectionServices.WriteToMemoryService(buffer.array());
            */
        }

        public void sendP3_ID_Request()
        {
            byte[] byteArray = new byte[1];
            byteArray[0] = (byte)SYSTEM_P3_ID_REQUEST;
            mP3ConnectionServices.WriteToSystemService(byteArray);
        }

        public void sendTemperatureRequest()
        {
            byte[] byteArray = new byte[1];
            byteArray[0] = (byte)SYSTEM_TEMPERATURE_REQUEST;
            mP3ConnectionServices.WriteToSystemService(byteArray);
        }

        public void sendMemoryRequest()
        {
            byte[] byteArray = new byte[1];
            byteArray[0] = MEMORY_STATUS_REQUEST;
            mP3ConnectionServices.WriteToMemoryService(byteArray);
        }

        public void sendScansHistoryRequest(int fileNum)
        {
            byte[] byteArray = new byte[2];
            byteArray[0] = MEMORY_GET_SCANS_REQUEST;
            byteArray[1] = (byte)fileNum;
            mP3ConnectionServices.WriteToMemoryService(byteArray);
        }

        public void sendClearMemoryRequest()
        {
            byte[] byteArray = new byte[1];
            byteArray[0] = MEMORY_CLEAR_REQUEST;
            mP3ConnectionServices.WriteToMemoryService(byteArray);
        }

        public void sendBatRequest()
        {
            byte[] byteArray = new byte[1];
            byteArray[0] = (byte)SYSTEM_BATTERY_REQUEST;
            mP3ConnectionServices.WriteToSystemService(byteArray);
        }

        public void setHomeContext()
        {
            //mP3ConnectionServices.setHomeActivityContext(context);
        }
        /*
            class AsyncConnection extends AsyncTask<SWS_P3BLEDevice, Void, bool> {
                ProgressBar pb;
                Button btnConnect;
                bool waitForConnectionResult = false;

                public AsyncConnection(ProgressBar progressBar, Button btn) {
                    this.pb = progressBar;
                    this.btnConnect = btn;

                }

                @Override
                protected bool doInBackground(SWS_P3BLEDevice... sws_p3BLEDevices) {

                    waitForConnectionResult = true;
                    // set the current device to my global device
                    currentConnectedDevice = sws_p3BLEDevices[0];
                    RxBleDevice myDevice = currentConnectedDevice.getDeviceInstance();
                    //Set the device
                    mP3ConnectionServices.setmRxBleDevice(myDevice);
                    //Connect to it
                    mP3ConnectionServices.ConnectToP3();
                    //Lock the thread while finding a channel
                    while (mP3ConnectionServices.getConnectionStatus() == SWS_P3ConnectionServices.ConnectionStatus.findingChannel) {
                        isConnected = false;
                        logMessage("bluetooth", "finding a channel");
                    }

                    if (mP3ConnectionServices.getConnectionStatus() == SWS_P3ConnectionServices.ConnectionStatus.failedToGetChannel) {
                        logMessage("bluetooth", "Failed to get a channel to connect to the sensor");
                        return false;
                    } else {
                        if (mP3ConnectionServices.getConnectionStatus() == SWS_P3ConnectionServices.ConnectionStatus.gotChannel) {
                            mP3ConnectionServices.setConnectionStatus(SWS_P3ConnectionServices.ConnectionStatus.connecting);
                        }
                        // get the connection status, this method will change the state of the parameter "connectionStatus"
                        isConnected = getCurrentConnectionStatus();
                        //Loop till the connection is success
                        while (mP3ConnectionServices.getConnectionStatus() != SWS_P3ConnectionServices.ConnectionStatus.connected) {
                            logMessage("bluetooth", "Connecting ...");
                        }
                    }
                    logMessage("bluetooth", "Connecting result equals: " + isConnected);
                    //set notification signal to the sensor
                    bluetoothAPI.setNotifications();
                    //update the status of isConnected
                    isConnected = getCurrentConnectionStatus();
                    // return the connection status
                    return isConnected;
                }

                private void setCurrentDeviceNull() {
                    currentConnectedDevice = null;
                }

                @Override
                protected void onPostExecute(bool abool) {
                    super.onPostExecute(abool);
                    if (!abool) {
                        logMessage("bluetooth", "Device failed to connect");
                        return;
                    }
                    logMessage("bluetooth", "Device is connected successfully");
                    pb.setVisibility(View.INVISIBLE);
                    //btnConnect.setText(mContext.getResources().getString(R.string.disconnect));
                    waitForConnectionResult = false;
                }

                @Override
                protected void onCancelled() {
                    super.onCancelled();
                    logMessage("bluetooth", "AsyncTask has cancelled");
                    setCurrentDeviceNull();
                    disconnectFromDevice();
                }
            }

            class AsyncConnection_old extends AsyncTask<SWS_P3BLEDevice, Void, bool> {
                ProgressBar pb;
                Button btnConnect;
                TextView devicename;
                SWS_P3BLEDevice swsDevice;

                public AsyncConnection_old(SWS_P3BLEDevice swsDevice, ProgressBar progressBar, Button btn, TextView devicenam) {
                    this.pb = progressBar;
                    this.btnConnect = btn;
                    this.devicename = devicenam;
                    this.swsDevice = swsDevice;
                }

                @Override
                protected bool doInBackground(SWS_P3BLEDevice... sws_p3BLEDevices) {

                    // set the current device to my global device
                    currentConnectedDevice = sws_p3BLEDevices[0];
                    RxBleDevice myDevice = sws_p3BLEDevices[0].getDeviceInstance();

                    if (mP3ConnectionServices.getmRxBleDevice() != myDevice)
                    {
                        //Set the device
                        mP3ConnectionServices.setmRxBleDevice(myDevice);
                        //Connect to it
                        mP3ConnectionServices.ConnectToP3();


                        while (!getCurrentConnectionStatus()) {
                            logMessage("bluetooth", "Connecting ..., isConnected equals: " + getCurrentConnectionStatus());
                        }

                        //set notification signal to the sensor
                        bluetoothAPI.setNotifications();
                        connectionCheckThread.start();
                    }
                    // return the connection status
                    return getCurrentConnectionStatus();
                }

                private void setCurrentDeviceNull() {
                    currentConnectedDevice = null;
                }

                @Override
                protected void onPostExecute(bool abool) {
                    super.onPostExecute(abool);
                    if (!abool) {
                        logMessage("bluetooth", "Device failed to connect");
                        return;
                    }
                    logMessage("bluetooth", "Device is connected successfully");
                    pb.setVisibility(View.INVISIBLE);
                    //btnConnect.setText(mContext.getResources().getString(R.string.disconnect));
                    swsDevice.connected = true;
                    devicename.setTypeface(Typeface.DEFAULT_BOLD);
                }

                @Override
                protected void onCancelled() {
                    super.onCancelled();
                    logMessage("bluetooth", "AsyncTask has cancelled");
                }
            }
            */
    }
}