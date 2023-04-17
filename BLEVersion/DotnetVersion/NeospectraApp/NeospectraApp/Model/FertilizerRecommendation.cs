using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeospectraApp.Model
{
    public class FertilizerRecommendation
    {
        public int Id { get; set; }
        public string Komoditas { get; set; }
        public double SP36 { get; set; }
        public double KCL { get; set; }
        public double Urea { get; set; }
        public double Urea_15 { get; set; }
        public double NPK_15 { get; set; }
    }
}
