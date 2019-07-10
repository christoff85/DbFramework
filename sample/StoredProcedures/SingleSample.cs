using System;
using DbFramework.DbCommands;
using DbFramework.Interfaces;
using SampleImplementation.Entities;
using SampleImplementation.Interfaces.DbServiceCommands;

namespace SampleImplementation.StoredProcedures
{
	// ISingleResultCommand<TResult>
	public class SingleResultSample : DbStoredProcedure, ISingleResultSample
	{
		private readonly string _id;

		public IDbReaderMapper<Person> Mapper { get; }

		public SingleResultSample(string id, IDbReaderMapper<Person> mapper)
		{
			_id = id;
			Mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
		}

		protected override string GetStoredProcedureName()
		{
			return "getPerson";
		}

		protected override IDbParameters MapParameters()
		{
			return base.MapParameters()
				.Add("@id", _id);
		}

	    public Person MapResult(IDbReader reader)
	    {
	        return Mapper.MapResult(reader);
	    }
    }
}
