using Microsoft.EntityFrameworkCore;
using ResturantDetails.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResturantDetails.DL
{
    public class RestaurantDetailsDbContext : DbContext
    {
        public RestaurantDetailsDbContext(DbContextOptions<RestaurantDetailsDbContext> options) : base(options)
        {
        }
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
