using System.Data;
using DbFramework.DbCommands;
using DbFramework.Interfaces;
using DbFramework.Invokers;
using NSubstitute;
using NUnit.Framework;

namespace DbFramework.Tests.UnitTests.Invokers
{
	[TestFixture]
	public class ScalarInvoker
	{
		[Test]
		public void InvokeCommand_ExpectTrueResult()
		{
			var serviceManager = Substitute.For<IDbManager>();
			var serviceCommand = Substitute.For<IScalarCommand<bool>>();
			serviceManager.ExecuteScalar<bool>(Arg.Any<IDbCommand>()).Returns(true);

			var sut = new ScalarCommandInvoker<bool>(serviceCommand);

			var result = sut.Invoke(serviceManager);

			Assert.IsTrue(result);
		}
	}
}
