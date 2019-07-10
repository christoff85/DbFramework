using System;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using DbFramework.DbManagers;
using DbFramework.Interfaces;
using NSubstitute;
using NUnit.Framework;

namespace DbFramework.Tests.UnitTests.DbManagers
{
	[TestFixture]
	public class BaseDbManagerTests
	{
		private IDbUtils _dbUtilsStub;

		[SetUp]
		public void Init()
		{
			_dbUtilsStub = Substitute.For<IDbUtils>();
		}

		[Test]
		public void InitializeBaseDbServiceManagerWithNullDatabase_ExceptArgumentNullException()
		{
			Assert.Throws<ArgumentNullException>(() => CreateTestDbServiceManager(null, "falseConnectionString"));
		}

		[Test]
		public void RunDisposeOnBaseServiceManagerWithoutConnectionAndTransaction_ExpectDoesNotThrowException()
		{
			var testDbServiceManager = CreateTestDbServiceManager(_dbUtilsStub, "falseConnectionString");

			Assert.DoesNotThrow(testDbServiceManager.Dispose);
		}

		[Test]
		public void RunDisposeOnBaseServiceManagerWithOpenConnection_ExpectConnectionDisposeReceivedCall()
		{
		    var connectionString = "connectionString";
			var testDbServiceManager = CreateTestDbServiceManager(_dbUtilsStub, connectionString);

			var connectionStub = Substitute.For<IDbConnection>();
			_dbUtilsStub.CreateConnection(connectionString).Returns(connectionStub);

			testDbServiceManager.StartConnection();
			testDbServiceManager.Dispose();

			connectionStub.Received().Dispose();
		}

        private TestDbServiceManager CreateTestDbServiceManager(IDbUtils dbUtils, string connectionString) 
			=> new TestDbServiceManager(dbUtils, connectionString);

		[ExcludeFromCodeCoverage]
		private class TestDbServiceManager : DbManager
		{
			public TestDbServiceManager(IDbUtils dbUtils, string connectionString) 
				: base(dbUtils, connectionString) { }

		    public override bool IsInTransaction => false;
		    public override void SaveChanges() => throw new NotImplementedException();
		}
	}
}
