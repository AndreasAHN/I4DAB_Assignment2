using System;
using System.Collections.Generic;

namespace Resturant.Models
{
    public partial class Dish
    {
        public Dish()
        {
            GuestDish = new HashSet<GuestDish>();
            RestaurantDish = new HashSet<RestaurantDish>();
            Review = new HashSet<Review>();
        }

        public int DishId { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        public ICollection<GuestDish> GuestDish { get; set; }
        public ICollection<RestaurantDish> RestaurantDish { get; set; }
        public ICollection<Review> Review { get; set; }
    }
}
