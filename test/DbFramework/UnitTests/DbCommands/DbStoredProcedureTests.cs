using System.Data;
using DbFramework.DbCommands;
using DbFramework.Interfaces;
using NSubstitute;
using NUnit.Framework;

namespace DbFramework.Tests.UnitTests.DbCommands
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

            var fakeManager = Substitute.For<IDbManager>();
            fakeManager.GetStoredProcCommand(spName).Returns(dbCommandMock);

            var storedProcedure = new TestDbStoredProcedure(spName);

            var dbCommand = storedProcedure.GetDbCommandWithAssignedParameters(fakeManager);

            Assert.AreEqual(spName, dbCommand.CommandText);
            Assert.AreEqual(CommandType.StoredProcedure, dbCommand.CommandType);
        }

        [Test]
        public void AddParameterToDbCommand_CheckCommand_ExpectSameParameterValues()
        {
            var procedureName = "myProcedure";

            var cmdParameter = Substitute.For<IDataParameter>();
            var command = Substitute.For<IDbCommand>();
            var dbManager = Substitute.For<IDbManager>();
            dbManager.GetStoredProcCommand(procedureName).Returns(command);

            string paramName = "myParam";

            cmdParameter.ParameterName = paramName;
            command.Parameters[paramName].Returns(cmdParameter);

            var dbParameter = Substitute.For<DbParameter>(paramName, true, ParameterDirection.Output, DbType.Boolean);

            var procedure = new TestDbStoredProcedure(procedureName);
            procedure.Parameters.Add(dbParameter);
            procedure.GetDbCommandWithAssignedParameters(dbManager);

            Assert.AreEqual(dbParameter.Value, cmdParameter.Value);
            Assert.AreEqual(dbParameter.Direction, cmdParameter.Direction);
            Assert.AreEqual(dbParameter.DatabaseType, cmdParameter.DbType);
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
        }
	}
}
