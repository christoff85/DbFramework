using System;
using System.Data;

namespace DbFramework.Extensions
{
	public static partial class DataReaderExtensions
	{
		/// <summary> Gets the value of the specified column as a Boolean </summary>
		/// <exception cref="IndexOutOfRangeException"></exception>
		public static bool GetBoolean(this IDataReader reader, string name)
			=> reader.GetValueByName(name, reader.GetBoolean);

		/// <summary> Gets the value of the specified column as a Boolean or default(bool), if column value is DbNull. </summary>
		public static bool GetBooleanOrDefault(this IDataReader reader, string columnName)
			=> reader.GetValueOrDefault(columnName, reader.GetBoolean);

		/// <summary> Gets the value of the specified column as a Boolean or given default, if column value is DbNull. </summary>
		public static bool GetBooleanOrDefault(this IDataReader reader, string columnName, bool defaultValue)
			=> reader.GetValueOrDefault(columnName, defaultValue, reader.GetBoolean);

		/// <summary> Gets the value of the specified column as a Boolean or default(bool), if column value is DbNull. </summary>
		public static bool GetBooleanOrDefault(this IDataReader reader, int columnIndex)
			=> reader.GetValueOrDefault(columnIndex, reader.GetBoolean);

		/// <summary> Gets the value of the specified column as a Boolean or given default, if column value is DbNull. </summary>
		public static bool GetBooleanOrDefault(this IDataReader reader, int columnIndex, bool defaultValue)
			=> reader.GetValueOrDefault(columnIndex, defaultValue, reader.GetBoolean);

		/// <summary> Gets the value of the specified column as a Boolean or default(bool?), if column value is DbNull. </summary>
		public static bool? GetBooleanNullableOrDefault(this IDataReader reader, string columnName)
			=> reader.GetValueOrDefault(columnName, reader.GetBooleanNullableOrDefault);

		/// <summary> Gets the value of the specified column as a Boolean or given default, if column value is DbNull. </summary>
		public static bool? GetBooleanNullableOrDefault(this IDataReader reader, string columnName, bool? defaultValue)
			=> reader.GetValueOrDefault(columnName, defaultValue, reader.GetBooleanNullableOrDefault);

		/// <summary> Gets the value of the specified column as a Boolean or default(bool?), if column value is DbNull. </summary>
		public static bool? GetBooleanNullableOrDefault(this IDataReader reader, int columnIndex)
			=> reader.GetNullableValueOrDefault(columnIndex, reader.GetBoolean);

		/// <summary> Gets the value of the specified column as a Boolean or given default, if column value is DbNull. </summary>
		public static bool? GetBooleanNullableOrDefault(this IDataReader reader, int columnIndex, bool? defaultValue)
			=> reader.GetNullableValueOrDefault(columnIndex, defaultValue, reader.GetBoolean);
	}
}
