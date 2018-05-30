using System.Data;

namespace DbFramework.Interfaces.Parameters
{
	public interface IDbParameter
	{
		string Name { get; }
		ParameterDirection Direction { get; }
		object Value { get; set; }
		object DbValue { get; }
		object OutValue { set; }
	}
}