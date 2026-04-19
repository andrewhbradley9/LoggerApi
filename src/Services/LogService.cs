using LoggerApi.src.Models;
using LoggerApi.src.Repositories;
namespace LoggerApi.src.Services;

public class LogService: ILogService
{
    private readonly ILogRepository _repository;

    public LogService(ILogRepository repository)
    {
        _repository = repository;
    }

    public async Task CreateLogAsync(string userId)
    {
        var logEntry = new Logs
        {
            UserID = userId,
            Timestamp = DateTime.UtcNow.ToString("O")
        };

        await _repository.AddLogAsync(logEntry);
    }

    public async Task<List<Logs>> GetUserHistoryAsync(string userId)
    {
        return await _repository.GetLogsByUserAsync(userId);
    }

    public async Task<List<Logs>> GetGlobalFeedAsync()
    {
        return await _repository.GetAllLogsAsync();
    }
}
