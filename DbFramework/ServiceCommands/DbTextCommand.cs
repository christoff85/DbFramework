using System.Data;
using DbFramework.Interfaces.Database;
using DbFramework.Interfaces.Parameters;

namespace DbFramework.ServiceCommands
{
	public abstract class DbTextCommand : DbServiceCommand
	{
	    public override IDbCommand GetDbCommand(IDatabase db) 
		    => db.GetSqlStringCommand(GetSqlString());

		public override void AddDbParameter(IDbCommand command, IDbParameter parameter)
		{
			var cmdParameter = command.CreateParameter();
			cmdParameter.ParameterName = parameter.Name;
			cmdParameter.Value = parameter.DbValue;
			cmdParameter.Direction = parameter.Direction;

			command.Parameters.Add(cmdParameter);
		}

		public override string GetCommandText() 
			=> GetSqlString();

		protected abstract string GetSqlString();
	}
}
