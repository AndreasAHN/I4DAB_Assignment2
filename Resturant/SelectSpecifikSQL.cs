﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Resturant.Models;
using Microsoft.EntityFrameworkCore;

namespace Resturant
{
    public class SelectSpecifikSQL
    {
        public SelectAllSQL selectAllSQL;
        private I4DAB_HandIn2Context db;

        public SelectSpecifikSQL(I4DAB_HandIn2Context db_)
        {
            db = db_;
            selectAllSQL = new SelectAllSQL();
        }

        public Restaurant getRestaurant(string addresse)
        {
            var dataOut = db.Restaurant.Where(r => r.Address == addresse).First();
            Console.WriteLine(dataOut.ToString());
            return dataOut;

        }

        public List<Review> selectReview(Restaurant resturant)
        {
            //List<Review> dataReviews = selectAllSQL.SelectAllReview();
            List<Review> dataOutPut;// = new List<Review>();
            //for (int i = 0; i < dataReviews.Count; i++)
            //{
            //    if(dataReviews[i].Addresse == resturant.Address)
            //    {
            //        dataOutPut.Add(dataReviews[i]);
            //        Console.WriteLine(dataReviews[i].ToString());
            //    }
            //}

           dataOutPut = db.Review.Where(reviewOut => reviewOut.Addresse.StartsWith(resturant.Address)).ToList();

            for (int i = 0; i < dataOutPut.Count; i++)
            {
                Console.WriteLine
                (
                    "\t" + "ReviewId: " + dataOutPut[i].ReviewId.ToString() + "\n" +
                    "\t" + "Stars: " + dataOutPut[i].Stars.ToString() + "\n"+
                    "\t" + "Addresse: " + dataOutPut[i].Addresse.ToString() + "\n" +
                    "\t" + "Text: " + dataOutPut[i].Text.ToString() + "\n"
                );
            }

            return dataOutPut.ToList();
        }


        public List<TableIns> selectTableIns(Restaurant resturant)
        {
            List<TableIns> dataOutPut;

            dataOutPut = db.TableIns.Where(reviewOut => reviewOut.Addresse.StartsWith(resturant.Address)).ToList();

            for (int i = 0; i < dataOutPut.Count; i++)
            {
                Console.WriteLine
                (
                    "\t" + "TableId: " + dataOutPut[i].TableId.ToString() + "\n" +
                    "\t" + "Addresse: " + dataOutPut[i].Addresse.ToString() + "\n" +
                    "\t" + "Number: " + dataOutPut[i].Number.ToString() + "\n" 
                );
            }

            return dataOutPut.ToList();
        }


        public Person selectPerson(int id)
        {
            List<Person> dataOutPut = new List<Person>();

            dataOutPut = db.Person.Where(personOut => personOut.PersonId == id).ToList();

            Person dataOut = new Person();

            Console.WriteLine
            (
                "\t" + "PersonId: " + dataOutPut[0].PersonId.ToString() + "\n" +
                "\t" + "Name: " + dataOutPut[0].Name.ToString() + "\n" 
            );

            dataOut = dataOutPut[0];

            return dataOut;
        }


        public Waiter selectWaiter(Person person)
        {
            var waiter = db.Waiter.Where(w => w.PersonId == person.PersonId).First();
                Console.WriteLine
                (
                    "\t" + "WaiterId: " + waiter.WaiterId.ToString() + "\n" +
                    "\t" + "Salary: " + waiter.Salary.ToString() + "\n"
                );

            return waiter;
        }

        public Waiter selectWaiter(int personID)
        {
            var waiter = db.Waiter.Where(w => w.PersonId == personID).First();
            Console.WriteLine
            (
                "\t" + "WaiterId: " + waiter.WaiterId.ToString() + "\n" +
                "\t" + "Salary: " + waiter.Salary.ToString() + "\n"
            );

            return waiter;
        }

        public List<WaiterTableIns> selectWaiterTableIns(Waiter waiter, TableIns tableIns)
        {
            List<WaiterTableIns> dataOutPut = new List<WaiterTableIns>();

            dataOutPut = db.WaiterTableIns.Where(waiterTableInsOut => ((waiterTableInsOut.WaiterId == waiter.WaiterId) && (waiterTableInsOut.TableId == tableIns.TableId))).ToList();

            return dataOutPut.ToList();
        }

