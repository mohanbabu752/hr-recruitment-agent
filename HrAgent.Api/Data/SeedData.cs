using HrAgent.Api.Models;

namespace HrAgent.Api.Data;

public static class SeedData
{
    public static async Task InitAsync(AppDbContext db)
    {
        if (db.Jobs.Any()) return;

        var job = new Job
        {
            Title = "Senior React Developer",
            Description = "Build scalable UIs with React, TypeScript and REST APIs.",
            RequiredSkills = "React,TypeScript,Redux,REST,Jest",
            MinExperience = 4
        };
        db.Jobs.Add(job);

        var candidates = new List<Candidate>
        {
            new() { Name = "Arun Kumar", Email = "arun@example.com", Skills = "React,TypeScript,Redux,Jest", ExperienceYears = 5, ResumeText = "5 years building React apps..." },
            new() { Name = "Divya R", Email = "divya@example.com", Skills = "React,JavaScript,REST", ExperienceYears = 3, ResumeText = "3 years frontend..." },
            new() { Name = "Karthik S", Email = "karthik@example.com", Skills = "Angular,TypeScript", ExperienceYears = 6, ResumeText = "Angular specialist..." },
            new() { Name = "Meena L", Email = "meena@example.com", Skills = "React,TypeScript,Redux,REST,Jest,Node", ExperienceYears = 6, ResumeText = "Lead frontend engineer..." },
            new() { Name = "Surya P", Email = "surya@example.com", Skills = "HTML,CSS,JavaScript", ExperienceYears = 1, ResumeText = "Fresher..." }
        };
        db.Candidates.AddRange(candidates);
        await db.SaveChangesAsync();

        db.JobApplications.AddRange(candidates.Select(c =>
            new JobApplication { JobId = job.Id, CandidateId = c.Id }));
        await db.SaveChangesAsync();
    }
}