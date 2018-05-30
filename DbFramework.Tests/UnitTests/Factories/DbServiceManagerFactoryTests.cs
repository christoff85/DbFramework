using NUnit.Framework;
using System.Data;
using DbFramework.Factories;
using DbFramework.Interfaces.Database;
using DbFramework.ServiceManagers;
using NSubstitute;

namespace DbFramework.Tests.UnitTests.Factories
{
	[TestFixture]
	public class DbServiceManagerFactoryTests
	{
		[Test]
		public void CreateNoTransactionManager_CheckIfIsInstanceOfNoTransactionDbServiceManager_ExpectTrue()
		{
			var databaseStub = Substitute.For<IDatabase>();
			var factory = new DbServiceManagerFactory();
			var manager = factory.CreateNoTransactionDbServiceManager(databaseStub);

			Assert.IsInstanceOf<NoTransactionDbServiceManager>(manager);
		}

		[Test]
		public void CreateDefaultTransactionManager_CheckIfIsInstanceOfNoTransactionDbServiceManager_ExpectTrue()
		{
			var databaseStub = Substitute.For<IDatabase>();
			var factory = new DbServiceManagerFactory();
			var manager = factory.CreateTransactionDbServiceManager(databaseStub);

			Assert.IsInstanceOf<TransactionDbServiceManager>(manager);
		}

		[Test]
		public void CreateCustomTransactionManager_CheckIfIsInstanceOfTransactionDbServiceManager_ExpectTrue()
		{
			var databaseStub = Substitute.For<IDatabase>();
			var factory = new DbServiceManagerFactory();
			var manager = factory.CreateTransactionDbServiceManager(databaseStub, IsolationLevel.Chaos);

			Assert.IsInstanceOf<TransactionDbServiceManager>(manager);
		}
	}
}
