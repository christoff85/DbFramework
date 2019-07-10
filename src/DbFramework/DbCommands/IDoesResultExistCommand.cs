using DbFramework.Interfaces;

namespace DbFramework.DbCommands
{
    public interface IDoesResultExistCommand : IDbFrameworkCommand
    {
        bool ResultContentChecker(IDbReader reader);
    }
}