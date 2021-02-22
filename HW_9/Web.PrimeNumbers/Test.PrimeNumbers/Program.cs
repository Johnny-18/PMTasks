using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Test.PrimeNumbers
{
    public static class Program
    {
        static async Task Main()
        {
            var json = await File.ReadAllTextAsync("settings.json");
            var settings = JsonSerializer.Deserialize<Settings>(json);

            var client = new HttpClient();

            var testService = new TestService(client, settings);

            await testService.TestBaseUrl();
            await testService.TestPrimeNumber_MustReturn_StatusCode_Ok();
            await testService.TestPrimeNumber_MustReturn_StatusCode_NotFound();
            await testService.TestPrimeNumbersInRange_SendOnlyOneParameter_MustReturn_BadRequest();
            await testService.TestPrimeNumbersInRange_MustReturn_Ok_AndArrayOfNumbers();
            await testService.TestPrimeNumbersInRange_MustReturn_Ok_WithEmptyArray();
        }
    }
}