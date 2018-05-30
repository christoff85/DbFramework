using System;
using System.Data;

namespace DbFramework.Extensions
{
	public static partial class DataReaderExtensions
	{
		/// <summary> Gets the value of the specified column as a Int32 </summary>
		/// <exception cref="IndexOutOfRangeException"></exception>
		public static int GetInt32(this IDataReader reader, string name)
			=> reader.GetValueByName(name, reader.GetInt32);

		/// <summary> Gets the value of the specified column as a Int32 or default(int), if column value is DbNull. </summary>
		public static int GetInt32OrDefault(this IDataReader reader, string columnName)
			=> reader.GetValueOrDefault(columnName, reader.GetInt32);

		/// <summary> Gets the value of the specified column as a Int32 or given default, if column value is DbNull. </summary>
		public static int GetInt32OrDefault(this IDataReader reader, string columnName, int defaultValue)
			=> reader.GetValueOrDefault(columnName, defaultValue, reader.GetInt32);

		/// <summary> Gets the value of the specified column as a Int32 or default(int), if column value is DbNull. </summary>
		public static int GetInt32OrDefault(this IDataReader reader, int columnIndex)
			=> reader.GetValueOrDefault(columnIndex, reader.GetInt32);

		/// <summary> Gets the value of the specified column as a Int32 or given default, if column value is DbNull. </summary>
		public static int GetInt32OrDefault(this IDataReader reader, int columnIndex, int defaultValue)
			=> reader.GetValueOrDefault(columnIndex, defaultValue, reader.GetInt32);

		/// <summary> Gets the value of the specified column as a Int32 or default(int?), if column value is DbNull. </summary>
		public static int? GetInt32NullableOrDefault(this IDataReader reader, string columnName)
			=> reader.GetValueOrDefault(columnName, reader.GetInt32NullableOrDefault);

		/// <summary> Gets the value of the specified column as a Int32 or given default, if column value is DbNull. </summary>
		public static int? GetInt32NullableOrDefault(this IDataReader reader, string columnName, int? defaultValue)
			=> reader.GetValueOrDefault(columnName, defaultValue, reader.GetInt32NullableOrDefault);

		/// <summary> Gets the value of the specified column as a Int32 or default(int?), if column value is DbNull. </summary>
		public static int? GetInt32NullableOrDefault(this IDataReader reader, int columnIndex)
			=> reader.GetNullableValueOrDefault(columnIndex, reader.GetInt32);

		/// <summary> Gets the value of the specified column as a Int32 or given default, if column value is DbNull. </summary>
		public static int? GetInt32NullableOrDefault(this IDataReader reader, int columnIndex, int? defaultValue)
			=> reader.GetNullableValueOrDefault(columnIndex, defaultValue, reader.GetInt32);
	}
}
