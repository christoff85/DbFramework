using System;
using System.Collections.Generic;
using DbFramework.DbCommands;

namespace DbFramework.Interfaces
{
	public interface IDbContext : IDisposable
	{
        bool IsInTransaction { get; }

	    void SaveChanges();

		int ExecuteCommand(INonQueryCommand command);
		int ExecuteCommand(INonQueryCommandComposite composite);
		bool ExecuteCommand(IDoesResultExistCommand command);
		TResult ExecuteCommand<TResult>(INonQueryCommand<TResult> command);
		TResult ExecuteCommand<TResult>(IScalarCommand<TResult> command);
		TResult ExecuteCommand<TResult>(ISingleResultCommand<TResult> command);
		TResult ExecuteCommand<TResult>(ISingleResultOrDefaultCommand<TResult> command);
		TResult ExecuteCommand<TResult>(IFirstResultCommand<TResult> command);
		TResult ExecuteCommand<TResult>(IFirstResultOrDefaultCommand<TResult> command);
		IEnumerable<TResult> ExecuteCommand<TResult>(IManyResultsCommand<TResult> command);

	    //Task<IEnumerable<TResult>> ExecuteCommandAsync<TResult>(IManyResultsCommand<TResult> command);
	    //Task<int> ExecuteCommandAsync(INonQueryCommand command);
	    //Task<int> ExecuteCommandAsync(INonQueryCommandComposite composite);
	    //Task<TResult> ExecuteCommandAsync<TResult>(INonQueryCommand<TResult> command);
	    //Task<bool> ExecuteCommandAsync(IDoesResultExistCommand command);
	    //Task<TResult> ExecuteCommandAsync<TResult>(IScalarCommand<TResult> command);
	    //Task<TResult> ExecuteCommandAsync<TResult>(ISingleResultCommand<TResult> command);
	    //Task<TResult> ExecuteCommandAsync<TResult>(ISingleResultOrDefaultCommand<TResult> command);
	    //Task<TResult> ExecuteCommandAsync<TResult>(IFirstResultCommand<TResult> command);
	    //Task<TResult> ExecuteCommandAsync<TResult>(IFirstResultOrDefaultCommand<TResult> command);

	    //Task<IEnumerable<TResult>> ExecuteCommandAsync<TResult>(IManyResultsCommand<TResult> command, CancellationToken cancellationToken);
	    //Task<int> ExecuteCommandAsync(INonQueryCommand command, CancellationToken cancellationToken);
	    //Task<int> ExecuteCommandAsync(INonQueryCommandComposite composite, CancellationToken cancellationToken);
	    //Task<TResult> ExecuteCommandAsync<TResult>(INonQueryCommand<TResult> command, CancellationToken cancellationToken);
	    //Task<bool> ExecuteCommandAsync(IDoesResultExistCommand command, CancellationToken cancellationToken);
	    //Task<TResult> ExecuteCommandAsync<TResult>(IScalarCommand<TResult> command, CancellationToken cancellationToken);
	    //Task<TResult> ExecuteCommandAsync<TResult>(ISingleResultCommand<TResult> command, CancellationToken cancellationToken);
	    //Task<TResult> ExecuteCommandAsync<TResult>(ISingleResultOrDefaultCommand<TResult> command, CancellationToken cancellationToken);
	    //Task<TResult> ExecuteCommandAsync<TResult>(IFirstResultCommand<TResult> command, CancellationToken cancellationToken);
	    //Task<TResult> ExecuteCommandAsync<TResult>(IFirstResultOrDefaultCommand<TResult> command, CancellationToken cancellationToken);
	}
}