using NUnit.Framework;
using System;
using System.Data;
using DbFramework.Interfaces.Database;
using DbFramework.Interfaces.DbCommands;
using DbFramework.Interfaces.Invokers;
using DbFramework.Interfaces.ServiceManagers;
using DbFramework.Invokers;
using NSubstitute;

namespace DbFramework.Tests.UnitTests.Invokers
{
	[TestFixture]
	public class NonQueryInvokerCompositeTests
	{
		[Test]
		public void AddCommandToComposite_Invoke_ExpectCallReceived()
		{
			var dbCommandStub = Substitute.For<IDbCommand>();
			var serviceCommandStub = Substitute.For<INonQueryCommand>();
			serviceCommandStub.GetDbCommand(Arg.Any<IDatabase>()).Returns(dbCommandStub);
			var managerStub = Substitute.For<IDbServiceManager>();

			var composite = NonQueryCommandInvokerComposite.Create();
			composite.Add(serviceCommandStub);

			composite.Invoke(managerStub);

			managerStub.Received().ExecuteNonQuery(dbCommandStub);
		}

		[Test]
		public void AddAndRemoveCommandFromComposite_Invoke_ExpectNoCallReceived()
		{
			var dbCommandStub = Substitute.For<IDbCommand>();
			var serviceCommandStub = Substitute.For<INonQueryCommand>();
			serviceCommandStub.GetDbCommand(Arg.Any<IDatabase>()).Returns(dbCommandStub);
			var managerStub = Substitute.For<IDbServiceManager>();

			var composite = NonQueryCommandInvokerComposite.Create();
			composite.Add(serviceCommandStub)
				.Remove(serviceCommandStub);

			composite.Invoke(managerStub);

			managerStub.DidNotReceive().ExecuteNonQuery(dbCommandStub);
		}

		[Test]
		public void AddCommandTwice_ExpectOnlyOneCommandInComposite()
		{
			var serviceCommandStub = Substitute.For<INonQueryCommand>();

			var composite = NonQueryCommandInvokerComposite.Create();
			composite.Add(serviceCommandStub)
				.Add(serviceCommandStub);

			var count = composite.Count;

			Assert.AreEqual(1, count);
		}

		[Test]
		public void AddNullCommandToComposite_ExpectArgumentNullException()
		{
			var composite = NonQueryCommandInvokerComposite.Create();

			INonQueryCommand command = null;
			Assert.Throws<ArgumentNullException>(() => composite.Add(command));
		}

		[Test]
		public void RemoveNullCommandToComposite_ExpectArgumentNullException()
		{
			var composite = NonQueryCommandInvokerComposite.Create();

			INonQueryCommand command = null;
			Assert.Throws<ArgumentNullException>(() => composite.Remove(command));
		}

		[Test]
		public void AddNullInvokerToComposite_ExpectArgumentNullException()
		{
			var composite = NonQueryCommandInvokerComposite.Create();

			INonQueryCommandInvoker commandInvoker = null;
			Assert.Throws<ArgumentNullException>(() => composite.Add(commandInvoker));
		}

		[Test]
		public void RemoveNullInvokeroComposite_ExpectArgumentNullException()
		{
			var composite = NonQueryCommandInvokerComposite.Create();

			INonQueryCommandInvoker commandInvoker = null;
			Assert.Throws<ArgumentNullException>(() => composite.Remove(commandInvoker));
		}
	}
}
