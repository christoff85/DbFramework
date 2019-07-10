using System.Data;
using DbFramework.DbCommands;
using DbFramework.Interfaces;
using NSubstitute;
using NUnit.Framework;

namespace DbFramework.Tests.UnitTests.DbCommands
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

            var fakeManager = Substitute.For<IDbManager>();
            fakeManager.GetSqlStringCommand(sqlString).Returns(dbCommandMock);
            
            var textCommand = new TestDbTextCommand(sqlString);

            var dbCommand = textCommand.GetDbCommandWithAssignedParameters(fakeManager);

            Assert.AreEqual(sqlString, dbCommand.CommandText);
            Assert.AreEqual(CommandType.Text, dbCommand.CommandType);
        }

        [Test]
        public void AddParameterToDbCommand_CheckCommand_ExpectSameParameterValues()
        {
            var sqlText = "SELECT * FROM myTable";
            var paramName = "myParam";
            
            var commandMock = Substitute.For<IDbCommand>();
            var dbManager = Substitute.For<IDbManager>();
            dbManager.GetSqlStringCommand(sqlText).Returns(commandMock);

            var cmdParameter = Substitute.For<IDbDataParameter>();
            commandMock.CreateParameter().Returns(cmdParameter);
            commandMock.Parameters[paramName].Returns(cmdParameter);
            
            var dbParameter = Substitute.For<DbParameter>(paramName, true, ParameterDirection.Output, DbType.Boolean);
            var textCommand = new TestDbTextCommand(sqlText);

            textCommand.Parameters.Add(dbParameter);
            textCommand.GetDbCommandWithAssignedParameters(dbManager);

            commandMock.Parameters.Received().Add(cmdParameter);

            Assert.AreEqual(dbParameter.Name, cmdParameter.ParameterName);
            Assert.AreEqual(dbParameter.Value, cmdParameter.Value);
            Assert.AreEqual(dbParameter.Direction, cmdParameter.Direction);
            Assert.AreEqual(dbParameter.DatabaseType, cmdParameter.DbType);
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

		}
	}
}
