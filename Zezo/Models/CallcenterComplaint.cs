using System;
using System.Collections.Generic;

namespace Zezo.Models
{
    public partial class CallcenterComplaint
    {
        public int Id { get; set; }
        public string? Complaint { get; set; }
        public DateTime? ComplaintTime { get; set; }
        public string? Requestnumber { get; set; }
        public int? ComplaintType { get; set; }
        public int? ComplaintStatus { get; set; }
        public string? RscReplay { get; set; }
        public string? RscStatus { get; set; }
        public string? SubType { get; set; }
    }
}
