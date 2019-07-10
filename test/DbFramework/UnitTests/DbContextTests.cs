using System;
using DbFramework.DbCommands;
using DbFramework.DbContexts;
using DbFramework.Interfaces;
using DbFramework.Interfaces.Factories;
using DbFramework.Interfaces.Invokers;
using NSubstitute;
using NUnit.Framework;

namespace DbFramework.Tests.UnitTests
{
	[TestFixture]
	public class DbContextTests
	{
		private IDbInvokerFactory _dbInvokerFactoryStub;
		private IDbManager _dbServiceManagerStub;

		[SetUp]
		public void Init()
		{
			_dbInvokerFactoryStub = Substitute.For<IDbInvokerFactory>();
			_dbServiceManagerStub = Substitute.For<IDbManager>();
		}

		[Test]
		public void InitializeWithNullDbInvokerFactory_ExpectArgumentNullExceptionThrown()
		{
			Assert.Throws<ArgumentNullException>(() => new DbContext(null, _dbServiceManagerStub));
		}

		[Test]
		public void InitializeWithNullDbServiceManager_ExpectArgumentNullExceptionThrown()
		{
			Assert.Throws<ArgumentNullException>(() => new DbContext(_dbInvokerFactoryStub, null));
		}

		[Test]
		public void InvokeManyResultsCommand_ExpectCallReceivedOnManyResultsCommandInvoker()
		{
			var commandStub = Substitute.For<IManyResultsCommand<bool>>();
			var commandInvokerMock = Substitute.For<IManyResultCommandInvoker<bool>>();

			_dbInvokerFactoryStub.Create(commandStub).Returns(commandInvokerMock);

			var sut = CreateDbInvoker();
			sut.ExecuteCommand(commandStub);

			commandInvokerMock.Received().Invoke(_dbServiceManagerStub);
		}

		[Test]
		public void InvokeSingleResultCommand_ExpectCallReceivedOnSingleResultCommandInvoker()
		{
			var commandStub = Substitute.For<ISingleResultCommand<bool>>();
			var commandInvokerMock = Substitute.For<ISingleResultCommandInvoker<bool>>();

			_dbInvokerFactoryStub.Create(commandStub).Returns(commandInvokerMock);

			var sut = CreateDbInvoker();
			sut.ExecuteCommand(commandStub);

			commandInvokerMock.Received().Invoke(_dbServiceManagerStub);
		}

		[Test]
		public void InvokeSingleResultOrDefaultCommand_ExpectCallReceivedOnSingleResultOrDefaultCommandInvoker()
		{
			var commandStub = Substitute.For<ISingleResultOrDefaultCommand<bool>>();
			var commandInvokerMock = Substitute.For<ISingleResultOrDefaultCommandInvoker<bool>>();

			_dbInvokerFactoryStub.Create(commandStub).Returns(commandInvokerMock);

			var sut = CreateDbInvoker();
			sut.ExecuteCommand(commandStub);

			commandInvokerMock.Received().Invoke(_dbServiceManagerStub);
		}

		[Test]
		public void InvokeFirstResultCommand_ExpectCallReceivedOnFirstResultCommandInvoker()
		{
			var commandStub = Substitute.For<IFirstResultCommand<bool>>();
			var commandInvokerMock = Substitute.For<IFirstResultCommandInvoker<bool>>();

			_dbInvokerFactoryStub.Create(commandStub).Returns(commandInvokerMock);

			var sut = CreateDbInvoker();
			sut.ExecuteCommand(commandStub);

			commandInvokerMock.Received().Invoke(_dbServiceManagerStub);
		}

		[Test]
		public void InvokeFirstResultOrDefaultCommand_ExpectCallReceivedOnFirstResultOrDefaultCommandInvoker()
		{
			var commandStub = Substitute.For<IFirstResultOrDefaultCommand<bool>>();
			var commandInvokerMock = Substitute.For<IFirstResultOrDefaultCommandInvoker<bool>>();

			_dbInvokerFactoryStub.Create(commandStub).Returns(commandInvokerMock);

			var sut = CreateDbInvoker();
			sut.ExecuteCommand(commandStub);

			commandInvokerMock.Received().Invoke(_dbServiceManagerStub);
		}

		[Test]
		public void InvokeScalarCommand_ExpectCallReceivedOnScalarCommandInvoker()
		{
			var commandStub = Substitute.For<IScalarCommand<bool>>();
			var commandInvokerMock = Substitute.For<IScalarCommandInvoker<bool>>();

			_dbInvokerFactoryStub.Create(commandStub).Returns(commandInvokerMock);

			var sut = CreateDbInvoker();
			sut.ExecuteCommand(commandStub);

			commandInvokerMock.Received().Invoke(_dbServiceManagerStub);
		}

		[Test]
		public void InvokeDoesResultExistCommand_ExpectCallReceivedOnDoesResultExistCommandInvoker()
		{
			var commandStub = Substitute.For<IDoesResultExistCommand>();
			var commandInvokerMock = Substitute.For<IDoesResultExistCommandInvoker>();

			_dbInvokerFactoryStub.Create(commandStub).Returns(commandInvokerMock);

			var sut = CreateDbInvoker();
			sut.ExecuteCommand(commandStub);

			commandInvokerMock.Received().Invoke(_dbServiceManagerStub);
		}

		[Test]
		public void InvokeNonQueryCommand_ExpectCallReceivedOnNonQueryCommandInvoker()
		{
			var commandStub = Substitute.For<INonQueryCommand>();
			var commandInvokerMock = Substitute.For<INonQueryCommandInvoker>();

			_dbInvokerFactoryStub.Create(commandStub).Returns(commandInvokerMock);

			var sut = CreateDbInvoker();
			sut.ExecuteCommand(commandStub);

			commandInvokerMock.Received().Invoke(_dbServiceManagerStub);
		}

		[Test]
		public void InvokeNonQueryResultCommand_ExpectCallReceivedOnNonQueryResultCommandInvoker()
		{
			var commandStub = Substitute.For<INonQueryCommand<bool>>();
			var commandInvokerMock = Substitute.For<INonQueryCommandInvoker<bool>>();

			_dbInvokerFactoryStub.Create(commandStub).Returns(commandInvokerMock);

			var sut = CreateDbInvoker();
			sut.ExecuteCommand(commandStub);

			commandInvokerMock.Received().Invoke(_dbServiceManagerStub);
		}

		private IDbContext CreateDbInvoker()
		{
			return new DbContext(_dbInvokerFactoryStub, _dbServiceManagerStub);
		}
	}
}
