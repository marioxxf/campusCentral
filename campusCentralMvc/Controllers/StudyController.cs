using campusCentralMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json.Serialization;

namespace campusCentralMvc.Controllers
{
    public class StudyController : Controller
    {
        public IActionResult Index()
        {
            HttpContext.Session.SetString("SessionKey", "Any"); // Isso trava a geração de um novo SessionID a cada requisição na mesma instância de navegador
            ViewData["SessionId"] = HttpContext.Session.Id;
            return View();
        }

        HttpClientHandler _clientHandler = new HttpClientHandler();
        List<Topic> _oTopics = new List<Topic>();
        List<TopicScheduleTime> _oTopicScheduleTimes = new List<TopicScheduleTime>();
        List<Course> _oCourses = new List<Course>();

        [HttpGet]
        public async Task<List<Topic>> GetAllTopics()
        {
            _oTopics = new List<Topic>();

            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = await httpClient.GetAsync("https://localhost:7200/api/Topic?apiKey=secretKey"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _oTopics = JsonConvert.DeserializeObject<List<Topic>>(apiResponse);
                }
            }
            return _oTopics;
        }

        [HttpGet]
        public async Task<List<TopicScheduleTime>> GetAllTopicScheduleTime()
        {
            _oTopicScheduleTimes = new List<TopicScheduleTime>();

            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = await httpClient.GetAsync("https://localhost:7200/api/TopicScheduleTime?apiKey=secretKey"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _oTopicScheduleTimes = JsonConvert.DeserializeObject<List<TopicScheduleTime>>(apiResponse);
                }
            }
            return _oTopicScheduleTimes;
        }

        [HttpGet]
        public async Task<List<TopicScheduleTime>> GetTopicScheduleTimesByCourseId(int courseId)
        {
            _oTopicScheduleTimes = new List<TopicScheduleTime>();

            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = await httpClient.GetAsync("https://localhost:7200/api/TopicScheduleTime/course/" + courseId + "?apiKey=secretKey"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _oTopicScheduleTimes = JsonConvert.DeserializeObject<List<TopicScheduleTime>>(apiResponse);
                }
            }
            return _oTopicScheduleTimes;
        }

        [HttpGet]
        public async Task<List<Topic>> GetTopicsByCourseId(int courseId)
        {
            _oTopics = new List<Topic>();

            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = await httpClient.GetAsync("https://localhost:7200/api/Topic/course/" + courseId + "?apiKey=secretKey"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _oTopics = JsonConvert.DeserializeObject<List<Topic>>(apiResponse);
                }
            }
            return _oTopics;
        }

        [HttpGet]
        public async Task<List<Topic>> GetTopicsByCourseIdAndBySemesterAvailability(int courseId, int semesterAvailability)
        {
            _oTopics = new List<Topic>();

            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = await httpClient.GetAsync("https://localhost:7200/api/Topic/course/" + courseId + "/semester/" + semesterAvailability + "?apiKey=secretKey"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _oTopics = JsonConvert.DeserializeObject<List<Topic>>(apiResponse);
                }
            }
            return _oTopics;
        }

        [HttpGet]
        public async Task<List<Course>> GetAllCourses()
        {
            _oCourses = new List<Course>();

            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = await httpClient.GetAsync("https://localhost:7200/api/Course?apiKey=secretKey"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _oCourses = JsonConvert.DeserializeObject<List<Course>>(apiResponse);
                }
            }
            return _oCourses;
        }
    }
}