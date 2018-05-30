using System;
using System.Data;
using DbFramework.Factories;
using DbFramework.Interfaces.Database;
using DbFramework.Interfaces.DbOperations;
using DbFramework.Interfaces.Factories;
using DbFramework.Interfaces.ServiceManagers;
using DbFramework.Interfaces.Services;

namespace DbFramework.Services
{
    internal class DbServiceBuilder<TResult>
    {
        internal IDatabase Database { get; }
        internal IDbServiceLogic<TResult> DbServiceLogic { get; }
        internal IDbServiceManager DbServiceManager { get; set; }
		internal IDbServiceManagerFactory DbServiceManagerFactory { private get; set; } = new DbServiceManagerFactory();

        internal DbServiceBuilder(IDatabase db, IDbServiceLogic<TResult> dbServiceLogic)
        {
            Database = db ?? throw new ArgumentNullException(nameof(db));
            DbServiceLogic = dbServiceLogic ?? throw new ArgumentNullException(nameof(dbServiceLogic));
        }

        public DbServiceBuilder<TResult> WithTransaction()
        {
	        DbServiceManager = DbServiceManagerFactory.CreateTransactionDbServiceManager(Database);
            return this;
        }

        public DbServiceBuilder<TResult> WithTransaction(IsolationLevel isolationLevel)
        {
	        DbServiceManager = DbServiceManagerFactory.CreateTransactionDbServiceManager(Database, isolationLevel);
            return this;
        }

        public IDbService<TResult> Build()
        {
            if (DbServiceManager == null)
	            DbServiceManager = DbServiceManagerFactory.CreateNoTransactionDbServiceManager(Database);

            return new DbService<TResult>(this);
        }
    }
}