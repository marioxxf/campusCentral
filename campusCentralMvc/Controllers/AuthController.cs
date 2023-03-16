using campusCentralMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json.Serialization;

namespace campusCentralMvc.Controllers
{
    public class AuthController : Controller
    {
        HttpClientHandler _clientHandler = new HttpClientHandler();
        UserAccount _oUserAccount = new UserAccount();
        List<UserAccountCourseSchedule> _oUserAccountCourseSchedules = new List<UserAccountCourseSchedule>();
        List<UserAccount> _oUserAccounts = new List<UserAccount>();
        public IActionResult NewAccount()
        {
            HttpContext.Session.SetString("SessionKey", "Any"); // Isso trava a geração de um novo SessionID a cada requisição na mesma instância de navegador
            ViewData["SessionId"] = HttpContext.Session.Id;
            return View();
        }

        public IActionResult MyAccount()
        {
            HttpContext.Session.SetString("SessionKey", "Any"); // Isso trava a geração de um novo SessionID a cada requisição na mesma instância de navegador
            ViewData["SessionId"] = HttpContext.Session.Id;
            return View();
        }

        public IActionResult MyCourseSchedule()
        {
            HttpContext.Session.SetString("SessionKey", "Any"); // Isso trava a geração de um novo SessionID a cada requisição na mesma instância de navegador
            ViewData["SessionId"] = HttpContext.Session.Id;
            return View();
        }

        [HttpGet]
        public async Task<UserAccount> GetById(int userAccountId)
        {
            _oUserAccount = new UserAccount();

            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = await httpClient.GetAsync("https://localhost:7200/api/UserAccount/" + userAccountId + "?apiKey=secretKey"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _oUserAccount = JsonConvert.DeserializeObject<UserAccount>(apiResponse);
                }
            }
            return _oUserAccount;
        }

        [HttpGet]
        public async Task<List<UserAccountCourseSchedule>> GetUserAccountCourseScheduleByUserAccountId(int userAccountId)
        {
            _oUserAccountCourseSchedules = new List<UserAccountCourseSchedule>();

            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = await httpClient.GetAsync("https://localhost:7200/api/UserAccountCourseSchedule/user/" + userAccountId + "?apiKey=secretKey"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _oUserAccountCourseSchedules = JsonConvert.DeserializeObject<List<UserAccountCourseSchedule>>(apiResponse);
                }
            }
            return _oUserAccountCourseSchedules;
        }

        [HttpGet]
        public async Task<UserAccount> GetByEmail(string emailToFind)
        {
            _oUserAccount = new UserAccount();

            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = await httpClient.GetAsync("https://localhost:7200/api/UserAccount/email/" + emailToFind + "?apiKey=secretKey"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _oUserAccount = JsonConvert.DeserializeObject<UserAccount>(apiResponse);
                }
            }
            return _oUserAccount;
        }

        [HttpGet]
        public async Task<UserAccount> GetByUsername(string nameToFind)
        {
            _oUserAccount = new UserAccount();

            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = await httpClient.GetAsync("https://localhost:7200/api/UserAccount/username/" + nameToFind + "?apiKey=secretKey"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _oUserAccount = JsonConvert.DeserializeObject<UserAccount>(apiResponse);
                }
            }
            return _oUserAccount;
        }

        [HttpGet]
        public async Task<List<UserAccount>> GetAllUserAccounts()
        {
            _oUserAccounts = new List<UserAccount>();

            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = await httpClient.GetAsync("https://localhost:7200/api/UserAccount?apiKey=secretKey"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _oUserAccounts = JsonConvert.DeserializeObject<List<UserAccount>>(apiResponse);
                }
            }
            return _oUserAccounts;
        }

        [HttpGet]
        public async Task<UserAccount> GetByPassAndEmail(string passToFind, string emailToFind)
        {
            _oUserAccount = new UserAccount();

            using (var httpClient = new HttpClient(_clientHandler))
            {
                using (var response = await httpClient.GetAsync("https://localhost:7200/api/UserAccount/pass/" + passToFind + "/" + emailToFind + "?apiKey=secretKey"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _oUserAccount = JsonConvert.DeserializeObject<UserAccount>(apiResponse);
                    if(_oUserAccount.UserAccountId > 0)
                    {
                        HttpContext.Session.SetString("UserAccountIdLogged", _oUserAccount.UserAccountId.ToString());
                        HttpContext.Session.SetString("UserAccountUsernameLogged", _oUserAccount.Username);
                        HttpContext.Session.SetString("UserAccountNameLogged", _oUserAccount.Name);
                    }
                }
            }
            return _oUserAccount;
        }

        [HttpPost]
        public async Task<UserAccount> AddUserAccount(UserAccount userAccount)
        {
            _oUserAccount = new UserAccount();

            using (var httpClient = new HttpClient(_clientHandler))
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(userAccount), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync("https://localhost:7200/api/UserAccount?apiKey=secretKey", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    _oUserAccount = JsonConvert.DeserializeObject<UserAccount>(apiResponse);
                }
            }
            HttpContext.Session.SetString("UserAccountIdLogged", _oUserAccount.UserAccountId.ToString());
            HttpContext.Session.SetString("UserAccountUsernameLogged", _oUserAccount.Username);
            HttpContext.Session.SetString("UserAccountNameLogged", _oUserAccount.Name);

            return _oUserAccount;
        }

        [HttpPost]
        public IActionResult DisconnectUserAccountLogged()
        {
            HttpContext.Session.SetString("UserAccountIdLogged", "");
            HttpContext.Session.SetString("UserAccountUsernameLogged", "");
            HttpContext.Session.SetString("UserAccountNameLogged", "");
            return Json(new { success = true });
        }
    }
}