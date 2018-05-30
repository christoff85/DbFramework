using DbFramework.Adapters;
using DbFramework.Interfaces.Database;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

namespace DbFramework.Factories
{
	public static class DbFactory
	{
		public static IDatabase GetSqlDatabase(string connectionString)
		{
			var db = new SqlDatabase(connectionString);
			return new DatabaseAdapter(db);
		}
	}
}
