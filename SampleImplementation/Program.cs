using System;
using System.Configuration;
using System.Data;
using DbFramework.Extensions;
using DbFramework.Factories;
using SampleImplementation.ServiceLogic;

namespace SampleImplementation
{
    internal class Program
    {
        private static void Main(string[] args)
        {
			//Create new IDatabase instance
	        var connectionString = ConfigurationManager.ConnectionStrings["LocalDb"].ConnectionString;
            var database = DbFactory.GetSqlDatabase(connectionString);

			// Instantiate logic
			var logic = new GetCitiesLogic();

			// Creating service and executing in one step with use of extension method (preferred)
			var results = logic.CreateTransactionServiceAndExecute(database, IsolationLevel.ReadUncommitted);

			// Alternatively create instance of service and execute in the second step
			var service = DbService.CreateService(database, logic);
			results = service.Execute();

			// Any other steps needed after service has returned the result
			foreach (var result in results)
				Console.WriteLine(result);

            Console.ReadLine();
        }
    }
}
