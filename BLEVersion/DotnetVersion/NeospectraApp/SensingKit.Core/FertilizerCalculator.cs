using Newtonsoft.Json;
using SensingKit.Core.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text.RegularExpressions;

namespace SensingKit.Core
{
    public class FertilizerCalculator
    {
        bool IsReady = false;
        public string DataPath { get; set; }
        public List<FertilizerData> Datas { get; set; }
        public List<DataMappingNPK> DataNPK { get; set; }

        public FertilizerCalculator()
        {
            if (Datas == null)
            {
                Datas = JsonConvert.DeserializeObject<List<FertilizerData>>(Resources.Data);
                IsReady = true;
            }
            if (DataNPK == null)
            {
                var RowData = Regex.Split(Resources.NPK, Environment.NewLine);
                int RowCounter = 0;
                DataNPK = new List<DataMappingNPK>();
                foreach (var row in RowData)
                {
                    var cols = row.Split(',');
                    RowCounter++;
                    if (RowCounter > 1 && cols.Length == 6)
                    {
                        DataNPK.Add(new DataMappingNPK() { No = int.Parse(cols[0]), P205 = cols[1], K2O = cols[2], NPK = float.Parse(cols[3]), Urea = float.Parse(cols[4]), Jenis = cols[5] });
                    }
                }

            }
        }

        public FertilizerCalculator(string PathToData)
        {
            try
            {
                if (File.Exists(PathToData))
                {
                    this.DataPath = PathToData;
                    Datas = JsonConvert.DeserializeObject<List<FertilizerData>>(File.ReadAllText(PathToData));
                    IsReady = true;
                }
            }
            catch
            {
                IsReady = false;
            }
        }

        public double GetFertilizerDoze(double Unsur, string Tanaman = "Padi", string Pupuk = "Urea")
        {
            if (!IsReady) throw new Exception("Recommendation Data is not found.");

            var selConstant = from x in Datas
                              where x.Pupuk == Pupuk && x.Tanaman == Tanaman
                              select x;
            if (selConstant != null && selConstant.Count() > 0)
            {
                var Node = selConstant.SingleOrDefault();
                return (1 - Node.C1 * Unsur) / Node.C2;
            }
            return -1;
        }

        public (float NPK, float Urea) GetNPKDoze(float P2O5, float K2O, string Jenis = "Padi")
        {
            var conditionList = from x in DataNPK
                                where x.Jenis == Jenis
                                select x;
            foreach (var item in conditionList)
            {
                var conditionA = item.P205.Replace("$A", P2O5.ToString("n2"));
                var conditionB = item.K2O.Replace("$B", K2O.ToString("n2"));
                var a = LogicEvaluator.EvaluateLogicalExpression(conditionA);
                var b = LogicEvaluator.EvaluateLogicalExpression(conditionB);
                if (a && b) return (item.NPK, item.Urea);

            }
            return (0, 0);
        }
    }

    public class FertilizerData
    {
        public int No { get; set; }
        public string Tanaman { get; set; }
        public double C1 { get; set; }
        public double C2 { get; set; }
        public string Pupuk { get; set; }
    }

    public class DataMappingNPK
    {
        public int No { get; set; }
        public string P205 { get; set; }
        public string K2O { get; set; }
        public float Urea { get; set; }
        public float NPK { get; set; }
        public string Jenis { get; set; }
    }
}
