using System.Data;
using DbFramework.Interfaces;

namespace DbFramework.DbCommands
{
	public abstract class DbTextCommand : DbFrameworkCommand
	{
	    protected override IDbCommand GetDbCommand(IDbManager dbManager) 
		    => dbManager.GetSqlStringCommand(GetSqlString());

        protected override void DiscoverParameters(IDbManager dbManager, IDbCommand dbCommand)
        {
            foreach (var parameter in Parameters)
            {
                var cmdParameter = dbCommand.CreateParameter();
                cmdParameter.ParameterName = parameter.Name;

                dbCommand.Parameters.Add(cmdParameter);
            }
        }

	    //protected override Task DiscoverParametersAsync(IDbManager dbManager, IDbCommand dbCommand, CancellationToken cancellationToken)
	    //{
     //       DiscoverParameters(dbManager, dbCommand);
	    //    return base.DiscoverParametersAsync(dbManager, dbCommand, cancellationToken); 
	    //}

	    public override string GetCommandText() 
			=> GetSqlString();

		protected abstract string GetSqlString();
	}
}
