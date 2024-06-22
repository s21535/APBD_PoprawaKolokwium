namespace WebProject1.Models;

public class Access
{
    public int IdUser { get; set; }
    public int IdProject { get; set; }

    public virtual User IdUserNavigation { get; set; }
    public virtual Project IdProjectNavigation { get; set; }
}