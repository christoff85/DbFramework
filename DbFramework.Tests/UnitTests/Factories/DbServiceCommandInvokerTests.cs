using NUnit.Framework;
using DbFramework.Factories;
using DbFramework.Interfaces.DbCommands;
using DbFramework.Invokers;
using NSubstitute;

namespace DbFramework.Tests.UnitTests.Factories
{
	[TestFixture]
	public class DbServiceCommandInvokerTests
	{
		[Test]
		public void CreateInvokerForNonQueryCommand_ExpectInstanceOfNonQueryInvoker()
		{
			var commandStub = Substitute.For<INonQueryCommand>();
			var invoker = DbServiceComponentInvokerFactory.Create(commandStub);
			Assert.IsInstanceOf<NonQueryCommandInvoker>(invoker);
		}

		[Test]
		public void CreateInvokerForGenericNonQueryCommand_ExpectInstanceOfGenericNonQueryInvoker()
		{
			var commandStub = Substitute.For<INonQueryCommand<bool>>();
			var invoker = DbServiceComponentInvokerFactory.Create(commandStub);
			Assert.IsInstanceOf<NonQueryCommandInvoker<bool>>(invoker);
		}

		[Test]
		public void CreateInvokerForSingleResultCommand_ExpectInstanceOfSingleResultInvoker()
		{
			var commandStub = Substitute.For<ISingleResultCommand<bool>>();
			var invoker = DbServiceComponentInvokerFactory.Create(commandStub);
			Assert.IsInstanceOf<SingleResultCommandInvoker<bool>>(invoker);
		}

		[Test]
		public void CreateInvokerForManyResultCommand_ExpectInstanceOfManyResultInvoker()
		{
			var commandStub = Substitute.For<IManyResultCommand<bool>>();
			var invoker = DbServiceComponentInvokerFactory.Create(commandStub);
			Assert.IsInstanceOf<ManyResultCommandInvoker<bool>>(invoker);
		}

		[Test]
		public void CreateInvokerForScalarCommand_ExpectInstanceOfScalarInvoker()
		{
			var commandStub = Substitute.For<IScalarCommand<bool>>();
			var invoker = DbServiceComponentInvokerFactory.Create(commandStub);
			Assert.IsInstanceOf<ScalarCommandInvoker<bool>>(invoker);
		}

		[Test]
		public void CreateInvokerForResultExistsCheckCommand_ExpectInstanceOfResultExistsCheckInvoker()
		{
			var commandStub = Substitute.For<IResultExistsCheckCommand>();
			var invoker = DbServiceComponentInvokerFactory.Create(commandStub);
			Assert.IsInstanceOf<ResultExistsCheckCommandInvoker>(invoker);
		}

		[Test]
		public void CreateInvokerForCustomHandlerCommand_ExpectInstanceOfCustomHandlerInvoker()
		{
			var commandStub = Substitute.For<ICustomHandlerCommand<bool>>();
			var invoker = DbServiceComponentInvokerFactory.Create(commandStub);
			Assert.IsInstanceOf<CustomHandlerCommandInvoker<bool>>(invoker);
		}
	}
}
