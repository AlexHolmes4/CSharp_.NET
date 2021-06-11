using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ResturantDetailsWebApp.BL;
using ResturantDetailsWebApp.DL;

namespace RestaurantsDetailsWebApp.Pages.Restaurants
{
    public class DetailModel : PageModel
    {
        private readonly IRestaurantData restaurantData;

        public DetailModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }

        [TempData]
        public string Message { get; set; }
        public Restaurant Restaurant{ get; set; }
        public IActionResult OnGet(int restaurantId)
        {
            Restaurant = restaurantData.GetById(restaurantId);
            return Restaurant == null ? RedirectToPage("./NotFound") : Page();
        }


    }
}
