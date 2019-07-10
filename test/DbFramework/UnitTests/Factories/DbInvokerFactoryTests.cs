using DbFramework.DbCommands;
using DbFramework.Factories;
using DbFramework.Invokers;
using NSubstitute;
using NUnit.Framework;

namespace DbFramework.Tests.UnitTests.Factories
{
	[TestFixture]
	public class DbInvokerFactoryTests
	{
		[Test]
		public void CreateInvokerForNonQueryCommand_ExpectInstanceOfNonQueryInvoker()
		{
			var commandStub = Substitute.For<INonQueryCommand>();
			var invoker = new DbInvokerFactory().Create(commandStub);
			Assert.IsInstanceOf<NonQueryCommandInvoker>(invoker);
		}

		[Test]
		public void CreateInvokerForGenericNonQueryCommand_ExpectInstanceOfGenericNonQueryInvoker()
		{
			var commandStub = Substitute.For<INonQueryCommand<bool>>();
			var invoker = new DbInvokerFactory().Create(commandStub);
			Assert.IsInstanceOf<NonQueryCommandInvoker<bool>>(invoker);
		}

		[Test]
		public void CreateInvokerForSingleResultCommand_ExpectInstanceOfSingleResultInvoker()
		{
			var commandStub = Substitute.For<ISingleResultCommand<bool>>();
			var invoker = new DbInvokerFactory().Create(commandStub);
			Assert.IsInstanceOf<SingleResultCommandInvoker<bool>>(invoker);
		}

		[Test]
		public void CreateInvokerForSingleResultOrDefaultCommand_ExpectInstanceOfSingleResultOrDefaultInvoker()
		{
			var commandStub = Substitute.For<ISingleResultOrDefaultCommand<bool>>();
			var invoker = new DbInvokerFactory().Create(commandStub);
			Assert.IsInstanceOf<SingleResultOrDefaultCommandInvoker<bool>>(invoker);
		}

		[Test]
		public void CreateInvokerForFirstResultCommand_ExpectInstanceOfFirstResultInvoker()
		{
			var commandStub = Substitute.For<IFirstResultCommand<bool>>();
			var invoker = new DbInvokerFactory().Create(commandStub);
			Assert.IsInstanceOf<FirstResultCommandInvoker<bool>>(invoker);
		}

		[Test]
		public void CreateInvokerForFirstResultOrDefaultCommand_ExpectInstanceOfFirstResultOrDefaultInvoker()
		{
			var commandStub = Substitute.For<IFirstResultOrDefaultCommand<bool>>();
			var invoker = new DbInvokerFactory().Create(commandStub);
			Assert.IsInstanceOf<FirstResultOrDefaultCommandInvoker<bool>>(invoker);
		}

		[Test]
		public void CreateInvokerForManyResultCommand_ExpectInstanceOfManyResultInvoker()
		{
			var commandStub = Substitute.For<IManyResultsCommand<bool>>();
			var invoker = new DbInvokerFactory().Create(commandStub);
			Assert.IsInstanceOf<ManyResultsCommandInvoker<bool>>(invoker);
		}

		[Test]
		public void CreateInvokerForScalarCommand_ExpectInstanceOfScalarInvoker()
		{
			var commandStub = Substitute.For<IScalarCommand<bool>>();
			var invoker = new DbInvokerFactory().Create(commandStub);
			Assert.IsInstanceOf<ScalarCommandInvoker<bool>>(invoker);
		}

		[Test]
		public void CreateInvokerForResultExistsCheckCommand_ExpectInstanceOfDoesResultExistsInvoker()
		{
			var commandStub = Substitute.For<IDoesResultExistCommand>();
			var invoker = new DbInvokerFactory().Create(commandStub);
			Assert.IsInstanceOf<DoesResultExistCommandInvoker>(invoker);
		}
	}
}
