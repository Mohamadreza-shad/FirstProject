using System;

namespace SeptaPay.Integration.Sepid.Dtos
{
    public class SepidPurchaseResult
    {
        public int SwResult { get; set; }
        public long Rrn { get; set; }
        public long Issrrn { get; set; }
        public int Stan { get; set; }
        public DateTime TransactionDate { get; set; }
        public int MessageCode { get; set; }
        public int Status { get; set; }
        public string FaMessageDesc { get; set; }
        public string EnMessageDesc { get; set; }
        public string InnerException { get; set; }
        public int CentralMessageCode { get; set; }

    }

}