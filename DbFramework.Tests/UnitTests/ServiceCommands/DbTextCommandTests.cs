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
    public class DbTextCommandTests
    {
        [Test]
        public void CreateTextCommandWithQuery_CheckDbCommandTextAndType_ExpectEqual()
        {
            var sqlString = "SELECT * FROM myTable";

            var dbCommandMock = Substitute.For<IDbCommand>();
            dbCommandMock.CommandText = sqlString;
            dbCommandMock.CommandType = CommandType.Text;

            var fakeDatabase = Substitute.For<IDatabase>();
            fakeDatabase.GetSqlStringCommand(sqlString).Returns(dbCommandMock);
            
            var textCommand = new TestDbTextCommand(sqlString);

            var dbCommand = textCommand.GetDbCommand(fakeDatabase);

            Assert.AreEqual(sqlString, dbCommand.CommandText);
            Assert.AreEqual(CommandType.Text, dbCommand.CommandType);
        }

	    [Test]
	    public void AddParameterToDbCommand_CheckCommand_ExpectSameParameterValues()
	    {
		    var cmdParameter = Substitute.For<IDbDataParameter>();
		    var command = Substitute.For<IDbCommand>();
		    command.CreateParameter().Returns(cmdParameter);
		    var dbParameter = Substitute.For<DbParameter>("myParam", true, ParameterDirection.Output);
		    var textCommand = new TestDbTextCommand("SELECT * FROM myTable");

		    textCommand.AddDbParameter(command, dbParameter);

		    Assert.AreEqual(dbParameter.Name, cmdParameter.ParameterName);
			Assert.AreEqual(dbParameter.Value, cmdParameter.Value);
		    Assert.AreEqual(dbParameter.Direction, cmdParameter.Direction);
	    }

	    [Test]
	    public void CreateDbTextCommand_CompareSqlStringAndDbProcedureHashCodes_ExpectSame()
	    {
			var sqlString = "SELECT * FROM myTable";
			var textCommand = new TestDbTextCommand(sqlString);

		    Assert.AreEqual(sqlString.GetHashCode(), textCommand.GetHashCode());
	    }

	    private class TestDbTextCommand : DbTextCommand
        {
            private string SqlString { get; set; }

            public TestDbTextCommand(string sqlString) => SqlString = sqlString;

            protected override string GetSqlString() => SqlString;
			protected override IDbParameters MapParameters()
			{
				return base.MapParameters()
					.Add("@id", 41)
					.Add("@name", "JohnDoe");
			}
		}
	}
}
