using SensingKit.Core.Model;
using SensingKit.Core.Properties;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
//using System.Linq;
using System.Text.RegularExpressions;

namespace SensingKit.Core
{
    public class InputTypes
    {
        public const string INPUT_SELECT = "INPUT-SELECT";
        public const string INPUT_RANGE = "INPUT-RANGE";
    }

    public class FilterItem
    {
        public int ColIndex { get; set; }
        public string ColName { get; set; }
        public string Answer { get; set; }
        public FilterItem(int index,string colname, string value)
        {
            ColIndex = index;
            this.ColName = colname;
            this.Answer = value;
        }
    }
    public class FertilizerCalculator2
    {
        public bool IsReady { get; set; } = false;
        public List<string> ColTypes { get; set; }
        public DataTableCustom TableKB { get; set; }
        public DataTableCustom TableMetadata { get; set; }
        public FertilizerCalculator2()
        {
            InitLib(Resources.KB, Resources.KB_METADATA);
        }

        void InitLib(string DataKB, string DataMetadata)
        {
            ColTypes = new List<string>();
            if (DataKB != null)
            {
                var RowData = Regex.Split(DataKB, Environment.NewLine);
                int RowCounter = 0;
                TableKB = new DataTableCustom("KB");
                var ColCounter = 0;
                foreach (var row in RowData)
                {
                    var cols = row.Split(',');
                    RowCounter++;
                    //col type
                    if (RowCounter == 1)
                    {
                        foreach(var col in cols)
                        {
                            ColTypes.Add(col.ToUpper());
                        }
                    }else if (RowCounter == 2)
                    {
                        //colnames
                        foreach (var col in cols)
                        {
                            TableKB.Columns.Add(col.ToUpper());
                        }
                        TableKB.AcceptChanges();
                    }
                    else
                    {
                        ColCounter = 0;
                        var newRow = TableKB.NewRow();
                        foreach (var col in cols)
                        {
                            newRow[ColCounter++] = col;
                        }
                        TableKB.Rows.Add(newRow);
                    }
                    
                }
                
            }
            if (DataMetadata != null)
            {
                
                var RowData = Regex.Split(DataMetadata, Environment.NewLine);
                int RowCounter = 0;
                TableMetadata = new DataTableCustom("Metadata");
                var ColCounter = 0;
                foreach (var row in RowData)
                {
                    var cols = row.Split(',');
                    RowCounter++;
                    //col type
                   if (RowCounter == 1)
                    {
                        //colnames
                        foreach (var col in cols)
                        {
                            TableMetadata.Columns.Add(col);
                        }
                        TableMetadata.AcceptChanges();
                    }
                    else
                    {
                        ColCounter = 0;
                        var newRow = TableMetadata.NewRow();
                        foreach (var col in cols)
                        {
                            newRow[ColCounter++] = col;
                        }
                        TableMetadata.Rows.Add(newRow);
                    }
                }

            }
        }
        public FertilizerCalculator2(string KBPath, string MetadataPath)
        {
            try
            {
                var dataKBStr = string.Empty;
                var dataMetadataStr = string.Empty;
                if (File.Exists(KBPath))
                {
                    dataKBStr = File.ReadAllText(KBPath);
                }
                if (File.Exists(MetadataPath))
                {
                    dataMetadataStr = File.ReadAllText(MetadataPath);
                }
                if(!string.IsNullOrEmpty(dataKBStr) || !string.IsNullOrEmpty(dataMetadataStr))
                {
                    InitLib(dataKBStr,dataMetadataStr);
                    IsReady = true;
                }
            }
            catch
            {
                IsReady = false;
            }
        }
        
        List<object> GetDistinct(List<DataRowCustom> Items, int ColIndex)
        {
            var distinctList = new HashSet<object>();

            foreach(var item in Items)
            {
                if(!distinctList.Contains(item[ColIndex]))
                    distinctList.Add(item[ColIndex]);
            }
            var listFinal = new List<object>();
            foreach(var item in distinctList)
            {
                listFinal.Add(item);
            }
            return listFinal;
        }

        List<DataRowCustom> FilterData(List<DataRowCustom> Items, string Column, string ValueFilter)
        {
            var data = new List<DataRowCustom>();

            foreach (var item in Items)
            {
                if(item[Column].ToString() == ValueFilter)
                {
                    data.Add(item);
                }
              
            }
            return data;
        }

        List<DataRowCustom> FilterData(List<DataRowCustom> Items, int ColumnIndex, string ValueFilter)
        {
            var data = new List<DataRowCustom>();

            foreach (var item in Items)
            {
                if (item[ColumnIndex].ToString() == ValueFilter)
                {
                    data.Add(item);
                }

            }
            return data;
        }

        public void TestRecommendation(Dictionary<string,float> Unsur)
        {
            bool isSkip = false;
            var filters = new List<FilterItem>();
            var ColIdx = 1;
            var currentRows = TableKB.Rows;
            while (true)
            {
                isSkip = false;
                var ColName = TableKB.Columns[ColIdx].ColumnName;
                Console.WriteLine($"{ColName} ?");
                if (ColTypes[ColIdx] == InputTypes.INPUT_SELECT)
                {
                    var selections = GetDistinct(currentRows,ColIdx); 
                    //currentRows.Select(row => row[ColIdx]).Distinct().ToList();
                    if (selections.Count == 1 && selections[0].ToString() == "NA")
                    {
                        Console.WriteLine("SKIP QUESTION >>");
                        isSkip = true;
                        //goto skip;
                    }
                    if (!isSkip)
                    {
                        var selectstr = String.Join(", ", selections);
                        Console.WriteLine($"SELECTION: {selectstr}");
                    }
                }
                else if (ColTypes[ColIdx] == InputTypes.INPUT_RANGE)
                {
                    Console.WriteLine("INPUT MANUALLY:");
                }
                else
                {
                    break;
                }
                if (!isSkip)
                {
                    var answer = Console.ReadLine();
                    filters.Add(new FilterItem(ColIdx, ColName, answer));

                    if (ColTypes[ColIdx] == InputTypes.INPUT_RANGE)
                    {
                        var logicRows = FilterData(TableMetadata.Rows,"Column",ColName);
                        // TableMetadata.Rows.Where(x => x["Column"].ToString() == ColName).ToList();
                        foreach (var row in logicRows)
                        {
                            var exp = row["Logic"].ToString();
                            exp = exp.Replace("[X]", Unsur[ColName].ToString("n2"));
                            var res = LogicEvaluator.EvaluateLogicalExpression(exp);
                            if (res)
                            {
                                answer = row["Value"].ToString();
                                break;
                            }
                        }
                    }
                    currentRows = FilterData(currentRows, ColIdx, answer);
                        /*
                        (from x in currentRows
                                   where x[ColIdx].ToString() == answer
                                   select x).ToList();*/
                }
                //skip:
                ColIdx++;

                if (!ColTypes[ColIdx].StartsWith("INPUT")) break;
            }
            if (currentRows.Count == 1)
            {
                Console.WriteLine("THE RESULT IS:");
                for(var i=0;i< TableKB.Columns.Count;i++)
                {
                    if (ColTypes[i] == "OUTPUT")
                    {
                        Console.WriteLine($"{TableKB.Columns[i].ColumnName} : {currentRows[0][i]}");
                    }
                }
            }
        }
    }
}
