﻿using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace Resturant
{
    class Creating
    {
        public void addRestaurant(string address, string name, string type)
        {
            using (var db = new I4DAB_HandIn2Context())
            {
                var restaurant = new Resturant.Restaurant();
                restaurant.Address = address;
                restaurant.Name = name;
                restaurant.Type = type;

                db.Restaurant.Add(restaurant);
                db.SaveChanges();
            }
        }

        public void addReview(int star, string text,Restaurant restaurant)
        {
            using (var db = new I4DAB_HandIn2Context())
            {
                var review = new Review();
                review.Stars = star;
                review.Text = text;
                review.AddresseNavigation = restaurant;

                db.Review.Add(review);
                db.SaveChanges();

            }
        }

        public void addDish(double price,string type, Review review, Restaurant restaurant, Guest guest)
        {
            using (var db = new I4DAB_HandIn2Context())
            {
                var dish = new Dish();
                dish.Price = price;
                dish.Type = type;

                dish.ReviewId = review.ReviewId;

                var gd = new GuestDish();
                gd.Dish = dish;
                gd.Guest = guest;

                dish.GuestDish.Add(gd);

                db.Dish.Add(dish);
                db.SaveChanges();
            }
            

        }

        public void addGuest(Person person, TableIns table, Review review, Dish dish, DateTime time)
        {
            using (var db = new I4DAB_HandIn2Context())
            {
                var guest = new Guest();
                guest.Reservation = time;
                guest.ReviewId = review.ReviewId;
                guest.TableId = table.TableId;
                guest.FkPersonId = person.PersonId;


                dish.ReviewId = review.ReviewId;

                var gd = new GuestDish();
                gd.Dish = dish;
                gd.Guest = guest;

                guest.GuestDish.Add(gd);

                db.Guest.Add(guest);
                db.SaveChanges();
            }


        }

        public void addTable(int number, Restaurant restaurant, Waiter waiter)
        {
            using (var db = new I4DAB_HandIn2Context())
            {
                var table = new TableIns();
                table.Addresse = restaurant.Address;
                table.Number = number;


                var gd = new GuestDish();


                //dish.ReviewId = review.ReviewId;

                //var gd = new GuestDish();
                //gd.Dish = dish;
                //gd.Guest = guest;

                //guest.GuestDish.Add(gd);

                //db.Guest.Add(guest);
                //db.SaveChanges();
            }
        }


    }
}
