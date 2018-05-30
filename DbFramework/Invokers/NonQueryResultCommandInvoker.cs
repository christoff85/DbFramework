using System.Data;
using DbFramework.Interfaces.DbCommands;
using DbFramework.Interfaces.Invokers;
using DbFramework.Interfaces.ServiceManagers;

namespace DbFramework.Invokers
{
    public class NonQueryCommandInvoker<TResult>
        : DbServiceCommandInvoker<INonQueryCommand<TResult>, TResult>, INonQueryCommandInvoker<TResult>
    {
        internal NonQueryCommandInvoker(INonQueryCommand<TResult> command)
            : base(command)
        {
        }

        protected override TResult Execute(IDbServiceManager dbServiceManager, IDbCommand command)
        {
	        dbServiceManager.ExecuteNonQuery(command);

            GetOutParametersValues(command);

            return Command.MapOutParametersToResult();
        }

        protected void GetOutParametersValues(IDbCommand command)
        {
            foreach(var parameter in Command.Parameters)
                if (parameter.Direction != ParameterDirection.Input)
                {
                    var cmdParameter = (IDataParameter)command.Parameters[parameter.Name];
                    parameter.OutValue = cmdParameter.Value;
                }
        }
    }
}