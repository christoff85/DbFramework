using System;
using System.Data;
using System.Data.Common;
using DbFramework.Interfaces;

namespace DbFramework
{
    public abstract class BaseDbUtils : IDbUtils
    {
        private readonly DbProviderFactory _dbProviderFactory;

        protected BaseDbUtils(DbProviderFactory dbProviderFactory)
        {
            _dbProviderFactory = dbProviderFactory ?? throw new ArgumentNullException(nameof(dbProviderFactory));
        }

        public virtual IDbConnection CreateConnection(string connectionString)
        {
            var connection = _dbProviderFactory.CreateConnection();
            connection.ConnectionString = connectionString;
            return connection;
        }

        public virtual IDbCommand GetStoredProcCommand(string storedProcedureName)
        {
            if (string.IsNullOrEmpty(storedProcedureName))
                throw new ArgumentException("Null or empty string", nameof(storedProcedureName));
            return CreateCommandByCommandType(CommandType.StoredProcedure, storedProcedureName);
        }

        public IDbCommand GetSqlStringCommand(string query)
        {
            if (string.IsNullOrEmpty(query))
                throw new ArgumentException("Null or empty string", nameof(query));
            return CreateCommandByCommandType(CommandType.Text, query);
        }

        //public Task DiscoverParametersAsync(IDbCommand command, CancellationToken cancellationToken)
        //{
        //    if (cancellationToken.IsCancellationRequested)
        //        return CreatedTaskWithCancellation<bool>();

        //    var tokenRegistration = new CancellationTokenRegistration();
        //    try
        //    {
        //        DiscoverParameters(command);
        //        return Task.FromResult(true);
        //    }
        //    catch (Exception ex)
        //    {
        //        tokenRegistration.Dispose();
        //        return CreatedTaskWithException<bool>(ex);
        //    }
        //}

        public void DiscoverParameters(IDbCommand command)
        {
            if (command == null) throw new ArgumentNullException(nameof(command));
            if (command.Connection == null) throw new ArgumentException("Command has no assigned conenction");
            using (var commandByCommandType = CreateCommandByCommandType(command.CommandType, command.CommandText))
            {
                commandByCommandType.Connection = command.Connection;
                commandByCommandType.Transaction = command.Transaction;
                DeriveParameters(commandByCommandType);
                foreach (ICloneable parameter in commandByCommandType.Parameters)
                {
                    IDataParameter dataParameter = (IDataParameter)parameter.Clone();
                    command.Parameters.Add(dataParameter);
                }
            }
        }

        //private Task<T> CreatedTaskWithCancellation<T>()
        //{
        //    TaskCompletionSource<T> completionSource = new TaskCompletionSource<T>();
        //    completionSource.SetCanceled();
        //    return completionSource.Task;
        //}

        //private Task<T> CreatedTaskWithException<T>(Exception ex)
        //{
        //    TaskCompletionSource<T> completionSource = new TaskCompletionSource<T>();
        //    completionSource.SetException(ex);
        //    return completionSource.Task;
        //}

        private IDbCommand CreateCommandByCommandType(CommandType commandType, string commandText)
        {
            var command = _dbProviderFactory.CreateCommand();
            command.CommandType = commandType;
            command.CommandText = commandText;
            return command;
        }

        protected abstract void DeriveParameters(IDbCommand discoveryCommand);
    }
}
