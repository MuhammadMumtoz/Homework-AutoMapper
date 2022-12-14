using System.ComponentModel.DataAnnotations;
using Domain.Entities;
namespace Domain.Dtos;

public class GetCourseDto
{
    public int CourseID { get; set; }
    public string Title { get; set; }
    public int Credits { get; set; }
}