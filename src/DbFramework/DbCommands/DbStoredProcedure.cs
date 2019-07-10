using System.Data;
using DbFramework.Interfaces;

namespace DbFramework.DbCommands
{
	public abstract class DbStoredProcedure : DbFrameworkCommand
	{
	    protected override IDbCommand GetDbCommand(IDbManager dbManager)
	    {
		    var spName = GetStoredProcedureName();
	        return dbManager.GetStoredProcCommand(spName);
	    }

	    protected override void DiscoverParameters(IDbManager dbManager, IDbCommand dbCommand)
	    {
	        dbManager.DiscoverParameters(dbCommand);
	    }

        //protected override async Task DiscoverParametersAsync(IDbManager dbManager, IDbCommand dbCommand, CancellationToken cancellationToken)
        //{
        //    await dbManager.DiscoverParametersAsync(dbCommand, cancellationToken);
        //}

		public override string GetCommandText() 
			=> GetStoredProcedureName();

		protected abstract string GetStoredProcedureName();
	}
}
