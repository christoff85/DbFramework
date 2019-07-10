using DbFramework.DbCommands;
using DbFramework.Interfaces;
using SampleImplementation.Entities;
using SampleImplementation.Interfaces.DbServiceCommands;

namespace SampleImplementation.StoredProcedures
{
	// IManyResultCommand<TResult>
	public class ManyResultsSample : DbStoredProcedure, IManyResultsSample
	{
		public IDbReaderMapper<Person> Mapper { get; }

		public ManyResultsSample(IDbReaderMapper<Person> mapper)
		{
			Mapper = mapper;
		}

		protected override string GetStoredProcedureName()
		{
			return "getPeople";
		}

	    public Person MapResult(IDbReader reader)
	    {
	        return Mapper.MapResult(reader);
        }
	}
}
