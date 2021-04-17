using System;

namespace SeptaPay.Integration.Sepid.Dtos
{
    public class SepidPurchaseParam
    {
        public int LockFlag { get; set; }
        public long AmountAfterDiscount { get; set; }
        public long AmountBeforeDiscount { get; set; }
        public int CampaignID { get; set; }
        public int TerminalID { get; set; }
        public int InstituteId { get; set; }
        public long PAN { get; set; }
        public string CustomerId { get; set; }
        public string Mobile { get; set; }
        public DateTime TransactionDate { get; set; }
        public int? BarcodeStan { get; set; }
        public string NationalCode { get; set; }
        public DateTime ReceiveDate { get; set; }
        public int? WalletId { get; set; }
        public long? EntityId { get; set; }
        public long? IpgrRn { get; set; }
        public string Description { get; set; }

    }



}