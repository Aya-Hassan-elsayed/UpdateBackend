using System;
using System.Collections.Generic;

namespace Zezo.Models
{
    public partial class Userprofile
    {
        public int Id { get; set; }
        public string? Telephonenumber { get; set; }
        public string? Userid { get; set; }
        public DateTime? Addeddate { get; set; }
        public DateTime? Modifieddate { get; set; }
        public string? Description { get; set; }
        public string? Telephonenumber2 { get; set; }
    }
}
