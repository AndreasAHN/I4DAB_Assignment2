using System;
using System.Collections.Generic;

namespace Resturant.Models
{
    public partial class Guest
    {
        public Guest()
        {
            GuestDish = new HashSet<GuestDish>();
        }

        public int GuestId { get; set; }
        public DateTime Reservation { get; set; }
        public int TableId { get; set; }
        public int ReviewId { get; set; }
        public int? FkPersonId { get; set; }

        public Person FkPerson { get; set; }
        public Review Review { get; set; }
        public TableIns Table { get; set; }
        public ICollection<GuestDish> GuestDish { get; set; }
    }
}
