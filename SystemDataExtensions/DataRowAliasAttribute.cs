using System;

namespace SystemDataExtensions
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DataRowAliasAttribute : Attribute
    {
        public DataRowAliasAttribute(string ColumnName)
        {
            this.ColumnName = ColumnName;
        }

        public string ColumnName { get; protected set; }
    }
}
