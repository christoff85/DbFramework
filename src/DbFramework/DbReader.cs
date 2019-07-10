using System;
using System.Data;
using DbFramework.Interfaces;

namespace DbFramework
{
	internal class DbReader : IDbReader
	{
	    private readonly IDataReader _reader;

		#region Boolean
		/// <summary> Gets the value of the specified column as a Boolean. </summary>
		public bool GetBoolean(string columnName)
			=> InvokeByName(columnName, _reader.GetBoolean);

		/// <summary> Gets the value of the specified column as a Boolean or default(bool), if column value is DbNull. </summary>
		public bool GetBooleanOrDefault(string columnName)
			=> GetValueOrDefault(columnName, _reader.GetBoolean);

		/// <summary> Gets the value of the specified column as a Boolean or given default, if column value is DbNull. </summary>
		public bool GetBooleanOrDefault(string columnName, bool defaultValue)
			=> GetValueOrDefault(columnName, defaultValue, _reader.GetBoolean);

		/// <summary> Gets the value of the specified column as a Boolean or default(bool?), if column value is DbNull. </summary>
		public bool? GetBooleanNullableOrDefault(string columnName)
			=> GetNullableValueOrDefault(columnName, _reader.GetBoolean);

		/// <summary> Gets the value of the specified column as a Boolean or given default, if column value is DbNull. </summary>
		public bool? GetBooleanNullableOrDefault(string columnName, bool? defaultValue)
			=> GetNullableValueOrDefault(columnName, defaultValue, _reader.GetBoolean);
		#endregion

		#region Byte
		/// <summary> Gets the value of the specified column as a Byte. </summary>
		public byte GetByte(string columnName)
			=> InvokeByName(columnName, _reader.GetByte);

		/// <summary> Gets the value of the specified column as a Byte or default(byte), if column value is DbNull. </summary>
		public byte GetByteOrDefault(string columnName)
			=> GetValueOrDefault(columnName, _reader.GetByte);

		/// <summary> Gets the value of the specified column as a Byte or given default, if column value is DbNull. </summary>
		public byte GetByteOrDefault(string columnName, byte defaultValue)
			=> GetValueOrDefault(columnName, defaultValue, _reader.GetByte);

		/// <summary> Gets the value of the specified column as a Byte or default(byte?), if column value is DbNull. </summary>
		public byte? GetByteNullableOrDefault(string columnName)
			=> GetNullableValueOrDefault(columnName, _reader.GetByte);

		/// <summary> Gets the value of the specified column as a Byte or given default, if column value is DbNull. </summary>
		public byte? GetByteNullableOrDefault(string columnName, byte? defaultValue)
			=> GetNullableValueOrDefault(columnName, defaultValue, _reader.GetByte);
		#endregion

		#region DateTime
		/// <summary> Gets the value of the specified column as a DateTime. </summary>
		public DateTime GetDateTime(string columnName)
			=> InvokeByName(columnName, _reader.GetDateTime);

		/// <summary> Gets the value of the specified column as a DateTime or default(DateTime), if column value is DbNull. </summary>
		public DateTime GetDateTimeOrDefault(string columnName)
			=> GetValueOrDefault(columnName, _reader.GetDateTime);

		/// <summary> Gets the value of the specified column as a DateTime or given default, if column value is DbNull. </summary>
		public DateTime GetDateTimeOrDefault(string columnName, DateTime defaultValue)
			=> GetValueOrDefault(columnName, defaultValue, _reader.GetDateTime);

		/// <summary> Gets the value of the specified column as a DateTime or default(DateTime?), if column value is DbNull. </summary>
		public DateTime? GetDateTimeNullableOrDefault(string columnName)
			=> GetNullableValueOrDefault(columnName, _reader.GetDateTime);

		/// <summary> Gets the value of the specified column as a DateTime or given default, if column value is DbNull. </summary>
		public DateTime? GetDateTimeNullableOrDefault(string columnName, DateTime? defaultValue)
			=> GetNullableValueOrDefault(columnName, defaultValue, _reader.GetDateTime);
		#endregion

		#region Decimal
		/// <summary> Gets the value of the specified column as a Decimal. </summary>
		public decimal GetDecimal(string columnName)
			=> InvokeByName(columnName, _reader.GetDecimal);

		/// <summary> Gets the value of the specified column as a Decimal or default(decimal), if column value is DbNull. </summary>
		public decimal GetDecimalOrDefault(string columnName)
			=> GetValueOrDefault(columnName, _reader.GetDecimal);

		/// <summary> Gets the value of the specified column as a Decimal or given default, if column value is DbNull. </summary>
		public decimal GetDecimalOrDefault(string columnName, decimal defaultValue)
			=> GetValueOrDefault(columnName, defaultValue, _reader.GetDecimal);

		/// <summary> Gets the value of the specified column as a Decimal or default(decimal?), if column value is DbNull. </summary>
		public decimal? GetDecimalNullableOrDefault(string columnName)
			=> GetNullableValueOrDefault(columnName, _reader.GetDecimal);

