using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserApp.Models;

namespace UserApp.Web.Pages
{
    public class UserListModel : PageModel
    {
        private readonly HttpClient _http;

        public UserListModel(IHttpClientFactory httpClientFactory)
        {
            _http = httpClientFactory.CreateClient();
            _http.BaseAddress = new Uri("http://localhost:5001/api/"); // Ajusta si usas otro puerto/API URL
        }

        public List<User> Users { get; set; } = new();

        public async Task OnGetAsync()
        {
            var result = await _http.GetFromJsonAsync<List<User>>("user");
            if (result != null)
                Users = result;
        }

        public async Task<IActionResult> OnGetDeleteAsync(int id)
        {
            var response = await _http.DeleteAsync($"user/{id}");
            if (response.IsSuccessStatusCode)
            {
                TempData["Message"] = "User deleted successfully.";
            }
            return RedirectToPage();
        }
    }
}