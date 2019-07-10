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
	public class SingleResultOrDefaultInvokerTests
	{
		private IDbReader _readerStub;
		private IDbManager _serviceManager;
		private ISingleResultOrDefaultCommand<string> _serviceCommand;

		private readonly string _returnedResult = "expectedValue";

		[SetUp]
		public void Init()
		{
			_readerStub = Substitute.For<IDbReader>();
			_serviceManager = Substitute.For<IDbManager>();
			_serviceCommand = Substitute.For<ISingleResultOrDefaultCommand<string>>();

			_serviceManager.ExecuteReader(Arg.Any<IDbCommand>()).Returns(_readerStub);
		}

		[Test]
		public void FromDbReaderWithOneRecord_CompareResult_ExpectSame()
		{
			_readerStub.Read().Returns(true, false);
			_serviceCommand.MapResult(_readerStub).Returns(_returnedResult);

			var sut = new SingleResultOrDefaultCommandInvoker<string>(_serviceCommand);
			var result = sut.Invoke(_serviceManager);

			Assert.AreEqual(_returnedResult, result);
		}

		[Test]
		public void FromDbReaderWithTwoRecords_ExpectException()
		{
			_readerStub.Read().Returns(true, true, false);
			_serviceCommand.MapResult(_readerStub).Returns(_returnedResult);

			var sut = new SingleResultOrDefaultCommandInvoker<string>(_serviceCommand);

			Assert.Throws<InvalidOperationException>(() =>
			{
				sut.Invoke(_serviceManager);
			});
		}

		[Test]
		public void FromEmptyDbReader_ExpectDefaultOfString()
		{
			_readerStub.Read().Returns(false);

			var sut = new SingleResultOrDefaultCommandInvoker<string>(_serviceCommand);
			var result = sut.Invoke(_serviceManager);

			Assert.AreEqual(default(string), result);
		}
	}
}
