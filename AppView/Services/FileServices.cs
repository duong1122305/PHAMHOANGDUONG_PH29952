using Microsoft.AspNetCore.Components.Forms;
using System.Net.Http.Headers;

namespace AppView.Services
{
    public class FileServices : IFileServices
    {
        private readonly HttpClient _http;

        public FileServices(HttpClient http)
        {
            _http = http;
        }
        public async Task UploadFiles(IBrowserFile file)
        {
            var content = new MultipartFormDataContent();
            var streamContent = new StreamContent(file.OpenReadStream(file.Size));

            streamContent.Headers.ContentType = new MediaTypeHeaderValue(file.ContentType);

            content.Add(streamContent, "file", file.Name);

            var response = await _http.PostAsync("https://localhost:7167/api/UploadFile", content);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception(await response.Content.ReadAsStringAsync());
            }
        }
    }
}
