using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Resturant
{
    class SelectAllSQL
    {
        public SelectAllSQL()
        {

        }

        public List<Restaurant> ReadResturant()
        {
            using(var db = new I4DAB_HandIn2Context())
            {
                var resturants = db.Restaurant.ToList();

                return resturants;
            }
        }

        public List<Review> ReadReview()
        {
            using (var db = new I4DAB_HandIn2Context())
            {
                var review = db.Review.ToList();

                return review;
            }
        }

        public List<Dish> ReadDish()
        {
            using (var db = new I4DAB_HandIn2Context())
            {
                var dish = db.Dish.ToList();

                return dish;
            }
        }

        public List<Guest> ReadGuest()
        {
            using (var db = new I4DAB_HandIn2Context())
            {
                var guest = db.Guest.ToList();

                return guest;
            }
        }

        public List<Person> ReadPerson()
        {
            using (var db = new I4DAB_HandIn2Context())
            {
                var person = db.Person.ToList();

                return person;
            }
        }

        public List<Waiter> ReadWaiter()
        {
            using (var db = new I4DAB_HandIn2Context())
            {
                var waiter = db.Waiter.ToList();

                return waiter;
            }
        }

        public List<TableIns> ReadTable()
        {
            using (var db = new I4DAB_HandIn2Context())
            {
                var tableIns = db.TableIns.ToList();

                return tableIns;
            }
        }

        public List<WaiterTableIns> ReadWaiterTablelns()
        {
            using (var db = new I4DAB_HandIn2Context())
            {
                var waiterTableIns = db.WaiterTableIns.ToList();

                return waiterTableIns;
            }
        }
    }
}
