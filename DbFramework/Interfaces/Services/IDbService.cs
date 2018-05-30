using DbFramework.Interfaces.DbOperations;

namespace DbFramework.Interfaces.Services
{
	public interface IDbService<out TResult>
	{
		IDbServiceLogic<TResult> DbServiceLogic { get; }
		TResult Execute();
	}
}
