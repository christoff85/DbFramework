using DbFramework.Interfaces.Parameters;
using DbFramework.ServiceCommands;
using SampleImplementation.Interfaces.DbServiceCommands;

namespace SampleImplementation.StoredProcedures
{
	// IScalarCommand<TResult>
	public class ScalarSampleSample : DbStoredProcedure, IScalarSample
    {
        private readonly string _parameterOne;
        private readonly string _parameterTwo;

        public ScalarSampleSample(string parameterOne, string parameterTwo)
        {
            _parameterOne = parameterOne;
            _parameterTwo = parameterTwo;
        }

        protected override string GetStoredProcedureName()
        {
            return "someStoredProcedureName";
        }

        protected override IDbParameters MapParameters()
        {
            return base.MapParameters()
                .Add("@parameterOne", _parameterOne)
                .Add("@parameterTwo", _parameterTwo);
        }
    }
}
