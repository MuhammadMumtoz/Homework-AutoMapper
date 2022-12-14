using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
public class ServiceProfile : Profile
{
    public ServiceProfile()
    {
        CreateMap<AddStudentDto, Student>().ReverseMap();
        CreateMap<Student, GetStudentDto>().ReverseMap();
        CreateMap<AddStudentDto, GetStudentDto>().ReverseMap();
        CreateMap<AddCourseDto, Course>().ReverseMap();
        CreateMap<Course, GetCourseDto>().ReverseMap();
        CreateMap<AddCourseDto, GetCourseDto>().ReverseMap();
        CreateMap<AddEnrollementDto, Enrollement>().ReverseMap();
        CreateMap<Enrollement, GetEnrollementDto>().ReverseMap();
        CreateMap<AddEnrollementDto, GetEnrollementDto>().ReverseMap();
    }
}