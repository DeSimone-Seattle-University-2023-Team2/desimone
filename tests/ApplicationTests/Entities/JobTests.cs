using Application.Entities;

namespace ApplicationTests.Entities;

public class JobTests
{
    [Fact]
    public void JobInstantiation_ShouldBeSuccessful()
    {
        // Act
        Job job = new()
        {
            Id = 1,
            Name = "Test Job",
            InputFile = "path/to/input/file",
            RuntimeConfigFile = "path/to/runtime/config/file",
            OutputFileDirectory = "path/to/output/file/directory",
            SupplementalFilesDirectory = "path/to/supplemental/files/directory",
            CostUsd = 10000,
            CostEstimateUsd = 10000,
            DurationSeconds = 10000,
            Type = new JobType(),
            Status = new JobStatus(),
            MemoryType = new MemoryType(),
            CpuType = new CpuType(),
            Project = new Project(),
            Creator = new ApplicationUser(),
            Terminator = new ApplicationUser(),
            JobSubscriptions = new List<Application.Entities.JobSubscription>()
        };
        
        // Assert
        Assert.Equal(1, job.Id);
        Assert.Equal("Test Job", job.Name);
        Assert.Equal("path/to/input/file", job.InputFile);
        Assert.Equal("path/to/runtime/config/file", job.RuntimeConfigFile);
        Assert.Equal("path/to/output/file/directory", job.OutputFileDirectory);
        Assert.Equal("path/to/supplemental/files/directory", job.SupplementalFilesDirectory);
        Assert.Equal(10000, job.CostUsd);
        Assert.Equal(10000, job.CostEstimateUsd);
        Assert.Equal(10000, job.DurationSeconds);
        Assert.IsType<JobType>(job.Type);
        Assert.IsType<JobStatus>(job.Status);
        Assert.IsType<MemoryType>(job.MemoryType);
        Assert.IsType<CpuType>(job.CpuType);
        Assert.IsType<Project>(job.Project);
        Assert.IsType<ApplicationUser>(job.Creator);
        Assert.IsType<ApplicationUser>(job.Terminator);
        Assert.IsType<List<Application.Entities.JobSubscription>>(job.JobSubscriptions);
    }
}
