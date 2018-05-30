using System.Data;
using DbFramework.Extensions;
using DbFramework.ServiceCommands;
using SampleImplementation.Entities;
using SampleImplementation.Interfaces.DbServiceCommands;

namespace SampleImplementation.StoredProcedures
{
	// IManyResultCommand<TResult>
	public class ManyResultSample : DbStoredProcedure, IManyResultSample
	{
		protected override string GetStoredProcedureName()
		{
			return "getPeople";
		}

		public Person MapReaderToResult(IDataReader reader)
		{
			return new Person()
			{
				Id = reader.GetInt32(0),
				FirstName = reader.GetString(1),
				LastName = reader.GetString(2),
				DateOfBirth = reader.GetDateTimeNullableOrDefault(3)
			};
		}
	}
}
