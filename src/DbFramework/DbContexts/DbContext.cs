using System;
using System.Collections.Generic;
using System.Linq;
using DbFramework.DbCommands;
using DbFramework.Interfaces;
using DbFramework.Interfaces.Factories;

namespace DbFramework.DbContexts
{
    public class DbContext : IDbContext
	{
	    private readonly IDbInvokerFactory _dbInvokerFactory;
	    private readonly IDbManager _dbManager;

	    public DbContext(IDbInvokerFactory dbInvokerFactory, IDbManager dbManager)
	    {
		    _dbInvokerFactory = dbInvokerFactory ?? throw new ArgumentNullException(nameof(dbInvokerFactory));
		    _dbManager = dbManager ?? throw new ArgumentNullException(nameof(dbManager));
		}

	    public bool IsInTransaction => _dbManager.IsInTransaction;

	    public void SaveChanges()
	    {
	        _dbManager.SaveChanges();
	    }

	    public IEnumerable<TResult> ExecuteCommand<TResult>(IManyResultsCommand<TResult> command)
		    => _dbInvokerFactory.Create(command).Invoke(_dbManager);

		public int ExecuteCommand(INonQueryCommand command)
		    => _dbInvokerFactory.Create(command).Invoke(_dbManager);

		public int ExecuteCommand(INonQueryCommandComposite composite)
		    => composite.Sum(command => _dbInvokerFactory.Create(command).Invoke(_dbManager));

		public TResult ExecuteCommand<TResult>(INonQueryCommand<TResult> command)
			=> _dbInvokerFactory.Create(command).Invoke(_dbManager);

		public bool ExecuteCommand(IDoesResultExistCommand command)
		    => _dbInvokerFactory.Create(command).Invoke(_dbManager);

		public TResult ExecuteCommand<TResult>(IScalarCommand<TResult> command)
		    => _dbInvokerFactory.Create(command).Invoke(_dbManager);

		public TResult ExecuteCommand<TResult>(ISingleResultCommand<TResult> command)
			=> _dbInvokerFactory.Create(command).Invoke(_dbManager);

		public TResult ExecuteCommand<TResult>(ISingleResultOrDefaultCommand<TResult> command)
			=> _dbInvokerFactory.Create(command).Invoke(_dbManager);

		public TResult ExecuteCommand<TResult>(IFirstResultCommand<TResult> command)
			=> _dbInvokerFactory.Create(command).Invoke(_dbManager);

		public TResult ExecuteCommand<TResult>(IFirstResultOrDefaultCommand<TResult> command)
			=> _dbInvokerFactory.Create(command).Invoke(_dbManager);

	    //public async Task<IEnumerable<TResult>> ExecuteCommandAsync<TResult>(IManyResultsCommand<TResult> command)
	    //    => await ExecuteCommandAsync(command, CancellationToken.None);

	    //public async Task<int> ExecuteCommandAsync(INonQueryCommand command)
	    //    => await ExecuteCommandAsync(command, CancellationToken.None);

     //   public async Task<int> ExecuteCommandAsync(INonQueryCommandComposite composite)
     //       => await ExecuteCommandAsync(composite, CancellationToken.None);

     //   public async Task<TResult> ExecuteCommandAsync<TResult>(INonQueryCommand<TResult> command)
     //       => await ExecuteCommandAsync(command, CancellationToken.None);

     //   public async Task<bool> ExecuteCommandAsync(IDoesResultExistCommand command)
     //       => await ExecuteCommandAsync(command, CancellationToken.None);

     //   public async Task<TResult> ExecuteCommandAsync<TResult>(IScalarCommand<TResult> command)
     //       => await ExecuteCommandAsync(command, CancellationToken.None);

     //   public async Task<TResult> ExecuteCommandAsync<TResult>(ISingleResultCommand<TResult> command)
     //       => await ExecuteCommandAsync(command, CancellationToken.None);

     //   public async Task<TResult> ExecuteCommandAsync<TResult>(ISingleResultOrDefaultCommand<TResult> command)
     //       => await ExecuteCommandAsync(command, CancellationToken.None);

     //   public async Task<TResult> ExecuteCommandAsync<TResult>(IFirstResultCommand<TResult> command)
     //       => await ExecuteCommandAsync(command, CancellationToken.None);

     //   public async Task<TResult> ExecuteCommandAsync<TResult>(IFirstResultOrDefaultCommand<TResult> command)
     //       => await ExecuteCommandAsync(command, CancellationToken.None);


     //   public async Task<IEnumerable<TResult>> ExecuteCommandAsync<TResult>(IManyResultsCommand<TResult> command, CancellationToken cancellationToken)
	    //    => await _dbInvokerFactory.Create(command).InvokeAsync(_dbManager, cancellationToken);

	    //public async Task<int> ExecuteCommandAsync(INonQueryCommand command, CancellationToken cancellationToken)
	    //    => await _dbInvokerFactory.Create(command).InvokeAsync(_dbManager, cancellationToken);

	    //public async Task<int> ExecuteCommandAsync(INonQueryCommandComposite composite, CancellationToken cancellationToken)
	    //{
	    //    var result = 0;
	    //    foreach (var command in composite)
	    //        result += await _dbInvokerFactory.Create(command).InvokeAsync(_dbManager, cancellationToken);

	    //    return result;
	    //}

	    //public async Task<TResult> ExecuteCommandAsync<TResult>(INonQueryCommand<TResult> command, CancellationToken cancellationToken)
	    //    => await _dbInvokerFactory.Create(command).InvokeAsync(_dbManager, cancellationToken);

	    //public async Task<bool> ExecuteCommandAsync(IDoesResultExistCommand command, CancellationToken cancellationToken)
	    //    => await _dbInvokerFactory.Create(command).InvokeAsync(_dbManager, cancellationToken);

	    //public async Task<TResult> ExecuteCommandAsync<TResult>(IScalarCommand<TResult> command, CancellationToken cancellationToken)
	    //    => await _dbInvokerFactory.Create(command).InvokeAsync(_dbManager, cancellationToken);

	    //public async Task<TResult> ExecuteCommandAsync<TResult>(ISingleResultCommand<TResult> command, CancellationToken cancellationToken)
	    //    => await _dbInvokerFactory.Create(command).InvokeAsync(_dbManager, cancellationToken);

	    //public async Task<TResult> ExecuteCommandAsync<TResult>(ISingleResultOrDefaultCommand<TResult> command, CancellationToken cancellationToken)
	    //    => await _dbInvokerFactory.Create(command).InvokeAsync(_dbManager, cancellationToken);

	    //public async Task<TResult> ExecuteCommandAsync<TResult>(IFirstResultCommand<TResult> command, CancellationToken cancellationToken)
	    //    => await _dbInvokerFactory.Create(command).InvokeAsync(_dbManager, cancellationToken);

	    //public async Task<TResult> ExecuteCommandAsync<TResult>(IFirstResultOrDefaultCommand<TResult> command, CancellationToken cancellationToken)
	    //    => await _dbInvokerFactory.Create(command).InvokeAsync(_dbManager, cancellationToken);

        public void Dispose()
	    {
	        _dbManager?.Dispose();
	    }
	}
}