		/// <summary> Gets the value of the specified column as a Decimal or given default, if column value is DbNull. </summary>
		public decimal? GetDecimalNullableOrDefault(string columnName, decimal? defaultValue)
			=> GetNullableValueOrDefault(columnName, defaultValue, _reader.GetDecimal);
		#endregion

		#region Double
		/// <summary> Gets the value of the specified column as a Double. </summary>
		public double GetDouble(string columnName)
			=> InvokeByName(columnName, _reader.GetDouble);

		/// <summary> Gets the value of the specified column as a Double or default(double), if column value is DbNull. </summary>
		public double GetDoubleOrDefault(string columnName)
			=> GetValueOrDefault(columnName, _reader.GetDouble);

		/// <summary> Gets the value of the specified column as a Double or given default, if column value is DbNull. </summary>
		public double GetDoubleOrDefault(string columnName, double defaultValue)
			=> GetValueOrDefault(columnName, defaultValue, _reader.GetDouble);

		/// <summary> Gets the value of the specified column as a Double or default(double?), if column value is DbNull. </summary>
		public double? GetDoubleNullableOrDefault(string columnName)
			=> GetNullableValueOrDefault(columnName, _reader.GetDouble);

		/// <summary> Gets the value of the specified column as a Double or given default, if column value is DbNull. </summary>
		public double? GetDoubleNullableOrDefault(string columnName, double? defaultValue)
			=> GetNullableValueOrDefault(columnName, defaultValue, _reader.GetDouble);
		#endregion

		#region Float
		/// <summary> Gets the value of the specified column as a Float. </summary>
		public float GetFloat(string columnName)
			=> InvokeByName(columnName, _reader.GetFloat);

		/// <summary> Gets the value of the specified column as a Float or default(float), if column value is DbNull. </summary>
		public float GetFloatOrDefault(string columnName)
			=> GetValueOrDefault(columnName, _reader.GetFloat);

		/// <summary> Gets the value of the specified column as a Float or given default, if column value is DbNull. </summary>
		public float GetFloatOrDefault(string columnName, float defaultValue)
			=> GetValueOrDefault(columnName, defaultValue, _reader.GetFloat);

		/// <summary> Gets the value of the specified column as a Float or default(float?), if column value is DbNull. </summary>
		public float? GetFloatNullableOrDefault(string columnName)
			=> GetNullableValueOrDefault(columnName, _reader.GetFloat);

		/// <summary> Gets the value of the specified column as a Float or given default, if column value is DbNull. </summary>
		public float? GetFloatNullableOrDefault(string columnName, float? defaultValue)
			=> GetNullableValueOrDefault(columnName, defaultValue, _reader.GetFloat);
		#endregion

		#region Guid
		/// <summary> Gets the value of the specified column as a Guid. </summary>
		public Guid GetGuid(string columnName)
			=> InvokeByName(columnName, _reader.GetGuid);

		/// <summary> Gets the value of the specified column as a Guid or default(Guid), if column value is DbNull. </summary>
		public Guid GetGuidOrDefault(string columnName)
			=> GetValueOrDefault(columnName, _reader.GetGuid);

		/// <summary> Gets the value of the specified column as a Guid or given default, if column value is DbNull. </summary>
		public Guid GetGuidOrDefault(string columnName, Guid defaultValue)
			=> GetValueOrDefault(columnName, defaultValue, _reader.GetGuid);

		/// <summary> Gets the value of the specified column as a Guid or default(Guid?), if column value is DbNull. </summary>
		public Guid? GetGuidNullableOrDefault(string columnName)
			=> GetNullableValueOrDefault(columnName, _reader.GetGuid);

		/// <summary> Gets the value of the specified column as a Guid or given default, if column value is DbNull. </summary>
		public Guid? GetGuidNullableOrDefault(string columnName, Guid? defaultValue)
			=> GetNullableValueOrDefault(columnName, defaultValue, _reader.GetGuid);
		#endregion

		#region Int
		/// <summary> Gets the value of the specified column as a Int32. </summary>
		public int GetInt(string columnName)
			=> InvokeByName(columnName, _reader.GetInt32);

		/// <summary> Gets the value of the specified column as a Int32 or default(int), if column value is DbNull. </summary>
		public int GetIntOrDefault(string columnName)
			=> GetValueOrDefault(columnName, _reader.GetInt32);

		/// <summary> Gets the value of the specified column as a Int32 or given default, if column value is DbNull. </summary>
		public int GetIntOrDefault(string columnName, int defaultValue)
			=> GetValueOrDefault(columnName, defaultValue, _reader.GetInt32);

		/// <summary> Gets the value of the specified column as a Int32 or default(int?), if column value is DbNull. </summary>
		public int? GetIntNullableOrDefault(string columnName)
			=> GetNullableValueOrDefault(columnName, _reader.GetInt32);

		/// <summary> Gets the value of the specified column as a Int32 or given default, if column value is DbNull. </summary>
		public int? GetIntNullableOrDefault(string columnName, int? defaultValue)
			=> GetNullableValueOrDefault(columnName, defaultValue, _reader.GetInt32);
		#endregion

		#region Long
		/// <summary> Gets the value of the specified column as a Int32. </summary>
		public long GetLong(string columnName)
			=> InvokeByName(columnName, _reader.GetInt64);

