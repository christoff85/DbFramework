using System;
using System.Data;
using DbFramework.DbCommands;
using DbFramework.Interfaces;
using DbFramework.Invokers;
using NSubstitute;
using NUnit.Framework;

namespace DbFramework.Tests.UnitTests.Invokers
{
	[TestFixture]
	public class SingleResultInvokerTests
	{
		private IDbReader _readerStub;
		private IDbManager _serviceManager;
		private ISingleResultCommand<string> _serviceCommand;

		private readonly string _expected = "expectedValue";

		[SetUp]
		public void Init()
		{
			_readerStub = Substitute.For<IDbReader>();
			_serviceManager = Substitute.For<IDbManager>();
			_serviceCommand = Substitute.For<ISingleResultCommand<string>>();

			_serviceManager.ExecuteReader(Arg.Any<IDbCommand>()).Returns(_readerStub);
		    _serviceCommand.MapResult(_readerStub).Returns(_expected);
		}

		[Test]
		public void FromDbReaderWithOneRecord_CompareResult_ExpectSame()
		{
			_readerStub.Read().Returns(true, false);

			var sut = new SingleResultCommandInvoker<string>(_serviceCommand);
			var result = sut.Invoke(_serviceManager);

			Assert.AreEqual(_expected, result);
		}

		[Test]
		public void FromDbReaderWithTwoRecords_ExpectException()
		{
			_readerStub.Read().Returns(true, true, false);

			var sut = new SingleResultCommandInvoker<string>(_serviceCommand);

			Assert.Throws<InvalidOperationException>(() =>
			{
				sut.Invoke(_serviceManager);
			});
		}

		[Test]
		public void FromEmptyDbReader_ExpectException()
		{
			_readerStub.Read().Returns(false);

			var sut = new SingleResultCommandInvoker<string>(_serviceCommand);

			Assert.Throws<InvalidOperationException>(() =>
			{
				sut.Invoke(_serviceManager);
			});
		}
	}
}
