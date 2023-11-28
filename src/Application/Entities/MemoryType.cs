namespace Application.Entities;

/**
 * Represents a memory type. For example, DDR4 with a value of 3200.
 */
public sealed class MemoryType : Entity
{
    // The name of the memory type. e.g. DDR4.
    public string? Name { get; set; }
    // The value of the memory type in GB.
    public int? Value { get; set; }
    // The list of job speeds that use this memory type.
    public List<JobSpeed>? JobSpeeds { get; set; }
}
