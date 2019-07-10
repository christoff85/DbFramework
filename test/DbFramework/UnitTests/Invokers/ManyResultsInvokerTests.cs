using System.Collections.Generic;
using System.Data;
using DbFramework.DbCommands;
using DbFramework.Interfaces;
using DbFramework.Invokers;
using NSubstitute;
using NUnit.Framework;

namespace DbFramework.Tests.UnitTests.Invokers
{
	[TestFixture]
	public class ManyResultsInvokerTests
	{
		private IDbReader _fakeReader;
		private IDbManager _serviceManager;
		private IManyResultsCommand<string> _serviceCommand;

		[SetUp]
		public void Init()
		{
			_fakeReader = Substitute.For<IDbReader>();
			_serviceManager = Substitute.For<IDbManager>();
			_serviceCommand = Substitute.For<IManyResultsCommand<string>>();

			_serviceManager.ExecuteReader(Arg.Any<IDbCommand>()).Returns(_fakeReader);
		}

		[Test]
		public void InvokeCommand_ResultAndExpectedAreEqual()
		{
			var expected = new List<string>() { "result1", "result2", "result3" };

			_fakeReader.Read().Returns(true, true, true, false);
		    _serviceCommand.MapResult(_fakeReader).Returns("result1", "result2", "result3");
			
			var sut = new ManyResultsCommandInvoker<string>(_serviceCommand);

			var result = sut.Invoke(_serviceManager);

			Assert.AreEqual(expected, result);
		}
	}
}
