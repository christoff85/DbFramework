namespace DbFramework.Interfaces.Factories
{
	public interface IDatabaseFactory
	{
		IDbUtils CreateDatabase();
	}
}