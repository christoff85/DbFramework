using System.Data;
using DbFramework.DbCommands;
using DbFramework.Interfaces;
using DbFramework.Interfaces.Invokers;

namespace DbFramework.Invokers
{
	internal class NonQueryCommandInvoker<TResult>
        : DbCommandInvoker<INonQueryCommand<TResult>, TResult>, INonQueryCommandInvoker<TResult>
    {
        internal NonQueryCommandInvoker(INonQueryCommand<TResult> command)
            : base(command)
        {
        }

        protected override TResult Execute(IDbManager dbManager, IDbCommand command)
        {
	        dbManager.ExecuteNonQuery(command);

            GetOutParametersValues(command);

            return Command.MapOutParametersToResult();
        }

        //protected override async Task<TResult> ExecuteAsync(IDbManager dbManager, IDbCommand command, CancellationToken cancellationToken)
        //{
        //    await dbManager.ExecuteNonQueryAsync(command, cancellationToken);

        //    GetOutParametersValues(command);

        //    return Command.MapOutParametersToResult();
        //}

        private void GetOutParametersValues(IDbCommand command)
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