		/// <summary> Gets the value of the specified column as a Int64 or default(long), if column value is DbNull. </summary>
		public long GetLongOrDefault(string columnName)
			=> GetValueOrDefault(columnName, _reader.GetInt64);

		/// <summary> Gets the value of the specified column as a Int64 or given default, if column value is DbNull. </summary>
		public long GetLongOrDefault(string columnName, long defaultValue)
			=> GetValueOrDefault(columnName, defaultValue, _reader.GetInt64);

		/// <summary> Gets the value of the specified column as a Int64 or default(long?), if column value is DbNull. </summary>
		public long? GetLongNullableOrDefault(string columnName)
			=> GetNullableValueOrDefault(columnName, _reader.GetInt64);

		/// <summary> Gets the value of the specified column as a Int64 or given default, if column value is DbNull. </summary>
		public long? GetLongNullableOrDefault(string columnName, long? defaultValue)
			=> GetNullableValueOrDefault(columnName, defaultValue, _reader.GetInt64);
		#endregion

		#region Short
		/// <summary> Gets the value of the specified column as a Int32. </summary>
		public short GetShort(string columnName)
			=> InvokeByName(columnName, _reader.GetInt16);

		/// <summary> Gets the value of the specified column as a Int16 or default(short), if column value is DbNull. </summary>
		public short GetShortOrDefault(string columnName)
			=> GetValueOrDefault(columnName, _reader.GetInt16);

		/// <summary> Gets the value of the specified column as a Int16 or given default, if column value is DbNull. </summary>
		public short GetShortOrDefault(string columnName, short defaultValue)
			=> GetValueOrDefault(columnName, defaultValue, _reader.GetInt16);

		/// <summary> Gets the value of the specified column as a Int16 or default(short?), if column value is DbNull. </summary>
		public short? GetShortNullableOrDefault(string columnName)
			=> GetNullableValueOrDefault(columnName, _reader.GetInt16);

		/// <summary> Gets the value of the specified column as a Int16 or given default, if column value is DbNull. </summary>
		public short? GetShortNullableOrDefault(string columnName, short? defaultValue)
			=> GetNullableValueOrDefault(columnName, defaultValue, _reader.GetInt16);
		#endregion

		#region String
		/// <summary> Gets the value of the specified column as a String </summary>
		/// <exception cref="IndexOutOfRangeException"></exception>
		public string GetString(string name)
			=> InvokeByName(name, _reader.GetString);

		/// <summary> Gets the value of the specified column as a String or default(string), if column value is DbNull. </summary>
		public string GetStringOrDefault(string columnName)
			=> GetValueOrDefault(columnName, _reader.GetString);

		/// <summary> Gets the value of the specified column as a String or given default, if column value is DbNull. </summary>
		public string GetStringOrDefault(string columnName, string defaultValue)
			=> GetValueOrDefault(columnName, defaultValue, _reader.GetString);
		#endregion

		#region Helpers
		private T InvokeByName<T>(string columnName, Func<int, T> getValueMethod)
		{
			var index = _reader.GetOrdinal(columnName);
			return getValueMethod.Invoke(index);
		}

		private T GetValueOrDefault<T>(string columnName, Func<int, T> getValueMethod)
			=> GetValueOrDefault(columnName, default(T), getValueMethod);

		private T GetValueOrDefault<T>(string columnName, T defaultVal, Func<int, T> getValueMethod)
		{
			var index = _reader.GetOrdinal(columnName);
			return _reader.IsDBNull(index) ? defaultVal : getValueMethod(index);
		}

		private T? GetNullableValueOrDefault<T>(string columnName, Func<int, T> getValueMethod)
			where T : struct
			=> GetNullableValueOrDefault(columnName, default(T?), getValueMethod);
		
		private T? GetNullableValueOrDefault<T>(string columnName, T? defaultVal, Func<int, T> getValueMethod)
			where T : struct
		{
			var index = _reader.GetOrdinal(columnName);
			return _reader.IsDBNull(index) ? defaultVal : getValueMethod.Invoke(index);
		}
		#endregion

		#region BaseOperations
		public object this[int index]
			=> _reader[index];

		public int FieldCount
			=> _reader.FieldCount;

		public DbReader(IDataReader reader)
			=> _reader = reader ?? throw new ArgumentNullException(nameof(reader));

		public bool Read()
			=> _reader.Read();

		public bool NextResult()
			=> _reader.NextResult();

		public string GetName(int index)
			=> _reader.GetName(index);

		public bool IsDbNull(string columnName)
			=> InvokeByName(columnName, _reader.IsDBNull);

		public bool IsDbNull(int columnIndex)
			=> _reader.IsDBNull(columnIndex);
        #endregion

        public bool DoesColumnExist(string columnName)
	    {
	        var defaultView = _reader.GetSchemaTable()?.DefaultView;

	        if (defaultView == null)
	            return false;

	        defaultView.RowFilter = $"ColumnName= '{columnName}'";
	        return defaultView.Count > 0;
        }

	    public void Dispose()
		{
			_reader?.Dispose();
		}
	}
}
