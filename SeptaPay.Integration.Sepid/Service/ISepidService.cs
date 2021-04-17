using SeptaPay.Integration.Sepid.Dtos;
using System.Threading.Tasks;

namespace SepidIntigration.Service
{
    public interface ISepidService
    {
        Task<string> BankListAsync(string cardNumber);
        Task<string> CardToDepositAsync(string cardNumber);
        Task<string> CardToIbanAsync(string cardNumber);
        Task<string> DepositToIbanAsync(SepidDepositParam depositParam);
        Task<string> GetCustomerInfoAsync(string nationalCode, string accountNumber);
        Task<string> GetCustomerInfoDetailAsync(string nationalCode, string accountNumber, long birthday);
        Task<SepidPurchaseEntityInfo> GetPurchaseByEntityIdAsync(long EntityId);
        Task<SepidPurchaseRRnInfo> GetPurchaseByRRNAsync(long RRn);
        Task<SepidBarcodeTaxiDriverInfo> GetSepidBarcodeTaxiDriverInfoAsync(string barcode);
        Task<SepidBarcodeTaxiDriverInfo> GetSepidBarcodeTaxiDriverInfoByTermianlIdAsync(string terminalId);
        Task<string> IbanInquiryAsync(string cardNumber);
        Task<SepidPurchaseResult> PurchaseAsync(SepidPurchaseRequest purchaseRequest);
    }
}
