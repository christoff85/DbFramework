using NUnit.Framework;
using System.Data;
using DbFramework.Extensions;
using DbFramework.Interfaces.Database;
using DbFramework.Interfaces.DbOperations;
using DbFramework.ServiceManagers;
using NSubstitute;

namespace DbFramework.Tests.UnitTests.Extensions
{
	[TestFixture]
	public class DbServiceLogicExtensionsTests
	{
		[Test]
		public void CreateServiceAndExecuteLogicByExtensionsMethods_ExpectCallReceivedOnLogicExecuteWithNoTransactionServiceArgument()
		{
			var serviceLogic = Substitute.For<IDbServiceLogic<bool>>();
			var databaseStub = Substitute.For<IDatabase>();
			serviceLogic.CreateServiceAndExecute(databaseStub);
			serviceLogic.Received().Execute(Arg.Any<NoTransactionDbServiceManager>());
		}

		[Test]
		public void CreateTransactionServiceAndExecuteLogicByExtensionsMethods_ExpectCallReceivedOnLogicExecuteWithTransactionServiceArgument()
		{
			var serviceLogic = Substitute.For<IDbServiceLogic<bool>>();
			var databaseStub = Substitute.For<IDatabase>();
			serviceLogic.CreateTransactionServiceAndExecute(databaseStub);
			serviceLogic.Received().Execute(Arg.Any<TransactionDbServiceManager>());
		}

		[Test]
		public void CreateTransactionServiceWithCustomLevelAndExecuteLogicByExtensionsMethods_ExpectCallReceivedOnLogicExecuteWithTransactionServiceArgument()
		{
			var serviceLogic = Substitute.For<IDbServiceLogic<bool>>();
			var databaseStub = Substitute.For<IDatabase>();
			serviceLogic.CreateTransactionServiceAndExecute(databaseStub, IsolationLevel.Chaos);
			serviceLogic.Received().Execute(Arg.Any<TransactionDbServiceManager>());
		}
	}
}
