namespace Infrastructure.Services;
using Domain.Entities;
using Infrastructure.Context;
using Domain.Dtos;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

public class EnrollementService
{
    private readonly DataContext _context;
    private readonly IMapper _iMapper;
    public EnrollementService(DataContext context, IMapper iMapper)
    {
        _context = context;
        _iMapper = iMapper;
    }
    public async Task<List<GetEnrollementDto>> GetEnrollementLists()
    {
        var list = await _context.Enrollements.Select(t => new GetEnrollementDto()
        {
            EnrollementID = t.EnrollementID,
            Grade = t.Grade,
            CourseID = t.CourseID,
            StudentID = t.StudentID
        }).ToListAsync();
        return list;
    }
    public async Task<GetEnrollementDto> GetById(int id)
    {
        var find = await _context.Enrollements.FindAsync(id);
        var response = new GetEnrollementDto()
        {
            EnrollementID = find.EnrollementID,
            Grade = find.Grade,
            CourseID = find.CourseID,
            StudentID = find.StudentID
        };
        return response;
    }
    public async Task<GetEnrollementDto> AddEnrollement(AddEnrollementDto enrollement)
    {
        // var response = new GetEnrollementDto()
        // {
        //     EnrollementID = enrollement.EnrollementID,
        //     Grade = enrollement.Grade,
        //     CourseID = enrollement.CourseID,
        //     StudentID = enrollement.StudentID
        // };
        // var newEnrollement = new Enrollement()
        // {
        //     EnrollementID = enrollement.EnrollementID,
        //     Grade = enrollement.Grade,
        //     CourseID = enrollement.CourseID,
        //     StudentID = enrollement.StudentID
        // };
        var map = _iMapper.Map<Enrollement>(enrollement);
        _context.Enrollements.Add(map);
        await _context.SaveChangesAsync();
        return _iMapper.Map<GetEnrollementDto>(enrollement);
    }

    public async Task<GetEnrollementDto> UpdateEnrollement(AddEnrollementDto enrollement)
    {
        // var response = new GetEnrollementDto()
        // {
        //     EnrollementID = enrollement.EnrollementID,
        //     Grade = enrollement.Grade,
        //     CourseID = enrollement.CourseID,
        //     StudentID = enrollement.StudentID
        // };
        var map = _iMapper.Map<GetEnrollementDto>(enrollement);

        var find = await _context.Enrollements.FindAsync(enrollement.EnrollementID);
        find.Grade = enrollement.Grade;
        find.CourseID = enrollement.CourseID;
        find.StudentID = enrollement.StudentID;
        await _context.SaveChangesAsync();
        return map;
    }

    public async Task<int> DeleteEnrollement(int id)
    {
        var find = await _context.Enrollements.FindAsync(id);
        _context.Remove(find);
        return await _context.SaveChangesAsync();
    }
}
