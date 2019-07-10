using DbFramework.DbCommands;
using DbFramework.Interfaces;
using SampleImplementation.Interfaces.DbServiceCommands;

namespace SampleImplementation.StoredProcedures
{
	// INonQueryCommand
	public sealed class NonQueryStoredProcedureSample : DbStoredProcedure, INonQueryStoredProcedureSample
	{
		private readonly decimal? _parameterOne;
		private readonly string _parameterTwo;
		private readonly int? _parameterThree;

		public NonQueryStoredProcedureSample(decimal? parameterOne, string parameterTwo, int? parameterThree)
		{
			_parameterOne = parameterOne;
			_parameterTwo = parameterTwo;
			_parameterThree = parameterThree;
		}

		protected override string GetStoredProcedureName()
		{
			return "some_stored_procedure_name";
		}

		protected override IDbParameters MapParameters()
		{
			return base.MapParameters()
				.Add("@parameter_one", _parameterOne)
				.Add("@parameter_two", _parameterTwo)
				.Add("@parameter_three", _parameterThree);
		}
	}
}
