using System.Collections;

namespace WebProject1.Models;

public class User
{
    public int IdUser { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    
    public virtual ICollection<Access> Accesses { get; set; }
    public virtual ICollection<Task> ReportedTasks { get; set; }
    public virtual ICollection<Task> AssignedTasks { get; set; }
}