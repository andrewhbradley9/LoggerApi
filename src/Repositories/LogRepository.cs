using Amazon.DynamoDBv2.DataModel;
using LoggerApi.src.Models;


namespace LoggerApi.src.Repositories;

public class LogRepository : ILogRepository
{
  private readonly IDynamoDBContext _context;

    public LogRepository(IDynamoDBContext context)
    {
        _context = context;
    }

    public async Task AddLogAsync(Logs log)
    {
        await _context.SaveAsync(log);
    }

    public async Task<List<Logs>> GetLogsByUserAsync(string userId)
    {
        return await _context.QueryAsync<Logs>(userId).GetRemainingAsync();
    }

    public async Task<List<Logs>> GetAllLogsAsync()
    {
        return await _context.ScanAsync<Logs>(new List<ScanCondition>()).GetRemainingAsync();
    }
}
