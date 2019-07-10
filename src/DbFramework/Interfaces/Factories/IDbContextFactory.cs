using System.Data;

namespace DbFramework.Interfaces.Factories
{
    public interface IDbContextFactory
    {
        /// <summary>Temporary solution for easier refactoring. DO NOT USE IT, IF NOT NEEDED </summary>
        IDbContext CreateFromExistingTransaction(IDbTransaction transaction);

        IDbContext CreateNoTransactionContext();
        IDbContext CreateTransactionContext();
        IDbContext CreateTransactionContext(IsolationLevel isolationLevel);
        //Task<IDbContext> CreateNoTransactionContextAsync();
        //Task<IDbContext> CreateTransactionContextAsync();
        //Task<IDbContext> CreateTransactionContextAsync(IsolationLevel isolationLevel);
    }
}