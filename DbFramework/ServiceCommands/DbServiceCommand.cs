using System.Data;
using DbFramework.Interfaces.Database;
using DbFramework.Interfaces.DbOperations;
using DbFramework.Interfaces.Parameters;
using DbFramework.Parameters;

namespace DbFramework.ServiceCommands
{
	public abstract class DbServiceCommand : IDbServiceCommand
	{
		private IDbParameters _parameters;
		public IDbParameters Parameters => _parameters ?? (_parameters = MapParameters());

		public abstract IDbCommand GetDbCommand(IDatabase db);
		public abstract void AddDbParameter(IDbCommand command, IDbParameter parameter);
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

			return Equals((IDbServiceCommand)obj);
		}

		public bool Equals(IDbServiceCommand other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;

			return string.Equals(GetCommandText(), other.GetCommandText());
		}
		#endregion
	}
}
