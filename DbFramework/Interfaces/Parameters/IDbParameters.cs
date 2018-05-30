using System.Collections.Generic;
using System.Data;

namespace DbFramework.Interfaces.Parameters
{
    public interface IDbParameters : IEnumerable<IDbParameter>
    {
        IDbParameter this[string key] { get; }

        IDbParameters Add(IDbParameter dbParameter);
        IDbParameters Add(string key, object value);
        IDbParameters Add(string key, object value, ParameterDirection direction);

        bool ContainsKey(string key);
    }
}