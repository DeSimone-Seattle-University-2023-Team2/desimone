namespace Application.Entities;

/**
 * A job speed is a combination of a memory type and a CPU type.
 * For example, a job speed could be "8GB RAM, 4 CPU cores".
 * A job speed is used to determine the price of a job.
 */
public sealed class JobSpeed : Entity
{
    /** The name of the job speed. */
    public string? Name { get; set; }
    /** Platform specific SKU ID for the VM instance used for getting pricing data */
    public string? SkuId { get; set; }
    /** The memory type of the job speed. e.g. 8GB RAM. */
    public MemoryType? MemoryType { get; set; }
    /** Denotes the name and number of vCPUs of the VM */
    public CpuType? CpuType { get; set; }
    /** The list of jobs that use this job speed. */
    public List<Job>? Jobs { get; set; }
}
