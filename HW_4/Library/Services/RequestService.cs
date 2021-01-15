using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Library.Services
{
    public class RequestService
    {
        public async Task<string> Request(string request)
        {
            var client = new HttpClient();
            var response = (await client.GetAsync(request)).EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync();
        }
    }
}