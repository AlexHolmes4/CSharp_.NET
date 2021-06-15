using ResturantDetails.BL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ResturantDetails.DL
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        Restaurant Add(Restaurant newRestaurant);
        Restaurant GetById(int id);
        Restaurant Update(Restaurant updatedRestaurant);
        Restaurant Delete(int id);
        int Commit();
    }
}
