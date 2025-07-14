using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using UserApp.Models;

namespace UserApp.Web.Pages;

public class UserModel : PageModel
{
    private readonly HttpClient _httpClient;

    public UserModel(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient();
        _httpClient.BaseAddress = new Uri("http://localhost:5001/api/");
    }

    [BindProperty]
    public new User User { get; set; } = new User();

    public string? Message { get; set; }

    public void OnGet() { }

    public async Task<IActionResult> OnPostAsync()
    {
        var response = await _httpClient.PostAsJsonAsync("user", User);
        if (response.IsSuccessStatusCode)
        {
            Message = "User created successfully.";
            return RedirectToPage("UserList");
        }
        Message = "Error creating user.";
        return Page();
    }
}