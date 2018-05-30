using DbFramework.Interfaces.DbOperations;

namespace DbFramework.Interfaces.DbLogic
{
	public interface ISingleResultLogic<out TResult> : IDbServiceLogic<TResult>
	{
	}
}