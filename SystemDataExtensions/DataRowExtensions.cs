using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace SystemDataExtensions
{
    public static partial class DataRowExtensions
    {
        public static T ToObject<T>(this DataRow dataRow, PropertyModFlags propertyModFlags = PropertyModFlags.None)
            where T : new()
        {
            T item = new T();
            var itemPropertiesAliases = new Dictionary<string, PropertyInfo>();

            //Property Dict with AliasAttribute
            item.GetType().GetProperties().ToList().ForEach(prop =>
            {
                DataRowAliasAttribute attribute = prop.GetCustomAttribute<DataRowAliasAttribute>();
                if (attribute != null)
                {
                    itemPropertiesAliases.Add(attribute.ColumnName, prop);
                }
            });

            foreach (DataColumn column in dataRow.Table.Columns)
            {
                PropertyInfo property = itemPropertiesAliases.ContainsKey(column.ColumnName) ? itemPropertiesAliases[column.ColumnName] : item.GetType().GetProperty(column.ColumnName);

                if (property != null && dataRow[column] != DBNull.Value)
                {
                    object result = Convert.ChangeType(dataRow[column], property.PropertyType);

                    //Trim Strings
                    if (property.PropertyType == typeof(string) && propertyModFlags.HasFlag(PropertyModFlags.TrimStrings))
                    {
                        result = ((string)result).Trim();
                    }

                    property.SetValue(item, result, null);
                }
            }

            return item;
        }
    }
}
