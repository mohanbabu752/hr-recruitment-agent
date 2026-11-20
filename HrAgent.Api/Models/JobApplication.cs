namespace HrAgent.Api.Models;

public class JobApplication
{
    public int Id { get; set; }
    public int JobId { get; set; }
    public Job Job { get; set; } = null!;
    public int CandidateId { get; set; }
    public Candidate Candidate { get; set; } = null!;
    public string Status { get; set; } = "Applied"; // Applied, Shortlisted, Interview, Rejected, Offer
    public int? MatchScore { get; set; }
    public string? ScoreReason { get; set; }
}