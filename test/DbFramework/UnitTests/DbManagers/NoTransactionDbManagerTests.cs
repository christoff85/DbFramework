using System;
using System.Data;
using DbFramework.DbManagers;
using DbFramework.Interfaces;
using NSubstitute;
using NUnit.Framework;

namespace DbFramework.Tests.UnitTests.DbManagers
{
    [TestFixture]
    public class NoTransactionDbManagerTests
    {
        private string _connectionString = "connectionString";
		private IDbUtils _dbUtilsStub;
        private IDbConnection _connectionStub;
        private IDbTransaction _transactionStub;

        [SetUp]
		public void Init()
		{
			_dbUtilsStub = Substitute.For<IDbUtils>();
		    _connectionStub = Substitute.For<IDbConnection>();
		    _transactionStub = Substitute.For<IDbTransaction>();

		    _dbUtilsStub.CreateConnection(_connectionString).Returns(_connectionStub);
		    _connectionStub.BeginTransaction().Returns(_transactionStub);
        }

        [Test]
        public void CreateManager_GetTextCommand_ExpectConnectionIsNotNullAndTransactionNull()
        {
            var commandText = "commandText";

            using (var dbManager = CreateDbManager(_connectionString))
            {
                dbManager.StartConnection();
                var result = dbManager.GetSqlStringCommand(commandText);

                Assert.AreEqual(_connectionStub, result.Connection);
                Assert.AreNotEqual(_transactionStub, result.Transaction);
            }
        }

        [Test]
        public void CreateManager_GetStoredProcedure_ExpectConnectionIsNotNullAndTransactionNull()
        {
            var spName = "spName";

            using (var dbManager = CreateDbManager(_connectionString))
            {
                dbManager.StartConnection();
                var result = dbManager.GetStoredProcCommand(spName);

                Assert.AreEqual(_connectionStub, result.Connection);
                Assert.AreNotEqual(_transactionStub, result.Transaction);
            }
        }

        [Test]
        public void CreateManager_EvaluateIsInTransaction_ExpectFalse()
        {
            using (var dbManager = CreateDbManager(_connectionString))
            {
                dbManager.StartConnection();
                Assert.IsFalse(dbManager.IsInTransaction);
            }

        }

        [Test]
		public void ExecuteReader_ExpectDbReaderReturnsSameValueAsDataReader()
		{
			var commandMock = Substitute.For<IDbCommand>();
			var readerStub = Substitute.For<IDataReader>();
		    readerStub.Read().Returns(true);

		    commandMock.ExecuteReader().Returns(readerStub);
		    using (var dbManager = CreateDbManager(_connectionString))
		    {
		        dbManager.StartConnection();
                var dbReader = dbManager.ExecuteReader(commandMock);
		        var result = dbReader.Read();

                Assert.AreEqual(true, result);
            }
                
		}

		[Test]
	    public void ExecuteNonQuery_ExpectFakeResult()
	    {
		    var commandMock = Substitute.For<IDbCommand>();
		    var fakeResult = 1;
	        commandMock.ExecuteNonQuery().Returns(fakeResult);

	        using (var dbManager = CreateDbManager(_connectionString))
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


            using (var dbManager = CreateDbManager(_connectionString))
            {
                dbManager.StartConnection();
                var result = dbManager.ExecuteScalar<int>(commandMock);

                Assert.AreEqual(fakeResult, result);
            }
	    }

        [Test]
        public void CommitTransaction_ExpectInvalidOperationExceptionThrown()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                var dbManager = CreateDbManager(_connectionString);
                dbManager.SaveChanges();
            });
        }

        private DbManager CreateDbManager(string connectionString) => new NoTransactionDbManager(_dbUtilsStub, connectionString);
	}
}
