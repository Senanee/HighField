using HighFieldAPI.Logic;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace HighFieldAPI.Extensions
{
    public static class HighFieldApiClientRepositoryExtention
    {
        public static HttpClient CreateHighfieldClient(this HighfielsApiRepository highFieldsApiRepository)
        {
            var client = new HttpClient
            {
                BaseAddress = new Uri(highFieldsApiRepository.HighfieldSettings.BaseUrl)
            };
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }

        public static async Task<T> QueryApiGet<T>(this HighfielsApiRepository highFieldsApiRepository, string path)
        {
            var response = await highFieldsApiRepository.Client.GetAsync(path);
            if (!response.IsSuccessStatusCode)
            {
                return default(T);
            }

            var result = await response.Content.ReadAsAsync<T>();
            return result;
        }
    }
}
