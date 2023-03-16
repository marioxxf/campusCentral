using campusCentralApi.Interfaces;
using campusCentralApi.Models;
using campusCentralApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor.Compilation;
using Microsoft.AspNetCore.Razor.Hosting;

namespace campusCentralApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : Controller
    {
        private readonly ICourseRepository _courseRepository;

        public CourseController(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourses()
        {
            return Ok(await _courseRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var Course = await _courseRepository.GetById(id);

            if (Course == null)
            {
                Course nullCourse = new Course();
                return NotFound(nullCourse);
            }

            return Ok(Course);
        }

        [HttpGet("name/{name}")]
        public async Task<ActionResult> GetByAproximatedName(string name)
        {
            var Course = await _courseRepository.GetByAproximatedName(name);

            if (Course == null)
            {
                Course nullCourse = new Course();
                return NotFound(nullCourse);
            }

            return Ok(Course);
        }

        [HttpPost]
        public async Task<ActionResult> AddCourse(Course Course)
        {
            _courseRepository.Create(Course);
            if(await _courseRepository.SaveAllAsync())
            {
                return Ok(Course);
            }

            return BadRequest("Error at create a new student.");
        }

        [HttpPut]
        public async Task<ActionResult> UpdateCourse(Course Course)
        {
            _courseRepository.Edit(Course);
            if(await _courseRepository.SaveAllAsync())
            {
                return Ok(Course);
            }

            return BadRequest("Error in operation.");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCourse(int id)
        {
            var Course = await _courseRepository.GetById(id);

            if(Course == null)
            {
                return NotFound("Student not found.");
            }

            _courseRepository.Delete(Course);

            if(await _courseRepository.SaveAllAsync())
            {
                return Ok(Course);
            }

            return BadRequest("Error in operation.");
        }        
    }
}
