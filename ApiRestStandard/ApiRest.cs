using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ApiRestStandard
{
    public sealed class ApiRest
    {
        readonly string _baseAddress;

        public ApiRest(string baseAddress)
            => _baseAddress = baseAddress;

        public async Task<TResponse> PostAsync<TResponse>(string requestUri, object body, Dictionary<string, string> headers = null)
            => await RestAuxAsync<TResponse>(HttpMethod.Post, requestUri, body, headers);

        public async Task<TResponse> PutAsync<TResponse>(string requestUri, object body, Dictionary<string, string> headers = null)
            => await RestAuxAsync<TResponse>(HttpMethod.Put, requestUri, body, headers);

        public async Task<TResponse> GetAsync<TResponse>(string requestUri, Dictionary<string, string> headers = null)
            => await RestAuxAsync<TResponse>(HttpMethod.Get, requestUri, headers: headers);

        async Task<TResponse> RestAuxAsync<TResponse>(HttpMethod httpMethod, string requestUri, object body, Dictionary<string, string> headers = null)
        {
            using (var content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json"))
                return await RestAuxAsync<TResponse>(httpMethod, requestUri, content, headers);
        }

        async Task<TResponse> RestAuxAsync<TResponse>(HttpMethod httpMethod, string requestUri, HttpContent requestContent = null, Dictionary<string, string> headers = null)
        {
            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage(httpMethod, $"{_baseAddress}{requestUri}"))
            {
                if (headers != null)
                    foreach (var item in headers)
                        client.DefaultRequestHeaders.Add(item.Key, item.Value);

                request.Content = requestContent;

                using (var response = await client.SendAsync(request).ConfigureAwait(false))
                using (var content = response.Content)
                {
                    var result = await content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                        return JsonConvert.DeserializeObject<TResponse>(result);

                    throw new ApiException
                    {
                        StatusCode = response.StatusCode,
                        Content = result
                    };
                }
            }
        }
    }
}
