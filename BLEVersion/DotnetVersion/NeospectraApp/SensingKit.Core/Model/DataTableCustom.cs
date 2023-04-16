using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SensingKit.Core.Model
{
    public class DataTableCustom
    {
        public List<DataRowCustom> Rows { get; set; }

        public DataColumnCollection Columns { get; set; }

        public string TableName { get; set; }
        public DataTableCustom(string TableName)
        {
            this.TableName = TableName;

            this.Columns = new DataColumnCollection();
            this.Rows = new List<DataRowCustom>();
        }


        public void AcceptChanges()
        {
            //do nothing
        }

        public DataTableCustom() : this("Table1")
        {

        }

        public DataRowCustom NewRow()
        {
            var dr = new DataRowCustom();
            foreach (var item in this.Columns)
            {
                dr.Add(item.ColumnName, string.Empty);
            }
            return dr;
        }
    }

    public class DataColumnCollection : List<DataColumnCustom>
    {
        public void Add(string NewCol)
        {
            this.Add(new DataColumnCustom() { ColumnName = NewCol, ColumnIndex = this.Count });
        }
    }
    public class DataColumnCustom
    {
        public string ColumnName { get; set; }
        public int ColumnIndex { get; set; }
    }
    public class DataRowCustom : Dictionary<string, object>
    {
        public object this[int index]
        {
            get
            {
                var keys = this.Keys.ToList();
                return this[keys[index]];
            }
            set
            {
                var keys = this.Keys.ToList();
                this[keys[index]] = value;
            }
        }
    }


}
