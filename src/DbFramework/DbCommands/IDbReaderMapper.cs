using DbFramework.Interfaces;

namespace DbFramework.DbCommands
{
	public interface IDbReaderMapper<out TResult>
	{
		TResult MapResult(IDbReader reader);
	}
}