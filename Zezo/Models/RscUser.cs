using System;
using System.Collections.Generic;

namespace Zezo.Models
{
    public partial class RscUser
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Fullname { get; set; }
        public int UserType { get; set; }
    }
}
