using System.Net.Http.Headers;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using HaffardBankWebApp.Utils;

namespace HaffardBankWebApp.ApiClient
{
    public class ApiImplementor
    {
        private readonly HttpClient client;
        public ApiImplementor(HttpClient httpClient)
        {
            client = httpClient;
        }
        public async Task<T?> PostApiServiceWithHeaders<T>(string apiurl, Object model, Dictionary<string, string>? headers = null)
        {
            T? resp = default;
            try
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                if (headers != null)
                {
                    foreach (var item in headers)
                    {
                        client.DefaultRequestHeaders.Add(item.Key, item.Value);
                    }
                }

                var data = JsonConvert.SerializeObject(model);
                AppLogManager.LogInfo("(Request)" + apiurl, data);
                var content = new StringContent(data, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(apiurl, content);

                var responseContent = await response.Content.ReadAsStringAsync();

                AppLogManager.LogInfo("(Response)" + apiurl, responseContent);
                resp = string.IsNullOrWhiteSpace(responseContent) ? resp : JsonConvert.DeserializeObject<T>(responseContent);

                return resp;
            }
            catch (TimeoutException)
            {
                AppLogManager.LogError($"{apiurl}", "(TimeoutError)" + apiurl);
            }
            catch (Exception ex)
            {
                AppLogManager.LogException($"{apiurl}", ex);
            }
            return resp;
        }

        public async Task<T?> GetApiServiceWithHeaders<T>(string apiurlAndParam, Dictionary<string, string>? headers = null)
        {
            T? resp = default;
            try
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                if (headers != null)
                {
                    foreach (var item in headers)
                    {
                        client.DefaultRequestHeaders.Add(item.Key, item.Value);
                    }
                }
                AppLogManager.LogInfo($"{apiurlAndParam}", "(Request)");
                var response = await client.GetAsync(apiurlAndParam);

                var responseContent = response.Content.ReadAsStringAsync().Result;

                AppLogManager.LogInfo("(Response)" + apiurlAndParam, responseContent);
                resp = string.IsNullOrWhiteSpace(responseContent) ? resp : JsonConvert.DeserializeObject<T>(responseContent);

                return resp;
            }
            catch (Exception ex)
            {
                AppLogManager.LogException("(ApiError)" + apiurlAndParam, ex);
                return resp;
            }
        }
    }
}
