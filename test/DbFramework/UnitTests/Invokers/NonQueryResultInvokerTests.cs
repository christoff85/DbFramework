using System.Data;
using System.Threading;
using System.Threading.Tasks;
using DbFramework.DbCommands;
using DbFramework.Interfaces;
using DbFramework.Invokers;
using NSubstitute;
using NUnit.Framework;

namespace DbFramework.Tests.UnitTests.Invokers
{
    [TestFixture]
    public class NonQueryResultInvokerTests
    {
        [Test]
        public void InvokeCommand_ExpectServiceManagerReceivedCallOnExecuteNonQuery()
        {
            var serviceManager = Substitute.For<IDbManager>();
            var serviceCommand = Substitute.For<INonQueryCommand<bool>>();

            var sut = new NonQueryCommandInvoker<bool>(serviceCommand);

            sut.Invoke(serviceManager);

            serviceManager.Received().ExecuteNonQuery(Arg.Any<IDbCommand>());
        }

        [Test]
        public void InvokeCommandWithParameterFalse_ExpectOutputParameterTrue()
        {
            var parameterName = "key";

            var serviceCommand = new FakeNonQueryCommand(parameterName);
            var serviceManager = Substitute.For<IDbManager>();

            var sut = new NonQueryCommandInvoker<bool>(serviceCommand);

            var result = sut.Invoke(serviceManager);

            Assert.IsTrue(result);
        }

        private class FakeNonQueryCommand : INonQueryCommand<bool>
        {
            private readonly string _parameterName;

            public IDbParameters Parameters { get; }
            public IDbCommand GetDbCommandWithAssignedParameters(IDbManager dbManager)
            {
                var cmdParameterStub = Substitute.For<IDataParameter>();
                cmdParameterStub.ParameterName = _parameterName;
                cmdParameterStub.Value = true;

                var dbCommandStub = Substitute.For<IDbCommand>();
                dbCommandStub.Parameters[_parameterName].Returns(cmdParameterStub);

                return dbCommandStub;
            }

            public Task<IDbCommand> GetDbCommandWithAssignedParametersAsync(IDbManager dbManager, CancellationToken cancellationToken)
            {
                throw new System.NotImplementedException();
            }

            public FakeNonQueryCommand(string parameterName)
            {
                _parameterName = parameterName;
                Parameters = new DbParameters() { { _parameterName, false, ParameterDirection.Output } };
            }

            public bool MapOutParametersToResult()
            {
                return (bool)Parameters[_parameterName].Value;
            }

            public string GetCommandText() => throw new System.NotImplementedException();
            public IDbCommand AssignParameters(IDbCommand dbCommand)
            {
                return dbCommand;
            }

            public bool Equals(IDbFrameworkCommand other) => throw new System.NotImplementedException();
        }
    }
}
