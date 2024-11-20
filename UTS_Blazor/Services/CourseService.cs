using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using UTS_Blazor.Models;

namespace UTS_Blazor.Services
{
    public class CourseService
    {
        private readonly HttpClient _httpClient;

        public CourseService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<List<Course>> GetCoursesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Course>>("https://actualbackendapp.azurewebsites.net/api/Courses");
        }

        public async Task<Course> GetCourseByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Course>($"https://actualbackendapp.azurewebsites.net/api/Courses/{id}");
        }
        public async Task<List<Course>> GetCourseByNameAsync(string name)
        {
            return await _httpClient.GetFromJsonAsync<List<Course>>($"https://actualbackendapp.azurewebsites.net/api/Courses/search/{name}");
        }
        public async Task AddCourseAsync(Course course)
        {
            await _httpClient.PostAsJsonAsync("https://actualbackendapp.azurewebsites.net/api/Courses", course);
        }

        public async Task UpdateCourseAsync(Course course)
        {
            await _httpClient.PutAsJsonAsync($"https://actualbackendapp.azurewebsites.net/api/Courses/{course.courseId}", course);
        }

        public async Task DeleteCourseAsync(int id)
        {
            await _httpClient.DeleteAsync($"https://actualbackendapp.azurewebsites.net/api/Courses/{id}");
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            var response = await _httpClient.GetAsync("https://actualbackendapp.azurewebsites.net/api/v1/Categories"); // Replace with your actual API endpoint
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<List<Category>>();
        }
    }
}
