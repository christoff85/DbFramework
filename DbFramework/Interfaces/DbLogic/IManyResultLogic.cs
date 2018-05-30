using System.Collections.Generic;
using DbFramework.Interfaces.DbOperations;

namespace DbFramework.Interfaces.DbLogic
{
    public interface IManyResultLogic<out TResult> : IDbServiceLogic<IEnumerable<TResult>>
    {
    }
}