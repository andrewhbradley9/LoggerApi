using Microsoft.AspNetCore.Mvc;
using LoggerApi.src.Services;
using LoggerApi.src.DTOs;

namespace LoggerApi.src.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LogsController : ControllerBase
    {
        private readonly ILogService _logService;

        public LogsController(ILogService logService)
        {
            _logService = logService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateLog([FromBody] LogRequestDto request)
        {
            await _logService.CreateLogAsync(request.UserID);
            
            return Ok(new { message = "Log saved to DynamoDB!" });
        }

        [HttpGet]
        public async Task<IActionResult> GetLogs([FromQuery] string? userId)
        {
            if (!string.IsNullOrEmpty(userId))
            {
                var userLogs = await _logService.GetUserHistoryAsync(userId);
                return Ok(userLogs);
            }

            var allLogs = await _logService.GetGlobalFeedAsync();
            return Ok(allLogs);
        }
    }
}
