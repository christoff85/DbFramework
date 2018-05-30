using System.Collections.Generic;
using DbFramework.Extensions;
using DbFramework.Factories;
using DbFramework.Interfaces.DbLogic;
using DbFramework.Interfaces.ServiceManagers;
using SampleImplementation.TextCommands;

namespace SampleImplementation.ServiceLogic
{
    class GetCitiesLogic : IManyResultLogic<string>
    {
        public IEnumerable<string> Execute(IDbServiceManager dbServiceManager)
        {
			// Logic contains all operation necessary for given operation
			// It can invoke command and other logics.

	        var cityId = 2180509090002001778;
	        var command = new GetCitiesTextCommand(cityId);

			// Commands and logics can be invoked by extesion methods (preffered)
			var names = command.Invoke(dbServiceManager);

			// Or alternatively by creating invoker and invoking in the second sterp
			var invoker = DbServiceComponentInvokerFactory.Create(command);
	        invoker.Invoke(dbServiceManager);

			return names;
        }
    }
}
