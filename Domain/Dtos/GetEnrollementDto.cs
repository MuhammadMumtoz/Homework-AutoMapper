using System.ComponentModel.DataAnnotations;
using Domain.Entities;
namespace Domain.Dtos;
public class GetEnrollementDto
{
    public int EnrollementID { get; set; }
    public Grade? Grade { get; set; }
    public int CourseID { get; set; }
    public int StudentID { get; set; }
}