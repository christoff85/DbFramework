using System.Data;
using System.Data.SqlClient;

namespace DbFramework
{
    public class SqlDbUtils : BaseDbUtils
    {
        public SqlDbUtils() 
            : base(SqlClientFactory.Instance)
        {
        }

        protected override void DeriveParameters(IDbCommand discoveryCommand)
        {
            SqlCommandBuilder.DeriveParameters((SqlCommand)discoveryCommand);
        }
    }
}