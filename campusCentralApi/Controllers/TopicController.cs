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
    public class TopicController : Controller
    {
        private readonly ITopicRepository _topicRepository;

        public TopicController(ITopicRepository topicRepository)
        {
            _topicRepository = topicRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Topic>>> GetTopics()
        {
            return Ok(await _topicRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var Topic = await _topicRepository.GetById(id);

            if (Topic == null)
            {
                Topic nullTopic = new Topic();
                return NotFound(nullTopic);
            }

            return Ok(Topic);
        }

        [HttpGet("name/{name}")]
        public async Task<ActionResult> GetByAproximatedName(string name)
        {
            var Topic = await _topicRepository.GetByAproximatedName(name);

            if (Topic == null)
            {
                Topic nullTopic = new Topic();
                return NotFound(nullTopic);
            }

            return Ok(Topic);
        }

        [HttpPost]
        public async Task<ActionResult> AddTopic(Topic Topic)
        {
            _topicRepository.Create(Topic);
            if(await _topicRepository.SaveAllAsync())
            {
                return Ok(Topic);
            }

            return BadRequest("Error at create a new student.");
        }

        [HttpPut]
        public async Task<ActionResult> UpdateTopic(Topic Topic)
        {
            _topicRepository.Edit(Topic);
            if(await _topicRepository.SaveAllAsync())
            {
                return Ok(Topic);
            }

            return BadRequest("Error in operation.");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTopic(int id)
        {
            var Topic = await _topicRepository.GetById(id);

            if(Topic == null)
            {
                return NotFound("Student not found.");
            }

            _topicRepository.Delete(Topic);

            if(await _topicRepository.SaveAllAsync())
            {
                return Ok(Topic);
            }

            return BadRequest("Error in operation.");
        }        
    }
}
