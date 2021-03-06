using RestaurantDetails.BL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantDetails.DL
{
    public interface IRestaurantData
    {
        Restaurant Add(Restaurant newRestaurant);
        Restaurant GetById(int id);
        Restaurant Update(Restaurant updatedRestaurant);
        Restaurant Delete(int id);
        int Commit();
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        int GetCountOfRestaurants();
    }
}
