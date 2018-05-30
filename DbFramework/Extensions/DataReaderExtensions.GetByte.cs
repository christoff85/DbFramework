using System;
using System.Data;

namespace DbFramework.Extensions
{
	public static partial class DataReaderExtensions
	{
		/// <summary> Gets the value of the specified column as a Byte </summary>
		/// <exception cref="IndexOutOfRangeException"></exception>
		public static byte GetByte(this IDataReader reader, string name)
			=> reader.GetValueByName(name, reader.GetByte);

		/// <summary> Gets the value of the specified column as a Byte or default(byte), if column value is DbNull. </summary>
		public static byte GetByteOrDefault(this IDataReader reader, string columnName)
			=> reader.GetValueOrDefault(columnName, reader.GetByte);

		/// <summary> Gets the value of the specified column as a Byte or given default, if column value is DbNull. </summary>
		public static byte GetByteOrDefault(this IDataReader reader, string columnName, byte defaultValue)
			=> reader.GetValueOrDefault(columnName, defaultValue, reader.GetByte);

		/// <summary> Gets the value of the specified column as a Byte or default(byte), if column value is DbNull. </summary>
		public static byte GetByteOrDefault(this IDataReader reader, int columnIndex)
			=> reader.GetValueOrDefault(columnIndex, reader.GetByte);

		/// <summary> Gets the value of the specified column as a Byte or given default, if column value is DbNull. </summary>
		public static byte GetByteOrDefault(this IDataReader reader, int columnIndex, byte defaultValue)
			=> reader.GetValueOrDefault(columnIndex, defaultValue, reader.GetByte);

		/// <summary> Gets the value of the specified column as a Byte or default(byte?), if column value is DbNull. </summary>
		public static byte? GetByteNullableOrDefault(this IDataReader reader, string columnName)
			=> reader.GetValueOrDefault(columnName, reader.GetByteNullableOrDefault);

		/// <summary> Gets the value of the specified column as a Byte or given default, if column value is DbNull. </summary>
		public static byte? GetByteNullableOrDefault(this IDataReader reader, string columnName, byte? defaultValue)
			=> reader.GetValueOrDefault(columnName, defaultValue, reader.GetByteNullableOrDefault);

		/// <summary> Gets the value of the specified column as a Byte or default(byte?), if column value is DbNull. </summary>
		public static byte? GetByteNullableOrDefault(this IDataReader reader, int columnIndex)
			=> reader.GetNullableValueOrDefault(columnIndex, reader.GetByte);

		/// <summary> Gets the value of the specified column as a Byte or given default, if column value is DbNull. </summary>
		public static byte? GetByteNullableOrDefault(this IDataReader reader, int columnIndex, byte? defaultValue)
			=> reader.GetNullableValueOrDefault(columnIndex, defaultValue, reader.GetByte);
	}
}
