using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
using UTS_Blazor.Models;

namespace UTS_Blazor.Services
{
    public class CategoryService
    {
        private readonly HttpClient _httpClient;

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("https://actualbackendapp.azurewebsites.net/api/v1/Categories");

                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<List<Category>>() ?? new List<Category>();
                }
                else
                {
                    // Handle the error response (logging, throwing an exception, etc.)
                    // You can log the error message or throw a custom exception
                    throw new HttpRequestException($"Error fetching categories: {response.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                // Log the exception or handle it accordingly
                Console.Error.WriteLine(ex.Message);
                return new List<Category>(); // Return an empty list on error
            }
        }


        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            // Updated URL for getting a category by ID
            return await _httpClient.GetFromJsonAsync<Category>($"https://actualbackendapp.azurewebsites.net/api/v1/Categories/{id}");
        }

        public async Task AddCategoryAsync(Category category)
        {
            // URL for posting a new category
            await _httpClient.PostAsJsonAsync("https://actualbackendapp.azurewebsites.net/api/v1/Categories", category);
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            // URL for updating a category
            await _httpClient.PutAsJsonAsync($"https://actualbackendapp.azurewebsites.net/api/v1/Categories/{category.CategoryId}", category);
        }

        public async Task DeleteCategoryAsync(int id)
        {
            // URL for deleting a category
            var response = await _httpClient.DeleteAsync($"https://actualbackendapp.azurewebsites.net/api/v1/Categories/{id}");

            if (!response.IsSuccessStatusCode)
            {
                // Optionally handle the error, e.g., throw an exception or log the error
                throw new Exception("Error deleting category");
            }
        }

    }
}
