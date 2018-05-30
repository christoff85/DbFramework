﻿using DbFramework.Interfaces.DbOperations;

namespace DbFramework.Interfaces.DbCommands
{
    public interface INonQueryCommand<out TResult> : IDbServiceCommand
    {
        TResult MapOutParametersToResult();
    }
}