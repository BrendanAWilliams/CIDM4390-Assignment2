using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace Food2URazor.Pages.Login;

public class LoginModel : PageModel
{
    [BindProperty, Required]
    public Credential Credential { get; set; } = default!;

    private readonly Food2URazor.Data.Food2URazorContext _context;
    public LoginModel(Food2URazor.Data.Food2URazorContext context)
    {
        _context = context;
    }

    // private readonly ILogger<LoginModel> _logger;
    // public LoginModel(ILogger<LoginModel> logger)
    // {
    //     _logger = logger;
    // }

    public void OnGet()
    {

    }
    public IActionResult OnPost()       //Searches Shoppers for matching username and password
    {
        IQueryable<string> loginQuery = from s in _context.Shoppers
                                        where s.Username == Credential.Username
                                        select s.Password;

        if(loginQuery.Count() >= 1)     //If query returns anything, check password
        {
            string pass = loginQuery.First();

            if(pass == Credential.Password)
            {
                return RedirectToPage("/Application/AppIndex");
            }
            return RedirectToPage("/Login/Failed");
        }

        else
        {
            return RedirectToPage("/Login/Failed");
        }
    }
}

public class Credential
{
    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }
}