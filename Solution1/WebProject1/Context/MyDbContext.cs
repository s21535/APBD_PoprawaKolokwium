using Microsoft.EntityFrameworkCore;
using WebProject1.Models;
using Task = WebProject1.Models.Task;


namespace WebProject1;

public class MyDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Task> Tasks { get; set; }
    public DbSet<Access> Accesses { get; set; }

    public MyDbContext() {}
    
    public MyDbContext(DbContextOptions dbContextOptions): base(dbContextOptions) {}
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(builder =>
        {
            builder.HasKey(u => u.IdUser);
            builder.Property(u => u.IdUser).ValueGeneratedOnAdd();

            builder.HasMany(u => u.Accesses)
                .WithOne(a => a.IdUserNavigation)
                .HasForeignKey(a => a.IdUser)
                .OnDelete(DeleteBehavior.Restrict);
            
            builder.HasMany(u => u.ReportedTasks)
                .WithOne(t => t.IdReporterNavigation)
                .HasForeignKey(t => t.IdReporter)
                .OnDelete(DeleteBehavior.Restrict);
            
            builder.HasMany(u => u.AssignedTasks)
                .WithOne(t => t.IdAssigneeNavigation)
                .HasForeignKey(t => t.IdAssignee)
                .OnDelete(DeleteBehavior.Restrict);
        });
        
        modelBuilder.Entity<Project>(builder =>
        {
            builder.HasKey(_ => _.IdProject);
            builder.Property(_ => _.IdProject).ValueGeneratedOnAdd();

            builder.HasMany(_ => _.Accesses)
                .WithOne(_ => _.IdProjectNavigation)
                .HasForeignKey(_ => _.IdProject)
                .OnDelete(DeleteBehavior.Restrict);
            
            builder.HasMany(_ => _.Tasks)
                .WithOne(_ => _.IdProjectNavigation)
                .HasForeignKey(_ => _.IdProject)
                .OnDelete(DeleteBehavior.Restrict);
        });
        
        modelBuilder.Entity<Access>(builder =>
        {
            builder.HasKey(_ => new{_.IdProject,_.IdUser});
        });
        
        modelBuilder.Entity<Task>(builder =>
        {
            builder.HasKey(_ => _.IdTask);
            builder.Property(_ => _.IdTask).ValueGeneratedOnAdd();
        });
        
    }
}