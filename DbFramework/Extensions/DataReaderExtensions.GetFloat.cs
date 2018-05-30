using System;
using System.Data;

namespace DbFramework.Extensions
{
	public static partial class DataReaderExtensions
	{
		/// <summary> Gets the value of the specified column as a Float </summary>
		/// <exception cref="IndexOutOfRangeException"></exception>
		public static float GetFloat(this IDataReader reader, string name)
			=> reader.GetValueByName(name, reader.GetFloat);

		/// <summary> Gets the value of the specified column as a Float or default(float), if column value is DbNull. </summary>
		public static float GetFloatOrDefault(this IDataReader reader, string columnName)
			=> reader.GetValueOrDefault(columnName, reader.GetFloat);

		/// <summary> Gets the value of the specified column as a Float or given default, if column value is DbNull. </summary>
		public static float GetFloatOrDefault(this IDataReader reader, string columnName, float defaultValue)
			=> reader.GetValueOrDefault(columnName, defaultValue, reader.GetFloat);

		/// <summary> Gets the value of the specified column as a Float or default(float), if column value is DbNull. </summary>
		public static float GetFloatOrDefault(this IDataReader reader, int columnIndex)
			=> reader.GetValueOrDefault(columnIndex, reader.GetFloat);

		/// <summary> Gets the value of the specified column as a Float or given default, if column value is DbNull. </summary>
		public static float GetFloatOrDefault(this IDataReader reader, int columnIndex, float defaultValue)
			=> reader.GetValueOrDefault(columnIndex, defaultValue, reader.GetFloat);

		/// <summary> Gets the value of the specified column as a Float or default(float?), if column value is DbNull. </summary>
		public static float? GetFloatNullableOrDefault(this IDataReader reader, string columnName)
			=> reader.GetValueOrDefault(columnName, reader.GetFloatNullableOrDefault);

		/// <summary> Gets the value of the specified column as a Float or given default, if column value is DbNull. </summary>
		public static float? GetFloatNullableOrDefault(this IDataReader reader, string columnName, float? defaultValue)
			=> reader.GetValueOrDefault(columnName, defaultValue, reader.GetFloatNullableOrDefault);

		/// <summary> Gets the value of the specified column as a Float or default(float?), if column value is DbNull. </summary>
		public static float? GetFloatNullableOrDefault(this IDataReader reader, int columnIndex)
			=> reader.GetNullableValueOrDefault(columnIndex, reader.GetFloat);

		/// <summary> Gets the value of the specified column as a Float or given default, if column value is DbNull. </summary>
		public static float? GetFloatNullableOrDefault(this IDataReader reader, int columnIndex, float? defaultValue)
			=> reader.GetNullableValueOrDefault(columnIndex, defaultValue, reader.GetFloat);
	}
}
