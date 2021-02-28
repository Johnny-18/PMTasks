using System;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace WebApiTests
{
    public class TestService
    {
        private readonly HttpClient _client;
        private readonly Settings _settings;

        public TestService(HttpClient client, Settings settings)
        {
            _settings = settings;
            _client = client;
        }

        public async Task TestBaseUrl()
        {
            var url = _settings.BaseUrl + "/";
            
            HttpResponseMessage response = await GetResponse(url);
            
            var expected = "Web application for prime numbers, created by Ivan Zherybor";

            var result = await response.Content.ReadAsStringAsync();

            PrintResult(expected, result);
        }

        public async Task TestPrimeNumber_MustReturn_StatusCode_Ok()
        {
            var url = _settings.BaseUrl + "/" + _settings.Api + "/5";
            
            HttpResponseMessage response = await GetResponse(url);

            var expected = 200;
            
            var result = (int)response.StatusCode;
            
            PrintResult(expected.ToString(), result.ToString());
        }

        public async Task TestPrimeNumber_MustReturn_StatusCode_NotFound()
        {
            var url = _settings.BaseUrl + "/" + _settings.Api + "/4";

            HttpResponseMessage response = await GetResponse(url);

            var expected = 404;
            
            var result = (int)response.StatusCode;
            
            PrintResult(expected.ToString(), result.ToString());
        }

        public async Task TestPrimeNumbersInRange_SendOnlyOneParameter_MustReturn_BadRequest()
        {
            var url = _settings.BaseUrl + "/" + _settings.Api + "?from=10";
            
            HttpResponseMessage response = await GetResponse(url);

            var expected = 400;
            
            var result = (int)response.StatusCode;
            
            PrintResult(expected.ToString(), result.ToString());
        }
        
        public async Task TestPrimeNumbersInRange_MustReturn_Ok_AndArrayOfNumbers()
        {
            var url = _settings.BaseUrl + "/" + _settings.Api + "?from=1&to=12";
            
            HttpResponseMessage response = await GetResponse(url);

            //serialize expected array to json
            var expected = JsonSerializer.Serialize(new []
            {
                2, 3, 5, 7, 11
            });

            //get stream from request
            await using var stream = await response.Content.ReadAsStreamAsync();
            var fileReader = new StreamReader(stream);
            
            PrintResult(expected, await fileReader.ReadToEndAsync());
        }

        public async Task TestPrimeNumbersInRange_MustReturn_Ok_WithEmptyArray()
        {
            var url = _settings.BaseUrl + "/" + _settings.Api + "?from=-10&to=1";
            
            HttpResponseMessage response = await GetResponse(url);

            //serialize expected array to json
            var expected = JsonSerializer.Serialize(new int[]{});

            var expectedStatusCode = 200;

            var responseStatusCode = (int)response.StatusCode;

            //get stream from request
            await using var stream = await response.Content.ReadAsStreamAsync();
            var fileReader = new StreamReader(stream);
            
            PrintResult(expectedStatusCode.ToString(), responseStatusCode.ToString());
            PrintResult(expected, await fileReader.ReadToEndAsync());
        }

        private Task<HttpResponseMessage> GetResponse(string url)
        {
            Console.WriteLine($"\nSending request to {url}");
            
            return _client.GetAsync(url);
        }

        private void PrintResult(string expected, string result)
        {
            Console.WriteLine($"We get: {result}");
            Console.WriteLine($"We need to get: {expected}");
            Console.WriteLine($"This results equal: {result == expected}.\n");
        }
    }
}