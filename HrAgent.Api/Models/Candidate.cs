namespace HrAgent.Api.Models;

public class Candidate
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
    public string Email { get; set; } = "";
    public string Skills { get; set; } = "";
    public int ExperienceYears { get; set; }
    public string ResumeText { get; set; } = "";
}