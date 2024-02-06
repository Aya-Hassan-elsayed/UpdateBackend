using System;
using System.Collections.Generic;

namespace Zezo.Models
{
    public partial class RequestPrice
    {
        public int Id { get; set; }
        public int UnitType { get; set; }
        public double AreaSizeFrom { get; set; }
        public double AreaSizeUpTo { get; set; }
        public double Price { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? Createdby { get; set; }
        public string? UpdatedBy { get; set; }
    }
}
