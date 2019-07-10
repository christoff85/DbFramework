using System;
using System.Data;
using DbFramework.DbManagers;
using DbFramework.Interfaces;
using DbFramework.Interfaces.Factories;
using DbFramework.Interfaces.Providers;

namespace DbFramework.Factories
{
	public class DbManagerFactory : IDbManagerFactory
	{
	    private readonly IDbUtils _dbUtils;
        private readonly IDbConnectionStringProvider _connectionStringProvider;

		public DbManagerFactory(IDbUtils dbUtilsUtils, IDbConnectionStringProvider connectionStringProvider)
		{
		    _connectionStringProvider = connectionStringProvider ?? throw new ArgumentNullException(nameof(connectionStringProvider));
		    _dbUtils = dbUtilsUtils ?? throw new ArgumentNullException(nameof(dbUtilsUtils));
		}

		public IDbManager CreateNoTransactionDbManager()
			=> new NoTransactionDbManager(_dbUtils, _connectionStringProvider.GetConnectionString());

		public IDbManager CreateTransactionDbManager() 
			=> new TransactionDbManager(_dbUtils, _connectionStringProvider.GetConnectionString());

        public IDbManager CreateTransactionDbManager(IsolationLevel isolationLevel)
			=> new TransactionDbManager(_dbUtils, _connectionStringProvider.GetConnectionString(), isolationLevel);

	    public IDbManager CreateTransactionDbManager(IDbTransaction existingTransaction)
	        => new TransactionDbManager(_dbUtils, existingTransaction);
    }
}
