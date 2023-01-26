using AutoMapper;
using EduHome.Business.DTOs.Courses;
using EduHome.Business.Exceptions;
using EduHome.Business.HelperServices.Interfaces;
using EduHome.Business.Services.Interfaces;
using EduHome.Core.Entities;
using EduHome.DataAccess.Repositories.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EduHome.Business.Services.Implementations;

public class CourseService : ICourseService
{
    private readonly ICourseRepository _courseRepository;
    private readonly IMapper _mapper;
    private readonly IWebHostEnvironment _env;
    private readonly IFileService _fileService;

    public CourseService(ICourseRepository courseRepository,
                         IMapper mapper,
                         IWebHostEnvironment env,
                         IFileService fileService)
    {
        _courseRepository = courseRepository;
        _mapper = mapper;
        _env = env;
        _fileService = fileService;
    }
    public async Task<List<CourseDto>> FindAllAsync()
    {
        var courses = await _courseRepository.FindAll().ToListAsync();
        var result = _mapper.Map<List<CourseDto>>(courses);
        return result;
    }

    public async Task<List<CourseDto>> FindByConditionAsync(Expression<Func<Course, bool>> expression)
    {
        var courses = await _courseRepository.FindByCondition(expression).ToListAsync();
        var result = _mapper.Map<List<CourseDto>>(courses);
        return result;
    }

    public async Task<CourseDto?> FindByIdAsync(int id)
    {
        var course = await _courseRepository.FindByIdAsync(id);
        if (course == null)
        {
            throw new NotFoundException("Not found");
        }
        return _mapper.Map<CourseDto?>(course);
    }

    public async Task CreateAsync(CoursePostDto course)
    {
     
        if (course is null) throw new ArgumentNullException(nameof(course));
        string fileName = await _fileService.CopyFileAsync(course.Image,_env.WebRootPath,"assets");

        Course newCourse = new()
        {
            Name = course.Name,
            Description = course.Description,
            Image = fileName
        };


        //var newCourse = _mapper.Map<Course>(course);
        await _courseRepository.CreateAsync(newCourse);
        await _courseRepository.SaveAsync();
    }

    public async Task Delete(int id)
    {
        var baseCourse = await _courseRepository.FindByIdAsync(id);
        if (baseCourse is null)
        {

            throw new NotFoundException("Not found.");
        }
        _courseRepository.Delete(baseCourse);
        await _courseRepository.SaveAsync();
    }

    public async Task UpdateAsync(int id, CourseUpdateDto course)
    {
        if (id != course.Id)
        {
            throw new BadRequestException("Enter valid ID.");
        }

        var baseCourse = _courseRepository.FindByCondition(c => c.Id == id);
        if (baseCourse is null)
        {

            throw new NotFoundException("Not found.");
        }

        var updateCourse = _mapper.Map<Course>(course);
        _courseRepository.Update(updateCourse);
        await _courseRepository.SaveAsync();
    }
}
