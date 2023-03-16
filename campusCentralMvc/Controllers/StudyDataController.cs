using campusCentralMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json.Serialization;

namespace campusCentralMvc.Controllers
{
    public class StudyDataController : Controller
    {
        HttpClientHandler _clientHandler = new HttpClientHandler();
        List<Topic> _oTopics = new List<Topic>();

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
    }
}