using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ResturantDetailsWebApp.BL;
using ResturantDetailsWebApp.DL;

namespace RestaurantsDetailsWebApp.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        private readonly IRestaurantData restaurantData;
        private readonly IHtmlHelper htmlhelper;

        [BindProperty] 
        public Restaurant Restaurant { get; set; }
        public IEnumerable<SelectListItem> Cuisines { get; set; }

        public EditModel(IRestaurantData restaurantData, IHtmlHelper htmlhelper)
        {
            this.restaurantData = restaurantData;
            this.htmlhelper = htmlhelper;
        }
        public IActionResult OnGet(int restaurantID)
        {
            Cuisines = htmlhelper.GetEnumSelectList<CuisineType>();
            Restaurant = restaurantData.GetById(restaurantID);
            return Restaurant == null ? RedirectToPage("./NotFound") : Page();
        }

        public IActionResult OnPost()
        {
            Cuisines = htmlhelper.GetEnumSelectList<CuisineType>();
            restaurantData.Update(Restaurant);
            restaurantData.Commit();
            return Page();
        }
    }
}
