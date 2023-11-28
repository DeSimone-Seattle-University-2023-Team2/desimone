using System.ComponentModel.DataAnnotations;

namespace Application.Entities;

/**
 * Job entity represents a job stored in database that is submitted to Cloud Job Service for execution.
 * TODO: Add more validations to this entity.
 */
public sealed class Job : Entity
{
    /** Job Name will be the description of the job */
    [Required(ErrorMessage = "Job Name is required")]
    [StringLength(maximumLength: 33, MinimumLength = 2, ErrorMessage = "Provide more than {2} and less than {1} characters")]
    public string Name { get; set; } = null!;
    /** Input file is the file path on external storage */
    public string? InputFile { get; set; }
    /** Runtime config file path on external storage */
    public string? RuntimeConfigFile { get; set; }
    /** Output File directory on external storage */
    public string? OutputFileDirectory { get; set; }
    /** Supplemental files directory on external storage */
    public string? SupplementalFilesDirectory { get; set; }
    /** Cost in USD */
    public int? CostUsd { get; set; }
    /** Cost estimate in USD */
    public int? CostEstimateUsd { get; set; }
    /** Runtime duration in seconds */
    public int? DurationSeconds { get; set; }
    /** Type of job (e.g. OpenSEES, CSI, etc.) */
    public JobType? Type { get; set; }
    /** Status of job (e.g. Pending, Running, Succeed, Failed, etc.) */
    public JobStatus? Status { get; set; }
    /** Size of memory in GB */
    public MemoryType? MemoryType { get; set; }
    /** Number of cores */
    public CpuType? CpuType { get; set; }
    /** DCE internal project number */
    public Project? Project { get; set; }
    /** Creator of job */
    public ApplicationUser? Creator { get; set; }
    /** Terminator of job */
    public ApplicationUser? Terminator { get; set; }
    /** List of job subscriptions */
    public List<JobSubscription>? JobSubscriptions { get; set; }
}
