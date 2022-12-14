namespace Domain.Entities;
using System.ComponentModel.DataAnnotations;
public class Student
{
    public int StudentID { get; set; }
    [Required]
    [StringLength(50)]
    [Display(Name = "Last Name")]
    public string LastName { get; set; }
    [Required]
    [StringLength(50)]
    [Display(Name = "First Name")]
    public string FirstMidName { get; set; }

    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    [Display(Name = "Enrollement Date")]

    public DateTime EnrollementDate { get; set; }
    public List<Enrollement> Enrollements { get; set; }
    public string ImageName {get; set;}
}