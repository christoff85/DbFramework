using System;
using System.Data;
using DbFramework.DbManagers;
using DbFramework.Factories;
using DbFramework.Interfaces;
using DbFramework.Interfaces.Providers;
using NSubstitute;
using NUnit.Framework;

namespace DbFramework.Tests.UnitTests.Factories
{
	[TestFixture]
	public class DbManagerFactoryTests
	{
		[Test]
		public void CreateNoTransactionManager_CheckIfIsInstanceOfNoTransactionDbServiceManager_ExpectTrue()
		{
			var sut = CreateServiceManagerFactory();
			var expectedManager = sut.CreateNoTransactionDbManager();
			Assert.IsInstanceOf<NoTransactionDbManager>(expectedManager);
		}

		[Test]
		public void CreateDefaultTransactionManager_CheckIfIsInstanceOfNoTransactionDbServiceManager_ExpectTrue()
		{
			var sut = CreateServiceManagerFactory();
			var expectedManager = sut.CreateTransactionDbManager();
			Assert.IsInstanceOf<TransactionDbManager>(expectedManager);
		}

		[Test]
		public void CreateCustomTransactionManager_CheckIfIsInstanceOfTransactionDbServiceManager_ExpectTrue()
		{
			var sut = CreateServiceManagerFactory();
			var expectedManager = sut.CreateTransactionDbManager(IsolationLevel.Chaos);
			Assert.IsInstanceOf<TransactionDbManager>(expectedManager);
		}

		private DbManagerFactory CreateServiceManagerFactory()
		{
			var dbUtilsStub = Substitute.For<IDbUtils>();
		    var connectionStringProviderStub = Substitute.For<IDbConnectionStringProvider>();

            return new DbManagerFactory(dbUtilsStub, connectionStringProviderStub);
		}

		// Null parameters in constructor
		[Test]
		public void InstatiateDbServiceManagerFactoryWithNullDbProvider_ExpectException()
		{
			Assert.Throws<ArgumentNullException>(() =>
			{
			    var connectionStringProviderStub = Substitute.For<IDbConnectionStringProvider>();
			    new DbManagerFactory(null, connectionStringProviderStub);
			});
		}

	    [Test]
	    public void InstatiateDbServiceManagerFactoryWithNullConnectionStringProvider_ExpectException()
	    {
	        Assert.Throws<ArgumentNullException>(() =>
	        {
	            var dbUtilsStub = Substitute.For<IDbUtils>();
	            new DbManagerFactory(dbUtilsStub, null);
	        });
	    }
    }
}
