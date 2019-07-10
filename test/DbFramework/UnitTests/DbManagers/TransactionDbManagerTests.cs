using System;
using System.Data;
using DbFramework.DbManagers;
using DbFramework.Interfaces;
using NSubstitute;
using NUnit.Framework;

namespace DbFramework.Tests.UnitTests.DbManagers
{
    [TestFixture]
    public class TransactionDbManagerTests
    {
        private string _connectionString = "connectionString";
        private readonly IsolationLevel _defaultLevel = IsolationLevel.ReadCommitted;
        private readonly IsolationLevel _customLevel = IsolationLevel.Chaos;

	    private IDbUtils _dbUtilsStub;
		private IDbConnection _connectionStub;
        private IDbTransaction _transactionStub;

        [SetUp]
        public void Init()
        {
			_dbUtilsStub = Substitute.For<IDbUtils>();
			_connectionStub = Substitute.For<IDbConnection>();
            _transactionStub = Substitute.For<IDbTransaction>();
		}

        [Test]
        public void CreateAndBeginTransactionWithDefaultIsolationLevel()
        {
	        _dbUtilsStub.CreateConnection(_connectionString).Returns(_connectionStub);
			_connectionStub.BeginTransaction(_defaultLevel).Returns(_transactionStub);

            using (var dbManager = CreateDbManager())
            {
                dbManager.StartConnection();
                Assert.AreEqual(_transactionStub, dbManager.DbTransaction);
            }
        }

        [Test]
        public void CreateManager_GetTextCommand_ExpectConnectionAndTransactionAreNotNull()
        {
            _dbUtilsStub.CreateConnection(_connectionString).Returns(_connectionStub);
            _connectionStub.BeginTransaction(_defaultLevel).Returns(_transactionStub);

            var commandText = "commandText";

            using (var dbManager = CreateDbManager())
            {
                dbManager.StartConnection();
                var result = dbManager.GetSqlStringCommand(commandText);

                Assert.AreEqual(_connectionStub, result.Connection);
                Assert.AreEqual(_transactionStub, result.Transaction);
            }
        }

        [Test]
        public void CreateManager_GetStoredProcedure_ExpectConnectionIsNotNullAndTransactionNull()
        {
            _dbUtilsStub.CreateConnection(_connectionString).Returns(_connectionStub);
            _connectionStub.BeginTransaction(_defaultLevel).Returns(_transactionStub);

            var spName = "spName";

            using (var dbManager = CreateDbManager())
            {
                dbManager.StartConnection();
                var result = dbManager.GetStoredProcCommand(spName);

                Assert.AreEqual(_connectionStub, result.Connection);
                Assert.AreEqual(_transactionStub, result.Transaction);
            }
        }

        [Test]
        public void CreateAndBeginTransaction_EvaluateIsInTransaction_ExpectTrue()
        {
            _dbUtilsStub.CreateConnection(_connectionString).Returns(_connectionStub);
            _connectionStub.BeginTransaction(_defaultLevel).Returns(_transactionStub);

            using (var dbManager = CreateDbManager())
            {
                dbManager.StartConnection();
                Assert.IsTrue(dbManager.IsInTransaction);
            }
        }

        [Test]
        public void CreateAndBeginTransaction_SaveChanges_EvaluateIsInTransaction_ExpectFalse()
        {
            _dbUtilsStub.CreateConnection(_connectionString).Returns(_connectionStub);
            _connectionStub.BeginTransaction(_defaultLevel).Returns(_transactionStub);

            using (var dbManager = CreateDbManager())
            {
                dbManager.StartConnection();
                dbManager.SaveChanges();
                Assert.IsFalse(dbManager.IsInTransaction);
            }
        }

        [Test]
        public void CreateAndBeginTransactionWithCustomIsolationLevel()
        {
	        _dbUtilsStub.CreateConnection(_connectionString).Returns(_connectionStub);
			_connectionStub.BeginTransaction(_customLevel).Returns(_transactionStub);

            using (var dbManager = CreateDbManager(_customLevel))
            {
                dbManager.StartConnection();
                Assert.AreEqual(_transactionStub, dbManager.DbTransaction);
            }   
        }

