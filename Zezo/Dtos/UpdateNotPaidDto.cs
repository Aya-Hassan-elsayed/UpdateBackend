namespace Zezo.Dtos
{
    public class UpdateNotPaidDto
    {
        public int ShippingId { get; set; }
        public string concate_serial { get; set; }
        public string print_date { get; set; }
        public int print_status { get; set; }
        public string recert_notpaid { get; set; }
        public string toFedex_notpaid { get; set; }
    }
}
