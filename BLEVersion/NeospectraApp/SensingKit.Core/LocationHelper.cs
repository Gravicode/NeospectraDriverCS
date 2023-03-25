using Newtonsoft.Json;
using SensingKit.Core.Properties;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace SensingKit.Core
{
    public class LocationHelper
    {
        public static void Init()
        {
            var x = DataLokasi;
        }

        private static List<Lokasi> _lokasi;

        public static List<Lokasi> DataLokasi
        {
            get {
                if (_lokasi == null)
                {
                    _lokasi = JsonConvert.DeserializeObject<List<Lokasi>>(Resources.Lokasi);
                }
                return _lokasi; }
           
        }

        public static IEnumerable<string> GetPropinsi()
        {
            var data = DataLokasi.Select(x => x.Propinsi).Distinct();
            return data;
        }
        public static IEnumerable<string> GetKabupaten(string Propinsi=null)
        {
            if (Propinsi == null)
            {
                var data = DataLokasi.Select(x => x.Kabupaten);
                return data;
            }
            else
            {
                var data = from x in DataLokasi
                           where x.Propinsi == Propinsi
                           select x;
                if(data!=null && data.Count()>0)
                    return data.Select(x => x.Kabupaten).Distinct();
            }
            return null;
        }
    }

  

    public class Lokasi
    {
        public string Kabupaten { get; set; }
        public string Propinsi { get; set; }
        public string Pulau { get; set; }
        public string Pemerintahan { get; set; }
    }

}
