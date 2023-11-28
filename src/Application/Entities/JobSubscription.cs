namespace Application.Entities;

/**
 * Represents a subscription to a job inlcuding the user who subscribed and the job that was subscribed to.
 */
public sealed class JobSubscription : Entity
{
    /** The subscriber. */
    public ApplicationUser? Subscriber { get; set; }
    /** The job that was subscribed to. */
    public Job? Job { get; set; }
}
