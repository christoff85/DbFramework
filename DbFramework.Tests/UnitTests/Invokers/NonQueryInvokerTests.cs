using NUnit.Framework;
using System.Data;
using DbFramework.Extensions;
using DbFramework.Interfaces.DbCommands;
using DbFramework.Interfaces.ServiceManagers;
using NSubstitute;

namespace DbFramework.Tests.UnitTests.Invokers
{
	[TestFixture]
	public class NonQueryInvokerTests
	{
		[Test]
		public void InvokeINonQueryCommandThroughExtensionMethod_ExpectServiceManagerReceivedCallOnExecuteNonQuery()
		{
			var serviceManager = Substitute.For<IDbServiceManager>();
			var serviceCommand = Substitute.For<INonQueryCommand>();

			serviceCommand.Invoke(serviceManager);

			serviceManager.Received().ExecuteNonQuery(Arg.Any<IDbCommand>());
		}
	}
}
