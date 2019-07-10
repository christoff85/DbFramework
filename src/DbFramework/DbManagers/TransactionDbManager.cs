using System;
using System.Data;
using DbFramework.Interfaces;

namespace DbFramework.DbManagers
{
	public class TransactionDbManager : DbManager
	{
	    private IsolationLevel IsolationLevel { get; }
	    private bool IsMyTransaction { get; set; }
        private bool WasTransactionOpened { get; set; }

        public IDbTransaction DbTransaction { get; private set; }

	    public override bool IsInTransaction => DbTransaction != null;

	    public TransactionDbManager(IDbUtils dbUtils, string connectionString) 
			: this(dbUtils, connectionString, IsolationLevel.ReadCommitted)
		{
		}

	    internal TransactionDbManager(IDbUtils dbUtils, IDbTransaction transaction)
	        : base(dbUtils, string.Empty)
	    {
	        DbTransaction = transaction ?? throw new ArgumentNullException(nameof(transaction));
	        DbConnection = transaction.Connection;

	        IsMyTransaction = false;
        }

	    public TransactionDbManager(IDbUtils dbUtils, string connectionString, IsolationLevel isolationLevel) 
			: base(dbUtils, connectionString)
		{
			IsolationLevel = isolationLevel;
        }

	    public override void StartConnection()
	    {
	        base.StartConnection();
	        DbTransaction = DbConnection.BeginTransaction(IsolationLevel);

	        IsMyTransaction = true;
            WasTransactionOpened = true;
        }


	    protected override void SetCommandsConnection(IDbCommand command)
	    {
	        base.SetCommandsConnection(command);
            command.Transaction = DbTransaction;
        }

	    public override void SaveChanges()
        {
            if (!WasTransactionOpened)
                return;

            if(!IsMyTransaction)
                throw new InvalidOperationException("Attempt to close external transaction");


            if (DbTransaction == null)
                throw new InvalidOperationException("Transaction is already closed.");

	        DbTransaction.Commit();
	        RemoveTransactionFromManager();
        }
        
        public override void Dispose()
	    {
	        if (IsMyTransaction)
	        {
	            if (DbTransaction != null)
	            {
	                DbTransaction.Rollback();
	                RemoveTransactionFromManager();
                }
	            
                ClearTransactionState();

	            base.Dispose();
            }
	    }

	    private void ClearTransactionState()
	    {
	        if (IsolationLevel == IsolationLevel.ReadCommitted)
	            return;

	        DbConnection.BeginTransaction().Commit();
	    }

	    private void RemoveTransactionFromManager()
	    {
	        DbTransaction.Dispose();
	        DbTransaction = null;
        }
    }
}
