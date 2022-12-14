using Domain.Entities;
namespace Domain.Dtos;
public class AddCourseDto
{
    public int CourseID { get; set; }
    public string Title { get; set; }
    public int Credits { get; set; }
}