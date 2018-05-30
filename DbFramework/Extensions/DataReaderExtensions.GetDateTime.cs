using System;
using System.Data;

namespace DbFramework.Extensions
{
	public static partial class DataReaderExtensions
	{
		/// <summary> Gets the value of the specified column as a DateTime </summary>
		/// <exception cref="IndexOutOfRangeException"></exception>
		public static DateTime GetDateTime(this IDataReader reader, string name)
			=> reader.GetValueByName(name, reader.GetDateTime);

		/// <summary> Gets the value of the specified column as a DateTime or default(DateTime), if column value is DbNull. </summary>
		public static DateTime GetDateTimeOrDefault(this IDataReader reader, string columnName)
			=> reader.GetValueOrDefault(columnName, reader.GetDateTime);

		/// <summary> Gets the value of the specified column as a DateTime or given default, if column value is DbNull. </summary>
		public static DateTime GetDateTimeOrDefault(this IDataReader reader, string columnName, DateTime defaultValue)
			=> reader.GetValueOrDefault(columnName, defaultValue, reader.GetDateTime);

		/// <summary> Gets the value of the specified column as a DateTime or default(DateTime), if column value is DbNull. </summary>
		public static DateTime GetDateTimeOrDefault(this IDataReader reader, int columnIndex)
			=> reader.GetValueOrDefault(columnIndex, reader.GetDateTime);

		/// <summary> Gets the value of the specified column as a DateTime or given default, if column value is DbNull. </summary>
		public static DateTime GetDateTimeOrDefault(this IDataReader reader, int columnIndex, DateTime defaultValue)
			=> reader.GetValueOrDefault(columnIndex, defaultValue, reader.GetDateTime);

		/// <summary> Gets the value of the specified column as a DateTime or default(DateTime?), if column value is DbNull. </summary>
		public static DateTime? GetDateTimeNullableOrDefault(this IDataReader reader, string columnName)
			=> reader.GetValueOrDefault(columnName, reader.GetDateTimeNullableOrDefault);

		/// <summary> Gets the value of the specified column as a DateTime or given default, if column value is DbNull. </summary>
		public static DateTime? GetDateTimeNullableOrDefault(this IDataReader reader, string columnName, DateTime? defaultValue)
			=> reader.GetValueOrDefault(columnName, defaultValue, reader.GetDateTimeNullableOrDefault);

		/// <summary> Gets the value of the specified column as a DateTime or default(DateTime?), if column value is DbNull. </summary>
		public static DateTime? GetDateTimeNullableOrDefault(this IDataReader reader, int columnIndex)
			=> reader.GetNullableValueOrDefault(columnIndex, reader.GetDateTime);

		/// <summary> Gets the value of the specified column as a DateTime or given default, if column value is DbNull. </summary>
		public static DateTime? GetDateTimeNullableOrDefault(this IDataReader reader, int columnIndex, DateTime? defaultValue)
			=> reader.GetNullableValueOrDefault(columnIndex, defaultValue, reader.GetDateTime);
	}
}
