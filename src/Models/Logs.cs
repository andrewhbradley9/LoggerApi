using Amazon.DynamoDBv2.DataModel;
namespace LoggerApi.src.Models;

[DynamoDBTable("Logs")]
public class Logs
{
    [DynamoDBHashKey("UserId")]
    public string UserID { get; set; } = string.Empty;

    [DynamoDBRangeKey("Timestamp")]
    public string Timestamp { get; set; } = string.Empty;

}
