using System;
using System.Collections.Generic;
using System.Text;

namespace Easy.Common.EFCore.Entitys
{
    public class UserContext
    {
        public long Id { get; set; }

        public string Account { get; set; }

        public string Name { get; set; }

        public string RemoteIpAddress { get; set; }

        public string Device { get; set; }

        public string Email { get; set; }

        public long[] RoleIds { get; set; }
    }
}
