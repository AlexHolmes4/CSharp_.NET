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
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        Restaurant GetById(int id);
        Restaurant Update(Restaurant updatedRestaurant);
        int Commit();
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

        public Restaurant GetById(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);
            if (restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cuisine = updatedRestaurant.Cuisine;
            }
            return restaurant;
        }

        public int Commit()
        {
            return 0;
        }
         
        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }

        public void UpdateRestaurant(int id)
        {
            
        }
    }
}
