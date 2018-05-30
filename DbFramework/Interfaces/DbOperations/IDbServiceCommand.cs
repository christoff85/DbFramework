using System;
using System.Data;
using DbFramework.Interfaces.Database;
using DbFramework.Interfaces.Parameters;

namespace DbFramework.Interfaces.DbOperations
{
    public interface IDbServiceCommand : IDbServiceComponent, IEquatable<IDbServiceCommand>
	{
        IDbParameters Parameters { get; }
        IDbCommand GetDbCommand(IDatabase db);
	    void AddDbParameter(IDbCommand command, IDbParameter parameter);
	    string GetCommandText();
    }
}
