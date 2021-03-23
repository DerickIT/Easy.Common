using System;
using System.Collections.Generic;
using System.Text;

namespace Easy.Common.Shared.Entities
{
    public interface ISoftDelete
    {
        bool IsDeleted { get; set; }
    }
}
