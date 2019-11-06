using System;
using System.Collections.Generic;

namespace Resturant.Models
{
    public partial class TableIns
    {
        public TableIns()
        {
            Guest = new HashSet<Guest>();
            WaiterTableIns = new HashSet<WaiterTableIns>();
        }

        public int TableId { get; set; }
        public string Addresse { get; set; }
        public int? Number { get; set; }

        public Restaurant AddresseNavigation { get; set; }
        public ICollection<Guest> Guest { get; set; }
        public ICollection<WaiterTableIns> WaiterTableIns { get; set; }
    }
}
