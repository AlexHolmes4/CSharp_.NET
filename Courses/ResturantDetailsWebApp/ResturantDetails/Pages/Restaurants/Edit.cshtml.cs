using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ResturantDetails.BL;
using ResturantDetails.DL;

namespace RestaurantsDetails.Pages.Restaurants
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
        public IActionResult OnGet(int? restaurantId)
        {
            Cuisines = htmlhelper.GetEnumSelectList<CuisineType>();
            if (restaurantId.HasValue)
            {
                Restaurant = restaurantData.GetById(restaurantId.Value);
            }
            else
            {
                Restaurant = new Restaurant();
            }

            return Restaurant == null ? RedirectToPage("./NotFound") : Page();            
        }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                Cuisines = htmlhelper.GetEnumSelectList<CuisineType>();
                return Page();
            }

            if (Restaurant.Id > 0)
            {
                TempData["Message"] = "Restaurant Updated";
                restaurantData.Update(Restaurant);
            }
            else
            {
                TempData["Message"] = "New Restaurant Added";
                restaurantData.Add(Restaurant);
            }

            restaurantData.Commit();
            return RedirectToPage("./Detail", new { restaurantId = Restaurant.Id });
        }
    }
}
