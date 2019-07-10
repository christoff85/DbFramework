namespace DbFramework.Interfaces.Invokers
{
    public interface IDbFrameworkCommandInvoker<TResult>
    {
	    TResult Invoke(IDbManager dbManager);
        //Task<TResult> InvokeAsync(IDbManager dbManager, CancellationToken cancellationToken);
    }
}