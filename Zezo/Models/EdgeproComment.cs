using System;
using System.Collections.Generic;

namespace Zezo.Models
{
    public partial class EdgeproComment
    {
        public int Id { get; set; }
        public string? Comment { get; set; }
        public DateTime? CommentTime { get; set; }
        public string? Requestnumber { get; set; }
    }
}
