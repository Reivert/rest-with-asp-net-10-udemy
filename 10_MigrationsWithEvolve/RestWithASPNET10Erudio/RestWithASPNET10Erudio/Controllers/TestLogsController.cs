using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RestWithASPNET10Erudio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestLogsController : ControllerBase
    {
        private readonly ILogger<TestLogsController> _logger;

        public TestLogsController(ILogger<TestLogsController> logger) { _logger = logger; }

        [HttpGet]
        public IActionResult LogTest()
        {
            _logger.LogTrace("This is a trace log.");
            _logger.LogDebug("This is a debug log.");
            _logger.LogInformation("This is an information log.");
            _logger.LogWarning("This is a warning log.");
            _logger.LogError("This is an error log.");
            _logger.LogCritical("This is a critical log.");
            return Ok("Logs have been generated. Check your logging output.");
        }
    }
}
