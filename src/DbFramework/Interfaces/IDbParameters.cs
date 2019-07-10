using System.Collections.Generic;
using System.Data;

namespace DbFramework.Interfaces
{
    public interface IDbParameters : IEnumerable<IDbParameter>
    {
        IDbParameter this[string key] { get; }

        IDbParameters Add(IDbParameter dbParameter);
        IDbParameters Add(string key, object value);
        IDbParameters Add(string key, ParameterDirection direction);
        IDbParameters Add(string key, object value, DbType dbType);
        IDbParameters Add(string key, object value, ParameterDirection direction);
        IDbParameters Add(string key, object value, ParameterDirection direction, DbType dbType);

        bool ContainsKey(string key);
    }
}