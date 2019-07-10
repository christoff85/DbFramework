using System;
using System.Data;
using DbFramework.Interfaces;

namespace DbFramework.DbManagers
{
    public abstract class DbManager : IDbManager
    {
        private IDbUtils DbUtils { get; }
	    protected IDbConnection DbConnection { get; set; }
        private string ConnectionString { get; }

        public abstract bool IsInTransaction { get; }

	    protected DbManager(IDbUtils dbUtils, string connectionString)
	    {
	        DbUtils = dbUtils ?? throw new ArgumentNullException(nameof(dbUtils));
	        ConnectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));
	    }

	    public virtual void StartConnection()
	    {
            DbConnection = DbUtils.CreateConnection(ConnectionString);
		    DbConnection.Open();
		}

        //public virtual async Task StartConnectionAsync()
        //{
        //    var connection = (DbConnection)DbUtils.CreateConnection(ConnectionString);
        //    DbConnection = connection;

        //    await connection.OpenAsync();
        //}

        public IDbCommand GetSqlStringCommand(string query)
        {
            var command = DbUtils.GetSqlStringCommand(query);
            SetCommandsConnection(command);

            return command;
        }

        public IDbCommand GetStoredProcCommand(string storedProcedureName)
        {
            var command = DbUtils.GetStoredProcCommand(storedProcedureName);
            SetCommandsConnection(command);

            return command;
        }

        protected virtual void SetCommandsConnection(IDbCommand command)
        {
            if(DbConnection == null)
                StartConnection();

            command.Connection = DbConnection;
        }

        public void DiscoverParameters(IDbCommand command)
        {
            DbUtils.DiscoverParameters(command);
        }
        
        //public async Task DiscoverParametersAsync(IDbCommand command, CancellationToken cancellationToken)
        //{
        //    await DbUtils.DiscoverParametersAsync(command, cancellationToken);
        //}
          
        public IDbReader ExecuteReader(IDbCommand command)
        {
            var reader = command.ExecuteReader();
            return new DbReader(reader);
        }

        //public async Task<IDbReader> ExecuteReaderAsync(IDbCommand command, CancellationToken cancellationToken)
        //{
        //    var dbCommand = (DbCommand)command;
        //    var reader = await dbCommand.ExecuteReaderAsync(cancellationToken);
        //    return new DbReader(reader);
        //}

        public int ExecuteNonQuery(IDbCommand command)
        {
            return command.ExecuteNonQuery();
        }

        //public async Task<int> ExecuteNonQueryAsync(IDbCommand command, CancellationToken cancellationToken)
        //{
        //    var dbCommand = (DbCommand)command;
        //    return await dbCommand.ExecuteNonQueryAsync(cancellationToken);
        //}

        public TResult ExecuteScalar<TResult>(IDbCommand command)
        {
            return (TResult)command.ExecuteScalar();
        }

        //public async Task<TResult> ExecuteScalarAsync<TResult>(IDbCommand command, CancellationToken cancellationToken)
        //{
        //    var dbCommand = (DbCommand)command;
        //    var result =  await dbCommand.ExecuteScalarAsync(cancellationToken);

        //    return (TResult) result;
        //}

        public abstract void SaveChanges();

        public virtual void Dispose()
	    {
            DbConnection?.Close();
		    DbConnection?.Dispose();
	        DbConnection = null;
	    }
    }
}