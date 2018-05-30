using System.Data;
using DbFramework.Interfaces.Database;
using DbFramework.Interfaces.DbOperations;
using DbFramework.Interfaces.Services;
using DbFramework.Services;

namespace DbFramework.Factories
{
    public static class DbService
    {
        public static IDbService<TResult> CreateService<TResult>(IDatabase db, IDbServiceLogic<TResult> dbServiceLogic) 
	        => new DbServiceBuilder<TResult>(db, dbServiceLogic).Build();

		public static IDbService<TResult> CreateTransactionService<TResult>(IDatabase db, IDbServiceLogic<TResult> dbServiceLogic) 
			=> new DbServiceBuilder<TResult>(db, dbServiceLogic).WithTransaction().Build();

		public static IDbService<TResult> CreateTransactionService<TResult>(IDatabase db, IDbServiceLogic<TResult> dbServiceLogic, IsolationLevel level)
			=> new DbServiceBuilder<TResult>(db, dbServiceLogic).WithTransaction(level).Build();
    }
}
