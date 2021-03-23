using System;
using System.Collections.Generic;
using System.Text;

namespace Easy.Common.Lite
{
    /// <summary>
    /// 当前用户上下文,放Easy.Common.Lite这里欠妥。
    /// </summary>
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
