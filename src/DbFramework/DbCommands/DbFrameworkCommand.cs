using System.Data;
using DbFramework.Interfaces;

namespace DbFramework.DbCommands
{
	public abstract class DbFrameworkCommand : IDbFrameworkCommand
	{
		private IDbParameters _parameters;
		public IDbParameters Parameters => _parameters ?? (_parameters = MapParameters());

	    public virtual IDbCommand GetDbCommandWithAssignedParameters(IDbManager dbManager)
	    {
	        var dbCommand = GetDbCommand(dbManager);
            DiscoverParameters(dbManager, dbCommand);

	        return AssignParameters(dbCommand);
	    }

	    //public virtual async Task<IDbCommand> GetDbCommandWithAssignedParametersAsync(IDbManager dbManager, CancellationToken cancellationToken)
	    //{
	    //    var dbCommand = GetDbCommand(dbManager);
	    //    await DiscoverParametersAsync(dbManager, dbCommand, cancellationToken);
	    //    return AssignParameters(dbCommand);
	    //}

        protected virtual IDbCommand AssignParameters(IDbCommand dbCommand)
	    {
	        foreach (var parameter in Parameters)
	            AddDbParameter(dbCommand, parameter);

	        return dbCommand;
	    }

	    protected virtual void AddDbParameter(IDbCommand dbCommand, IDbParameter parameter)
	    {
	        var cmdParameter = (IDataParameter)dbCommand.Parameters[parameter.Name];
	        cmdParameter.Value = parameter.DbValue;
	        cmdParameter.Direction = parameter.Direction;

	        if (parameter.DatabaseType.HasValue)
	            cmdParameter.DbType = parameter.DatabaseType.Value;
	    }

        protected virtual void DiscoverParameters(IDbManager dbManager, IDbCommand dbCommand)
	    {
        }

	    //protected virtual Task DiscoverParametersAsync(IDbManager dbManager, IDbCommand dbCommand, CancellationToken cancellationToken)
	    //{
	    //    return Task.FromResult(true);
	    //}

        protected abstract IDbCommand GetDbCommand(IDbManager dbManager);
	    public abstract string GetCommandText();


	    protected virtual IDbParameters MapParameters() 
			=> new DbParameters();

		#region IEquatable implementation
		public override int GetHashCode() 
			=> GetCommandText().GetHashCode();

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != GetType()) return false;

			return Equals((IDbFrameworkCommand)obj);
		}

		public bool Equals(IDbFrameworkCommand other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;

			return string.Equals(GetCommandText(), other.GetCommandText());
		}
		#endregion
	}
}
