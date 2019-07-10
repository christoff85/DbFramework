
using DXC.DbFramework.DbCommands;
using DXC.DbFramework.Interfaces;

namespace SampleImplementation.TextCommands
{
	public class GetCitiesFrameworkTextCommand : DbTextCommand, IManyResultsCommand<string>
    {
		private readonly long _communityId;

		public GetCitiesFrameworkTextCommand(long communityId)
		{
			_communityId = communityId;
		}

		protected override string GetSqlString()
		{
			return @"
				SELECT [Name]
				FROM [teryt].[CityDictionaries]
				WHERE CommunityDictionaries_Id = @id";
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
