using DbFramework.Interfaces;
using DbFramework.Interfaces.Factories;

namespace DbFramework.DbContexts
{
    public class NoTransactionDbContext : DbContext, INoTransactionDbContext
    {
        public NoTransactionDbContext(IDbInvokerFactory dbInvokerFactory, IDbManager dbManager) : base(dbInvokerFactory, dbManager)
        {
        }
    }
}