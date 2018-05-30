using System.Data;
using DbFramework.Interfaces.Database;
using DbFramework.Interfaces.Parameters;

namespace DbFramework.ServiceCommands
{
	public abstract class DbStoredProcedure : DbServiceCommand
	{
	    public override IDbCommand GetDbCommand(IDatabase db)
	    {
		    var spName = GetStoredProcedureName();

			var command = db.GetStoredProcCommand(spName);
		    db.DiscoverParameters(command);

		    return command;
	    }

		public override void AddDbParameter(IDbCommand command, IDbParameter parameter)
		{
			var cmdParameter = (IDataParameter)command.Parameters[parameter.Name];
			cmdParameter.Value = parameter.DbValue;
			cmdParameter.Direction = parameter.Direction;
		}

		public override string GetCommandText() 
			=> GetStoredProcedureName();

		protected abstract string GetStoredProcedureName();
	}
}
