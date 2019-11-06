using System;
using System.Collections.Generic;

namespace Resturant.Models
{
    public partial class WaiterTableIns
    {
        public int WaiterId { get; set; }
        public int TableId { get; set; }

        public TableIns Table { get; set; }
        public Waiter Waiter { get; set; }
    }
}
