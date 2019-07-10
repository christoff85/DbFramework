using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using DbFramework.Interfaces.Factories;
using DbFramework.Interfaces.Providers;
using SampleImplementation.Container;

namespace SampleImplementation
{
	internal class SampleImplementationConnectionStringProvider : IDbConnectionStringProvider
	{
		public string GetConnectionString()
		{
			return ConfigurationManager.ConnectionStrings["LocalDb"].ConnectionString;
		}
	}
    internal class Program
    {
        private static void Main(string[] args)
        {
            //Create new IDbUtils instance manually
            //var dbProvider = new SqlDbProvider();
            //var connectionStringProvider = new SampleImplementationConnectionStringProvider();
            //var dbFactory = new DatabaseFactory(connectionStringProvider, dbProvider);
            //var dbInvokerFactory = new DbInvokerFactory();
            //var dbManagerFactory = new DbManagerFactory(dbFactory);
            //var dbContextFactory = new DbContextFactory(dbManagerFactory, dbInvokerFactory);

            //Or via DI Container
            var builder = new ContainerBuilder();
	        builder.RegisterModule<DbFrameworkModule>();
	        builder.RegisterModule<ComponentsModule>();
			var container = builder.Build();

            var contextFactory = container.Resolve<IDbContextFactory>();
            using (var dbContext = contextFactory.CreateNoTransactionContext())
            {
                var cityProvider = container.Resolve<ICityProvider>();
                var results = cityProvider.GetCities(2171111234248002065, dbContext);

                // Any other steps needed after service has returned the result
                foreach (var result in results)
                    Console.WriteLine(result);
            }

            Console.ReadLine();
        }
    }
}
