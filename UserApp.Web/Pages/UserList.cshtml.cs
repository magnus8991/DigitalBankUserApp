using Microsoft.AspNetCore.Mvc.RazorPages;
using UserApp.Models;

namespace UserApp.Web.Pages;

public class UserListModel : PageModel
{
    private readonly HttpClient _httpClient;

    public UserListModel(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient();
        _httpClient.BaseAddress = new Uri("http://localhost:5001/api/");
    }

    public IEnumerable<User> Users { get; set; } = Enumerable.Empty<User>();

    public async Task OnGet()
    {
        try
        {
            Users = await _httpClient.GetFromJsonAsync<IEnumerable<User>>("user") ?? [];
        }
        catch(Exception ex)
        {
            Console.WriteLine(ex);
            Users = [];
        }
    }
}