using System;
using System.Collections.Generic;

namespace Zezo.Models
{
    public partial class ShippingordersNotpaid
    {
        public int Id { get; set; }
        public string Requestnumber { get; set; } = null!;
        public string? Createdby { get; set; }
        public string? Creatednotes { get; set; }
        public int? PrintStatus { get; set; }
        public string? Editcertificateinformation { get; set; }
        public int? PhoneNotPaid { get; set; }
        public string? StatusNotPaid { get; set; }
        public string? Con1 { get; set; }
        public string? RecertNotPaid { get; set; }
        public string? GehatElt3del { get; set; }
        public string? Createddate { get; set; }
        public string? PrintDate { get; set; }
        public string? TofidexNotPaid { get; set; }
        public string? CancateSeeriall { get; set; }
        public int? CompanyId { get; set; }
        public string? Companyname { get; set; }
        public string? CompanyReplay { get; set; }
    }
}
