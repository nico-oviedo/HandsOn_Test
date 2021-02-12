using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace HandsOn.Data.Repositories
{
    public abstract class HttpRequestRepository
    {
        private string _baseUrl;

        public HttpRequestRepository()
        {
            _baseUrl = "http://masglobaltestapi.azurewebsites.net/api/";
        }

        public async Task<T> GetAsync<T>(string apiUrl)
        {
            string endpoint = _baseUrl + apiUrl;

            try
            {
                HttpClient client = new HttpClient();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(endpoint);

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                    var objResponse = JsonConvert.DeserializeObject<T>(jsonResponse);

                    return objResponse;
                }
                else
                {
                    throw new Exception($"Ocurrió un error al consultar la api {endpoint} - HttpResponse: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
