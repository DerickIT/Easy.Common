using System;
using System.Collections.Generic;
using System.Text;

namespace Easy.Common.EFCore
{
    public class UnitOfWorkStatus
    {
        public bool IsStartingUow { get; internal set; }
    }
}
