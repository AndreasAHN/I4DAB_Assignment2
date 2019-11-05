using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using Microsoft.EntityFrameworkCore.Internal;

namespace Resturant
{
    class CreateSQL
    {
        public CreateSQL()
        {

        }

        public void addRestaurant(ref Restaurant restaurant)
        {
            using (var db = new I4DAB_HandIn2Context())
            {
                string addresse = restaurant.Address;
                if (db.Restaurant.Any(r => r.Address == addresse))
                    return;
                db.Restaurant.Add(restaurant);
                db.SaveChanges();
            }
        }

        public void addReview(ref Review review, ref Restaurant restaurant)
        {
            using (var db = new I4DAB_HandIn2Context())
            {
                review.Addresse = restaurant.Address;

                db.Review.Add(review);
                db.SaveChanges();

            }
        }

        public void addDish(ref Dish dish, ref Review review, ref Restaurant restaurant, ref Guest guest)
        {
            using (var db = new I4DAB_HandIn2Context())
            {

                dish.ReviewId = review.ReviewId;

                var gd = new GuestDish();
                gd.Dish = dish;
                gd.Guest = guest;

                dish.GuestDish.Add(gd);
                db.Dish.Add(dish);

                db.SaveChanges();
            }


        }

        public void addGuest(ref Guest guest, ref Person person, ref TableIns table, ref Review review, ref Dish dish)
        {
            using (var db = new I4DAB_HandIn2Context())
            {
                
                guest.ReviewId = review.ReviewId;
                guest.TableId = table.TableId;
                guest.FkPersonId = person.PersonId;
                db.Guest.Add(guest);

                dish.ReviewId = review.ReviewId;

                var gd = new GuestDish();
                gd.Dish = dish;
                gd.Guest = guest;

                guest.GuestDish.Add(gd);

               
                db.SaveChanges();
            }


        }

        public void addTable(ref TableIns table, ref Restaurant restaurant, ref Waiter waiter)
        {
            using (var db = new I4DAB_HandIn2Context())
            {
                table.Addresse = restaurant.Address;

                var waiterTable = new WaiterTableIns();

                waiterTable.TableId = table.TableId;
                waiterTable.WaiterId = waiter.WaiterId;
                db.TableIns.Add(table);
                db.WaiterTableIns.Add(waiterTable);
                db.SaveChanges();
               
            }
        }

        public void addWaiter(ref Waiter waiter, Person person, TableIns table)
        {
            using (var db = new I4DAB_HandIn2Context())
            {
                waiter.PersonId = person.PersonId;

                var waiterTable = new WaiterTableIns();
                waiterTable.TableId = table.TableId;
                waiterTable.WaiterId = waiter.WaiterId;

                db.Waiter.Add(waiter);
                db.WaiterTableIns.Add(waiterTable);
                db.SaveChanges();

            }
        }

        public void addPerson(ref Person person)
        {
            using (var db = new I4DAB_HandIn2Context())
            {
                db.Person.Add(person);
                db.SaveChanges();

            }
        }


    }
}
