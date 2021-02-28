using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace WebApiPrimesControllers.Controllers
{
    [ApiController]
    [Route("")]
    public class StatusController : ControllerBase
    {
        private readonly ILogger<StatusController> _logger;

        public StatusController(ILogger<StatusController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetText()
        {
            var text = "Web api prime numbers with controllers, created by Ivan Zherybor!";
            
            _logger.Log(LogLevel.Information, "Endpoint: /, answer: {Text}", text);
            
            return Ok(text);
        }
    }
}