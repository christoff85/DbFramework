using System.Data;
using DbFramework.Interfaces.DbCommands;
using DbFramework.Interfaces.Parameters;
using DbFramework.ServiceCommands;

namespace SampleImplementation.TextCommands
{
	// IManyResult with DbTextCommand
	class GetCitiesTextCommand : DbTextCommand, IManyResultCommand<string>
	{
		private readonly long _communityId;

		public GetCitiesTextCommand(long communityId)
		{
			_communityId = communityId;
		}

		protected override string GetSqlString()
		{
			return @"
				SELECT [Name]
				FROM [dbo].[cities]
				WHERE id = @id";
		}

		protected override IDbParameters MapParameters()
		{
			return base.MapParameters()
				.Add("@id", _communityId);
		}

		public string MapReaderToResult(IDataReader reader)
		{
			return reader.GetString(reader.GetOrdinal("Name"));
		}
	}
}
