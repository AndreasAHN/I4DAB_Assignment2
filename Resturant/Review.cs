﻿using System;
using System.Collections.Generic;

namespace Resturant
{
    public partial class Review
    {
        public Review()
        {
            Dish = new HashSet<Dish>();
            Guest = new HashSet<Guest>();
        }

        public int ReviewId { get; set; }
        public int? Stars { get; set; }
        public string Addresse { get; set; }
        public string Text { get; set; }

        public Restaurant AddresseNavigation { get; set; }
        public ICollection<Dish> Dish { get; set; }
        public ICollection<Guest> Guest { get; set; }
    }
}
