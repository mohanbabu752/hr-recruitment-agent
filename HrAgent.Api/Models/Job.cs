namespace HrAgent.Api.Models;

public class Job
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public string Description { get; set; } = "";
    public string RequiredSkills { get; set; } = ""; // "React,TypeScript,REST"
    public int MinExperience { get; set; }
}
