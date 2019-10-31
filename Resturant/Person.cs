using System;
using System.Collections.Generic;

namespace Resturant
{
    public partial class Person
    {
        public int PersonId { get; set; }
        public string Name { get; set; }

        public Guest Guest { get; set; }
        public Waiter Waiter { get; set; }
    }
}
