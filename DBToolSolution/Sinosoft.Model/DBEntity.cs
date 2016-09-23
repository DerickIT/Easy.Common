using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sinosoft.Model
{
    public class DataAttrEntity
    {
        /// <summary>
        /// 字段名称
        /// </summary>
        public string ColumnName { get; set; }
        /// <summary>
        /// 字段类型
        /// </summary>
        public string ValueType { get; set; }
        /// <summary>
        /// 类型长度
        /// </summary>
        public decimal TypeLength { get; set; }
        /// <summary>
        /// 标记是否被处理过，true：已经处理
        /// </summary>
        public bool Flag { get; set; }
    }


    public class IEComparer : IEqualityComparer<DataAttrEntity>
    {
        bool IEqualityComparer<DataAttrEntity>.Equals(DataAttrEntity x, DataAttrEntity y)
        {
            return x.ColumnName.Equals(y.ColumnName);
        }

        int IEqualityComparer<DataAttrEntity>.GetHashCode(DataAttrEntity obj)
        {
            return obj.ColumnName.GetHashCode();
        }
    }
}
