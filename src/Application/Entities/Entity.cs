namespace Application.Entities;

/*
 * This is the base class for all entities in the application.
 */
public abstract class Entity
{
    /** The Id property is the primary key for all entities. */
    public int Id { get; set; }
    /** The CreatedAt property is the date and time the entity was created. */
    public DateTime? CreatedAt { get; set; }
    /** The UpdatedAt property is the last updated timestamp of the entity. */
    public DateTime? UpdatedAt { get; set; }
}
