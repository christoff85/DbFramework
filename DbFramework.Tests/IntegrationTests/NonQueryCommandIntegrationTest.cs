using System.Data;
using DbFramework.Extensions;
using DbFramework.Factories;
using DbFramework.Interfaces.Database;
using DbFramework.Interfaces.DbCommands;
using DbFramework.Interfaces.DbLogic;
using DbFramework.Interfaces.Parameters;
using DbFramework.Interfaces.ServiceManagers;
using DbFramework.ServiceCommands;
using NSubstitute;
using NUnit.Framework;

namespace DbFramework.Tests.IntegrationTests
{
	[TestFixture]
	public class NonQueryCommandIntegrationTest
	{
		[Test]
		public void NonQueryCommandIntegrationTest_ExpectThreeAsResult()
		{
			var id = 1;
			var name = "John Doe";

			var database = new FakeDatabase();
			var dbLogic = new NonQeuryServiceLogic(id, name);
			var dbService = DbService.CreateService(database, dbLogic);

			var result = dbService.Execute();

			Assert.AreEqual(3, result);
		}

		private class NonQeuryServiceLogic : ISingleResultLogic<int>
		{
			private readonly int _id;
			private readonly string _name;

			public NonQeuryServiceLogic(int id, string name)
			{
				_id = id;
				_name = name;
			}

			public int Execute(IDbServiceManager dbServiceManager)
			{
				var serviceCommand = new NonQueryStoredProcedure(_id, _name);
				return serviceCommand.Invoke(dbServiceManager);
			}
		}

		private class NonQueryStoredProcedure : DbStoredProcedure, INonQueryCommand
		{
			private readonly int _id;
			private readonly string _name;

			public NonQueryStoredProcedure(int id, string name)
			{
				_id = id;
				_name = name;
			}

			protected override string GetStoredProcedureName() => "NonQuery command stored procedure";

			protected override IDbParameters MapParameters()
			{
				return base.MapParameters()
					.Add("id", _id)
					.Add("name", _name);
			}
		}

		private class FakeDatabase : IDatabase
		{

			public IDbConnection CreateConnection() => Substitute.For<IDbConnection>();
			
			public IDbCommand GetStoredProcCommand(string storedProcedureName)
			{
				var dbCommand = Substitute.For<IDbCommand>();
				dbCommand.CommandType = CommandType.StoredProcedure;
				dbCommand.CommandText = storedProcedureName;

				return dbCommand;
			}

			public void DiscoverParameters(IDbCommand command)
			{
				if (command.CommandText == "NonQuery command stored procedure" && command.CommandType == CommandType.StoredProcedure)
				{
					AddParameter(command, "id");
					AddParameter(command, "name");
				}
			}

			private void AddParameter(IDbCommand command, string name)
			{
				var cmdParameterStub = Substitute.For<IDataParameter>();
				cmdParameterStub.ParameterName = name;

				command.Parameters[name].Returns(cmdParameterStub);
			}

			public int ExecuteNonQuery(IDbCommand command)
			{
				if (command.CommandText == "NonQuery command stored procedure" && command.CommandType == CommandType.StoredProcedure)
				{
					var idParameter = (IDataParameter)command.Parameters["id"];
					var nameParameter = (IDataParameter)command.Parameters["name"];

					if ((int)idParameter.Value == 1 && (string)nameParameter.Value == "John Doe")
						return 3;
				}

				return 0;
			}

			#region Not implemented
			public IDbCommand GetSqlStringCommand(string query) => throw new System.NotImplementedException();
			public IDataReader ExecuteReader(IDbCommand command) => throw new System.NotImplementedException();
			public IDataReader ExecuteReader(IDbCommand command, IDbTransaction transaction) => throw new System.NotImplementedException();
			public int ExecuteNonQuery(IDbCommand command, IDbTransaction transaction) => throw new System.NotImplementedException();
			public object ExecuteScalar(IDbCommand command) => throw new System.NotImplementedException();
			public object ExecuteScalar(IDbCommand command, IDbTransaction transaction) => throw new System.NotImplementedException();
			#endregion
		}
	}
}
