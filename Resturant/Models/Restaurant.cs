using System;
using System.Collections.Generic;

namespace Resturant.Models
{
    public partial class Restaurant
    {
        public Restaurant()
        {
            RestaurantDish = new HashSet<RestaurantDish>();
            Review = new HashSet<Review>();
            TableIns = new HashSet<TableIns>();
        }

        public string Address { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        public ICollection<RestaurantDish> RestaurantDish { get; set; }
        public ICollection<Review> Review { get; set; }
        public ICollection<TableIns> TableIns { get; set; }
    }
}
