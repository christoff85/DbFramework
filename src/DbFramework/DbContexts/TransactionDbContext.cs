using DbFramework.Interfaces;
using DbFramework.Interfaces.Factories;

namespace DbFramework.DbContexts
{
    public class TransactionDbContext : DbContext, ITransactionDbContext
    {
        public TransactionDbContext(IDbInvokerFactory dbInvokerFactory, IDbManager dbManager) : base(dbInvokerFactory, dbManager)
        {
        }
    }
}
