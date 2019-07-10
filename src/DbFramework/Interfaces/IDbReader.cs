using System;

namespace DbFramework.Interfaces
{
	public interface IDbReader : IDisposable
	{
		object this [int index] { get; }
		int FieldCount { get; }

		bool GetBoolean(string columnName);
		bool? GetBooleanNullableOrDefault(string columnName);
		bool? GetBooleanNullableOrDefault(string columnName, bool? defaultValue);
		bool GetBooleanOrDefault(string columnName);
		bool GetBooleanOrDefault(string columnName, bool defaultValue);
		byte GetByte(string columnName);
		byte? GetByteNullableOrDefault(string columnName);
		byte? GetByteNullableOrDefault(string columnName, byte? defaultValue);
		byte GetByteOrDefault(string columnName);
		byte GetByteOrDefault(string columnName, byte defaultValue);
		DateTime GetDateTime(string columnName);
		DateTime? GetDateTimeNullableOrDefault(string columnName);
		DateTime? GetDateTimeNullableOrDefault(string columnName, DateTime? defaultValue);
		DateTime GetDateTimeOrDefault(string columnName);
		DateTime GetDateTimeOrDefault(string columnName, DateTime defaultValue);
		decimal GetDecimal(string columnName);
		decimal? GetDecimalNullableOrDefault(string columnName);
		decimal? GetDecimalNullableOrDefault(string columnName, decimal? defaultValue);
		decimal GetDecimalOrDefault(string columnName);
		decimal GetDecimalOrDefault(string columnName, decimal defaultValue);
		double GetDouble(string columnName);
		double? GetDoubleNullableOrDefault(string columnName);
		double? GetDoubleNullableOrDefault(string columnName, double? defaultValue);
		double GetDoubleOrDefault(string columnName);
		double GetDoubleOrDefault(string columnName, double defaultValue);
		float GetFloat(string columnName);
		float? GetFloatNullableOrDefault(string columnName);
		float? GetFloatNullableOrDefault(string columnName, float? defaultValue);
		float GetFloatOrDefault(string columnName);
		float GetFloatOrDefault(string columnName, float defaultValue);
		Guid GetGuid(string columnName);
		Guid? GetGuidNullableOrDefault(string columnName);
		Guid? GetGuidNullableOrDefault(string columnName, Guid? defaultValue);
		Guid GetGuidOrDefault(string columnName);
		Guid GetGuidOrDefault(string columnName, Guid defaultValue);
		int GetInt(string columnName);
		int? GetIntNullableOrDefault(string columnName);
		int? GetIntNullableOrDefault(string columnName, int? defaultValue);
		int GetIntOrDefault(string columnName);
		int GetIntOrDefault(string columnName, int defaultValue);
		long GetLong(string columnName);
		long? GetLongNullableOrDefault(string columnName);
		long? GetLongNullableOrDefault(string columnName, long? defaultValue);
		long GetLongOrDefault(string columnName);
		long GetLongOrDefault(string columnName, long defaultValue);
		short GetShort(string columnName);
		short? GetShortNullableOrDefault(string columnName);
		short? GetShortNullableOrDefault(string columnName, short? defaultValue);
		short GetShortOrDefault(string columnName);
		short GetShortOrDefault(string columnName, short defaultValue);
		string GetString(string name);
		string GetStringOrDefault(string columnName);
		string GetStringOrDefault(string columnName, string defaultValue);
		bool IsDbNull(string columnName);
		bool IsDbNull(int columnIndex);
		bool Read();
		bool NextResult();
		string GetName(int index);
	    bool DoesColumnExist(string columnName);

	}
}