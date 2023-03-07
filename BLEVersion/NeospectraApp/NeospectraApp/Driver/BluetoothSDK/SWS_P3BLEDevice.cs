using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Bluetooth;
using Windows.Devices.Bluetooth.GenericAttributeProfile;

namespace NeospectraApp.Driver
{
    public class SWS_P3BLEDevice
    {

        private String DeviceName;
        private String DeviceMacAddress;
        private int DeviceRSSI;
        private BluetoothLEDevice DeviceInstance;
        public bool connected = false;


        private BluetoothLEDevice gattDeviceInstance = null; // The mi band
        private bool isConnectedToGatt = false; // the gatt connection
        private GattDeviceService myGatBand = null;

        //SWS_P3BLEDevice(String mName, String mMacAddress, int mRSSI, RxBleDevice mInstance)
        //{
        //    DeviceName = mName;
        //    DeviceMacAddress = mMacAddress;
        //    DeviceRSSI = mRSSI;
        //    DeviceInstance = mInstance;
        //}

        SWS_P3BLEDevice(String mName, String mMacAddress, int mRSSI, BluetoothLEDevice mInstance)
        {
            DeviceName = mName;
            DeviceMacAddress = mMacAddress;
            DeviceRSSI = mRSSI;
            gattDeviceInstance = mInstance;
            isConnectedToGatt = false;
        }

        public String getDeviceName()
        {
            return DeviceName;
        }

        public void setDeviceName(String deviceName)
        {
            DeviceName = deviceName;
        }

        public String getDeviceMacAddress()
        {
            return DeviceMacAddress;
        }

        public void setDeviceMacAddress(String deviceMacAddress)
        {
            DeviceMacAddress = deviceMacAddress;
        }

        public int getDeviceRSSI()
        {
            return DeviceRSSI;
        }

        public void setDeviceRSSI(int deviceRSSI)
        {
            DeviceRSSI = deviceRSSI;
        }

        public BluetoothLEDevice getDeviceInstance()
        {
            return DeviceInstance;
        }

        public void setDeviceInstance(BluetoothLEDevice deviceInstance)
        {
            DeviceInstance = deviceInstance;
        }

        public BluetoothLEDevice getGattDeviceInstance()
        {
            return gattDeviceInstance;
        }

        public void setGattDeviceInstance(BluetoothLEDevice gattDeviceInstance)
        {
            this.gattDeviceInstance = gattDeviceInstance;
        }
        public GattDeviceService getMyGatBand()
        {
            return myGatBand;
        }

        public void setMyGatBand(GattDeviceService myGatBand)
        {
            this.myGatBand = myGatBand;
        }

       

        public void setConnectedToGatt(bool connectedToGatt)
        {
            isConnectedToGatt = connectedToGatt;
        }

    }

}
