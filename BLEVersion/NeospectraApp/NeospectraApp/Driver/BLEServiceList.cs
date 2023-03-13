using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Bluetooth.GenericAttributeProfile;
using Windows.Devices.Bluetooth;
using System.Reflection.PortableExecutable;
using Windows.Devices.Enumeration;

namespace NeospectraApp.Driver
{
    public class BLEServiceUID
    {
        public Guid UID { get; set; }

        public List<Guid> CharacteristicUIDs { get; set; }
        public BLEServiceUID(Guid UID)
        {
            this.UID = UID;
            CharacteristicUIDs = new List<Guid>();
        }
    }
    public class BLEServiceList
    {
        List<BLEServiceUID> BLEServiceUIDs;
        public BLEServiceList(BluetoothLEDevice bluetoothLeDevice)
        {
            this.BLEServiceUIDs = new List<BLEServiceUID>();
            Setup(bluetoothLeDevice);
        }

        async void Setup(BluetoothLEDevice bluetoothLeDevice)
        {
            GattDeviceServicesResult result = await bluetoothLeDevice.GetGattServicesAsync(BluetoothCacheMode.Uncached);

            if (result.Status == GattCommunicationStatus.Success)
            {
                var services = result.Services;
                foreach(var service in services) {

                    var svc = new BLEServiceUID(service.Uuid);
                    var accessStatus = await service.RequestAccessAsync();
                    if (accessStatus == DeviceAccessStatus.Allowed)
                    {
                        // BT_Code: Get all the child characteristics of a service. Use the cache mode to specify uncached characterstics only 
                        // and the new Async functions to get the characteristics of unpaired devices as well. 
                        var result2 = await service.GetCharacteristicsAsync(BluetoothCacheMode.Uncached);
                        if (result2.Status == GattCommunicationStatus.Success)
                        {
                           var  characteristics = result2.Characteristics;
                            foreach (var characteristic in characteristics)
                            {
                                svc.CharacteristicUIDs.Add(characteristic.Uuid);
                            }
                        }
                    }
                    BLEServiceUIDs.Add(svc);
                }
            }
        }

        public Guid? GetServiceUIDByCharacteristicUID(Guid UID)
        {
            foreach(var service in BLEServiceUIDs)
            {
                if(service.CharacteristicUIDs.Any(x=>x.Equals(UID)))
                {
                    return service.UID;
                }
            }
            return null;
        }
    }
}
