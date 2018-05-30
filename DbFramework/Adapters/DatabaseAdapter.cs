using System.Data;
using System.Data.Common;
using DbFramework.Interfaces.Database;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace DbFramework.Adapters
{
	public class DatabaseAdapter : IDatabase
	{
		private Database Db { get; }

		public DatabaseAdapter(Database db) 
			=> Db = db;

		public IDbConnection CreateConnection() 
			=> Db.CreateConnection();

		public IDbCommand GetStoredProcCommand(string storedProcedureName) 
			=> Db.GetStoredProcCommand(storedProcedureName);

		public IDbCommand GetSqlStringCommand(string query) 
			=> Db.GetSqlStringCommand(query);

		public void DiscoverParameters(IDbCommand command) 
			=> Db.DiscoverParameters((DbCommand)command);

		public object ExecuteScalar(IDbCommand command) 
			=> Db.ExecuteScalar((DbCommand)command);

		public object ExecuteScalar(IDbCommand command, IDbTransaction transaction) 
			=> Db.ExecuteScalar((DbCommand)command, (DbTransaction)transaction);

		public IDataReader ExecuteReader(IDbCommand command) 
			=> Db.ExecuteReader((DbCommand)command);

		public IDataReader ExecuteReader(IDbCommand command, IDbTransaction transaction) 
			=> Db.ExecuteReader((DbCommand)command, (DbTransaction)transaction);

		public int ExecuteNonQuery(IDbCommand command) 
			=> Db.ExecuteNonQuery((DbCommand)command);

		public int ExecuteNonQuery(IDbCommand command, IDbTransaction transaction)
			=> Db.ExecuteNonQuery((DbCommand)command, (DbTransaction)transaction);
	}
}
