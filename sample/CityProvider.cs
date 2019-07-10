using System.Collections.Generic;
using System.Threading.Tasks;
using DbFramework.Interfaces;
using SampleImplementation.TextCommands;

namespace SampleImplementation
{
    internal class CityProvider : ICityProvider
    {
        public IEnumerable<string> GetCities(long communityId, IDbContext dbInvoker)
        {
            var command = new GetCitiesTextCommand(communityId);
            return dbInvoker.ExecuteCommand(command);
        }

        //public async Task<IEnumerable<string>> GetCitiesAsync(long communityId, IDbContext dbInvoker)
        //{
        //    var command = new GetCitiesTextCommand(communityId);
        //    return await dbInvoker.ExecuteCommandAsync(command);
        //}
    }
}
