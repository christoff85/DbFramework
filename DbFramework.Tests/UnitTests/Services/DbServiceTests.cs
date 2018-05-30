using System;
using DbFramework.Exceptions;
using DbFramework.Interfaces.Database;
using DbFramework.Interfaces.DbOperations;
using DbFramework.Interfaces.ServiceManagers;
using DbFramework.Services;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NUnit.Framework;

namespace DbFramework.Tests.UnitTests.Services
{
    [TestFixture]
    public class DbServiceTests
    {
        private IDatabase _database;
        private IDbServiceLogic<bool> _logic;
        private IDbServiceManager _dbServiceManager;

        [SetUp]
        public void Init()
        {
            _database = Substitute.For<IDatabase>();
            _logic = Substitute.For<IDbServiceLogic<bool>>();
            _dbServiceManager = Substitute.For<IDbServiceManager>();
        }

        [Test]
        public void RunDbService_CheckResult_ExpectTrue()
        {
           _logic.Execute(Arg.Any<IDbServiceManager>()).ReturnsForAnyArgs(true);
            var service = BuildDbService();

            var result = service.Execute();

            Assert.IsTrue(result);
        }

        [Test]
        public void RunDbService_CheckConnectionStates_ExpectOpenAndDisposed()
        {
            var service = BuildDbService();

            service.Execute();

            _dbServiceManager.Received().CreateAndOpenConnection();
	        _dbServiceManager.Received().Dispose();
        }

        [Test]
        public void RunDbService_CheckIfTransactionWasCommited_ExpectTrue()
        {
            var service = BuildDbService();

            service.Execute();

            _dbServiceManager.Received().CommitTransaction();
        }

        [Test]
        public void RunDbServiceWithException_CheckIfThrows_ExpectTrue()
        {
            SetLogicToThrowException();
            var service = BuildDbService();

            Assert.Throws<DbServiceException>(() => service.Execute());
        }

        [Test]
        public void RunDbServiceWithException_CheckConnectionStates_ExpectOpenAndClosed()
        {
            SetLogicToThrowException();
            var service = BuildDbService();

            try { service.Execute(); }
            catch { }

			_dbServiceManager.Received().CreateAndOpenConnection();
	        _dbServiceManager.Received().Dispose();
		}

        [Test]
        public void RunDbServiceWithException_CheckIfTransactionWasRollbacked_ExpectTrue()
        {
            SetLogicToThrowException();
            var service = BuildDbService();

            try { service.Execute(); }
            catch { }

            _dbServiceManager.Received().RollbackTransaction();
        }

	    // Null parameters in constructor
	    [Test]
	    public void InstatiateDbServiceWithNullLogic_ExpectException()
	    {
		    Assert.Throws<ArgumentNullException>(() => new DbService<bool>(null, _dbServiceManager));
	    }

	    [Test]
	    public void InstatiateDbServiceWithNullTransaction_ExpectException()
	    {
		    Assert.Throws<ArgumentNullException>(() => new DbService<bool>(_logic, null));
	    }

		private void SetLogicToThrowException() 
            => _logic.Execute(Arg.Any<IDbServiceManager>()).Throws(new NotImplementedException());

        private DbService<bool> BuildDbService() 
            => new DbService<bool>(_logic, _dbServiceManager);
    }
}
