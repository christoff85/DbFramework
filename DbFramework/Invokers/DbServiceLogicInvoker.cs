using System;
using DbFramework.Interfaces.DbOperations;
using DbFramework.Interfaces.Invokers;
using DbFramework.Interfaces.ServiceManagers;

namespace DbFramework.Invokers
{
	class DbServiceLogicInvoker<TResult> : DbServiceComponentInvoker<TResult>, IDbServiceLogicInvoker<TResult>
	{
		private IDbServiceLogic<TResult> Logic { get; }

		public DbServiceLogicInvoker(IDbServiceLogic<TResult> logic)
		{
			Logic = logic ?? throw new ArgumentNullException(nameof(logic));
		}

		protected override string InvokedMemberName()
			=> Logic.GetType().FullName;

		protected override TResult Execute(IDbServiceManager dbServiceManager)
			=> Logic.Execute(dbServiceManager);
	}
}
