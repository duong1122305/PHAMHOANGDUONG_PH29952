using Newtonsoft.Json;
using System.Net.Http;
using System;

namespace AppView.Helper
{
    public class CallApiHelper<T>
    {
        private readonly HttpClient _http;
        private string Url = "api/SinhVien/";
        public CallApiHelper(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<T>> APIGetAll()
        {
            var response = await _http.GetAsync(Url);
            var read = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<List<T>>(read);

            return result;
        }
        public async Task<T> GetById(int id)
        {
            var response = await _http.GetAsync($"{Url}/{id}");
            var readResponse = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<T>(readResponse);

            if (result != null) return result;

            throw new Exception();
        }

        public async Task<bool> CreateAPI(T entity)
        {
            var response = await _http.PostAsJsonAsync($"{Url}/create", entity);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> UpdateAPI(int id, T entity)
        {
            var response = await _http.PutAsJsonAsync($"{Url}/update/{id}", entity);
            if (response.IsSuccessStatusCode) return true;

            return false;
        }

        public async Task<bool> DeleteAPI(int id)
        {
            var response = await _http.DeleteAsync($"{Url}/delete/{id}");
            if (response.IsSuccessStatusCode) return true;

            return false;
        }
    }
}
