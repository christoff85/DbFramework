using NUnit.Framework;
using System.Data;
using DbFramework.Extensions;
using DbFramework.Interfaces.DbCommands;
using DbFramework.Interfaces.ServiceManagers;
using NSubstitute;

namespace DbFramework.Tests.UnitTests.Invokers
{
	[TestFixture]
	public class ScalarInvokerTests
	{
		[Test]
		public void InvokeIScalarCommandThroughExtensionMethod_ExpectTrueResult()
		{
			var serviceManager = Substitute.For<IDbServiceManager>();
			var serviceCommand = Substitute.For<IScalarCommand<bool>>();
			serviceManager.ExecuteScalar(Arg.Any<IDbCommand>()).Returns(true);

			var result = serviceCommand.Invoke(serviceManager);

			Assert.IsTrue(result);
		}
	}
}
