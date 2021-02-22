using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;

namespace Web.PrimeNumbers
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<PrimeNumbersService>();
        }
        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSerilogRequestLogging();
            
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    var logger = context.RequestServices.GetRequiredService<ILogger<Startup>>();

                    var text = "Web application for prime numbers, created by Ivan Zherybor";
                    
                    logger.Log(LogLevel.Information, "Endpoint: /, answer: {Text}", text);
                    
                    await context.Response.WriteAsync(text);
                });

                endpoints.MapGet("primes/{number:int}", context =>
                {
                    var logger = context.RequestServices.GetRequiredService<ILogger<Startup>>();
                    var primaryNumberService = context.RequestServices.GetRequiredService<PrimeNumbersService>();

                    var number = int.Parse(((string)context.Request.RouteValues["number"]) ?? string.Empty);
                    
                    logger.Log(LogLevel.Information, "Endpoint: primes/number:int");
                    
                    if (primaryNumberService != null && primaryNumberService.IsPrime(number))
                    {
                        logger.Log(LogLevel.Information, "Answer: number: {Number} is prime", number);
                        context.Response.StatusCode = (int)HttpStatusCode.OK;
                    }
                    else
                    {
                        logger.Log(LogLevel.Information, "Answer: number: {Number} is not prime", number);
                        context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    }

                    return Task.CompletedTask;
                });

                endpoints.MapGet("primes", async context =>
                {
                    var logger = context.RequestServices.GetRequiredService<ILogger<Startup>>();
                    var primaryNumberService = context.RequestServices.GetRequiredService<PrimeNumbersService>();

                    var rangeFromString = context.Request.Query["from"].FirstOrDefault();
                    var rangeToString = context.Request.Query["to"].FirstOrDefault();
                    
                    logger.Log(LogLevel.Information, "Endpoint: primes");

                    if (string.IsNullOrEmpty(rangeFromString) || string.IsNullOrEmpty(rangeToString) ||
                        !int.TryParse(rangeFromString, out var rangeFrom) ||
                        !int.TryParse(rangeToString, out var rangeTo) || rangeFrom > rangeTo)
                    {
                        logger.Log(LogLevel.Information, "Answer: Bad request");
                        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        return;
                    }

                    var primeNumbers = primaryNumberService.GetPrimes(rangeFrom, rangeTo);

                    context.Response.StatusCode = (int) HttpStatusCode.OK;
                    
                    if (primeNumbers == null)
                    {
                        logger.Log(LogLevel.Information, "Answer: primes was not found in range {From} => {To}", rangeFrom, rangeTo);
                        return;
                    }
                    
                    logger.Log(LogLevel.Information, "Answer: primes was found in range {From} => {To}", rangeFrom, rangeTo);
                    await context.Response.WriteAsJsonAsync(primeNumbers);
                });
            });
        }
    }
}