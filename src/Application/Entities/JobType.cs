namespace Application.Entities;

/**
 * Represents a type of job. Refer to the type of program running the simulation.
 * For example, a job type could be "OpenSEES" or "CSI".
 */
public sealed class JobType : Entity
{
    /** The name of the job type. */
    public string? Name { get; set; }
    /** The list of jobs that are of this type. */
    public List<Job>? Jobs { get; set; }
}
