using Autofac;

namespace SampleImplementation.Container
{
	class ComponentsModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterAssemblyTypes(GetType().Assembly)
				.AsImplementedInterfaces()
				.AsSelf();

			base.Load(builder);
		}
	}
}
