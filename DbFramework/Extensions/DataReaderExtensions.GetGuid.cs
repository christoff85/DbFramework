using System;
using System.Data;

namespace DbFramework.Extensions
{
	public static partial class DataReaderExtensions
	{
		/// <summary> Gets the value of the specified column as a Guid </summary>
		/// <exception cref="IndexOutOfRangeException"></exception>
		public static Guid GetGuid(this IDataReader reader, string name)
			=> reader.GetValueByName(name, reader.GetGuid);

		/// <summary> Gets the value of the specified column as a Guid or default(Guid), if column value is DbNull. </summary>
		public static Guid GetGuidOrDefault(this IDataReader reader, string columnName)
			=> reader.GetValueOrDefault(columnName, reader.GetGuid);

		/// <summary> Gets the value of the specified column as a Guid or given default, if column value is DbNull. </summary>
		public static Guid GetGuidOrDefault(this IDataReader reader, string columnName, Guid defaultValue)
			=> reader.GetValueOrDefault(columnName, defaultValue, reader.GetGuid);

		/// <summary> Gets the value of the specified column as a Guid or default(Guid), if column value is DbNull. </summary>
		public static Guid GetGuidOrDefault(this IDataReader reader, int columnIndex)
			=> reader.GetValueOrDefault(columnIndex, reader.GetGuid);

		/// <summary> Gets the value of the specified column as a Guid or given default, if column value is DbNull. </summary>
		public static Guid GetGuidOrDefault(this IDataReader reader, int columnIndex, Guid defaultValue)
			=> reader.GetValueOrDefault(columnIndex, defaultValue, reader.GetGuid);

		/// <summary> Gets the value of the specified column as a Guid or default(Guid?), if column value is DbNull. </summary>
		public static Guid? GetGuidNullableOrDefault(this IDataReader reader, string columnName)
			=> reader.GetValueOrDefault(columnName, reader.GetGuidNullableOrDefault);

		/// <summary> Gets the value of the specified column as a Guid or given default, if column value is DbNull. </summary>
		public static Guid? GetGuidNullableOrDefault(this IDataReader reader, string columnName, Guid? defaultValue)
			=> reader.GetValueOrDefault(columnName, defaultValue, reader.GetGuidNullableOrDefault);

		/// <summary> Gets the value of the specified column as a Guid or default(Guid?), if column value is DbNull. </summary>
		public static Guid? GetGuidNullableOrDefault(this IDataReader reader, int columnIndex)
			=> reader.GetNullableValueOrDefault(columnIndex, reader.GetGuid);

		/// <summary> Gets the value of the specified column as a Guid or given default, if column value is DbNull. </summary>
		public static Guid? GetGuidNullableOrDefault(this IDataReader reader, int columnIndex, Guid? defaultValue)
			=> reader.GetNullableValueOrDefault(columnIndex, defaultValue, reader.GetGuid);
	}
}
