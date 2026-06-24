namespace Domain.Models;

public class Department
{
    public int DepartmentId { get; set; }
    public string DepartmentName { get; set; } = string.Empty;
    
    // Navigation property
    public ICollection<Staff> StaffMembers { get; set; } = new List<Staff>();
}
