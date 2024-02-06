using System;
using System.Collections.Generic;

namespace Zezo.Models
{
    public partial class MappUserRole
    {
        public string Id { get; set; } = null!;
        public string UserId { get; set; } = null!;
        public string RoleId { get; set; } = null!;
    }
}
