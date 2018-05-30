using NUnit.Framework;
using System.Data;
using DbFramework.Interfaces.Database;
using DbFramework.Interfaces.Parameters;
using DbFramework.ServiceCommands;

namespace DbFramework.Tests.UnitTests.ServiceCommands
{
    [TestFixture]
    public class DbServiceCommandTests
	{
	    [Test]
		public void MapParameters_CompareParametersFromMapper_ExpectSame()
		{
			var serviceCommand = new TestDbServiceCommand("fakeCommand");
			var parameters = serviceCommand.Parameters;

			Assert.AreEqual(41, parameters["@id"].Value);
			Assert.AreEqual("JohnDoe", parameters["@name"].Value);
		}

	    [Test]
	    public void MapParametersTwice_CompareParametersFromMapper_ExpectSame()
	    {
		    var serviceCommand = new TestDbServiceCommand("fakeCommand");
		    var parameters = serviceCommand.Parameters;
		    parameters = serviceCommand.Parameters;

		    Assert.AreEqual(41, parameters["@id"].Value);
		    Assert.AreEqual("JohnDoe", parameters["@name"].Value);
	    }

	    [Test]
	    public void CreateDbServiceCommand_CompareCommantTextAndDbServiceCommandHashCodes_ExpectSame()
	    {
		    var commandText = "fakeCommand";
		    var serviceCommand = new TestDbServiceCommand(commandText);

		    Assert.AreEqual(commandText.GetHashCode(), serviceCommand.GetHashCode());
	    }

		[Test]
	    public void CreateTwoServiceCommandWithSameCommandText_Compare_ExpectEqual()
	    {
		    var commandText = "fakeCommand";
		    var serviceCommand = new TestDbServiceCommand(commandText);
		    var otherServiceCommand = new TestDbServiceCommand(commandText);

		    var result = serviceCommand.Equals(otherServiceCommand);

		    Assert.IsTrue(result);
	    }

		[Test]
		public void CreateTwoServiceCommandWithSameCommandText_CompareAsObject_ExpectEqual()
		{
			var commandText = "fakeCommand";
			var serviceCommand = new TestDbServiceCommand(commandText);
			object otherServiceCommand = new TestDbServiceCommand(commandText);

			var result = serviceCommand.Equals(otherServiceCommand);

			Assert.IsTrue(result);
		}

		[Test]
	    public void CompareDbServiceCommandWithSelf_ExpectEqual()
	    {
		    var commandText = "fakeCommand";
		    var serviceCommand = new TestDbServiceCommand(commandText);
		    var otherServiceCommand = serviceCommand;

		    var result = serviceCommand.Equals(otherServiceCommand);

			Assert.IsTrue(result);
	    }

	    [Test]
	    public void CompareDbServiceCommandWithSelfObject_ExpectEqual()
	    {
		    var commandText = "fakeCommand";
		    var serviceCommand = new TestDbServiceCommand(commandText);
		    object otherServiceCommand = serviceCommand;

		    var result = serviceCommand.Equals(otherServiceCommand);

		    Assert.IsTrue(result);
	    }

		[Test]
	    public void CompareDbServiceCommandWithNullServiceCommand_ExpectNotEqual()
	    {
		    var commandText = "fakeCommand";
		    var serviceCommand = new TestDbServiceCommand(commandText);
		    DbServiceCommand otherServiceCommand = null;

		    var result = serviceCommand.Equals(otherServiceCommand);

		    Assert.IsFalse(result);
	    }

		[Test]
	    public void CompareDbServiceCommandWithNullObject_ExpectNotEqual()
	    {
		    var commandText = "fakeCommand";
		    var serviceCommand = new TestDbServiceCommand(commandText);
			object otherServiceCommand = null;

		    var result = serviceCommand.Equals(otherServiceCommand);

		    Assert.IsFalse(result);
	    }

	    [Test]
	    public void CompareDbServiceCommandWithAnotherTypeObject_ExpectNotEqual()
	    {
		    var commandText = "sp_name";
		    var serviceCommand = new TestDbServiceCommand(commandText);
		    object anotherType = "anotherType";

		    var result = serviceCommand.Equals(anotherType);

		    Assert.IsFalse(result);
	    }

		private class TestDbServiceCommand : DbServiceCommand
		{
			private string ProcedureName { get; }

			public TestDbServiceCommand(string procedureName) => ProcedureName = procedureName;

			public override IDbCommand GetDbCommand(IDatabase db) 
				=> throw new System.NotImplementedException();

			public override void AddDbParameter(IDbCommand command, IDbParameter parameter)
				=> throw new System.NotImplementedException();

			public override string GetCommandText() => ProcedureName;

			protected override IDbParameters MapParameters()
			{
				return base.MapParameters()
					.Add("@id", 41)
					.Add("@name", "JohnDoe");
			}
		}
	}
}
