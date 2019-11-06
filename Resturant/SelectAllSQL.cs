using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Resturant.Models;

namespace Resturant
{
    class SelectAllSQL
    {
        public SelectAllSQL()
        {

        }

        public List<Restaurant> SelectAllResturant()
        {
            using(var db = new I4DAB_HandIn2Context())
            {
                var resturants = db.Restaurant.ToList();
                foreach (var rest in resturants)
                {
                    Console.WriteLine(rest.Name);
                    Console.WriteLine("Type: "+rest.Type);
                    Console.WriteLine("Addresse: "+rest.Address);
                    Console.WriteLine();
                }
                return resturants.ToList();
            }
        }

        public List<Review> SelectAllReview()
        {
            using (var db = new I4DAB_HandIn2Context())
            {
                var review = db.Review.ToList();

                return review;
            }
        }

        public List<Dish> SelectAllDish()
        {
            using (var db = new I4DAB_HandIn2Context())
            {
                var dish = db.Dish.ToList();

                return dish.ToList();
            }
        }

        public List<Guest> SelectAllGuest()
        {
            using (var db = new I4DAB_HandIn2Context())
            {
                var guest = db.Guest.ToList();

                return guest.ToList();
            }
        }

        public List<Person> SelectAllPerson()
        {
            using (var db = new I4DAB_HandIn2Context())
            {
                var person = db.Person.ToList();

                return person.ToList();
            }
        }

        public List<Waiter> ReadWaiter()
        {
            using (var db = new I4DAB_HandIn2Context())
            {
                var waiter = db.Waiter.ToList();

                return waiter.ToList();
            }
        }

        public List<TableIns> SelectAllTable()
        {
            using (var db = new I4DAB_HandIn2Context())
            {
                var tableIns = db.TableIns.ToList();

                return tableIns.ToList();
            }
        }

        public List<WaiterTableIns> SelectAllWaiterTablelns()
        {
            using (var db = new I4DAB_HandIn2Context())
            {
                var waiterTableIns = db.WaiterTableIns.ToList();

                return waiterTableIns.ToList();
            }
        }
    }
}
