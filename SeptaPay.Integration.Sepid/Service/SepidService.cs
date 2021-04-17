using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SeptaNSF.Helper.Persian.PersianDateTime;
using SeptaPay.Integration.Sepid.Contexts;
using SeptaPay.Integration.Sepid.Dtos;
using SeptaPay.Integration.Sepid.Extentions;
using SeptaPay.Integration.Sepid.Model;
using SeptaPay.Integration.Sepid.Request;
using System;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SepidIntigration.Service
{
    public class SepidService : ISepidService
    {

        private const string barcodeBaseUrl = "https://srv170-apigateway.tehran.ir/ApiContainer.SepidExtension.RCL1";
        private const string tmBaseUrl = "https://srv170-apigateway.tehran.ir/ApiContainer.Sepid.RCL1";

        private readonly SepidHttpClient _sepidHttpClient;
        private readonly SepidContext _sepidContext;
        private readonly SepidOptions _sepidOptions;

        public SepidService(
            SepidHttpClient sepidHttpClient, 
            IOptions<SepidOptions> sepidOptions, 
            SepidContext sepidContext
        )
        {
            _sepidHttpClient = sepidHttpClient;
            _sepidContext = sepidContext;
            _sepidOptions = sepidOptions.Value;
        }

        //Done
        public async Task<SepidBarcodeTaxiDriverInfo> GetSepidBarcodeTaxiDriverInfoAsync(string barcode)
        {
            string i, terminalId;
            GetTerminalAndInstituteId(barcode, out i, out terminalId);

            using (var request_ = new HttpRequestMessage())
            {
                request_.Method = HttpMethod.Get;

                var url = $"{barcodeBaseUrl}/api/v1/SepidBarcode/GetInfo/{i}/{terminalId}";
                request_.RequestUri = new Uri(url, UriKind.RelativeOrAbsolute);

                CancellationTokenSource source = new CancellationTokenSource();
                CancellationToken token = source.Token;


                var response_ = await _sepidHttpClient.SendAsync(request_, token).ConfigureAwait(false);


                if (!response_.IsSuccessStatusCode)
                {
                    throw new Exception(response_.ReasonPhrase);
                }
                var apiResponse = await response_.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<SepidBarcodeTaxiDriverInfo>(apiResponse);

            }

        }

        //Done
        public async Task<SepidBarcodeTaxiDriverInfo> GetSepidBarcodeTaxiDriverInfoByTermianlIdAsync(string terminalId)
        {

            using (var request_ = new HttpRequestMessage())
            {
                request_.Method = HttpMethod.Get;

                var url = $"{barcodeBaseUrl}/api/v1/SepidBarcode/GetTaxiInfoByTerminal/{terminalId}";
                request_.RequestUri = new System.Uri(url, System.UriKind.RelativeOrAbsolute);


                var response_ = await _sepidHttpClient.SendAsync(request_, default(CancellationToken)).ConfigureAwait(false);

                if (!response_.IsSuccessStatusCode)
                {
                    throw new Exception(response_.ReasonPhrase);
                }

                var apiResponse = await response_.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<SepidBarcodeTaxiDriverInfo>(apiResponse);

            }

        }

        //Done
        public async Task<string> CardToIbanAsync(string cardNumber)
        {
            using (var request_ = new HttpRequestMessage())
            {
                request_.Method = HttpMethod.Get;

                var url = $"{barcodeBaseUrl}/api/V1/IBAN/cardToIban/{cardNumber}";
                request_.RequestUri = new System.Uri(url, System.UriKind.RelativeOrAbsolute);

                var response_ = await _sepidHttpClient.SendAsync(request_, default(CancellationToken)).ConfigureAwait(false);

                if (!response_.IsSuccessStatusCode)
                {
                    throw new Exception(response_.ReasonPhrase);
                }

                var apiResponse = await response_.Content.ReadAsStringAsync();
                return apiResponse;
            }
        }

        public async Task<string> CardToDepositAsync(string cardNumber)
        {
            using (var msg = new HttpRequestMessage())
            {
                msg.Method = HttpMethod.Get;

                var url = $"{barcodeBaseUrl}/api/V1/IBAN/cardToDeposit/{cardNumber}";
                msg.RequestUri = new Uri(url, UriKind.RelativeOrAbsolute);

                var response_ = await _sepidHttpClient.SendAsync(msg, default(CancellationToken)).ConfigureAwait(false);

                if (!response_.IsSuccessStatusCode)
                {
                    throw new Exception(response_.ReasonPhrase);
                }

                return await response_.Content.ReadAsStringAsync();
            }

        }

        //done
        public async Task<string> DepositToIbanAsync(SepidDepositParam depositParam)
        {
            using (var request_ = new HttpRequestMessage())
            {

                var url = $"{barcodeBaseUrl}/api/V1/IBAN/depositToIban";
                request_.RequestUri = new Uri(url, System.UriKind.RelativeOrAbsolute);

                var content_ = new StringContent(JsonConvert.SerializeObject(depositParam), Encoding.UTF8, "application/json");
                request_.Content = content_;
                request_.Method = HttpMethod.Post;


                var response_ = await _sepidHttpClient.SendAsync(request_, default(CancellationToken)).ConfigureAwait(false);

                if (!response_.IsSuccessStatusCode)
                {
                    throw new Exception(response_.ReasonPhrase);
                }

                var apiResponse = await response_.Content.ReadAsStringAsync();
                return apiResponse;
            }

        }

        //done
        public async Task<string> IbanInquiryAsync(string cardNumber)
        {
            using (var request_ = new HttpRequestMessage())
            {
                request_.Method = HttpMethod.Get;

                var url = $"{barcodeBaseUrl}/api/V1/IBAN/IbanInquiry/{cardNumber}";
                request_.RequestUri = new System.Uri(url, System.UriKind.RelativeOrAbsolute);

                var response_ = await _sepidHttpClient.SendAsync(request_, default(CancellationToken)).ConfigureAwait(false);

                if (!response_.IsSuccessStatusCode)
                {
                    throw new Exception(response_.ReasonPhrase);
                }

                var apiResponse = await response_.Content.ReadAsStringAsync();
                return apiResponse;
            }

        }

        //done
        public async Task<string> BankListAsync(string cardNumber)
        {
            using (var request_ = new HttpRequestMessage())
            {
                request_.Method = HttpMethod.Get;

                var url = $"{barcodeBaseUrl}/api/V1/IBAN/BankList"; 
                request_.RequestUri = new System.Uri(url, System.UriKind.RelativeOrAbsolute);

                var response_ = await _sepidHttpClient.SendAsync(request_, default(CancellationToken)).ConfigureAwait(false);
                

                if (!response_.IsSuccessStatusCode)
                {
                    throw new Exception(response_.ReasonPhrase);
                }

                var apiResponse = await response_.Content.ReadAsStringAsync();
                return apiResponse;
            }

        }

        public async Task<string> GetCustomerInfoAsync(string nationalCode, string accountNumber)
        {
            using (var request_ = new HttpRequestMessage())
            {
                request_.Method = HttpMethod.Get;

                var url = $"{barcodeBaseUrl}/api/V1/IBAN/GetCustomerInfo/{nationalCode}/{accountNumber}";
                request_.RequestUri = new System.Uri(url, System.UriKind.RelativeOrAbsolute);

                var response_ = await _sepidHttpClient.SendAsync(request_, default(CancellationToken)).ConfigureAwait(false);

                if (!response_.IsSuccessStatusCode)
                {
                    throw new Exception(response_.ReasonPhrase);
                }

                var apiResponse = await response_.Content.ReadAsStringAsync();
                return apiResponse;
            }

        }

        public async Task<string> GetCustomerInfoDetailAsync(string nationalCode, string accountNumber, long birthday)
        {
            using (var request_ = new HttpRequestMessage())
            {
                request_.Method = HttpMethod.Get;

                var url = $"{barcodeBaseUrl}/api/V1/IBAN/GetCustomerInfoDetail/{nationalCode}/{accountNumber}/{birthday}";
                request_.RequestUri = new System.Uri(url, System.UriKind.RelativeOrAbsolute);

                var response_ = await _sepidHttpClient.SendAsync(request_, default(CancellationToken)).ConfigureAwait(false);

                if (!response_.IsSuccessStatusCode)
                {
                    throw new Exception(response_.ReasonPhrase);
                }

                var apiResponse = await response_.Content.ReadAsStringAsync();
                return apiResponse;
            }
        }

        public async Task<SepidPurchaseResult> PurchaseAsync(SepidPurchaseRequest purchaseRequest)
        {
            string i, terminalId;
            GetTerminalAndInstituteId(purchaseRequest.Barcode, out i, out terminalId);

            var count = _sepidContext.PurchaseRequestEntities.LongCount() + 1;

            SepidPurchaseParam purchaseParam = new SepidPurchaseParam()
            {
                LockFlag = 0,
                AmountAfterDiscount = purchaseRequest.Amount,
                AmountBeforeDiscount = purchaseRequest.Amount,
                CampaignID = 0,
                TerminalID = int.Parse(terminalId),
                InstituteId = int.Parse(i),
                PAN = long.Parse(CreatePAN(purchaseRequest.CustomerUniqueNumber)),
                CustomerId = purchaseRequest.CustomerId,
                Mobile = purchaseRequest.Mobile,
                TransactionDate = DateTime.Now,
                BarcodeStan = null,
                NationalCode = purchaseRequest.NationalCode,
                ReceiveDate = purchaseRequest.ReceiveDate,
                WalletId = null,
                EntityId = long.Parse(CreateEntityId(count)),
                IpgrRn = purchaseRequest.IpgrRn,
                Description = purchaseRequest.Description
            };

            _sepidContext.PurchaseRequestEntities.Add(new PurchaseRequestEntity()
            {
                AmountAfterDiscount = purchaseParam.AmountAfterDiscount,
                AmountBeforeDiscount = purchaseParam.AmountBeforeDiscount,
                BarcodeStan = purchaseParam.BarcodeStan,
                CampaignID = purchaseParam.CampaignID,
                Counter = count,
                CustomerId = purchaseParam.CustomerId,
                Description = purchaseParam.Description,
                EntityId = purchaseParam.EntityId,
                InstituteId = purchaseParam.InstituteId,
                IpgrRn = purchaseParam.IpgrRn,
                LockFlag = purchaseParam.LockFlag,
                Mobile = purchaseParam.Mobile,
                NationalCode = purchaseParam.NationalCode,
                PAN = purchaseParam.PAN,
                ReceiveDate = purchaseParam.ReceiveDate,
                TerminalID = purchaseParam.TerminalID,
                TransactionDate = purchaseParam.TransactionDate,
                WalletId = purchaseParam.WalletId,

            });

            await _sepidContext.SaveChangesAsync();


            using (var request_ = new HttpRequestMessage())
            {

                var url = $"{tmBaseUrl}/api/V1/Sepid/Purchase";
                request_.RequestUri = new Uri(url, System.UriKind.RelativeOrAbsolute);

                var content_ = new StringContent(JsonConvert.SerializeObject(purchaseParam), Encoding.UTF8, "application/json");
                request_.Content = content_;
                request_.Method = HttpMethod.Post;


                var response_ = await _sepidHttpClient.SendAsync(request_, default(CancellationToken)).ConfigureAwait(false);

                if (!response_.IsSuccessStatusCode)
                {
                    throw new Exception(response_.ReasonPhrase);
                }

                var apiResponse = await response_.Content.ReadAsStringAsync();


                var result = JsonConvert.DeserializeObject<SepidPurchaseResult>(apiResponse);


                _sepidContext.PurchaseResponseEntities.Add(new PurchaseResponseEntity()
                {
                    CentralMessageCode = result.CentralMessageCode,
                    EnMessageDesc = result.EnMessageDesc,
                    FaMessageDesc = result.FaMessageDesc,
                    InnerException = result.InnerException,
                    Issrrn = result.Issrrn,
                    MessageCode = result.MessageCode,
                    Rrn = result.Rrn,
                    Stan = result.Stan,
                    Status = result.Status,
                    SwResult = result.SwResult,
                    TransactionDate = result.TransactionDate
                });

                await _sepidContext.SaveChangesAsync();

                return result;
            }

        }

        public async Task<SepidPurchaseRRnInfo> GetPurchaseByRRNAsync(long RRn)
        {
            using (var request_ = new HttpRequestMessage())
            {
                request_.Method = HttpMethod.Get;

                var url = $"{tmBaseUrl}/api/V1/Sepid/Inquiry/GetPurchaseByRRN/{RRn}";
                request_.RequestUri = new System.Uri(url, System.UriKind.RelativeOrAbsolute);

                var response_ = await _sepidHttpClient.SendAsync(request_, default(CancellationToken)).ConfigureAwait(false);

                if (!response_.IsSuccessStatusCode)
                {
                    throw new Exception(response_.ReasonPhrase);
                }

                var apiResponse = await response_.Content.ReadAsStringAsync();

                var result = JsonConvert.DeserializeObject<SepidPurchaseRRnInfo>(apiResponse);

                return result;
            }

        }

        public async Task<SepidPurchaseEntityInfo> GetPurchaseByEntityIdAsync(long EntityId)
        {
            using (var request_ = new HttpRequestMessage())
            {
                request_.Method = HttpMethod.Get;

                var url = $"{tmBaseUrl}/api/V1/Sepid/Inquiry/GetPurchaseByEntityId/{EntityId}";
                request_.RequestUri = new System.Uri(url, System.UriKind.RelativeOrAbsolute);

                var response_ = await _sepidHttpClient.SendAsync(request_, default(CancellationToken)).ConfigureAwait(false);

                if (!response_.IsSuccessStatusCode)
                {
                    throw new Exception(response_.ReasonPhrase);
                }

                var apiResponse = await response_.Content.ReadAsStringAsync();

                var result = JsonConvert.DeserializeObject<SepidPurchaseEntityInfo>(apiResponse);

                return result;
            }

        }

        #region Private

        private string CreatePAN(long CustomerUniqueNumber)
        {
            return _sepidOptions.PANFavaCode.ToString() + CustomerUniqueNumber.ToString() + GetLuhnCheckSum(CustomerUniqueNumber);
        }

        private string GetLuhnCheckSum(long n)
        {
            long nextdigit, sum = 0;

            bool alt = true;

            while (n != 0)
            {
                nextdigit = n % 10;

                if (alt)
                {
                    nextdigit *= 2;
                    nextdigit -= (nextdigit > 9) ? 9 : 0;
                }

                sum += nextdigit;

                n /= 10;
            }

            sum *= 9;

            return (sum % 10).ToString();

        }

        private void GetTerminalAndInstituteId(string barcode, out string i, out string terminalId)
        {
            try
            {
                var queryString = new Uri(barcode).Query;
                var queryDictionary = System.Web.HttpUtility.ParseQueryString(queryString);

                i = queryDictionary["i"].ToString();
                terminalId = queryDictionary["t"];
            }
            catch (Exception)
            {
                i = barcode.Substring(0, 2);
                terminalId = barcode.Substring(2);
            }
        }

        private string CreateEntityId(long count)
        {

            var counter = count.ToString();

            var counterLength = counter.Length;

            for (int i = 0; i < 9 - counterLength; i++)
            {
                counter += "0";
            }

            PersianDate persianDate = new PersianDate(DateTime.Now);
            var year = persianDate.Year.ToString().Substring(2);

            return _sepidOptions.SubSystemCode.ToString() + _sepidOptions.SystemCode.ToString() + year + counter;

        }

        #endregion


    }
}
