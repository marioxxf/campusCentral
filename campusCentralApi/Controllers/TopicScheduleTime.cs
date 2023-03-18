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
    public class TopicScheduleTimeController : Controller
    {
        private readonly ITopicScheduleTimeRepository _topicScheduleTimeRepository;

        public TopicScheduleTimeController(ITopicScheduleTimeRepository topicScheduleTimeRepository)
        {
            _topicScheduleTimeRepository = topicScheduleTimeRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TopicScheduleTime>>> GetTopicScheduleTimes()
        {
            return Ok(await _topicScheduleTimeRepository.GetAll());
        }

        [HttpGet("course/{id}")]
        public async Task<ActionResult<IEnumerable<TopicScheduleTime>>> GetTopicsByCourseId(int id)
        {
            var response = await _topicScheduleTimeRepository.GetTopicScheduleTimesByCourseId(id);
            if (!response.Any())
            {
                TopicScheduleTime nullListOfTopicsByCourseId = new TopicScheduleTime();
                return NotFound(nullListOfTopicsByCourseId);
            }
            return Ok(await _topicScheduleTimeRepository.GetTopicScheduleTimesByCourseId(id));
        }
    }
}
