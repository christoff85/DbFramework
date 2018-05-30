using NUnit.Framework;
using System.Data;
using DbFramework.Extensions;
using DbFramework.Interfaces.DbCommands;
using DbFramework.Interfaces.ServiceManagers;
using NSubstitute;

namespace DbFramework.Tests.UnitTests.Invokers
{
	[TestFixture]
	public class CustomHandlerInvokerTests
	{
		[Test]
		public void InvokeICustomHandlerCommandThroughExtensionMethod_ExpectTrueResult()
		{
			var serviceManager = Substitute.For<IDbServiceManager>();
			var serviceCommand = Substitute.For<ICustomHandlerCommand<bool>>();
			serviceCommand.CustomHandler(serviceManager, Arg.Any<IDbCommand>()).Returns(true);

			var result = serviceCommand.Invoke(serviceManager);

			Assert.IsTrue(result);
		}
	}
}
