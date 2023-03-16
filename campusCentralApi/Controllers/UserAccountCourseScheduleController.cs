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
    public class UserAccountCourseScheduleController : Controller
    {
        private readonly IUserAccountCourseScheduleRepository _userAccountCourseScheduleRepository;

        public UserAccountCourseScheduleController(IUserAccountCourseScheduleRepository userAccountCourseScheduleRepository)
        {
            _userAccountCourseScheduleRepository = userAccountCourseScheduleRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserAccountCourseSchedule>>> GetUserAccountCourseSchedules()
        {
            return Ok(await _userAccountCourseScheduleRepository.GetAll());
        }

        [HttpGet("user/{id}")]
        public async Task<ActionResult<IEnumerable<UserAccountCourseSchedule>>> GetUserAccountCourseSchedulesByUserAccountId(int id)
        {
            var response = await _userAccountCourseScheduleRepository.GetAllByUserAccountId(id);
            if (!response.Any())
            {
                List<UserAccountCourseSchedule> nullUserAccountCourseSchedule = new List<UserAccountCourseSchedule>();
                return NotFound(nullUserAccountCourseSchedule);
            }
            return Ok(await _userAccountCourseScheduleRepository.GetAllByUserAccountId(id));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var UserAccountCourseSchedule = await _userAccountCourseScheduleRepository.GetById(id);

            if (UserAccountCourseSchedule == null)
            {
                UserAccountCourseSchedule nullUserAccountCourseSchedule = new UserAccountCourseSchedule();
                return NotFound(nullUserAccountCourseSchedule);
            }

            return Ok(UserAccountCourseSchedule);
        }

        [HttpPost]
        public async Task<ActionResult> AddUserAccountCourseSchedule(UserAccountCourseSchedule UserAccountCourseSchedule)
        {
            _userAccountCourseScheduleRepository.Create(UserAccountCourseSchedule);
            if(await _userAccountCourseScheduleRepository.SaveAllAsync())
            {
                return Ok(UserAccountCourseSchedule);
            }

            return BadRequest("Error at create a new student.");
        }

        [HttpPut]
        public async Task<ActionResult> UpdateUserAccountCourseSchedule(UserAccountCourseSchedule UserAccountCourseSchedule)
        {
            _userAccountCourseScheduleRepository.Edit(UserAccountCourseSchedule);
            if(await _userAccountCourseScheduleRepository.SaveAllAsync())
            {
                return Ok(UserAccountCourseSchedule);
            }

            return BadRequest("Error in operation.");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUserAccountCourseSchedule(int id)
        {
            var UserAccountCourseSchedule = await _userAccountCourseScheduleRepository.GetById(id);

            if(UserAccountCourseSchedule == null)
            {
                return NotFound("Student not found.");
            }

            _userAccountCourseScheduleRepository.Delete(UserAccountCourseSchedule);

            if(await _userAccountCourseScheduleRepository.SaveAllAsync())
            {
                return Ok(UserAccountCourseSchedule);
            }

            return BadRequest("Error in operation.");
        }        
    }
}
