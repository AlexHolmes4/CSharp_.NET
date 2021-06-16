using Microsoft.EntityFrameworkCore;
using RestaurantDetails.BL;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantDetails.DL
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly RestaurantDetailsDbContext db;

        public SqlRestaurantData(RestaurantDetailsDbContext db)
        {
            this.db = db;
        }

        public Restaurant Add(Restaurant newRestaurant)
        {
            db.Restaurants.Add(newRestaurant);
            return newRestaurant;
        }

        public Restaurant GetById(int id)
        {
            return db.Restaurants.Find(id);
        }

        public Restaurant Update(Restaurant updatedRestaurant)
        {
            //implementation detail comment - Attach method: 
            //when someone initiates process to update restaurant details the attach method is called
            //this tells the EF that when SaveChanges() is invoked to update the attached entity to the DB with all it's current changes
            var entity = db.Restaurants.Attach(updatedRestaurant);
            entity.State = EntityState.Modified;
            return updatedRestaurant;
        }

        public Restaurant Delete(int id)
        {
            var restaurant = GetById(id);
            if (restaurant != null)
            {
                db.Restaurants.Remove(restaurant);
            }
            return restaurant;
        }

        public int Commit()
        {
            return db.SaveChanges(); //returns number of rows affected
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
        {
            var query = from r in db.Restaurants
                        where r.Name.StartsWith(name) || string.IsNullOrEmpty(name)
                        orderby r.Name
                        select r;
            return query;
        }

        public int GetCountOfRestaurants()
        {
            return db.Restaurants.Count();
        }
    }
}
