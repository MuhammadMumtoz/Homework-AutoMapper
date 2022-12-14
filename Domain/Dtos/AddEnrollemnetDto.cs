using Domain.Entities;
namespace Domain.Dtos;
public class AddEnrollementDto{
    public int EnrollementID {get; set;}
    public int StudentID {get; set;}
    public int CourseID {get; set;}
    public Grade? Grade { get; set; }
}