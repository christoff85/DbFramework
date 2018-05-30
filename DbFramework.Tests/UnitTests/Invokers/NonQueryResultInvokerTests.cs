using NUnit.Framework;
using System.Data;
using DbFramework.Extensions;
using DbFramework.Interfaces.Database;
using DbFramework.Interfaces.DbCommands;
using DbFramework.Interfaces.DbOperations;
using DbFramework.Interfaces.Parameters;
using DbFramework.Interfaces.ServiceManagers;
using DbFramework.Parameters;
using NSubstitute;

namespace DbFramework.Tests.UnitTests.Invokers
{
	[TestFixture]
	public class NonQueryResultInvokerTests
	{
		[Test]
		public void InvokeINonQueryResultCommandThroughExtensionMethod_ExpectServiceManagerReceivedCallOnExecuteNonQuery()
		{
			var serviceManager = Substitute.For<IDbServiceManager>();
			var serviceCommand = Substitute.For<INonQueryCommand<bool>>();

			serviceCommand.Invoke(serviceManager);

			serviceManager.Received().ExecuteNonQuery(Arg.Any<IDbCommand>());
		}

		[Test]
		public void InvokeINonQueryResultCommand_Expect()
		{
			string name = "key";
			
			var serviceCommand = new FakeNonQueryCommand(name);
			var serviceManager = Substitute.For<IDbServiceManager>();
			
			var result = serviceCommand.Invoke(serviceManager);

			Assert.IsTrue(result);
		}

		private class FakeNonQueryCommand : INonQueryCommand<bool>
		{
			private string _name;
			public IDbParameters Parameters { get; }

			public FakeNonQueryCommand(string name)
			{
				_name = name;
				Parameters = new DbParameters() {{_name, false, ParameterDirection.Output}};
			}
			
			public bool MapOutParametersToResult()
			{
				return (bool)Parameters[_name].Value;
			}

			public IDbCommand GetDbCommand(IDatabase db)
			{
				var cmdParameterStub = Substitute.For<IDataParameter>();
				cmdParameterStub.ParameterName = _name;
				cmdParameterStub.Value = true;

				var dbCommandStub = Substitute.For<IDbCommand>();
				dbCommandStub.Parameters[_name].Returns(cmdParameterStub);

				return dbCommandStub;
			}

			public void AddDbParameter(IDbCommand command, IDbParameter parameter)
			{
			}

			public string GetCommandText() => throw new System.NotImplementedException();

			public bool Equals(IDbServiceCommand other) => throw new System.NotImplementedException();
		}
	}
}
