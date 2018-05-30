using NUnit.Framework;
using System.Data;
using DbFramework.Interfaces.Database;
using DbFramework.Interfaces.Parameters;
using DbFramework.Parameters;
using DbFramework.ServiceCommands;
using NSubstitute;

namespace DbFramework.Tests.UnitTests.ServiceCommands
{
    [TestFixture]
    public class DbStoredProcedureTests
    {
        [Test]
        public void CreateStoredProcedureWithName_CheckDbCommandTextAndType_ExpectEqual()
        {
            var spName = "sp_name";

            var dbCommandMock = Substitute.For<IDbCommand>();
            dbCommandMock.CommandText = spName;
            dbCommandMock.CommandType = CommandType.StoredProcedure;

            var fakeDatabase = Substitute.For<IDatabase>();
            fakeDatabase.GetStoredProcCommand(spName).Returns(dbCommandMock);

            var storedProcedure = new TestDbStoredProcedure(spName);

            var dbCommand = storedProcedure.GetDbCommand(fakeDatabase);

            Assert.AreEqual(spName, dbCommand.CommandText);
            Assert.AreEqual(CommandType.StoredProcedure, dbCommand.CommandType);
        }

	    [Test]
	    public void AddParameterToDbCommand_CheckCommand_ExpectSameParameterValues()
	    {
		    string paramName = "myParam";
		    var cmdParameter = Substitute.For<IDataParameter>();
		    cmdParameter.ParameterName = paramName;
		    var command = Substitute.For<IDbCommand>();
		    command.Parameters[paramName].Returns(cmdParameter);
			var dbParameter = Substitute.For<DbParameter>(paramName, true, ParameterDirection.Output);

		    var procedure = new TestDbStoredProcedure("myProcedure");
		    procedure.AddDbParameter(command, dbParameter);

			Assert.AreEqual(dbParameter.Value, cmdParameter.Value);
			Assert.AreEqual(dbParameter.Direction, cmdParameter.Direction);
	    }

	    [Test]
	    public void CreateDbStoredProcedure_CompareNameAndDbProcedureHashCodes_ExpectSame()
	    {
		    var spName = "fakeName";
		    var procedure = new TestDbStoredProcedure(spName);

		    Assert.AreEqual(spName.GetHashCode(), procedure.GetHashCode());
	    }

	    private class TestDbStoredProcedure : DbStoredProcedure
        {
            private string ProcedureName { get; }

            public TestDbStoredProcedure(string procedureName) => ProcedureName = procedureName;

            protected override string GetStoredProcedureName() => ProcedureName;

			protected override IDbParameters MapParameters()
	        {
		        return base.MapParameters()
			        .Add("@id", 41)
			        .Add("@name", "JohnDoe");
	        }
        }
	}
}
