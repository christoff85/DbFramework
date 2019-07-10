using System;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using DbFramework.DbContexts;
using DbFramework.Interfaces;
using DbFramework.Interfaces.Factories;

namespace DbFramework.Factories
{
    public class DbContextFactory : IDbContextFactory
    {
        private readonly IDbManagerFactory _managerFactory;
        private readonly IDbInvokerFactory _dbInvokerFactory;

        public DbContextFactory(IDbManagerFactory managerFactory, IDbInvokerFactory dbInvokerFactory)
        {
            _managerFactory = managerFactory ?? throw new ArgumentNullException(nameof(managerFactory));
            _dbInvokerFactory = dbInvokerFactory ?? throw new ArgumentNullException(nameof(dbInvokerFactory));
        }

        /// <summary>Temporary solution for easier refactoring. DO NOT USE IT, IF NOT NEEDED </summary>
        [ExcludeFromCodeCoverage]
        public IDbContext CreateFromExistingTransaction(IDbTransaction transaction)
        {
            var dbManager = _managerFactory.CreateTransactionDbManager(transaction);

            return new DbContext(_dbInvokerFactory, dbManager);
        }

        public IDbContext CreateNoTransactionContext()
        {
            var manager = _managerFactory.CreateNoTransactionDbManager();
            return CreateNewDbContextAndStartConnection(manager);
        }

        //public async Task<IDbContext> CreateNoTransactionContextAsync()
        //{
        //    var manager = _managerFactory.CreateNoTransactionDbManager();
        //    return await CreateNewDbContextAndStartConnectionAsync(manager);
        //}

        public IDbContext CreateTransactionContext()
        {
            var manager = _managerFactory.CreateTransactionDbManager();
            return CreateNewDbContextAndStartConnection(manager);
        }

        //public async Task<IDbContext> CreateTransactionContextAsync()
        //{
        //    var manager = _managerFactory.CreateTransactionDbManager();
        //    return await CreateNewDbContextAndStartConnectionAsync(manager);
        //}

        public IDbContext CreateTransactionContext(IsolationLevel isolationLevel)
        {
            var manager = _managerFactory.CreateTransactionDbManager(isolationLevel);
            return CreateNewDbContextAndStartConnection(manager);
        }

        //public async Task<IDbContext> CreateTransactionContextAsync(IsolationLevel isolationLevel)
        //{
        //    var manager = _managerFactory.CreateTransactionDbManager(isolationLevel);
        //    return await CreateNewDbContextAndStartConnectionAsync(manager);
        //}

        //private async Task<IDbContext> CreateNewDbContextAndStartConnectionAsync(IDbManager dbManager)
        //{
        //    var context = new DbContext(_dbInvokerFactory, dbManager);
        //    await dbManager.StartConnectionAsync();

        //    return context;
        //}

        private IDbContext CreateNewDbContextAndStartConnection(IDbManager dbManager)
        {
            var context = new DbContext(_dbInvokerFactory, dbManager);
            dbManager.StartConnection();

            return context;
        }
    }
}
