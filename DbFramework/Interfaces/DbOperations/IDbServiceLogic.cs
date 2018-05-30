using DbFramework.Interfaces.ServiceManagers;

namespace DbFramework.Interfaces.DbOperations
{
	public interface IDbServiceLogic<out TResult> : IDbServiceComponent
	{
		/// <summary> Contains and executes logic of db service. For logging and argument checking use Invoke extension method. </summary>
		TResult Execute(IDbServiceManager dbServiceManager);
	}
}
