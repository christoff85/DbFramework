using NUnit.Framework;
using DbFramework.Adapters;
using DbFramework.Factories;

namespace DbFramework.Tests.UnitTests.Factories
{
	[TestFixture]
	public class DbFactoryTests
	{
		[Test]
		public void CreateDatabaseThroughDbFactory_ExpectInstanceOfDatabaseAdapter()
		{
			var database = DbFactory.GetSqlDatabase("connectionString");
			Assert.IsInstanceOf<DatabaseAdapter>(database);
		}
	}
}
