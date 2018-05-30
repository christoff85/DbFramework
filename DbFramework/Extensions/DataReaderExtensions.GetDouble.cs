using System;
using System.Data;

namespace DbFramework.Extensions
{
	public static partial class DataReaderExtensions
	{
		/// <summary> Gets the value of the specified column as a Double </summary>
		/// <exception cref="IndexOutOfRangeException"></exception>
		public static double GetDouble(this IDataReader reader, string name)
			=> reader.GetValueByName(name, reader.GetDouble);

		/// <summary> Gets the value of the specified column as a Double or default(double), if column value is DbNull. </summary>
		public static double GetDoubleOrDefault(this IDataReader reader, string columnName)
			=> reader.GetValueOrDefault(columnName, reader.GetDouble);

		/// <summary> Gets the value of the specified column as a Double or given default, if column value is DbNull. </summary>
		public static double GetDoubleOrDefault(this IDataReader reader, string columnName, double defaultValue)
			=> reader.GetValueOrDefault(columnName, defaultValue, reader.GetDouble);

		/// <summary> Gets the value of the specified column as a Double or default(double), if column value is DbNull. </summary>
		public static double GetDoubleOrDefault(this IDataReader reader, int columnIndex)
			=> reader.GetValueOrDefault(columnIndex, reader.GetDouble);

		/// <summary> Gets the value of the specified column as a Double or given default, if column value is DbNull. </summary>
		public static double GetDoubleOrDefault(this IDataReader reader, int columnIndex, double defaultValue)
			=> reader.GetValueOrDefault(columnIndex, defaultValue, reader.GetDouble);

		/// <summary> Gets the value of the specified column as a Double or default(double?), if column value is DbNull. </summary>
		public static double? GetDoubleNullableOrDefault(this IDataReader reader, string columnName)
			=> reader.GetValueOrDefault(columnName, reader.GetDoubleNullableOrDefault);

		/// <summary> Gets the value of the specified column as a Double or given default, if column value is DbNull. </summary>
		public static double? GetDoubleNullableOrDefault(this IDataReader reader, string columnName, double? defaultValue)
			=> reader.GetValueOrDefault(columnName, defaultValue, reader.GetDoubleNullableOrDefault);

		/// <summary> Gets the value of the specified column as a Double or default(double?), if column value is DbNull. </summary>
		public static double? GetDoubleNullableOrDefault(this IDataReader reader, int columnIndex)
			=> reader.GetNullableValueOrDefault(columnIndex, reader.GetDouble);

		/// <summary> Gets the value of the specified column as a Double or given default, if column value is DbNull. </summary>
		public static double? GetDoubleNullableOrDefault(this IDataReader reader, int columnIndex, double? defaultValue)
			=> reader.GetNullableValueOrDefault(columnIndex, defaultValue, reader.GetDouble);
	}
}
