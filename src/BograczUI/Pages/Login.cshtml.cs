using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http.Headers;
using System.Text.Json;

public class LoginModel : PageModel
{
    [BindProperty]
    public string Username { get; set; } = string.Empty;
    [BindProperty]
    public string Password { get; set; } = string.Empty;

    private readonly IHttpClientFactory _clientFactory;
    public LoginModel(IHttpClientFactory clientFactory)
    {
        _clientFactory = clientFactory;
    }

    public void OnGet() {}

    public async Task<IActionResult> OnPostAsync()
    {
        var client = _clientFactory.CreateClient();
        var response = await client.PostAsJsonAsync("/api/auth/login", new { Username, Password });
        if (response.IsSuccessStatusCode)
        {
            var token = await response.Content.ReadAsStringAsync();
            Response.Cookies.Append("jwt", token);
            return RedirectToPage("Index");
        }
        ModelState.AddModelError(string.Empty, "Invalid login");
        return Page();
    }
}
