namespace Domain.Entities;

public class Enrollement{
    public int EnrollementID {get; set;}
    public int StudentID {get; set;}
    public int CourseID {get; set;}
    public Grade? Grade { get; set; }
    public Student Student{get; set;}
    public Course Course{get; set;}
}
public enum Grade{
    A, B, C, D, F
}