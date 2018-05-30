using System;
using System.Collections.Generic;
using System.Data;
using DbFramework.Interfaces.Database;
using DbFramework.Interfaces.DbOperations;
using DbFramework.Interfaces.Invokers;
using DbFramework.Interfaces.Parameters;
using DbFramework.Interfaces.ServiceManagers;

namespace DbFramework.Invokers
{
    public abstract class DbServiceCommandInvoker<TDbServiceCommand, TResult> 
	    : DbServiceComponentInvoker<TResult>, IDbServiceCommandInvoker<TResult> 
	    where TDbServiceCommand : IDbServiceCommand
    {
		protected TDbServiceCommand Command { get; set; }
        protected IDbParameters Parameters { get; set; }

        protected DbServiceCommandInvoker(TDbServiceCommand command)
        {
			if (command == null) throw new ArgumentNullException(nameof(command));

			Command = command;
		}

	    protected override string InvokedMemberName()
		    => Command.GetType().FullName;

		protected override TResult Execute(IDbServiceManager dbServiceManager)
        {
		    var command = GetCommandWithAssignedParameters(dbServiceManager.Database, Command.Parameters);
		    return Execute(dbServiceManager, command);
        }

        protected virtual IDbCommand GetCommandWithAssignedParameters(IDatabase db, IDbParameters parameters)
        {
            var command = Command.GetDbCommand(db);

            foreach (var parameter in parameters)
				Command.AddDbParameter(command, parameter);

            return command;
        }

        protected abstract TResult Execute(IDbServiceManager dbServiceManager, IDbCommand command);

	    #region IEquatable implementation
		protected bool Equals(DbServiceCommandInvoker<TDbServiceCommand, TResult> other) 
		    => EqualityComparer<TDbServiceCommand>.Default.Equals(Command, other.Command);

	    public bool Equals(IDbServiceCommandInvoker<TResult> other) 
		    => Equals((DbServiceCommandInvoker<TDbServiceCommand, TResult>) other);

	    public override bool Equals(object obj)
	    {
		    if (ReferenceEquals(null, obj)) return false;
		    if (ReferenceEquals(this, obj)) return true;
		    if (obj.GetType() != GetType()) return false;

		    return Equals((DbServiceCommandInvoker<TDbServiceCommand, TResult>) obj);
	    }

	    public override int GetHashCode()
		    => EqualityComparer<TDbServiceCommand>.Default.GetHashCode(Command);
		#endregion
	}
}
