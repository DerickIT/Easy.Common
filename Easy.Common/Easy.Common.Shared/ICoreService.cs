using System;
using System.Linq.Expressions;

namespace Easy.Common.Shared
{
    public abstract class CoreService : ICoreService
    {
        protected Expression<Func<TEntity, object>>[] UpdatingProps<TEntity>(params Expression<Func<TEntity, object>>[] expressions)
        {
            return expressions;
        }
    }
}
