using System;
using System.Collections.Generic;

namespace Resturant
{
    public partial class Dish
    {
        public Dish()
        {
            GuestDish = new HashSet<GuestDish>();
            RestaurantDish = new HashSet<RestaurantDish>();
        }

        public int DishId { get; set; }
        public int ReviewId { get; set; }
        public double Price { get; set; }
        public string Type { get; set; }

        public Review Review { get; set; }
        public ICollection<GuestDish> GuestDish { get; set; }
        public ICollection<RestaurantDish> RestaurantDish { get; set; }
    }
}
