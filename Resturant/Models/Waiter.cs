using System;
using System.Collections.Generic;

namespace Resturant.Models
{
    public partial class Waiter
    {
        public Waiter()
        {
            WaiterTableIns = new HashSet<WaiterTableIns>();
        }

        public int WaiterId { get; set; }
        public int? Salary { get; set; }
        public int? PersonId { get; set; }

        public Person Person { get; set; }
        public ICollection<WaiterTableIns> WaiterTableIns { get; set; }
    }
}
