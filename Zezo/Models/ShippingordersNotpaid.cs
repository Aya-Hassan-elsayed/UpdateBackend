using System;
using System.Collections.Generic;

namespace Zezo.Models
{
    public partial class ShippingordersNotpaid
    {
        public long Id { get; set; }
        public string? Requestnumber { get; set; }
        public string? Createdby { get; set; }
        public DateOnly? Createddate { get; set; }
        public string? Creatednotes { get; set; }
        public int? PrintStatus { get; set; }
        public DateOnly? PrintDate { get; set; }
        public string? Editcertificateinformation { get; set; }
    }
}
