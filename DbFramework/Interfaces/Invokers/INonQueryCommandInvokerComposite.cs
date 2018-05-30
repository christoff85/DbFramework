using System.Collections.Generic;
using DbFramework.Interfaces.DbCommands;

namespace DbFramework.Interfaces.Invokers
{
	public interface INonQueryCommandInvokerComposite : INonQueryCommandInvoker, IEnumerable<INonQueryCommandInvoker>
	{
		int Count { get; }

		INonQueryCommandInvokerComposite Add(INonQueryCommandInvoker nonQueryCommandInvoker);
		INonQueryCommandInvokerComposite Add(INonQueryCommand nonQueryCommand);
		INonQueryCommandInvokerComposite Remove(INonQueryCommand nonQueryCommand);
		INonQueryCommandInvokerComposite Remove(INonQueryCommandInvoker nonQueryCommandInvoker);
	}
}