using System.Data;
using DbFramework.Interfaces.Database;
using DbFramework.Interfaces.ServiceManagers;
using DbFramework.ServiceManagers;
using NSubstitute;
using NUnit.Framework;

namespace DbFramework.Tests.UnitTests.ServiceManagers
{
    [TestFixture]
    public class TransactionDbServiceManagerTests
    {
        private readonly IsolationLevel _defaultLevel = IsolationLevel.ReadCommitted;
        private readonly IsolationLevel _customLevel = IsolationLevel.Chaos;

	    private IDatabase _databaseStub;
        private IDbConnection _connectionStub;
        private IDbTransaction _transactionStub;

        [SetUp]
        public void Init()
        {
	        _databaseStub = Substitute.For<IDatabase>();
            _connectionStub = Substitute.For<IDbConnection>();
            _transactionStub = Substitute.For<IDbTransaction>();
		}

        [Test]
        public void CreateAndBeginTransactionWithDefaultIsolationLevel()
        {
	        _databaseStub.CreateConnection().Returns(_connectionStub);
			_connectionStub.BeginTransaction(_defaultLevel).Returns(_transactionStub);

            var dbServiceManager = CreateDbServiceManager();
	        dbServiceManager.CreateAndOpenConnection();
			dbServiceManager.BeginTransaction();

            Assert.AreEqual(_transactionStub, dbServiceManager.DbTransaction);
        }

        [Test]
        public void CreateAndBeginTransactionWithCustomIsolationLevel()
        {
	        _databaseStub.CreateConnection().Returns(_connectionStub);
			_connectionStub.BeginTransaction(_customLevel).Returns(_transactionStub);

	        var dbServiceManager = CreateDbServiceManager(_customLevel);
			dbServiceManager.CreateAndOpenConnection();
	        dbServiceManager.BeginTransaction();

            Assert.AreEqual(_transactionStub, dbServiceManager.DbTransaction);
        }

        [Test]
        public void CreateTransactionWithDefaultIsolationLevelAndCommit_CheckIfCommited_ExpectTrue()
        {
	        _databaseStub.CreateConnection().Returns(_connectionStub);
			_connectionStub.BeginTransaction(_defaultLevel).Returns(_transactionStub);

	        var dbServiceManager = CreateDbServiceManager();
	        dbServiceManager.CreateAndOpenConnection();
			dbServiceManager.BeginTransaction();
	        dbServiceManager.CommitTransaction();

            _transactionStub.Received().Commit();
        }

        [Test]
        public void CreateTransactionWithDefaultIsolationLevelAndRollback_CheckIfRollbacked_ExpectTrue()
        {
	        _databaseStub.CreateConnection().Returns(_connectionStub);
			_connectionStub.BeginTransaction(_defaultLevel).Returns(_transactionStub);

            var dbServiceManager = CreateDbServiceManager();
	        dbServiceManager.CreateAndOpenConnection();
			dbServiceManager.BeginTransaction();
	        dbServiceManager.RollbackTransaction();

            _transactionStub.Received().Rollback();;
        }

	    [Test]
	    public void CreateTransactionWithCustomIsolationLevelAndCommit_CheckIfTransactionStateWasCleared_ExpectTrue()
	    {
		    _databaseStub.CreateConnection().Returns(_connectionStub);
			_connectionStub.BeginTransaction().Returns(_transactionStub); // Cleaning state transaction

		    var dbServiceManager = CreateDbServiceManager(_customLevel);
		    dbServiceManager.CreateAndOpenConnection();
		    dbServiceManager.BeginTransaction();
		    dbServiceManager.CommitTransaction();

		    _transactionStub.Received().Commit();
	    }

	    [Test]
	    public void ExecuteReader_ExpectReaderStubReturned()
	    {
		    var commandStub = Substitute.For<IDbCommand>();
		    var readerStub = Substitute.For<IDataReader>();

		    _databaseStub.CreateConnection().Returns(_connectionStub);
		    _connectionStub.BeginTransaction(_defaultLevel).Returns(_transactionStub);
			_databaseStub.ExecuteReader(commandStub, _transactionStub).Returns(readerStub);

		    var dbServiceManager = CreateDbServiceManager();
		    dbServiceManager.CreateAndOpenConnection();
		    dbServiceManager.BeginTransaction();
			var result = dbServiceManager.ExecuteReader(commandStub);

		    Assert.AreEqual(readerStub, result);
	    }

	    [Test]
	    public void ExecuteNonQuery_ExpectFakeResult()
	    {
		    var commandStub = Substitute.For<IDbCommand>();
		    var fakeResult = 1;

		    _databaseStub.CreateConnection().Returns(_connectionStub);
		    _connectionStub.BeginTransaction(_defaultLevel).Returns(_transactionStub);
			_databaseStub.ExecuteNonQuery(commandStub, _transactionStub).Returns(fakeResult);

			var dbServiceManager = CreateDbServiceManager();
			dbServiceManager.CreateAndOpenConnection();
			dbServiceManager.BeginTransaction();
			var result = dbServiceManager.ExecuteNonQuery(commandStub);

		    Assert.AreEqual(fakeResult, result);
	    }

	    [Test]
	    public void ExecuteScalar_ExpectFakeResult()
	    {
			var commandStub = Substitute.For<IDbCommand>();
		    var fakeResult = 1;

		    _databaseStub.CreateConnection().Returns(_connectionStub);
		    _connectionStub.BeginTransaction(_defaultLevel).Returns(_transactionStub);
		    _databaseStub.ExecuteScalar(commandStub, _transactionStub).Returns(fakeResult);

		    var dbServiceManager = CreateDbServiceManager();
		    dbServiceManager.CreateAndOpenConnection();
		    dbServiceManager.BeginTransaction();
		    var result = (int)dbServiceManager.ExecuteScalar(commandStub);

		    Assert.AreEqual(fakeResult, result);
	    }

		private IDbServiceManager CreateDbServiceManager() => new TransactionDbServiceManager(_databaseStub);
        private IDbServiceManager CreateDbServiceManager(IsolationLevel level) => new TransactionDbServiceManager(_databaseStub, level);
    }
}
