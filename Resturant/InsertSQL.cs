using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using Microsoft.EntityFrameworkCore.Internal;
using Resturant.Models;

namespace Resturant
{
    class InsertSQL
    {
        private I4DAB_HandIn2Context db;

        public InsertSQL(I4DAB_HandIn2Context db_)
        {
            db = db_;
        }

        

        public void addRestaurant(ref Restaurant restaurant)
        {
            
                string addresse = restaurant.Address;
                //if (db.Restaurant.Any(r => r.Address == addresse))
                    //return;
                db.Restaurant.Add(restaurant);
                db.SaveChanges();
            
        }

        public void addReview(ref Review review, ref Restaurant restaurant)
        {
            review.AddresseNavigation = restaurant;

            db.Review.Add(review);
            db.SaveChanges();
        }
        public void addReview(ref Review review, ref Restaurant restaurant, ref Dish dish)
        {
                review.Dish = dish;
                review.AddresseNavigation = restaurant;
                
                db.Review.Add(review);
                dish.Review.Add(review);
                db.SaveChanges();

        }

        public void addDish(ref Dish dish, ref Restaurant restaurant, ref Guest guest)
        {
                db.Dish.Add(dish);
                db.SaveChanges();

                //var guest2 = db.Guest.Take(1).First();
                var gd = new GuestDish();
                gd.Dish = dish;
                gd.Guest = guest;

                dish.GuestDish.Add(gd);
                

                db.SaveChanges();


            }

        public void addDish(ref Dish dish, ref Restaurant restaurant)
        {

            db.Dish.Add(dish);
            db.SaveChanges();

            //var guest2 = db.Guest.Take(1).First();
            var rd = new RestaurantDish();
            rd.Dish = dish;
            rd.AddresseNavigation = restaurant;
            //rd.Addresse = restaurant.Address;
            //rd.DishId = dish.DishId;
            db.RestaurantDish.Add(rd);
            restaurant.RestaurantDish.Add(rd);
            dish.RestaurantDish.Add(rd);
            db.SaveChanges();


        }

        public void addGuest(ref Guest guest, ref Person person, ref TableIns table, ref Review review)
        {

                guest.ReviewId = review.ReviewId;
                guest.TableId = table.TableId;
                guest.FkPersonId = person.PersonId;
                db.Guest.Add(guest);

                //dish.ReviewId = review.ReviewId;

                //var gd = new GuestDish();
                //gd.Dish = dish;
                //gd.Guest = guest;

                //guest.GuestDish.Add(gd);

               
                db.SaveChanges();


        }

        public void addGuest(ref Guest guest, ref Person person, ref TableIns table)
        {

            
            guest.TableId = table.TableId;
            guest.FkPersonId = person.PersonId;
            db.Guest.Add(guest);


            db.SaveChanges();


        }

        public void addDishToGuest(ref Dish dish, ref Guest guest)
        {
            var gd = new GuestDish();
            gd.DishId = dish.DishId;
            gd.GuestId = guest.GuestId;
            db.GuestDish.Add(gd);

            db.SaveChanges();
        }
        public void addTable(ref TableIns table, ref Restaurant restaurant, ref Waiter waiter)
        {
            
                table.Addresse = restaurant.Address;
                db.TableIns.Add(table);
                db.SaveChanges();

                var waiterTable = new WaiterTableIns();

                waiterTable.TableId = table.TableId;
                waiterTable.WaiterId = waiter.WaiterId;
                
                db.WaiterTableIns.Add(waiterTable);
                db.SaveChanges();
                
        }

        public void addWaiter(ref Waiter waiter, ref Person person)
        {
            waiter.PersonId = person.PersonId;

                //var waiterTable = new WaiterTableIns();
                //waiterTable.TableId = table.TableId;
                //waiterTable.WaiterId = waiter.WaiterId;

                db.Waiter.Add(waiter);
                //db.WaiterTableIns.Add(waiterTable);
                db.SaveChanges();

        }

        public void addPerson(ref Person person)
        {
            db.Person.Add(person);
                db.SaveChanges();

        }


    }
}
