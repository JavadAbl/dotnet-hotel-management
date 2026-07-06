namespace Domain.Entities;

/// <summary>
/// Base entity class providing common audit fields for all entities.
/// Follows the DRY principle — every entity inherits id, timestamp, and soft-delete tracking.
/// </summary>
public abstract class BaseEntity
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public string? CreatedBy { get; set; }
    public string? UpdatedBy { get; set; }
    public DateTime? DeletedAt { get; set; }
}
