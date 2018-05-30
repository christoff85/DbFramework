using NUnit.Framework;
using System.Data;
using DbFramework.Extensions;
using DbFramework.Interfaces.DbCommands;
using DbFramework.Interfaces.ServiceManagers;
using NSubstitute;

namespace DbFramework.Tests.UnitTests.Invokers
{
	[TestFixture]
	public class ResultExistsCheckInvokerTests
	{
		[Test]
		public void InvokeIResultExistsCheckCommandThroughExtensionMethod_ExpectTrueResult()
		{
			var readerStub = Substitute.For<IDataReader>();
			readerStub.Read().Returns(true);
			var serviceManager = Substitute.For<IDbServiceManager>();
			serviceManager.ExecuteReader(Arg.Any<IDbCommand>()).Returns(readerStub);
			var serviceCommand = Substitute.For<IResultExistsCheckCommand>();
			serviceCommand.ResultContentCheck(readerStub).Returns(true);

			var result = serviceCommand.Invoke(serviceManager);

			Assert.IsTrue(result);
		}
	}
}
