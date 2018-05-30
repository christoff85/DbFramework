using DbFramework.Interfaces.DbCommands;
using SampleImplementation.Entities;

namespace SampleImplementation.Interfaces.DbServiceCommands
{
    public interface IManyResultSample : IManyResultCommand<Person>
	{
	}
}
