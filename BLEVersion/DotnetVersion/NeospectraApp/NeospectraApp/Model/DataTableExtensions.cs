using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeospectraApp
{
    public static class DataTableExtensions
    {
        public static IEnumerable<dynamic> ToExpandoObjectList(this DataTable self)
        {
            var result = new List<dynamic>(self.Rows.Count);
            foreach (var row in self.Rows.OfType<DataRow>())
            {
                var expando = new ExpandoObject() as IDictionary<string, object>;
                foreach (var col in row.Table.Columns.OfType<DataColumn>())
                {
                    expando.Add(col.ColumnName, row[col]);
                }
                result.Add(expando);
            }
            return result;
        }
    }
}
