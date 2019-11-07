﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Resturant.Models;

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

            using (var db = new I4DAB_HandIn2Context())
            {
                dataOutPut = db.Review.Where(reviewOut => reviewOut.Addresse.StartsWith(resturant.Address)).ToList();
            }

            for (int i = 0; i < dataOutPut.Count; i++)
            {
                Console.WriteLine(dataOutPut[i].ToString());
            }

            return dataOutPut.ToList();
        }


        public List<TableIns> selectTableIns(Restaurant resturant)
        {
            List<TableIns> dataOutPut;

            using (var db = new I4DAB_HandIn2Context())
            {
                dataOutPut = db.TableIns.Where(reviewOut => reviewOut.Addresse.StartsWith(resturant.Address)).ToList();
            }

            for (int i = 0; i < dataOutPut.Count; i++)
            {
                Console.WriteLine(dataOutPut[i].ToString());
            }

            return dataOutPut.ToList();
        }


        public Person selectPerson(int id)
        {
            List<Person> dataOutPut = new List<Person>();

            using (var db = new I4DAB_HandIn2Context())
            {
                dataOutPut = db.Person.Where(personOut => personOut.PersonId == id).ToList();
            }

            Console.WriteLine(dataOutPut[0].ToString());

            return dataOutPut[0];
        }


        public List<Waiter> selectWaiter(Person person)
        {
            List<Waiter> dataOutPut = new List<Waiter>();

            using (var db = new I4DAB_HandIn2Context())
            {
                dataOutPut = db.Waiter.Where(waiterOut => waiterOut.PersonId == person.PersonId).ToList();
            }

            for (int i = 0; i < dataOutPut.Count; i++)
            {
                Console.WriteLine(dataOutPut[i].ToString());
            }

            return dataOutPut.ToList();
        }


        public List<WaiterTableIns> selectWaiterTableIns(Waiter waiter, TableIns tableIns)
        {
            List<WaiterTableIns> dataOutPut = new List<WaiterTableIns>();

            using (var db = new I4DAB_HandIn2Context())
            {
                dataOutPut = db.WaiterTableIns.Where(waiterTableInsOut => ((waiterTableInsOut.WaiterId == waiter.WaiterId) && (waiterTableInsOut.TableId == tableIns.TableId))).ToList();
            }

            Console.WriteLine(dataOutPut.ToString());

            return dataOutPut.ToList();
        }

        public List<Guest> selectGuest(Review review, TableIns tableIns)
        {
            List<Guest> dataOutPut = new List<Guest>();

            using (var db = new I4DAB_HandIn2Context())
            {
                dataOutPut = db.Guest.Where(guestOut => ((guestOut.ReviewId == review.ReviewId) && (guestOut.TableId == tableIns.TableId))).ToList();
            }

            Console.WriteLine(dataOutPut.ToString());

            return dataOutPut.ToList();
        }


        public List<Dish> selectDish(Review review)
        {
            List<Dish> dataOutPut = new List<Dish>();

            using (var db = new I4DAB_HandIn2Context())
            {
                dataOutPut = db.Dish.Where(dishOut => dishOut.Review == review).ToList();
            }

            for (int i = 0; i < dataOutPut.Count; i++)
            {
                Console.WriteLine(dataOutPut[i].ToString());
            }

            return dataOutPut.ToList();
        }


        public List<GuestDish> selectGuest(Guest guest, Dish dish)
        {
            List<GuestDish> dataOutPut = new List<GuestDish>();

            using (var db = new I4DAB_HandIn2Context())
            {
                dataOutPut = db.GuestDish.Where(guestDishOut => ((guestDishOut.GuestId == guest.GuestId) && (guestDishOut.DishId == dish.DishId))).ToList();
            }

            Console.WriteLine(dataOutPut.ToString());

            return dataOutPut.ToList();
        }

        public List<RestaurantDish> selectGuest(Restaurant restaurant, Dish dish)
        {
            List<RestaurantDish> dataOutPut = new List<RestaurantDish>();

            using (var db = new I4DAB_HandIn2Context())
            {
                dataOutPut = db.RestaurantDish.Where(restaurantDishOut => ((restaurantDishOut.Addresse == restaurant.Address) && (restaurantDishOut.DishId == dish.DishId))).ToList();
            }

            Console.WriteLine(dataOutPut.ToString());

            return dataOutPut.ToList();
        }

    }
}
