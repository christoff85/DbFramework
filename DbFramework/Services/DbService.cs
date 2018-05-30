using System;
using DbFramework.Exceptions;
using DbFramework.Extensions;
using DbFramework.Interfaces.DbOperations;
using DbFramework.Interfaces.ServiceManagers;
using DbFramework.Interfaces.Services;
using log4net;

namespace DbFramework.Services
{
	public class DbService<TResult> : IDbService<TResult>
	{
		public IDbServiceLogic<TResult> DbServiceLogic { get; }
		internal IDbServiceManager DbServiceManager { get; }

		private ILog Logger { get; }

		internal DbService(DbServiceBuilder<TResult> builder)
			: this(builder.DbServiceLogic, builder.DbServiceManager)
		{
		}

		internal DbService(IDbServiceLogic<TResult> dbServiceLogic, IDbServiceManager dbServiceManager)
		{
			Logger = LogManager.GetLogger(GetType());

			DbServiceLogic = dbServiceLogic ?? throw new ArgumentNullException(nameof(dbServiceLogic));
			DbServiceManager = dbServiceManager ?? throw new ArgumentNullException(nameof(dbServiceManager));
		}

		public TResult Execute()
		{
			var methodName = $"{GetType().Name}.{nameof(Execute)}({DbServiceLogic.GetType().Name})";
			Logger.DebugFormat("Method invoked: {0}", methodName);

			using (DbServiceManager)
			{
				DbServiceManager.CreateAndOpenConnection();
				DbServiceManager.BeginTransaction();
				try
				{
					var result = DbServiceLogic.Invoke(DbServiceManager);

					DbServiceManager.CommitTransaction();
					return result;
				}
				catch (Exception ex)
				{
					Logger.Error($"Error in method: {methodName}", ex);
					DbServiceManager.RollbackTransaction();

					throw new DbServiceException(ex.Message, ex);
				}
			}
		}
	}
}
