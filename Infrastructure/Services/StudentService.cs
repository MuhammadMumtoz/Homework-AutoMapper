namespace Infrastructure.Services;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.AspNetCore.Hosting;
using Domain.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using AutoMapper;

public class StudentService
{
    private readonly DataContext _context;
    private readonly IWebHostEnvironment _environment;
    private readonly IMapper _iMapper;
    public StudentService(DataContext context, IWebHostEnvironment environment, IMapper iMapper)
    {
        _context = context;
        _environment = environment;
        _iMapper = iMapper;
    }
    public async Task<List<GetStudentDto>> GetStudentLists()
    {
        var list = await _context.Students.Select(t => new GetStudentDto()
        {
            StudentID = t.StudentID,
            LastName = t.LastName,
            FirstMidName = t.FirstMidName,
            EnrollementDate = t.EnrollementDate,
            ImageName = t.ImageName
        }).ToListAsync();
        return list;
    }
    public async Task<GetStudentDto> GetById(int id)
    {
        var find = await _context.Students.FindAsync(id);
        var response = new GetStudentDto()
        {
            StudentID = find.StudentID,
            LastName = find.LastName,
            FirstMidName = find.FirstMidName,
            EnrollementDate = find.EnrollementDate,
            ImageName = find.ImageName
        };
        return response;
    }
    public async Task<GetStudentDto> AddStudent(AddStudentDto student)
    {
        // var response = new GetStudentDto()
        // {
        //     StudentID = student.StudentID,
        //     LastName = student.LastName,
        //     FirstMidName = student.FirstMidName,
        //     EnrollementDate = student.EnrollementDate,
        //     ImageName = student.Image.Name
        // };
        // var newStudent = new Student()
        // {
        //     StudentID = student.StudentID,
        //     LastName = student.LastName,
        //     FirstMidName = student.FirstMidName,
        //     EnrollementDate = student.EnrollementDate,
        //     ImageName = student.Image.Name
        // };
        var map = _iMapper.Map<Student>(student);
        _context.Students.Add(map);
        map.ImageName = await UploadFile(student.Image);
        await _context.SaveChangesAsync();
        return _iMapper.Map<GetStudentDto>(student);
    }

    public async Task<GetStudentDto> UpdateStudent(AddStudentDto student)
    {
        // var response = new GetStudentDto()
        // {
        //     StudentID = student.StudentID,
        //     LastName = student.LastName,
        //     FirstMidName = student.FirstMidName,
        //     EnrollementDate = student.EnrollementDate,
        //     ImageName = student.Image.Name
        // };
        var map = _iMapper.Map<GetStudentDto>(student);

        var find = await _context.Students.FindAsync(student.StudentID);
        find.LastName = student.LastName;
        find.FirstMidName = student.FirstMidName;
        find.EnrollementDate = student.EnrollementDate;
        find.ImageName = student.Image.Name;

        if (student.Image != null)
        {
            find.ImageName = await UpdateFile(student.Image, find.ImageName);
        }
        await _context.SaveChangesAsync();

        return map;
    }

    public async Task<string> UploadFile(IFormFile file)
    {
        if (file == null) return null;
        var path = Path.Combine(_environment.WebRootPath, "Student");
        if (Directory.Exists(path) == false) Directory.CreateDirectory(path);

        var filepath = Path.Combine(path, file.FileName);
        using (var stream = new FileStream(filepath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        return file.FileName;
    }

    public async Task<string> UpdateFile(IFormFile file, string oldFileName)
    {
        if (oldFileName != null)
        {
            var filepath = Path.Combine(_environment.WebRootPath, "Student", oldFileName);
            if (File.Exists(filepath) == true) File.Delete(filepath);
        }

        var newFilepath = Path.Combine(_environment.WebRootPath, "Student", file.FileName);
        using (var stream = new FileStream(newFilepath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }
        return file.FileName;
    }
    public async Task<int> DeleteStudent(int id)
    {
        var find = await _context.Students.FindAsync(id);
        _context.Remove(find);
        return await _context.SaveChangesAsync();
    }
}
