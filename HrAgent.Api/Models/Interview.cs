namespace HrAgent.Api.Models;

public class Interview
{
    public int Id { get; set; }
    public int JobApplicationId { get; set; }
    public DateTime ScheduledAt { get; set; }
    public string Status { get; set; } = "Scheduled";
}