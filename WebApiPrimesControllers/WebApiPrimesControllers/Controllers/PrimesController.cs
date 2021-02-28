using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApiPrimesControllers.Controllers
{
    [ApiController]
    [Route("primes")]
    public class PrimesController : ControllerBase
    {
        private readonly PrimeNumbersService _primeNumbersService;

        private readonly ILogger<PrimesController> _logger;

        public PrimesController(PrimeNumbersService primeNumbersService, ILogger<PrimesController> logger)
        {
            _primeNumbersService = primeNumbersService;
            _logger = logger;
        }
        
        [HttpGet("{number}")]
        public IActionResult GetPrime([FromRoute] int number)
        {
            _logger.Log(LogLevel.Information, "Endpoint: primes/number:int");

            if (number < 2 || _primeNumbersService.IsPrime(number) == false)
            {
                _logger.Log(LogLevel.Information, "Answer: number: {Number} is prime", number);
                return NotFound();
            }
            
            _logger.Log(LogLevel.Information, "Answer: number: {Number} is not prime", number);
            return Ok();
        }
        
        [HttpGet]
        public IActionResult GetPrimesInRange([FromQuery][Required] int @from, [FromQuery][Required] int to)
        {
            _logger.Log(LogLevel.Information, "Endpoint: primes");

            if (ModelState.IsValid == false || @from > to)
            {
                _logger.Log(LogLevel.Information, "Answer: Bad request");
                return BadRequest();
            }
            
            var primeNumbers = _primeNumbersService.GetPrimes(@from, to);
                    
            if (primeNumbers == null)
            {
                _logger.Log(LogLevel.Information, "Answer: primes was not found in range {From} => {To}", @from, to);
            }
                    
            _logger.Log(LogLevel.Information, "Answer: primes was found in range {From} => {To}", @from, to);
            return Ok(primeNumbers);
        }
    }
}