using System;
using System.Data;
using DbFramework.Interfaces;

namespace DbFramework
{
	internal class DbParameter : IDbParameter
	{
		public string Name { get; }

		public ParameterDirection Direction { get; }
	    public DbType? DatabaseType { get; }
		public object Value { get; set; }

        public object DbValue
		{
			get
			{
			    if (Value == null || (Value is string s && s == string.Empty))
			        return DBNull.Value;

				return Value;
			}
		}

		public object OutValue
		{
			set => Value = value == DBNull.Value ? null : value;
		}

		public DbParameter(string key, object value, DbType? dbType = null) 
		    : this(key, value, ParameterDirection.Input, dbType) { }

	    public DbParameter(string key, object value, ParameterDirection direction, DbType? dbType = null)
	    {
	        Name = key;
	        Value = value;
	        Direction = direction;
	        DatabaseType = dbType;
        }

	    public TValue GetValue<TValue>() => (TValue)Value;
    }
}