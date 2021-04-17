using System.Collections.Generic;

namespace SeptaPay.Integration.Sepid.Dtos
{
    public class SepidBarcodeTaxiDriverInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NationalCode { get; set; }
        public short BarcodType { get; set; }
        public string BarcodeTypeDescription { get; set; }
        public long? IdentificationCode { get; set; }
        public string IdentificationDesc { get; set; }
        public string ImageUrl { get; set; }
        public Dictionary<string, dynamic> CustomData { get; set; }

        public List<SepidPrice> Price { get; set; }
    }



}