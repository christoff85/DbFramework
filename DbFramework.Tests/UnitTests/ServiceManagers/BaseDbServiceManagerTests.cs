using NUnit.Framework;
using System;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using DbFramework.Interfaces.Database;
using DbFramework.ServiceManagers;
using NSubstitute;

namespace DbFramework.Tests.UnitTests.ServiceManagers
{
	[TestFixture]
	public class BaseDbServiceManagerTests
	{
		private IDatabase _databaseStub;

		[SetUp]
		public void Init()
		{
			_databaseStub = Substitute.For<IDatabase>();
		}

		[Test]
		public void InitializeBaseDbServiceManagerWithNullDatabase_ExceptArgumentNullException()
		{
			Assert.Throws<ArgumentNullException>(() => CreateTestDbServiceManager(null));
		}

		[Test]
		public void RunDisposeOnBaseServiceManagerWithoutConnectionAndTransaction_ExpectDoesNotThrowException()
		{
			var testDbServiceManager = CreateTestDbServiceManager(_databaseStub);

			Assert.DoesNotThrow(testDbServiceManager.Dispose);
		}

		[Test]
		public void RunDisposeOnBaseServiceManagerWithOpenConnection_ExpectConnectionDisposeReceivedCall()
		{
			var testDbServiceManager = CreateTestDbServiceManager(_databaseStub);
			
			var connectionStub = Substitute.For<IDbConnection>();
			_databaseStub.CreateConnection().Returns(connectionStub);

			testDbServiceManager.CreateAndOpenConnection();
			testDbServiceManager.Dispose();

			connectionStub.Received().Dispose();
		}

		[Test]
		public void RunDisposeOnBaseServiceManagerWithTransaction_ExpectTransactionDisposeReceivedCall()
		{
			var testDbServiceManager = CreateTestDbServiceManager(_databaseStub);
			var transactionStub = Substitute.For<IDbTransaction>();

			testDbServiceManager.DbTransaction = transactionStub;
			testDbServiceManager.Dispose();

			transactionStub.Received().Dispose();
		}

		private TestDbServiceManager CreateTestDbServiceManager(IDatabase database) 
			=> new TestDbServiceManager(database);

		[ExcludeFromCodeCoverage]
		private class TestDbServiceManager : DbServiceManager
		{
			public TestDbServiceManager(IDatabase database) : base(database){ }
			public override void BeginTransaction() => throw new NotImplementedException();
			public override void CommitTransaction() => throw new NotImplementedException();
			public override void RollbackTransaction() => throw new NotImplementedException();
			public override IDataReader ExecuteReader(IDbCommand command) => throw new NotImplementedException();
			public override int ExecuteNonQuery(IDbCommand command) => throw new NotImplementedException();
			public override object ExecuteScalar(IDbCommand command) => throw new NotImplementedException();
		}
	}
}
