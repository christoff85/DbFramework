using DbFramework.Interfaces.ServiceManagers;

namespace DbFramework.Interfaces.Invokers
{
    public interface IDbServiceComponentInvoker<out TResult>
    {
        TResult Invoke(IDbServiceManager dbServiceManager);
    }
}