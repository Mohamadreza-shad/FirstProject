using System;

namespace SeptaPay.Integration.Sepid.Extentions
{
    public class SepidOptions
    {
        public string ConnectionString { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public long PANFavaCode { get; set; }
        public int SubSystemCode { get; set; }
        public int SystemCode { get; set; }
    }
}