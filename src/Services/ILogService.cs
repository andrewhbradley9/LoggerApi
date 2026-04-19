using LoggerApi.src.Models;
namespace LoggerApi.src.Services;

public interface ILogService
{
    Task CreateLogAsync(string userId);

    Task<List<Logs>> GetUserHistoryAsync(string userId);

    Task<List<Logs>> GetGlobalFeedAsync();
}
