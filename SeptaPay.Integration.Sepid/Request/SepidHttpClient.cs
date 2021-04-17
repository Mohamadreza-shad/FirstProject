using IdentityModel.Client;
using Microsoft.Extensions.Options;
using SeptaPay.Integration.Sepid.Extentions;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace SeptaPay.Integration.Sepid.Request
{
    public class SepidHttpClient : HttpClient
    {
        private readonly SepidOptions _sepidOptions;
        private async Task SetToken()
        {

            TokenResponse tokenResponse = await this.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
            {
                Address = "https://srv170-apigateway.tehran.ir/ApiContainer.SSO.RCL1/connect/token",
                ClientId = _sepidOptions.ClientId,
                ClientSecret = _sepidOptions.ClientSecret,
                Scope = "",
                GrantType = "client_credentials"
            });

            this.SetBearerToken(tokenResponse.AccessToken);

        }

        public SepidHttpClient(IOptions<SepidOptions> sepidOptions)
        {
            _sepidOptions = sepidOptions.Value;

            SetToken().Wait();

        }

        public override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {

            var result = await base.SendAsync(request, cancellationToken);

            if (result.StatusCode == HttpStatusCode.Unauthorized)
            {
                await SetToken();

                //return await base.SendAsync(request, cancellationToken);
            }

            return result;
        }

    }
}