using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Infrastructure.Services;
using Domain.Dtos;
namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]

public class CourseController{
    public readonly CourseService _courseService;
    public CourseController(CourseService courseService)
    {
        _courseService = courseService;
    }

    [HttpGet("GetAll")]
    public async Task<List<GetCourseDto>> GetCourseLists(){
        return await _courseService.GetCourseLists();
    }
    [HttpGet("GetById")]
    public async Task<GetCourseDto> GetById(int id){
        return await _courseService.GetById(id);
    }
    [HttpPost("Add")]
    public async Task<GetCourseDto> AddCourse(AddCourseDto course){
        return await _courseService.AddCourse(course);
    }
    [HttpPut("Update")]
    public async Task<GetCourseDto> UpdateCourse(AddCourseDto course){
        return await _courseService.UpdateCourse(course);
    }
    [HttpDelete("Delete")]
    public async Task<int> DeleteCourse(int id){
        return await _courseService.DeleteCourse(id);
    }
}