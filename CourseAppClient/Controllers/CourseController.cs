using CourseAppClient.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json.Serialization;
using CourseApp.Models.Course;

namespace CourseAppClient.Controllers
{
    public class CourseController : Controller
    {
       public async Task<ActionResult> GetAllCourses()
        {
            List<GetCourses> allCourses = new List<GetCourses>();
            using(var httpClient = new HttpClient())
            {
                using (var response  = await httpClient.GetAsync("https://localhost:7184/api/Course"))
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    allCourses = JsonConvert.DeserializeObject<List<GetCourses>>(data);
                   


                }
                return View(allCourses);
            }
        }

        public async Task<ActionResult> GetCourseById(int id)
        {
            GetCourseById course = new GetCourseById();
            using(var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:7184/api/Course/" + id))
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    course = JsonConvert.DeserializeObject<GetCourseById>(data);
                }
                return View(course);
            }
        }


        [HttpGet]
        public async Task<ActionResult> AddCourses()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddCourses(AddCourseDto addCourseDto)
        {
            AddCourseDto add = new AddCourseDto();
            using ( var httpClient = new HttpClient()) { 
            StringContent content = new StringContent(JsonConvert.SerializeObject(addCourseDto),Encoding.UTF8,"application/json");
                using (var response = await httpClient.PostAsync("https://localhost:7184/api/Course",content))
                {
                    string data = response.Content.ReadAsStringAsync().Result;
                    add = JsonConvert.DeserializeObject<AddCourseDto>(data);
                }
                return View(add);
            }
        }
    }
}
