using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Easy.Common.Shared.Entities;

namespace Easy.Common.Shared.IRepositories
{
    /// <summary>
    /// 仓储基类接口
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepository<TEntity> where TEntity : class
    {
    }
}
