using System;
using System.Collections.Generic;

namespace Resturant
{
    public partial class GuestDish
    {
        public int GuestId { get; set; }
        public int DishId { get; set; }

        public Dish Dish { get; set; }
        public Guest Guest { get; set; }
    }
}
