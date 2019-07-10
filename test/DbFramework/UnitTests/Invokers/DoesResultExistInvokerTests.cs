using System.Data;
using DbFramework.DbCommands;
using DbFramework.Interfaces;
using DbFramework.Invokers;
using NSubstitute;
using NUnit.Framework;

namespace DbFramework.Tests.UnitTests.Invokers
{
	[TestFixture]
	public class DoesResultExistInvokerTests
	{
		private IDbReader _readerStub;
		private IDoesResultExistCommand _serviceCommand = Substitute.For<IDoesResultExistCommand>();
		private IDbManager _serviceManager = Substitute.For<IDbManager>();

		[SetUp]
		public void Init()
		{
			_readerStub = Substitute.For<IDbReader>();
			_serviceCommand = Substitute.For<IDoesResultExistCommand>();
			_serviceManager = Substitute.For<IDbManager>();

			_serviceManager.ExecuteReader(Arg.Any<IDbCommand>()).Returns(_readerStub);
		}

		[Test]
		public void WhenReaderWithContentAndContentCheckerReturnsTrue_ExpectTrue()
		{
			_readerStub.Read().Returns(true);
			_serviceCommand.ResultContentChecker(_readerStub).Returns(true);
			var sut = new DoesResultExistCommandInvoker(_serviceCommand);

			var result = sut.Invoke(_serviceManager);

			Assert.IsTrue(result);
		}

		[Test]
		public void WhenReaderWithContentAndContentCheckerReturnsFalse_ExpectFalse()
		{
			_readerStub.Read().Returns(true);
			_serviceCommand.ResultContentChecker(_readerStub).Returns(false);
			var sut = new DoesResultExistCommandInvoker(_serviceCommand);

			var result = sut.Invoke(_serviceManager);

			Assert.IsFalse(result);
		}

		[Test]
		public void WhenEmptyReader_ExpectFalse()
		{
			_readerStub.Read().Returns(false);

			var sut = new DoesResultExistCommandInvoker(_serviceCommand);

			var result = sut.Invoke(_serviceManager);

			Assert.IsFalse(result);
		}
	}
}
