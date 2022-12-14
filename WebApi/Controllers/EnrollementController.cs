using Microsoft.AspNetCore.Mvc;
using Domain.Entities;
using Infrastructure.Services;
using Domain.Dtos;
namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]

public class EnrollementController{
    public readonly EnrollementService _enrollementService;
    public EnrollementController(EnrollementService enrollementService)
    {
        _enrollementService = enrollementService;
    }

    [HttpGet("GetAll")]
    public async Task<List<GetEnrollementDto>> GetEnrollementLists(){
        return await _enrollementService.GetEnrollementLists();
    }
    [HttpGet("GetById")]
    public async Task<GetEnrollementDto> GetById(int id){
        return await _enrollementService.GetById(id);
    }
    [HttpPost("Add")]
    public async Task<GetEnrollementDto> AddEnrollement(AddEnrollementDto enrollement){
        return await _enrollementService.AddEnrollement(enrollement);
    }
    [HttpPut("Update")]
    public async Task<GetEnrollementDto> UpdateEnrollement(AddEnrollementDto enrollement){
        return await _enrollementService.UpdateEnrollement(enrollement);
    }
    [HttpDelete("Delete")]
    public async Task<int> DeleteEnrollement(int id){
        return await _enrollementService.DeleteEnrollement(id);
    }
}