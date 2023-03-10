using EduHome.Business.DTOs.Courses;
using EduHome.Core.Entities;
using System.Linq.Expressions;

namespace EduHome.Business.Services.Interfaces;

public interface ICourseService
{
    Task<List<CourseDto>> FindAllAsync();
    Task<List<CourseDto>> FindByConditionAsync(Expression<Func<Course, bool>> expression);
    Task<CourseDto?> FindByIdAsync(int id);
    Task CreateAsync(CoursePostDto course);
    Task UpdateAsync(int id,CourseUpdateDto course);
    Task Delete(int id);

}
