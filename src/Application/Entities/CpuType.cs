namespace Application.Entities;

/**
 * This entity is used to represent the CPU type of a job.
 */
public sealed class CpuType : Entity
{
    /** The name of the CPU type.
     *  Breakdown: [Family] + [Subfamily]* + [# of vCPUs] + [Additive Features] + [Accelerator Type]* + [Version]
     */
    public string? Name { get; set; }
    /** Denotes the number of vCPUs of the VM */
    public int? Value { get; set; }
    /** The list of job speeds that use this CPU type. */
    public List<JobSpeed>? JobSpeeds { get; set; }
}
