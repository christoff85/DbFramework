using NUnit.Framework;
using System.Data;
using DbFramework.Enums;
using DbFramework.Extensions;
using DbFramework.Interfaces.DbCommands;
using DbFramework.Interfaces.ServiceManagers;
using NSubstitute;

namespace DbFramework.Tests.UnitTests.Invokers
{
	[TestFixture]
	public class SingleResultInvokerTests
	{
		[Test]
		public void InvokeISingleResultCommandThroughExtensionMethod_ExpectTrueResult()
		{
			var readerStub = Substitute.For<IDataReader>();
			readerStub.Read().Returns(true, false);
			var serviceManager = Substitute.For<IDbServiceManager>();
			serviceManager.ExecuteReader(Arg.Any<IDbCommand>()).Returns(readerStub);

			var serviceCommand = Substitute.For<ISingleResultCommand<bool>>();
			serviceCommand.MapReaderToResult(readerStub).Returns(true);
			serviceCommand.Options.Returns(SingleResultOptions.First);

			var result = serviceCommand.Invoke(serviceManager);

			Assert.IsTrue(result);
		}
	}
}
