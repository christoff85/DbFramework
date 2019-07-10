using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using DbFramework.Interfaces;

namespace DbFramework
{
    internal class DbParameters : IDbParameters
    {
        private readonly IList<IDbParameter> _parameters = new List<IDbParameter>();

	    public IDbParameter this[string key]
	    {
		    get
		    {
			    var parameter = _parameters.SingleOrDefault(p => p.Name.Equals(key));

			    if (parameter == default(DbParameter))
				    throw new InvalidOperationException("DbParameter with the specified key does not exist.");

			    return parameter;
		    }
	    }

        public bool ContainsKey(string key)
		    => _parameters.Any(p => p.Name == key);

        public IDbParameters Add(string key, object value) 
		    => Add(new DbParameter(key, value));

        public IDbParameters Add(string key, ParameterDirection direction)
            => Add(new DbParameter(key, null, direction));

        public IDbParameters Add(string key, object value, DbType dbType)
            => Add(new DbParameter(key, value, dbType));

        public IDbParameters Add(string key, object value, ParameterDirection direction) 
		    => Add(new DbParameter(key, value, direction));

        public IDbParameters Add(string key, object value, ParameterDirection direction, DbType dbType)
            => Add(new DbParameter(key, value, direction, dbType));

        public IDbParameters Add(IDbParameter dbParameter) 
		    => AddWithKeyCheck(dbParameter);

	    private IDbParameters AddWithKeyCheck(IDbParameter dbParameter)
        {
            if (ContainsKey(dbParameter.Name))
                throw new InvalidOperationException("DbParameter with the specified key already exists.");

            _parameters.Add(dbParameter);

            return this;
        }

	    #region IEnumerable implementation
        public IEnumerator<IDbParameter> GetEnumerator()
	        => _parameters.GetEnumerator();

	    [ExcludeFromCodeCoverage]
        IEnumerator IEnumerable.GetEnumerator() 
		    => GetEnumerator();

	    #endregion
    }
}