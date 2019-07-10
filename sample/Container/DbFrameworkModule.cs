using Autofac;
using DbFramework;
using DbFramework.Factories;
using DbFramework.Interfaces;
using DbFramework.Interfaces.Factories;
using DbFramework.Interfaces.Providers;

namespace SampleImplementation.Container
{
	class DbFrameworkModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<SampleImplementationConnectionStringProvider>()
				.As<IDbConnectionStringProvider>()
				.SingleInstance();

			builder.RegisterType<DbInvokerFactory>()
				.As<IDbInvokerFactory>()
				.SingleInstance();

		    builder.RegisterType<DbContextFactory>()
		        .As<IDbContextFactory>()
		        .SingleInstance();

            builder.RegisterType<DbManagerFactory>()
				.As<IDbManagerFactory>()
				.SingleInstance();

		    builder.RegisterType<SqlDbUtils>()
		        .As<IDbUtils>()
		        .SingleInstance();

            base.Load(builder);
		}
	}
}
