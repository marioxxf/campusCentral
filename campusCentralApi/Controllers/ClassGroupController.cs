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
    public class ClassGroupController : Controller
    {
        private readonly IClassGroupRepository _classGroupRepository;

        public ClassGroupController(IClassGroupRepository classGroupRepository)
        {
            _classGroupRepository = classGroupRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ClassGroup>>> GetClassGroups()
        {
            return Ok(await _classGroupRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var ClassGroup = await _classGroupRepository.GetById(id);

            if (ClassGroup == null)
            {
                ClassGroup nullClassGroup = new ClassGroup();
                return NotFound(nullClassGroup);
            }

            return Ok(ClassGroup);
        }
        [HttpGet("course/{id}")]
        public async Task<ActionResult<IEnumerable<ClassGroup>>> GetByCourseIdAndAvailabilityByCourse(int id)
        {
            var response = await _classGroupRepository.GetByCourseIdAndAvailabilityByCourse(id);
            if (!response.Any())
            {
                ClassGroup nullListOfTopicsByCourseId = new ClassGroup();
                return NotFound(nullListOfTopicsByCourseId);
            }
            return Ok(await _classGroupRepository.GetByCourseIdAndAvailabilityByCourse(id));
        }

        [HttpPost]
        public async Task<ActionResult> AddClassGroup(ClassGroup ClassGroup)
        {
            _classGroupRepository.Create(ClassGroup);
            if(await _classGroupRepository.SaveAllAsync())
            {
                return Ok(ClassGroup);
            }

            return BadRequest("Error at create a new student.");
        }

        [HttpPut]
        public async Task<ActionResult> UpdateClassGroup(ClassGroup ClassGroup)
        {
            _classGroupRepository.Edit(ClassGroup);
            if(await _classGroupRepository.SaveAllAsync())
            {
                return Ok(ClassGroup);
            }

            return BadRequest("Error in operation.");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteClassGroup(int id)
        {
            var ClassGroup = await _classGroupRepository.GetById(id);

            if(ClassGroup == null)
            {
                return NotFound("Student not found.");
            }

            _classGroupRepository.Delete(ClassGroup);

            if(await _classGroupRepository.SaveAllAsync())
            {
                return Ok(ClassGroup);
            }

            return BadRequest("Error in operation.");
        }        
    }
}
