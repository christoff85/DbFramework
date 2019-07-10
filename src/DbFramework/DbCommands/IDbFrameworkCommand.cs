using System;
using System.Data;
using DbFramework.Interfaces;

namespace DbFramework.DbCommands
{
    public interface IDbFrameworkCommand : IEquatable<IDbFrameworkCommand>
	{
		IDbParameters Parameters { get; }
	    IDbCommand GetDbCommandWithAssignedParameters(IDbManager dbManager);
	    //Task<IDbCommand> GetDbCommandWithAssignedParametersAsync(IDbManager dbManager, CancellationToken cancellationToken);

	    string GetCommandText();
	}
}
