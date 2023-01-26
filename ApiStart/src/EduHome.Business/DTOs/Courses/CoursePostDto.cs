using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EduHome.Business.DTOs.Courses;

public class CoursePostDto
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public IFormFile? Image { get; set; }
}

public class HeaderDto
{
    [FromHeader(Name = "Content-Type")]
    public string? ContenType { get; set; }
    [FromHeader]
    public string? Connection { get; set; }

}
