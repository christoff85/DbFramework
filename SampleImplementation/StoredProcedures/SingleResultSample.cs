using System.Data;
using DbFramework.Enums;
using DbFramework.Extensions;
using DbFramework.Interfaces.Parameters;
using DbFramework.ServiceCommands;
using SampleImplementation.Entities;
using SampleImplementation.Interfaces.DbServiceCommands;

namespace SampleImplementation.StoredProcedures
{
	// ISingleResultCommand<TResult>
	public class SingleResultSample : DbStoredProcedure, ISingleResultSample
	{
		private readonly string _id;

		public SingleResultOptions Options { get; }

		public SingleResultSample(string id)
		{
			_id = id;
			Options = SingleResultOptions.Single;
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

		public Person MapReaderToResult(IDataReader reader)
		{
			var person = new Person()
			{
				Id = reader.GetInt32(0),
				FirstName = reader.GetString(1),
				LastName = reader.GetString(2),
				DateOfBirth = reader.GetDateTimeNullableOrDefault(3)
			};

			return person;
		}
	}
}
