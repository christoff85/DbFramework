using System;
using System.Data;

namespace DbFramework.Extensions
{
    public static partial class DataReaderExtensions
    {
	    /// <summary> Gets the value of the specified column as a String </summary>
	    /// <exception cref="IndexOutOfRangeException"></exception>
		public static string GetString(this IDataReader reader, string name) 
		    => reader.GetValueByName(name, reader.GetString);

	    /// <summary> Gets the value of the specified column as a String or default(string), if column value is DbNull. </summary>
		public static string GetStringOrDefault(this IDataReader reader, string columnName)
		    => reader.GetValueOrDefault(columnName, reader.GetString);

	    /// <summary> Gets the value of the specified column as a String or given default, if column value is DbNull. </summary>
		public static string GetStringOrDefault(this IDataReader reader, string columnName, string defaultValue)
		    => reader.GetValueOrDefault(columnName, defaultValue, reader.GetString);

	    /// <summary> Gets the value of the specified column as a String or default(string), if column value is DbNull. </summary>
	    public static string GetStringOrDefault(this IDataReader reader, int columnIndex) 
		    => reader.GetValueOrDefault(columnIndex, reader.GetString);

	    /// <summary> Gets the value of the specified column as a String or given default, if column value is DbNull. </summary>
		public static string GetStringOrDefault(this IDataReader reader, int columnIndex, string defaultValue) 
		    => reader.GetValueOrDefault(columnIndex, defaultValue, reader.GetString);
    }
}
