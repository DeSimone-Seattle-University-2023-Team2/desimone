namespace Application.Entities;

/**
 * Represents the status of a job.
 */
public sealed class JobStatus : Entity
{
    /** The name of the job status. */
    public string? Name { get; set; }
    /** The list of jobs that have this status. */
    public List<Job>? Jobs { get; set; }
}
