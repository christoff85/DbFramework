using System.Data;
using DbFramework.Interfaces.DbCommands;
using DbFramework.Interfaces.Invokers;
using DbFramework.Interfaces.ServiceManagers;

namespace DbFramework.Invokers
{
    public class NonQueryCommandInvoker : DbServiceCommandInvoker<INonQueryCommand, int>, INonQueryCommandInvoker
    {
        internal NonQueryCommandInvoker(INonQueryCommand dbServiceCommand)
            : base(dbServiceCommand)
        {
        }

        protected override int Execute(IDbServiceManager dbServiceManager, IDbCommand command) 
	        => dbServiceManager.ExecuteNonQuery(command);
    }
}