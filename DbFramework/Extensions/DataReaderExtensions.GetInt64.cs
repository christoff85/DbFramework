using System;
using System.Data;

namespace DbFramework.Extensions
{
	public static partial class DataReaderExtensions
	{
		/// <summary> Gets the value of the specified column as a Int64 </summary>
		/// <exception cref="IndexOutOfRangeException"></exception>
		public static long GetInt64(this IDataReader reader, string name)
			=> reader.GetValueByName(name, reader.GetInt64);

		/// <summary> Gets the value of the specified column as a Int64 or default(long), if column value is DbNull. </summary>
		public static long GetInt64OrDefault(this IDataReader reader, string columnName)
			=> reader.GetValueOrDefault(columnName, reader.GetInt64);

		/// <summary> Gets the value of the specified column as a Int64 or given default, if column value is DbNull. </summary>
		public static long GetInt64OrDefault(this IDataReader reader, string columnName, long defaultValue)
			=> reader.GetValueOrDefault(columnName, defaultValue, reader.GetInt64);

		/// <summary> Gets the value of the specified column as a Int64 or default(long), if column value is DbNull. </summary>
		public static long GetInt64OrDefault(this IDataReader reader, int columnIndex)
			=> reader.GetValueOrDefault(columnIndex, reader.GetInt64);

		/// <summary> Gets the value of the specified column as a Int64 or given default, if column value is DbNull. </summary>
		public static long GetInt64OrDefault(this IDataReader reader, int columnIndex, long defaultValue)
			=> reader.GetValueOrDefault(columnIndex, defaultValue, reader.GetInt64);

		/// <summary> Gets the value of the specified column as a Int64 or default(long?), if column value is DbNull. </summary>
		public static long? GetInt64NullableOrDefault(this IDataReader reader, string columnName)
			=> reader.GetValueOrDefault(columnName, reader.GetInt64NullableOrDefault);

		/// <summary> Gets the value of the specified column as a Int64 or given default, if column value is DbNull. </summary>
		public static long? GetInt64NullableOrDefault(this IDataReader reader, string columnName, long? defaultValue)
			=> reader.GetValueOrDefault(columnName, defaultValue, reader.GetInt64NullableOrDefault);

		/// <summary> Gets the value of the specified column as a Int64 or default(long?), if column value is DbNull. </summary>
		public static long? GetInt64NullableOrDefault(this IDataReader reader, int columnIndex)
			=> reader.GetNullableValueOrDefault(columnIndex, reader.GetInt64);

		/// <summary> Gets the value of the specified column as a Int64 or given default, if column value is DbNull. </summary>
		public static long? GetInt64NullableOrDefault(this IDataReader reader, int columnIndex, long? defaultValue)
			=> reader.GetNullableValueOrDefault(columnIndex, defaultValue, reader.GetInt64);
	}
}
