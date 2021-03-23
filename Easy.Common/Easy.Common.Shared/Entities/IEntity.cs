using System;
using System.Collections.Generic;
using System.Text;

namespace Easy.Common.Shared.Entities
{
    public interface IEntity<TKey>
    {
        public TKey Id { get; set; }
    }
}
