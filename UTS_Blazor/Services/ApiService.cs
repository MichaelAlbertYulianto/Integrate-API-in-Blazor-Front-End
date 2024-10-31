using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using UTS_Blazor.Models;
namespace UTS_Blazor.Services
{

    public class ApiService
    {
        private readonly HttpClient _httpClient;

        public ApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Category>>("https://actualbackendapp.azurewebsites.net/api/v1/Categories");
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Category>($"https://actualbackendapp.azurewebsites.net/api/v1/Categories/{id}");
        }

        public async Task<List<Course>> GetCoursesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Course>>("https://actualbackendapp.azurewebsites.net/api/Courses");
        }

        public async Task<Course> GetCourseByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Course>($"https://actualbackendapp.azurewebsites.net/api/Courses/{id}");
        }

        public async Task CreateCategoryAsync(Category category)
        {
            await _httpClient.PostAsJsonAsync("https://actualbackendapp.azurewebsites.net/api/v1/Categories", category);
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            await _httpClient.PutAsJsonAsync($"https://actualbackendapp.azurewebsites.net/api/v1/Categories/{category.CategoryId}", category);
        }

        public async Task DeleteCategoryAsync(int id)
        {
            await _httpClient.DeleteAsync($"https://actualbackendapp.azurewebsites.net/api/v1/Categories/{id}");
        }

        // Similarly, you can add methods for Course CRUD operations.
    }
}
