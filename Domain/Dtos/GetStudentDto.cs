using System.ComponentModel.DataAnnotations;
using Domain.Entities;
namespace Domain.Dtos;
public class GetStudentDto
{
    public int StudentID { get; set; }
    public string LastName { get; set; }
    public string FirstMidName { get; set; }
    // [DataType(DataType.Date)]
    // [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime EnrollementDate { get; set; }
    // public int CourseID { get; set; }
    // public string Title { get; set; }
    // public int Credits { get; set; }
    // public Grade? Grade { get; set; }
    // public int EnrollementID { get; set; }
    public string ImageName {get; set;}
}