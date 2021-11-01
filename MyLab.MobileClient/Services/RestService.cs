using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using MyLab.CoreDTO.Models;
using System.Text.Json;
using Xamarin.Essentials;

namespace MyLab.MobileClient.Services
{
    public class RestService : IRestService
    {
        HttpClient httpClient;
        public RestService()
        {
            httpClient = new HttpClient();
        }

        public async Task<List<MyFile>> GetFilesListAsync()
        {
            string baseAddress =
            DeviceInfo.Platform == DevicePlatform.Android ? "http://10.0.2.2:25026/file" : "http://localhost:25026/file";
        List<MyFile> files = new List<MyFile>();

        Uri uri = new Uri(string.Format(baseAddress, string.Empty));
            HttpResponseMessage response = await httpClient.GetAsync(uri);

            if (response.IsSuccessStatusCode)
            {
                var options = new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                };
                string content = await response.Content.ReadAsStringAsync();
                files = JsonSerializer.Deserialize<List<MyFile>>(content, options);
            }

            return files;
        }
    }
}
