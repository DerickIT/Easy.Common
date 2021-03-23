using System;

namespace Easy.Common.Shared.Interceptors
{
    [AttributeUsage(AttributeTargets.Method, Inherited = true)]
    public class UnitOfWorkAttribute : Attribute
    {
        /// <summary>
        /// 需要把事务共享给CAP
        /// </summary>
        public bool SharedToCap { get; set; }
    }
}
