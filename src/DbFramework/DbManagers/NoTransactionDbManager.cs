using System;
using DbFramework.Interfaces;

namespace DbFramework.DbManagers
{
    public class NoTransactionDbManager : DbManager
    {
        public NoTransactionDbManager(IDbUtils dbUtils, string connectionString) : base(dbUtils, connectionString)
        {
        }

        public override bool IsInTransaction => false;

        public override void SaveChanges()
        {
            throw new InvalidOperationException("Operation without transaction does require commiting changes");
        }
    }
}