        [Test]
        public void CreateTransactionWithDefaultIsolationLevelAndCommit_CheckIfCommited_ExpectTrue()
        {
	        _dbUtilsStub.CreateConnection(_connectionString).Returns(_connectionStub);
			_connectionStub.BeginTransaction(_defaultLevel).Returns(_transactionStub);

            using (var dbManager = CreateDbManager())
            {
                dbManager.StartConnection();
                dbManager.SaveChanges();
            }
                
            _transactionStub.Received().Commit();
        }

        [Test]
        public void CreateTransactionWithDefaultIsolationLevelAndRollback_CheckIfRollbacked_ExpectTrue()
        {
	        _dbUtilsStub.CreateConnection(_connectionString).Returns(_connectionStub);
			_connectionStub.BeginTransaction(_defaultLevel).Returns(_transactionStub);

            using (var dbManager = CreateDbManager())
                dbManager.StartConnection();

            _transactionStub.Received().Rollback();
            _transactionStub.DidNotReceive().Commit();
        }

        [Test]
        public void CreateTransactionWithDefaultIsolationLevelAndCommitTwice_ExpectInvalidOperationExceptionThrown()
        {
            _dbUtilsStub.CreateConnection(_connectionString).Returns(_connectionStub);
            _connectionStub.BeginTransaction(_defaultLevel).Returns(_transactionStub);

            Assert.Throws<InvalidOperationException>(() =>
            {
                using (var dbManager = CreateDbManager())
                {
                    dbManager.StartConnection();
                    dbManager.SaveChanges();
                    dbManager.SaveChanges();
                }
            });
        }

        //TODO: test do poprawy, nie sprawdza czyszczenia transakcji
        [Test]
	    public void CreateTransactionWithCustomIsolationLevelAndCommit_CheckIfTransactionStateWasCleared_ExpectTrue()
	    {
		    _dbUtilsStub.CreateConnection(_connectionString).Returns(_connectionStub);
			_connectionStub.BeginTransaction().Returns(_transactionStub); // Cleaning state transaction

	        using (var dbManager = CreateDbManager(_customLevel))
	        {
	            dbManager.StartConnection();
            }

            _transactionStub.Received().Commit();
	    }

		[Test]
		public void ExecuteReader_ExpectReaderStubReturned()
		{
			var commandMock = Substitute.For<IDbCommand>();
			var readerStub = Substitute.For<IDataReader>();
		    readerStub.Read().Returns(true);

		    commandMock.ExecuteReader().Returns(readerStub);

		    using (var dbManager = CreateDbManager())
		    {
		        dbManager.StartConnection();

		        using (var dbReader = dbManager.ExecuteReader(commandMock))
		        {
		            var result = dbReader.Read();
                    Assert.AreEqual(true, result);
                } 
            }
		}

		[Test]
	    public void ExecuteNonQuery_ExpectFakeResult()
	    {
		    var commandMock = Substitute.For<IDbCommand>();
		    var fakeResult = 1;

	        commandMock.ExecuteNonQuery().Returns(fakeResult);

	        using (var dbManager = CreateDbManager())
	        {
	            dbManager.StartConnection();
	            var result = dbManager.ExecuteNonQuery(commandMock);

                Assert.AreEqual(fakeResult, result);
            }
                
	    }

	    [Test]
	    public void ExecuteScalar_ExpectFakeResult()
	    {
			var commandMock = Substitute.For<IDbCommand>();
		    var fakeResult = 1;

	        commandMock.ExecuteScalar().Returns(fakeResult);

	        using (var dbManager = CreateDbManager())
	        {
	            dbManager.StartConnection();
	            var result = dbManager.ExecuteScalar<int>(commandMock);

                Assert.AreEqual(fakeResult, result);
            }
	    }

		private TransactionDbManager CreateDbManager() => new TransactionDbManager(_dbUtilsStub, _connectionString);
        private TransactionDbManager CreateDbManager(IsolationLevel level) => new TransactionDbManager(_dbUtilsStub, _connectionString, level);
    }
}
