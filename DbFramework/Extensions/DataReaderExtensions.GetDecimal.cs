using System;
using System.Data;

namespace DbFramework.Extensions
{
	public static partial class DataReaderExtensions
	{
		/// <summary> Gets the value of the specified column as a Decimal </summary>
		/// <exception cref="IndexOutOfRangeException"></exception>
		public static decimal GetDecimal(this IDataReader reader, string name)
			=> reader.GetValueByName(name, reader.GetDecimal);

		/// <summary> Gets the value of the specified column as a Decimal or default(Decimal), if column value is DbNull. </summary>
		public static decimal GetDecimalOrDefault(this IDataReader reader, string columnName)
			=> reader.GetValueOrDefault(columnName, reader.GetDecimal);

		/// <summary> Gets the value of the specified column as a Decimal or given default, if column value is DbNull. </summary>
		public static decimal GetDecimalOrDefault(this IDataReader reader, string columnName, decimal defaultValue)
			=> reader.GetValueOrDefault(columnName, defaultValue, reader.GetDecimal);

		/// <summary> Gets the value of the specified column as a Decimal or default(Decimal), if column value is DbNull. </summary>
		public static decimal GetDecimalOrDefault(this IDataReader reader, int columnIndex)
			=> reader.GetValueOrDefault(columnIndex, reader.GetDecimal);

		/// <summary> Gets the value of the specified column as a Decimal or given default, if column value is DbNull. </summary>
		public static decimal GetDecimalOrDefault(this IDataReader reader, int columnIndex, decimal defaultValue)
			=> reader.GetValueOrDefault(columnIndex, defaultValue, reader.GetDecimal);

		/// <summary> Gets the value of the specified column as a Decimal or default(Decimal?), if column value is DbNull. </summary>
		public static decimal? GetDecimalNullableOrDefault(this IDataReader reader, string columnName)
			=> reader.GetValueOrDefault(columnName, reader.GetDecimalNullableOrDefault);

		/// <summary> Gets the value of the specified column as a Decimal or given default, if column value is DbNull. </summary>
		public static decimal? GetDecimalNullableOrDefault(this IDataReader reader, string columnName, decimal? defaultValue)
			=> reader.GetValueOrDefault(columnName, defaultValue, reader.GetDecimalNullableOrDefault);

		/// <summary> Gets the value of the specified column as a Decimal or default(Decimal?), if column value is DbNull. </summary>
		public static decimal? GetDecimalNullableOrDefault(this IDataReader reader, int columnIndex)
			=> reader.GetNullableValueOrDefault(columnIndex, reader.GetDecimal);

		/// <summary> Gets the value of the specified column as a Decimal or given default, if column value is DbNull. </summary>
		public static decimal? GetDecimalNullableOrDefault(this IDataReader reader, int columnIndex, decimal? defaultValue)
			=> reader.GetNullableValueOrDefault(columnIndex, defaultValue, reader.GetDecimal);
	}
}
