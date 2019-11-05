using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Resturant
{
    class ReadSQL
    {
        public ReadSQL()
        {

        }

        public void ReadResturant()
        {
            using(var db = new I4DAB_HandIn2Context())
            {
                db.Restaurant.ToList();
            }

            //var resturants = await db.Restaurant.ToListAsync();
            
           

            return resturants;
        }

        public void ReadReview()
        {
            Review review = new Review();
        }

        public void ReadDish()
        {
            Dish dish = new Dish();

        }

        public void ReadGuest()
        {
            Guest guest = new Guest();
        }

        public void ReadPerson()
        {
            Person person = new Person();
        }

        public void ReadWaiter()
        {
            Waiter waiter = new Waiter();
        }

        public void ReadTable()
        {
            TableIns tableIns = new TableIns();
        }

        public void ReadWaiterTablelns()
        {
            WaiterTableIns waiterTableIns = new WaiterTableIns();
        }
    }
}
