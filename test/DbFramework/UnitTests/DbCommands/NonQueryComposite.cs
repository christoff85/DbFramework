using System;
using DbFramework.DbCommands;
using NSubstitute;
using NUnit.Framework;

namespace DbFramework.Tests.UnitTests.DbCommands
{
	[TestFixture]
	public class NonQueryInvokerCompositeTests
	{
		[Test]
		public void AddSameCommandTwice_ExpectCountEqualsOne()
		{
			var commandStub = Substitute.For<INonQueryCommand>();
			var composite = NonQueryCommandComposite.Create();

			composite.Add(commandStub)
				.Add(commandStub);

			var count = composite.Count;

			Assert.AreEqual(1, count);
		}

		[Test]
		public void AddTwoDifferentCommand_ExpectCountEqualsTwo()
		{
			var commandStub = Substitute.For<INonQueryCommand>();
			var otherCommandStub = Substitute.For<INonQueryCommand>();
			var composite = NonQueryCommandComposite.Create();

			composite.Add(commandStub)
				.Add(otherCommandStub);

			var count = composite.Count;

			Assert.AreEqual(2, count);
		}

		[Test]
		public void AddAndRemoveCommandFromComposite_ExpectCountEqualsZero()
		{
			var serviceCommandStub = Substitute.For<INonQueryCommand>();

			var composite = new NonQueryCommandComposite();
			composite.Add(serviceCommandStub)
				.Remove(serviceCommandStub);

			var count = composite.Count;

			Assert.AreEqual(0, count);
		}

		[Test]
		public void AddNullCommandToComposite_ExpectArgumentNullException()
		{
			var composite = NonQueryCommandComposite.Create();

			Assert.Throws<ArgumentNullException>(() => composite.Add(null));
		}

		[Test]
		public void RemoveNullCommandToComposite_ExpectArgumentNullException()
		{
			var composite = NonQueryCommandComposite.Create();

			Assert.Throws<ArgumentNullException>(() => composite.Remove(null));
		}
	}
}
