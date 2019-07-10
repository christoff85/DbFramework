using System.Collections.Generic;

namespace DbFramework.Interfaces.Invokers
{
	public interface IManyResultCommandInvoker<TResult> : IDbFrameworkCommandInvoker<IEnumerable<TResult>>
	{
	}
}