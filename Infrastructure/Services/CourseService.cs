namespace Infrastructure.Services;
using Domain.Entities;
using Infrastructure.Context;
using Domain.Dtos;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
public class CourseService
{
    private readonly DataContext _context;
    private readonly IMapper _iMapper;
    public CourseService(DataContext context, IMapper iMapper)
    {
        _context = context;
        _iMapper = iMapper;
    }
    public async Task<List<GetCourseDto>> GetCourseLists()
    {
        var list = await _context.Courses.Select(t => new GetCourseDto()
        {
            CourseID = t.CourseID,
            Title = t.Title,
            Credits = t.Credits
        }).ToListAsync();
        return list;
    }
    public async Task<GetCourseDto> GetById(int id)
    {
        var find = await _context.Courses.FindAsync(id);
        var response = new GetCourseDto()
        {
            CourseID = find.CourseID,
            Title = find.Title,
            Credits = find.Credits
        };
        return response;
    }
    public async Task<GetCourseDto> AddCourse(AddCourseDto course)
    {
        
        
        // var response = new GetCourseDto()
        // {
        //     CourseID = course.CourseID,
        //     Title = course.Title,
        //     Credits = course.Credits
        // };
        // var newCourse = new Course()
        // {
        //     CourseID = course.CourseID,
        //     Title = course.Title,
        //     Credits = course.Credits
        // };
        var map = _iMapper.Map<Course>(course);
        _context.Courses.Add(map);
        await _context.SaveChangesAsync();
        return _iMapper.Map<GetCourseDto>(course);
    }

    public async Task<GetCourseDto> UpdateCourse(AddCourseDto course)
    {
        
        // var response = new GetCourseDto()
        // {
        //     CourseID = course.CourseID,
        //     Title = course.Title,
        //     Credits = course.Credits
        // };
        var map = _iMapper.Map<GetCourseDto>(course);
        var find = await _context.Courses.FindAsync(course.CourseID);
        find.Title = course.Title;
        find.Credits = course.Credits;
        await _context.SaveChangesAsync();
        return map;
    }

    public async Task<int> DeleteCourse(int id)
    {
        var find = await _context.Courses.FindAsync(id);
        _context.Remove(find);
        return await _context.SaveChangesAsync();
    }
}
