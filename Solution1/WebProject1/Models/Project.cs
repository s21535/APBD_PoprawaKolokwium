namespace WebProject1.Models;

public class Project
{
    public int IdProject { get; set; }
    public string Name { get; set; }
    
    public int IdDefaultAssignee { get; set; }
    public virtual User IdDefaultAssigneeNaivgation { get; set; }
    
    public virtual ICollection<Access> Accesses { get; set; }
    public virtual ICollection<Task> Tasks { get; set; }
}