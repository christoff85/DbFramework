using System.Data;
using DbFramework.DbCommands;
using DbFramework.Interfaces;
using DbFramework.Invokers;
using NSubstitute;
using NUnit.Framework;

namespace DbFramework.Tests.UnitTests.Invokers
{
	[TestFixture]
	public class NonQueryInvokerTests
	{
		[Test]
		public void InvokeCommand_ExpectServiceManagerReceivedCallOnExecuteNonQuery()
		{
			var serviceManager = Substitute.For<IDbManager>();
			var serviceCommand = Substitute.For<INonQueryCommand>();

			var sut = new NonQueryCommandInvoker(serviceCommand);

			sut.Invoke(serviceManager);

			serviceManager.Received().ExecuteNonQuery(Arg.Any<IDbCommand>());
		}
	}
}