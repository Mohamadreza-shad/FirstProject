using System;

namespace SeptaPay.Integration.Sepid.Dtos
{
    public class SepidPurchaseRRnInfo
    {
        public long AmountAfterDiscount { get; set; }
        public long AmountBeforDiscount { get; set; }
        public long PAN { get; set; }
        public int Stan { get; set; }
        public DateTime TransactionDate { get; set; }
        public long TerminalID { get; set; }
        public int InstituteId { get; set; }
        public string Description { get; set; }
        public long RRN { get; set; }
        public int MessageCode { get; set; }
        public string TransactionStatus { get; set; }
        public int CampainID { get; set; }
        public string NationalID { get; set; }
        public string Mobile { get; set; }
        public long Issrrn { get; set; }
        public long EntityId { get; set; }
        public int Merchant { get; set; }

    }



}