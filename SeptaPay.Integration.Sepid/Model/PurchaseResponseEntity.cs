using System;

namespace SeptaPay.Integration.Sepid.Model
{
    public class PurchaseResponseEntity
    {
        public Guid Id { get; set; }
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
        public virtual PurchaseRequestEntity PurchaseRequestEntity { get; set; }


    }


}
