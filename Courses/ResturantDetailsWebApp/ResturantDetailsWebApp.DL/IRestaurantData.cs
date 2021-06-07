using ResturantDetailsWebApp.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturantDetailsWebApp.DL
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
    }

    public class InMemoryResturantData : IRestaurantData
    {
        List<Restaurant> restaurants;
        public InMemoryResturantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant { Id = 1, Name = "Alex's Pizza", Location = "Kent", Cuisine=CuisineType.Italian },
                new Restaurant { Id = 2, Name = "Sarah's Palace SUCKS ", Location = "Perth", Cuisine=CuisineType.Indian },
                new Restaurant { Id = 3, Name = "Aaron's Taco Hut", Location = "St Georges Terrace", Cuisine=CuisineType.Mexican },
                new Restaurant { Id = 4, Name = "Chop Stick Quick", Location = "Como", Cuisine=CuisineType.Chinese }
            };

        }
        public IEnumerable<Restaurant> GetAll()
        {
            return from r in restaurants
                   orderby r.Name
                   select r;
        }
    }
}
