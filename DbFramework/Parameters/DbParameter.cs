using System;
using System.Data;
using DbFramework.Interfaces.Parameters;

namespace DbFramework.Parameters
{
	public class DbParameter : IDbParameter
	{
		public string Name { get; }

		public ParameterDirection Direction { get; }
		public object Value { get; set; }


		public object DbValue
		{
			get
			{
				if (Value == null || (Value is string && (string)Value == string.Empty))
					return DBNull.Value;

				return Value;
			}
		}

		public object OutValue
		{
			set => Value = value == DBNull.Value ? null : value;
		}

		public DbParameter(string key, object value) : this(key, value, ParameterDirection.Input) { }

		public DbParameter(string key, object value, ParameterDirection direction)
		{
			Name = key;
			Value = value;
			Direction = direction;
		}
	}
}