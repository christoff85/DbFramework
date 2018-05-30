using System.Data;
using DbFramework.Interfaces.Database;
using DbFramework.Interfaces.ServiceManagers;
using DbFramework.ServiceManagers;
using NSubstitute;
using NUnit.Framework;

namespace DbFramework.Tests.UnitTests.ServiceManagers
{
    [TestFixture]
    public class NoTransactionDbServiceManagerTests
    {
		[Test]
        public void BeginTransaction_CheckIfTransactionIsNull_ExpectTrue()
        {
	        var databaseStub = Substitute.For<IDatabase>();
			var dbServiceManager = CreateDbServiceManager(databaseStub);

            dbServiceManager.BeginTransaction();

            Assert.IsNull(dbServiceManager.DbTransaction);
        }

	    [Test]
		public void BeginTransaction_CheckIfCommitRaisesException_ExpectFalse()
	    {
		    var databaseStub = Substitute.For<IDatabase>();
			var dbServiceManager = CreateDbServiceManager(databaseStub);

		    dbServiceManager.BeginTransaction();
		    Assert.DoesNotThrow(() => dbServiceManager.CommitTransaction());
	    }

	    [Test]
		public void BeginTransaction_CheckIfRollbackRaisesException_ExpectFalse()
	    {
		    var databaseStub = Substitute.For<IDatabase>();
			var dbServiceManager = CreateDbServiceManager(databaseStub);

		    dbServiceManager.BeginTransaction();
		    Assert.DoesNotThrow(() => dbServiceManager.RollbackTransaction());
	    }

	    [Test]
	    public void ExecuteReader_ExpectReaderStubReturned()
	    {
		    var databaseMock = Substitute.For<IDatabase>();
		    var commandStub = Substitute.For<IDbCommand>();
		    var readerStub = Substitute.For<IDataReader>();
		    databaseMock.ExecuteReader(commandStub).Returns(readerStub);

		    var dbServiceManager = CreateDbServiceManager(databaseMock);
			var result = dbServiceManager.ExecuteReader(commandStub);

		    Assert.AreEqual(readerStub, result);
	    }

	    [Test]
	    public void ExecuteNonQuery_ExpectFakeResult()
	    {
		    var databaseMock = Substitute.For<IDatabase>();
		    var commandStub = Substitute.For<IDbCommand>();
		    var fakeResult = 1;
		    databaseMock.ExecuteNonQuery(commandStub).Returns(fakeResult);

		    var dbServiceManager = CreateDbServiceManager(databaseMock);
		    var result = dbServiceManager.ExecuteNonQuery(commandStub);

		    Assert.AreEqual(fakeResult, result);
	    }

	    [Test]
	    public void ExecuteScalar_ExpectFakeResult()
	    {
		    var databaseMock = Substitute.For<IDatabase>();
		    var commandStub = Substitute.For<IDbCommand>();
		    var fakeResult = 1;
		    databaseMock.ExecuteScalar(commandStub).Returns(fakeResult);

		    var dbServiceManager = CreateDbServiceManager(databaseMock);
		    var result = (int)dbServiceManager.ExecuteScalar(commandStub);

		    Assert.AreEqual(fakeResult, result);
	    }

	    private IDbServiceManager CreateDbServiceManager(IDatabase fakeDatabase) => new NoTransactionDbServiceManager(fakeDatabase);
	}
}
