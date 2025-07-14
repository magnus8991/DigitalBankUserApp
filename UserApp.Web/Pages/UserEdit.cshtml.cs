using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using UserApp.Models;

namespace UserApp.Web.Pages
{
    public class UserEditModel : PageModel
    {
        private readonly HttpClient _http;

        public UserEditModel(IHttpClientFactory factory)
        {
            _http = factory.CreateClient();
            _http.BaseAddress = new Uri("http://localhost:5001/api/");
        }

        [BindProperty]
        public User User { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var user = await _http.GetFromJsonAsync<User>($"user/{id}");
            if (user == null) return NotFound();
            User = user;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var response = await _http.PutAsJsonAsync($"user/{User.Id}", User);
            if (!response.IsSuccessStatusCode) return BadRequest();
            return RedirectToPage("/Index");
        }
    }
}