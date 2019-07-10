using DbFramework.DbCommands;
using DbFramework.Interfaces;

namespace SampleImplementation.TextCommands
{
	public class GetCitiesTextCommand : DbTextCommand, IManyResultsCommand<string>
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
				WHERE Community_Id = @id";
		}

		protected override IDbParameters MapParameters()
		{
			return base.MapParameters()
				.Add("@id", _communityId);
		}

	    public string MapResult(IDbReader reader)
	    {
	        return reader.GetString("Name");
        }
	}
}
