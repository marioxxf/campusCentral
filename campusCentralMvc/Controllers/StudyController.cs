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
        List<ClassGroup> _oClassGroups = new List<ClassGroup>();

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
        public async Task<List<ClassGroup>> GetClassGroupAvailabilityByCourseId(int courseId)
        {
            _oClassGroups = new List<ClassGroup>();

            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = await httpClient.GetAsync("https://localhost:7200/api/ClassGroup/course/" + courseId + "?apiKey=secretKey"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _oClassGroups = JsonConvert.DeserializeObject<List<ClassGroup>>(apiResponse);
                }
            }
            return _oClassGroups;
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

        [HttpPost]
        public async Task<List<UserAccountCourseSchedule>> AddUserAccountCourseScheduleList(List<UserAccountCourseSchedule> userAccountCourseSchedules)
        {
            List<UserAccountCourseSchedule> _oUserAccountCourseSchedulesList = new List<UserAccountCourseSchedule>();

            using (var httpClient = new HttpClient(_clientHandler))
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(userAccountCourseSchedules), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync("https://localhost:7200/api/UserAccountCourseSchedule?apiKey=secretKey", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _oUserAccountCourseSchedulesList = JsonConvert.DeserializeObject<List<UserAccountCourseSchedule>>(apiResponse);
                }
            }

            return _oUserAccountCourseSchedulesList;
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