        public Guest selectGuest(Review review, TableIns tableIns)
        {
            List<Guest> dataOutPut = new List<Guest>();

            dataOutPut = db.Guest.Where(guestOut => ((guestOut.ReviewId == review.ReviewId) && (guestOut.TableId == tableIns.TableId))).ToList();

            Console.WriteLine
            (
                "\t" + "GuestId: " + dataOutPut[0].GuestId.ToString() + "\n" +
                "\t" + "Reservation: " + dataOutPut[0].Reservation.ToString() + "\n" +
                "\t" + "TableId: " + dataOutPut[0].TableId.ToString() + "\n" +
                "\t" + "ReviewId: " + dataOutPut[0].ReviewId.ToString() + "\n"
            );

            Guest dataOut = new Guest();
            dataOut = dataOutPut[0];

            return dataOut;
        }


        public List<Dish> selectDish(Review review)
        {
            List<Dish> dataOutPut = new List<Dish>();

            dataOutPut = db.Dish.Where(dishOut => dishOut.Review == review).ToList();

            for (int i = 0; i < dataOutPut.Count; i++)
            {
                Console.WriteLine
                (
                    "\t" + "DishId: " + dataOutPut[i].DishId.ToString() + "\n" +
                    "\t" + "Price: " + dataOutPut[i].Price.ToString() + "\n" +
                    "\t" + "Type: " + dataOutPut[i].Type.ToString() + "\n"
                );
            }

            return dataOutPut.ToList();
        }


        public GuestDish selectGuestDish(Guest guest, Dish dish)
        {
            List<GuestDish> dataOutPut = new List<GuestDish>();

            dataOutPut = db.GuestDish.Where(guestDishOut => ((guestDishOut.GuestId == guest.GuestId) && (guestDishOut.DishId == dish.DishId))).ToList();

            GuestDish dataOut = new GuestDish();
            dataOut = dataOutPut[0];

            return dataOut;
        }

        public RestaurantDish selectGuest(Restaurant restaurant, Dish dish)
        {
            List<RestaurantDish> dataOutPut = new List<RestaurantDish>();

            dataOutPut = db.RestaurantDish.Where(restaurantDishOut => ((restaurantDishOut.Addresse == restaurant.Address) && (restaurantDishOut.DishId == dish.DishId))).ToList();

            RestaurantDish dataOut = new RestaurantDish();
            dataOut = dataOutPut[0];

            return dataOut;
        }

        public void selectAGuest(int id)
        {
            var guest = db.Guest.Where(g => g.GuestId == id).FirstOrDefault();
            Console.WriteLine("Gæsten:");
            Console.WriteLine("ID: "+guest.GuestId);
            Console.WriteLine("Reservation: "+guest.Reservation);
            var person = db.Person.Where(p => p.PersonId == guest.FkPersonId).First();
            Console.WriteLine("Navn: "+person.Name);
            Console.WriteLine();
        }

        public Dish selectADishAtRestaurant(ref Restaurant rest, string name)
        {
            var addresse = rest.Address;
            var dishesid = db.RestaurantDish.Where(r => r.Addresse.Equals(addresse));
            var dishes = from rd in dishesid select rd.Dish;
            return db.Dish.Where(d => d.Name.Equals(name)).First();
        }
        public void selectGuestsAtRestaurant(Restaurant rest)
        {
            var tableGuests = db.TableIns.Include(t => t.Guest).Where(t => t.Addresse == rest.Address).ToList();

            foreach (var tg in tableGuests)
            {

                if (!tg.Guest.Any())
                {
                    Console.WriteLine
                       (
                         "\t" + "Table number: " + tg.Number.ToString() + "\n" +
                         "\t" + "Empty" + "\n"
                        
                       );
                }
                foreach (var g in tg.Guest)
                Console.WriteLine
                (
                 "\t" + "Table number: " + tg.Number.ToString() + "\n" +
                 "\t" + "Reservation: " + g.Reservation.ToString() + "\n" +
                 "\t" + "GuestId: " + g.GuestId.ToString() + "\n"
                );
            }
        }
    }
}
