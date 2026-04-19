namespace LoggerApi.src.DTOs;

public class LogRequestDto
{
    [System.ComponentModel.DataAnnotations.Required]
    public string UserID { get; set; } = string.Empty;
}
