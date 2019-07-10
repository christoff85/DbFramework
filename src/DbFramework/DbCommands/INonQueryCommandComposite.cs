using System.Collections.Generic;

namespace DbFramework.DbCommands
{
	public interface INonQueryCommandComposite : IEnumerable<INonQueryCommand>
	{
		int Count { get; }

		INonQueryCommandComposite Add(INonQueryCommand nonQueryCommand);
		INonQueryCommandComposite Remove(INonQueryCommand nonQueryCommand);
	}
}