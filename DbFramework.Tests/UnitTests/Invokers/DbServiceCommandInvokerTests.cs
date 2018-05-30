using NUnit.Framework;
using System;
using System.Data;
using DbFramework.Interfaces.Database;
using DbFramework.Interfaces.DbCommands;
using DbFramework.Interfaces.Parameters;
using DbFramework.Interfaces.ServiceManagers;
using DbFramework.Invokers;
using DbFramework.Parameters;
using NSubstitute;

namespace DbFramework.Tests.UnitTests.Invokers
{
	[TestFixture]
	public class DbServiceCommandInvokerTests
	{
		[Test]
		public void InitializeInvokerWithNullCommand_ExpectArgumentNullExceptionThrown()
		{
			Assert.Throws<ArgumentNullException>(() => new TestDbServiceCommandInvoker(null));
		}

		[Test]
		public void InvokeCommandWithNullManager_ExpectArgumentNullExceptionThrown()
		{
			var commandStub = Substitute.For<INonQueryCommand>();
			var invoker = new TestDbServiceCommandInvoker(commandStub);

			Assert.Throws<ArgumentNullException>(() => invoker.Invoke(null));
		}

		[Test]
		public void InvokeCommand_ExpectCallReceivedOnGetDbCommand()
		{
			var commandStub = Substitute.For<INonQueryCommand>();
			var managerStub = Substitute.For<IDbServiceManager>();
			var invoker = new TestDbServiceCommandInvoker(commandStub);

			invoker.Invoke(managerStub);

			commandStub.Received().GetDbCommand(Arg.Any<IDatabase>());
		}

		[Test]
		public void InvokeCommandAndThrowException_ExpectExceptionThrow()
		{
			var commandStub = Substitute.For<INonQueryCommand>();
			var managerStub = Substitute.For<IDbServiceManager>();
			var invoker = new TestDbServiceCommandInvoker(commandStub, true);

			Assert.Throws<Exception>(() => invoker.Invoke(managerStub));
		}

		[Test]
		public void InvokeCommandWithParamater_ExpectCallOnAddDbParamater()
		{
			var parameterStub = Substitute.For<IDbParameter>();
			var parameters = new DbParameters() { parameterStub };
			var commandStub = Substitute.For<INonQueryCommand>();
			commandStub.Parameters.Returns(parameters);
			var managerStub = Substitute.For<IDbServiceManager>();
			var invoker = new TestDbServiceCommandInvoker(commandStub);

			invoker.Invoke(managerStub);

			commandStub.Received().AddDbParameter(Arg.Any<IDbCommand>(), parameterStub);
		}

		private class TestDbServiceCommandInvoker : DbServiceCommandInvoker<INonQueryCommand, IDbCommand>
		{
			private readonly bool _throwExpection;
			public TestDbServiceCommandInvoker(INonQueryCommand command, bool throwException = false) : base(command)
			{
				_throwExpection = throwException;
			}

			protected override IDbCommand Execute(IDbServiceManager dbServiceManager, IDbCommand command)
			{
				if(_throwExpection) throw new Exception();
				return command;
			}
		}
	}
}
