using System;
using System.Collections.Generic;

namespace Resturant.Models
{
    public partial class RestaurantDish
    {
        public string Addresse { get; set; }
        public int DishId { get; set; }

        public Restaurant AddresseNavigation { get; set; }
        public Dish Dish { get; set; }
    }
}
