using NUnit.Framework;
using System.Data;
using System.Linq;
using DbFramework.Extensions;
using DbFramework.Interfaces.DbCommands;
using DbFramework.Interfaces.ServiceManagers;
using NSubstitute;

namespace DbFramework.Tests.UnitTests.Invokers
{
	[TestFixture]
	public class ManyResultInvokerTests
	{
		[Test]
		public void InvokeIManyResultCommandThroughExtensionMethod_ExpectTrueResult()
		{
			var readerStub = Substitute.For<IDataReader>();
			readerStub.Read().Returns(true, false);
			var serviceManager = Substitute.For<IDbServiceManager>();
			serviceManager.ExecuteReader(Arg.Any<IDbCommand>()).Returns(readerStub);

			var serviceCommand = Substitute.For<IManyResultCommand<bool>>();
			serviceCommand.MapReaderToResult(readerStub).Returns(true);

			var result = serviceCommand.Invoke(serviceManager);

			Assert.IsTrue(result.FirstOrDefault());
		}
	}
}
