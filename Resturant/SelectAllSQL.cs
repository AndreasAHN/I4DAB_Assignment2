using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal;
using Resturant.Models;

namespace Resturant
{
    public class SelectAllSQL
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
                var persons = db.Person.ToList();

                Console.WriteLine("Tilgængelige personer:");

                foreach (var person in persons)
                {
                    Console.WriteLine("Navn: ");
                    Console.WriteLine(person.Name);
                }
                Console.WriteLine();

                return persons.ToList();
            }
        }

        public List<Waiter> ReadWaiter()
        {
            using (var db = new I4DAB_HandIn2Context())
            {
                var waiters = db.Waiter.ToList();
                Console.WriteLine("Waiters:");
                foreach (var waiter in waiters)
                {
                    Console.WriteLine("ID: "+waiter.WaiterId);
                    Console.WriteLine("Navn: "+waiter.Person.Name);
                    Console.WriteLine("Løn: "+waiter.Salary);
                    Console.WriteLine();
                }
                return waiters;
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

        public void SelectAllTabletoRestaurant(string addresse)
        {
            using (var db = new I4DAB_HandIn2Context())
            {
                var rest = db.Restaurant.Where(r => r.Address.Equals(addresse)).First();
                Console.WriteLine("Borde for restaurant "+rest.Name);

                foreach (var table in rest.TableIns)
                {
                    Console.WriteLine("Bord nr. "+table.Number);
                }
                Console.WriteLine();
                //return tableIns.ToList();
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
