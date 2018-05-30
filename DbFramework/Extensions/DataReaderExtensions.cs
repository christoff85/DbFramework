using System;
using System.Collections.Generic;
using System.Data;
using DbFramework.Enums;

namespace DbFramework.Extensions
{
	public static partial class DataReaderExtensions
	{
		/// <summary> Return whether a specified field is set to null. </summary>
		public static bool IsDBNull(this IDataReader reader, string name)
		{
			var index = reader.GetOrdinal(name);
			return reader.IsDBNull(index);
		}

		/// <summary> Gets collection of results from DataReader.  </summary>
		public static IList<TResult> GetManyResults<TResult>(this IDataReader reader, Func<IDataReader, TResult> readerToResultMapper)
		{
			var results = new List<TResult>();

			while (reader.Read())
				results.Add(readerToResultMapper(reader));

			return results;
		}

		/// <summary> Gets single result from DataReader with specified options. </summary>
		/// <exception cref="InvalidOperationException"></exception>
		public static TResult GetSingleResult<TResult>(this IDataReader reader, Func<IDataReader, TResult> readerToResultMapper, SingleResultOptions options)
		{
			var anyResults = reader.Read();

			if (!anyResults && (options == SingleResultOptions.Single || options == SingleResultOptions.First))
				throw new InvalidOperationException("No results found");

			var result = anyResults ? readerToResultMapper(reader) : default(TResult);

			if(reader.Read() && (options == SingleResultOptions.Single || options == SingleResultOptions.SingleOrDefault))
				throw new InvalidOperationException("Too many results");

			return result;
		}

		/// <summary> Checks if reader has any elements and check the result against conditions in result checker. </summary>
		public static bool CheckIfResultExists(this IDataReader reader, Func<IDataReader, bool> resultContentCheck)
		{
			return reader.Read() && resultContentCheck(reader);
		}

		#region Private methods
		/// <summary> Generic method: gets the value of the specified column by name. </summary>
		private static T GetValueByName<T>(this IDataReader reader, string name, Func<int, T> getValueMethod)
		{
			var index = reader.GetOrdinal(name);
			return getValueMethod.Invoke(index);
		}

		/// <summary> Generic method: gets the value of the specified column or default(T), if column value is DbNull. </summary>
		private static T GetValueOrDefault<T>(this IDataReader reader, string name, Func<int, T> getValueMethod)
			=> reader.GetValueOrDefault(name, default(T), getValueMethod);

		/// <summary> Generic method: gets the value of the specified column or given default, if column value is DbNull. </summary>
		private static T GetValueOrDefault<T>(this IDataReader reader, string name, T defaultVal, Func<int, T> getValueMethod)
		{
			var index = reader.GetOrdinal(name);
			return reader.GetValueOrDefault(index, defaultVal, getValueMethod);
		}

		/// <summary> Generic method: gets the value of the specified column or default(T), if column value is DbNull. </summary>
		private static T GetValueOrDefault<T>(this IDataReader reader, int ind, Func<int, T> getValueMethod)
			=> reader.GetValueOrDefault(ind, default(T), getValueMethod);

		/// <summary> Generic method: gets the value of the specified column or given default, if column value is DbNull. </summary>
		private static T GetValueOrDefault<T>(this IDataReader reader, int ind, T defaultVal, Func<int, T> getValueMethod)
			=> reader.IsDBNull(ind) ? defaultVal : getValueMethod(ind);

		/// <summary> Generic method: gets the nullable value of the specified column or default(T?), if column value is DbNull. </summary>
		private static T? GetNullableValueOrDefault<T>(this IDataReader reader, int ind, Func<int, T> getValueMethod)
			where T : struct
			=> reader.GetNullableValueOrDefault(ind, default(T?), getValueMethod);

		/// <summary> Generic method: gets the nullable value of the specified column or given default, if column value is DbNull. </summary>
		private static T? GetNullableValueOrDefault<T>(this IDataReader reader, int ind, T? defaultVal, Func<int, T> getValueMethod)
			where T : struct
			=> reader.IsDBNull(ind) ? defaultVal : getValueMethod.Invoke(ind);
		#endregion
	}
}
