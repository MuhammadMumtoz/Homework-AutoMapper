using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Infrastructure.Services;
using Domain.Dtos;
namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]

public class StudentController{
    public readonly StudentService _studentService;
    public StudentController(StudentService studentService)
    {
        _studentService = studentService;
    }

    [HttpGet("GetAll")]
    public async Task<List<GetStudentDto>> GetStudentLists(){
        return await _studentService.GetStudentLists();
    }
    [HttpGet("GetById")]
    public async Task<GetStudentDto> GetById(int id){
        return await _studentService.GetById(id);
    }
    [HttpPost("Add")]
    public async Task<GetStudentDto> AddStudent([FromForm]AddStudentDto student){
        return await _studentService.AddStudent(student);
    }
    [HttpPut("Update")]
    public async Task<GetStudentDto> UpdateStudent([FromForm]AddStudentDto student){
        return await _studentService.UpdateStudent(student);
    }
    [HttpDelete("Delete")]
    public async Task<int> DeleteStudent(int id){
        return await _studentService.DeleteStudent(id);
    }
}