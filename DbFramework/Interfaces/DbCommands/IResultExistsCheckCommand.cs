using System.Data;
using DbFramework.Interfaces.DbOperations;

namespace DbFramework.Interfaces.DbCommands
{
    public interface IResultExistsCheckCommand : IDbServiceCommand
    {
        bool ResultContentCheck(IDataReader reader);
    }
}