using System;

namespace DbFramework.Interfaces.Invokers
{
    public interface IDbServiceCommandInvoker<TResult> : IDbServiceComponentInvoker<TResult>, IEquatable<IDbServiceCommandInvoker<TResult>>
    {
    }
}