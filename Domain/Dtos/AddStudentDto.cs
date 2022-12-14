using System.ComponentModel.DataAnnotations;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
namespace Domain.Dtos;
public class AddStudentDto
{
    public int StudentID { get; set; }
    public string LastName { get; set; }
    public string FirstMidName { get; set; }
    public DateTime EnrollementDate { get; set; }
    public IFormFile Image {get; set;}
}