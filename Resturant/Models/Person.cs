using System;
using System.Collections.Generic;

namespace Resturant.Models
{
    public partial class Person
    {
        public int PersonId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public Guest Guest { get; set; }
        public Waiter Waiter { get; set; }
    }
}
