using Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace Infrastructure.Context;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    
    public DbSet<Student> Students {get; set;}
    public DbSet<Enrollement> Enrollements {get; set;}
    public DbSet<Course> Courses {get; set;}
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Enrollement>()
            .HasKey(et => new { et.StudentID, et.CourseID });
        modelBuilder.Entity<Enrollement>()
            .HasOne(et => et.Student)
            .WithMany(e => e.Enrollements)
            .HasForeignKey(et => et.StudentID);

        modelBuilder.Entity<Enrollement>()
            .HasOne(et => et.Course)
            .WithMany(t => t.Enrollements)
            .HasForeignKey(et => et.CourseID);
    }
    
}