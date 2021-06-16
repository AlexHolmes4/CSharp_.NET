using RestaurantDetails.BL;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantDetails.DL
{
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

        public Restaurant Add(Restaurant newRestaurant)
        {
            restaurants.Add(newRestaurant);
            newRestaurant.Id = restaurants.Max(r => r.Id) + 1;
            return newRestaurant;
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

        public Restaurant Delete(int id)
        {
            var restaurant = restaurants.FirstOrDefault(r => r.Id == id);
            if (restaurant != null)
            {
                restaurants.Remove(restaurant);
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
    }
}
