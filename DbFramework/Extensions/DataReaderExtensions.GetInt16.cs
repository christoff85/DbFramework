using System;
using System.Data;

namespace DbFramework.Extensions
{
	public static partial class DataReaderExtensions
	{
		/// <summary> Gets the value of the specified column as a Int16 </summary>
		/// <exception cref="IndexOutOfRangeException"></exception>
		public static short GetInt16(this IDataReader reader, string name)
			=> reader.GetValueByName(name, reader.GetInt16);

		/// <summary> Gets the value of the specified column as a Int16 or default(short), if column value is DbNull. </summary>
		public static short GetInt16OrDefault(this IDataReader reader, string columnName)
			=> reader.GetValueOrDefault(columnName, reader.GetInt16);

		/// <summary> Gets the value of the specified column as a Int16 or given default, if column value is DbNull. </summary>
		public static short GetInt16OrDefault(this IDataReader reader, string columnName, short defaultValue)
			=> reader.GetValueOrDefault(columnName, defaultValue, reader.GetInt16);

		/// <summary> Gets the value of the specified column as a Int16 or default(short), if column value is DbNull. </summary>
		public static short GetInt16OrDefault(this IDataReader reader, int columnIndex)
			=> reader.GetValueOrDefault(columnIndex, reader.GetInt16);

		/// <summary> Gets the value of the specified column as a Int16 or given default, if column value is DbNull. </summary>
		public static short GetInt16OrDefault(this IDataReader reader, int columnIndex, short defaultValue)
			=> reader.GetValueOrDefault(columnIndex, defaultValue, reader.GetInt16);

		/// <summary> Gets the value of the specified column as a Int16 or default(short?), if column value is DbNull. </summary>
		public static short? GetInt16NullableOrDefault(this IDataReader reader, string columnName)
			=> reader.GetValueOrDefault(columnName, reader.GetInt16NullableOrDefault);

		/// <summary> Gets the value of the specified column as a Int16 or given default, if column value is DbNull. </summary>
		public static short? GetInt16NullableOrDefault(this IDataReader reader, string columnName, short? defaultValue)
			=> reader.GetValueOrDefault(columnName, defaultValue, reader.GetInt16NullableOrDefault);

		/// <summary> Gets the value of the specified column as a Int16 or default(short?), if column value is DbNull. </summary>
		public static short? GetInt16NullableOrDefault(this IDataReader reader, int columnIndex)
			=> reader.GetNullableValueOrDefault(columnIndex, reader.GetInt16);

		/// <summary> Gets the value of the specified column as a Int16 or given default, if column value is DbNull. </summary>
		public static short? GetInt16NullableOrDefault(this IDataReader reader, int columnIndex, short? defaultValue)
			=> reader.GetNullableValueOrDefault(columnIndex, defaultValue, reader.GetInt16);
	}
}
