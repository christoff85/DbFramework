using System.Collections.Generic;
using System.Threading.Tasks;
using DbFramework.Interfaces;

namespace SampleImplementation
{
	interface ICityProvider
	{
		IEnumerable<string> GetCities(long communityId, IDbContext dbInvoker);
	    //Task<IEnumerable<string>> GetCitiesAsync(long communityId, IDbContext dbInvoker);
	}
}