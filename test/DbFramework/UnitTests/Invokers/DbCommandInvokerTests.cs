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
	public class DbCommandInvokerTests
	{
		[Test]
		public void InitializeInvokerWithNullCommand_ExpectArgumentNullExceptionThrown()
		{
			Assert.Throws<ArgumentNullException>(() => new TestDbCommandInvoker(null));
		}

		[Test]
		public void InvokeCommandWithNullManager_ExpectArgumentNullExceptionThrown()
		{
			var commandStub = Substitute.For<INonQueryCommand>();
			var invoker = new TestDbCommandInvoker(commandStub);

			Assert.Throws<ArgumentNullException>(() => invoker.Invoke(null));
		}

		[Test]
		public void InvokeCommand_ExpectCallReceivedOnGetDbCommand()
		{
			var commandStub = Substitute.For<INonQueryCommand>();
			var managerStub = Substitute.For<IDbManager>();
			var invoker = new TestDbCommandInvoker(commandStub);

			invoker.Invoke(managerStub);

			commandStub.Received().GetDbCommandWithAssignedParameters(Arg.Any<IDbManager>());
		}

		[Test]
		public void InvokeCommandAndThrowException_ExpectExceptionThrow()
		{
			var commandStub = Substitute.For<INonQueryCommand>();
			var managerStub = Substitute.For<IDbManager>();
			var invoker = new TestDbCommandInvoker(commandStub, true);

			Assert.Throws<Exception>(() => invoker.Invoke(managerStub));
		}

		[Test]
		public void InvokeCommandWithParamater_ExpectCallOnAddDbParamater()
		{
			var commandStub = Substitute.For<INonQueryCommand>();
			var managerStub = Substitute.For<IDbManager>();
			var invoker = new TestDbCommandInvoker(commandStub);

			invoker.Invoke(managerStub);

			commandStub.Received().GetDbCommandWithAssignedParameters(Arg.Any<IDbManager>());
		}

		private class TestDbCommandInvoker : DbCommandInvoker<INonQueryCommand, IDbCommand>
		{
			private readonly bool _throwExpection;
			public TestDbCommandInvoker(INonQueryCommand command, bool throwException = false) : base(command)
			{
				_throwExpection = throwException;
			}

			protected override IDbCommand Execute(IDbManager dbManager, IDbCommand command)
			{
				if(_throwExpection) throw new Exception();
				return command;
			}

		    //protected override Task<IDbCommand> ExecuteAsync(IDbManager dbManager, IDbCommand command, CancellationToken cancellationToken)
		    //{
		    //    throw new NotImplementedException();
		    //}
		}
	}
}
