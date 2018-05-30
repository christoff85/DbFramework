using System;
using System.Data;
using DbFramework.Interfaces.Parameters;
using DbFramework.ServiceCommands;
using SampleImplementation.Entities;
using SampleImplementation.Interfaces.DbServiceCommands;

namespace SampleImplementation.StoredProcedures
{
	// INonQueryCommand<TResult>
	public class NonQueryWithResultSample : DbStoredProcedure, INonQueryWithResultSample
	{
		private readonly Person _person;

		public NonQueryWithResultSample(Person person)
		{
			_person = person ?? throw new ArgumentNullException(nameof(person));
		}

		protected override string GetStoredProcedureName()
		{
			return "savePerson";
		}

		protected override IDbParameters MapParameters()
		{
			var p = _person;

			return base.MapParameters()
				.Add("@firstName", p.FirstName)
				.Add("@lastName", p.LastName)
				.Add("@dateOfBirth", p.DateOfBirth)
				.Add("@id", null, ParameterDirection.Output);
		}

		public Person MapOutParametersToResult()
		{
			_person.Id = (int)Parameters["@id"].Value;

			return _person;
		}
	}
}
