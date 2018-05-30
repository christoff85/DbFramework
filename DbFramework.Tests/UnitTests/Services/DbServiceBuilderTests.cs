using System;
using System.Data;
using DbFramework.Interfaces.Database;
using DbFramework.Interfaces.DbOperations;
using DbFramework.Interfaces.Factories;
using DbFramework.Interfaces.ServiceManagers;
using DbFramework.Services;
using NSubstitute;
using NUnit.Framework;

namespace DbFramework.Tests.UnitTests.Services
{
    [TestFixture]
    public class DbServiceBuilderTests
    {
        private IDatabase _databaseStub;
        private IDbConnection _connectionStub;
        private IDbTransaction _transactionStub;
        private IDbServiceLogic<bool> _serviceLogicStub;
	    private IDbServiceManager _dbServiceConnectionStub;

		[SetUp]
        public void Init()
        {
            _databaseStub = Substitute.For<IDatabase>();
            _connectionStub = Substitute.For<IDbConnection>();
            _transactionStub = Substitute.For<IDbTransaction>();
            _serviceLogicStub = Substitute.For<IDbServiceLogic<bool>>();

	        _dbServiceConnectionStub = Substitute.For<IDbServiceManager>();

            _databaseStub.CreateConnection().Returns(_connectionStub);
        }

		[Test]
		public void BuildDbServiceWithoutTransaction_CheckIfTransactionStubWasProvidedToLogicExecuteMethod_ExpectTrue()
		{
			var noTransactionServiceStub = Substitute.For<IDbServiceManager>();
			var managerFactoryStub = Substitute.For<IDbServiceManagerFactory>();
			managerFactoryStub.CreateNoTransactionDbServiceManager(Arg.Any<IDatabase>()).Returns(noTransactionServiceStub);
			
			var builder = new DbServiceBuilder<bool>(_databaseStub, _serviceLogicStub);
			builder.DbServiceManagerFactory = managerFactoryStub;
			var service = builder.Build();

			service.Execute();

			_serviceLogicStub.Received().Execute(noTransactionServiceStub);
		}


	    [Test]
	    public void BuildDbServiceWithDefaultTransaction_CheckIfTransactionStubWasProvidedToLogicExecuteMethod_ExpectTrue()
	    {
		    var defaultTransactionServiceStub = Substitute.For<IDbServiceManager>();
		    var managerFactoryStub = Substitute.For<IDbServiceManagerFactory>();
		    managerFactoryStub.CreateTransactionDbServiceManager(Arg.Any<IDatabase>()).Returns(defaultTransactionServiceStub);

		    var builder = new DbServiceBuilder<bool>(_databaseStub, _serviceLogicStub);
		    builder.DbServiceManagerFactory = managerFactoryStub;
		    var service = builder.WithTransaction().Build();

		    service.Execute();

		    _serviceLogicStub.Received().Execute(defaultTransactionServiceStub);
	    }

	    [Test]
	    public void BuildDbServiceWithCustomTransaction_CheckIfTransactionStubWasProvidedToLogicExecuteMethod_ExpectTrue()
	    {
		    var customTransactionServiceStub = Substitute.For<IDbServiceManager>();
		    var managerFactoryStub = Substitute.For<IDbServiceManagerFactory>();
		    managerFactoryStub.CreateTransactionDbServiceManager(Arg.Any<IDatabase>(), IsolationLevel.Chaos).Returns(customTransactionServiceStub);

		    var builder = new DbServiceBuilder<bool>(_databaseStub, _serviceLogicStub);
		    builder.DbServiceManagerFactory = managerFactoryStub;
		    var service = builder.WithTransaction(IsolationLevel.Chaos).Build();

		    service.Execute();

		    _serviceLogicStub.Received().Execute(customTransactionServiceStub);
	    }

		// Null parameters in constructor
		[Test]
	    public void InstatiateDbServiceBuilderWithNullDatabase_ExpectException()
	    {
		    Assert.Throws<ArgumentNullException>(() => new DbServiceBuilder<bool>(null, _serviceLogicStub));
	    }

	    [Test]
	    public void InstatiateDbServiceBuilderWithNullLogic_ExpectException()
	    {
		    Assert.Throws<ArgumentNullException>(() => new DbServiceBuilder<bool>(_databaseStub, null));
	    }
	}
}
