using DbFramework.DbCommands;
using DbFramework.Interfaces;
using SampleImplementation.Entities;

namespace SampleImplementation.Mappers
{
	public class ManyResultSample
	{
		public class PersonMapper : IDbReaderMapper<Person>
		{
			public Person MapResult(IDbReader reader)
			{
				return new Person()
				{
					Id = reader.GetInt("columnName1"),
					FirstName = reader.GetString("columnName1"),
					LastName = reader.GetString("columnName1"),
					DateOfBirth = reader.GetDateTimeNullableOrDefault("columnName1")
				};
			}
		}
	}
}
