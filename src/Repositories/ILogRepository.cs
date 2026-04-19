using System.Collections.Generic;
using System.Threading.Tasks;
using LoggerApi.src.Models;
namespace LoggerApi.src.Repositories;
public interface ILogRepository
{
    Task AddLogAsync(Logs log);
    Task<List<Logs>> GetLogsByUserAsync(string userId);
    Task<List<Logs>> GetAllLogsAsync();
}
