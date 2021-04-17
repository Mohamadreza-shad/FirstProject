using System;
using System.ComponentModel.DataAnnotations;

namespace SeptaPay.Integration.Sepid.Dtos
{
    public class SepidPurchaseRequest
    {
        public long Amount { get; set; }
        public string Barcode { get; set; }
        public string CustomerId { get; set; }
        public string Mobile { get; set; }
        public string NationalCode { get; set; }
        public DateTime ReceiveDate { get; set; }
        public long? IpgrRn { get; set; }
        public string Description { get; set; }

        [MaxLength(9, ErrorMessage = "شماره واحد هر مشتری باید 9 رقم باشد")]
        [MinLength(9, ErrorMessage = "شماره واحد هر مشتری باید 9 رقم باشد")]
        public long CustomerUniqueNumber { get; set; }

    }



}