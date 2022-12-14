namespace Domain.Entities;
using System.ComponentModel.DataAnnotations;
public class Course
{
    public int CourseID { get; set; }
    [Required]
    [StringLength(50)]
    public string Title { get; set; }
    [Range(0,5)]
    public int Credits { get; set; }
    // public int DepartmentID { get; set; }
    public List<Enrollement> Enrollements { get; set; }
    // public Department Department { get; set; }
    // public List<CourseAssignment> CourseAssigments {get; set;}
}