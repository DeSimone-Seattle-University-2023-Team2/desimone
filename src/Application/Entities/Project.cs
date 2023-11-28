namespace Application.Entities;

/**
 * This class represents a DCE project that will be used to track jobs.
 */
public sealed class Project : Entity
{
    /** The number of the project that can be validated by external service */
    public string? Number { get; set; }
    /** The name of the project. */
    public string? Name { get; set; }
    /** The list of jobs that are in this project. */
    public List<Job>? Jobs { get; set; }
}
