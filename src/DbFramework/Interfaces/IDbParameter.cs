using System.Data;

namespace DbFramework.Interfaces
{
	public interface IDbParameter
	{
		string Name { get; }
		ParameterDirection Direction { get; }
	    DbType? DatabaseType { get; }
        object Value { get; set; }
		object DbValue { get; }
		object OutValue { set; }

	    TValue GetValue<TValue>();

	}
}