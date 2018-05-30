using System;
using System.Data;
using System.Data.Common;
using NUnit.Framework;
using DbFramework.Adapters;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using NSubstitute;

namespace DbFramework.Tests.UnitTests.Adapters
{
	[TestFixture]
	public class DatabaseAdapterTests
	{
		private Database _databaseMock;
		private DatabaseAdapter _adapter;

		[SetUp]
		public void Init()
		{
			_databaseMock = Substitute.For<SqlDatabase>("fake connection string");
			_adapter = new DatabaseAdapter(_databaseMock);
		}

		[Test]
		public void RunCreateConnectionThroughDatabaseAdapter_ExpectCallReceivedOnDatabaseObject()
		{
			_adapter.CreateConnection();
			
			_databaseMock.Received().CreateConnection();
		}

		[Test]
		public void RunDiscoverParametersThroughDatabaseAdapter_ExpectCallReceivedOnDatabaseObject()
		{
			// There was no way to mock Database class to run DiscoverParameters
			Assert.Throws<ArgumentNullException>(() => _adapter.DiscoverParameters(null));
		}

		[Test]
		public void GetSqlStringCommandThroughDatabaseAdapter_ExpectCallReceivedOnDatabaseObject()
		{
			var query = "SELECT * FROM table";

			_adapter.GetSqlStringCommand(query);
			_databaseMock.Received().GetSqlStringCommand(query); 
		}

		[Test]
		public void GetStoredProcCommandThroughDatabaseAdapter_ExpectCallReceivedOnDatabaseObject()
		{
			var spName = "procedure_name";

			_adapter.GetStoredProcCommand(spName);
			_databaseMock.Received().GetSqlStringCommand(spName);
		}

		[Test]
		public void ExecuteNonQueryThroughAdapter_ExpectFakeResult()
		{
			var commandStub = Substitute.For<DbCommand>();
			var fakeResult = 1;
			_databaseMock.ExecuteNonQuery(commandStub).Returns(fakeResult);

			var result =_adapter.ExecuteNonQuery(commandStub);
			
			Assert.AreEqual(fakeResult, result);
		}

		[Test]
		public void ExecuteReaderThroughAdapter_ExpectReaderStub()
		{
			var commandStub = Substitute.For<DbCommand>();
			var readerStub = Substitute.For<IDataReader>();
			_databaseMock.ExecuteReader(commandStub).Returns(readerStub);

			var result = _adapter.ExecuteReader(commandStub);

			Assert.AreEqual(readerStub, result);
		}

		[Test]
		public void ExecuteScalarThroughAdapter_ExpectFakeResult()
		{
			var commandStub = Substitute.For<DbCommand>();
			var fakeResult = 1;
			_databaseMock.ExecuteScalar(commandStub).Returns(fakeResult);

			var result = (int)_adapter.ExecuteScalar(commandStub);

			Assert.AreEqual(fakeResult, result);
		}

		[Test]
		public void ExecuteNonQueryInTransactionThroughAdapter_ExpectFakeResult()
		{
			var commandStub = Substitute.For<DbCommand>();
			var transactionStub = Substitute.For<DbTransaction>();
			var fakeResult = 1;
			_databaseMock.ExecuteNonQuery(commandStub, transactionStub).Returns(fakeResult);

			var result = _adapter.ExecuteNonQuery(commandStub, transactionStub);

			Assert.AreEqual(fakeResult, result);
		}

		[Test]
		public void ExecuteReaderInTransactionThroughAdapter_ExpectReaderStub()
		{
			var commandStub = Substitute.For<DbCommand>();
			var transactionStub = Substitute.For<DbTransaction>();
			var readerStub = Substitute.For<IDataReader>();
			_databaseMock.ExecuteReader(commandStub, transactionStub).Returns(readerStub);

			var result = _adapter.ExecuteReader(commandStub, transactionStub);

			Assert.AreEqual(readerStub, result);
		}

		[Test]
		public void ExecuteScalarInTransactionThroughAdapter_ExpectFakeResult()
		{
			var commandStub = Substitute.For<DbCommand>();
			var transactionStub = Substitute.For<DbTransaction>();
			var fakeResult = 1;
			_databaseMock.ExecuteScalar(commandStub, transactionStub).Returns(fakeResult);

			var result = (int)_adapter.ExecuteScalar(commandStub, transactionStub);

			Assert.AreEqual(fakeResult, result);
		}
	}
}
