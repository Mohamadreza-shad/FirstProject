using Microsoft.AspNetCore.Mvc;
using SepidIntigration.Service;
using SeptaPay.Integration.Sepid.Dtos;
using System.Threading.Tasks;

namespace Sepid.Api.Controllers
{
    [Route("pay")]
    public class SepidPaymentController : BaseApiController
    {
        private readonly ISepidService _sepidService;

        public SepidPaymentController(ISepidService sepidService)
        {
            _sepidService = sepidService;
        }

        /// <summary>
        /// some more details about list of banks
        /// </summary>
        /// <param name="cardNumber"> Required item</param>
        /// <returns>returns a detailed list of banks</returns>
        [HttpGet("{cardNumber}/banks")]
        public async Task<ActionResult<string>> ListOfBanks(string cardNumber)
        {
            return await _sepidService.BankListAsync(cardNumber);
        }


        /// <summary>
        /// test summery explanation
        /// </summary>
        /// <param name="cardNumber">this is an important parameter</param>
        /// <returns>this action returns card number details</returns>
        [HttpGet("{cardNumber}/CardNumber")]
        public async Task<ActionResult<string>> CardToDeposit(string cardNumber)
        {
            return await _sepidService.CardToDepositAsync(cardNumber);
        }

        /// <summary>
        /// Card number-to-Iban number exchange 
        /// </summary>
        /// <param name="cardNumber">you need to insert your card number</param>
        /// <returns>Returns Iban Number corresponding to card number</returns>
        [HttpGet("{cardNumber}/sheba")]
        public async Task<ActionResult<string>> CardToIban(string cardNumber)
        {
            return await _sepidService.CardToIbanAsync(cardNumber);
        }

        /// <summary>
        /// Deposit-to-Iban number exchange
        /// </summary>
        /// <param name="depositParam">enter your deposit parameters</param>
        /// <returns>Returns Iban Number corresponding to deposit</returns>
        [HttpPost]
        public async Task<ActionResult<string>> DepositToIban(SepidDepositParam depositParam)
        {
            return await _sepidService.DepositToIbanAsync(depositParam);
        }


        /// <summary>
        /// Getting some Customer personal Information
        /// </summary>
        /// <param name="nationalCode">enter your national code</param>
        /// <param name="accountNumber">enter your account number</param>
        /// <returns>Returns Customer personal Information</returns>
        [HttpGet]
        public async Task<ActionResult<string>> GetCustomerInformation(string nationalCode, string accountNumber)
        {
            return await _sepidService.GetCustomerInfoAsync(nationalCode, accountNumber);
        }


        /// <summary>
        /// Getting some more detailed personal information about Customer
        /// </summary>
        /// <param name="nationalCode">enter your national code</param>
        /// <param name="accountNumber">enter your account number</param>
        /// <param name="birthday">Enter your date of birth</param>
        /// <returns>Returns some specific personal information</returns>
        [HttpGet("{nationalCode}/detail/{accountNumber}/birthday/{birthday}")]
        public async Task<ActionResult<string>> GetCustomerDetailInformation(string nationalCode, string accountNumber, long birthday)
        {
            return await _sepidService.GetCustomerInfoDetailAsync(nationalCode,accountNumber,birthday);
        }


        /// <summary>
        /// Getting item properties which is bought by Customer(using EntityInfo)
        /// </summary>
        /// <param name="entityId">enter your entity id</param>
        /// <returns>Returns information about item that customer has bought (using EntityInfo) </returns>
        [HttpGet("{EntityId}")]
        public async Task<ActionResult<SepidPurchaseEntityInfo>> GetPurchaseByEntityId(long entityId)
        {
            return await _sepidService.GetPurchaseByEntityIdAsync(entityId);
        }


        /// <summary>
        /// Getting item properties which is bought by Customer(using RRN)
        /// </summary>
        /// <param name="rRn">Enter your RRN</param>
        /// <returns>Returns information about item that customer has bought (using RRN)</returns>
        [HttpGet("{rRn}/RRNumber")]
        public async Task<ActionResult<SepidPurchaseRRnInfo>> GetPurchaseByRRN(long rRn)
        {
            return await _sepidService.GetPurchaseByRRNAsync(rRn);
        }

        /// <summary>
        /// Getting taxi driver barcode information
        /// </summary>
        /// <param name="barcode"></param>
        /// <returns>Returns information about taxi driver barcode </returns>
        [HttpGet("{barcode}/sepidBarcode")]
        public async Task<ActionResult<SepidBarcodeTaxiDriverInfo>> GetSepidBarcodeTaxiDriverInfo(string barcode)
        {
            return await _sepidService.GetSepidBarcodeTaxiDriverInfoAsync(barcode);
        }

        /// <summary>
        /// Getting taxi driver barcode information by means of terminal id
        /// </summary>
        /// <param name="terminalId"></param>
        /// <returns>Returns taxi driver barcode info by terminal id </returns>
        [HttpGet("{terminalId}/sepidTerminalId")]
        public async Task<ActionResult<SepidBarcodeTaxiDriverInfo>> GetSepidBarcodeTaxiDriverInfoByTermianlId(string terminalId)
        {
            return await _sepidService.GetSepidBarcodeTaxiDriverInfoByTermianlIdAsync(terminalId);
        }

        /// <summary>
        /// sdjdhsdkjs
        /// </summary>
        /// <param name="cardNumber"></param>
        /// <returns>djfhdkd</returns>
        [HttpGet("{cardNumber}/shebaInquiry")]
        public async Task<ActionResult<string>> IbanInquiry(string cardNumber)
        {
            return await _sepidService.IbanInquiryAsync(cardNumber);
        }

        /// <summary>
        /// some information about ietm which is bought by costumer
        /// </summary>
        /// <param name="purchaseRequest"></param>
        /// <returns> Returns some info about items that costumer has bought</returns>
        [HttpGet("{purchaseRequest}")]
        public async Task<ActionResult<SepidPurchaseResult>> Purchase(SepidPurchaseRequest purchaseRequest)
        {
            return await _sepidService.PurchaseAsync(purchaseRequest);
        }

    }
}
