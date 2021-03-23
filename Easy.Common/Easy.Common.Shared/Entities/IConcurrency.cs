using System;
using System.Collections.Generic;
using System.Text;

namespace Easy.Common.Shared.Entities
{
    public interface IConcurrency
    {
        /// <summary>
        /// 并发控制列
        /// </summary>
        public byte[] RowVersion { get; set; }
    }
}
