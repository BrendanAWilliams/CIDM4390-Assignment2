using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Food2URazor.Data;
using Food2URazor.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Food2URazor.Pages.Application;

public class BrowseRestaurantsModel : PageModel
{
    private readonly Food2URazor.Data.Food2URazorContext _context;

    public BrowseRestaurantsModel(Food2URazor.Data.Food2URazorContext context)
    {
        _context = context;
    }

    public IList<Restaurant> Restaurants { get; set; }
    

    public async Task OnGetAsync()
    {
        Restaurants = await _context.Restaurants.ToListAsync();
    }
}