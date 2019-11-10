using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;
using Microsoft.EntityFrameworkCore.Internal;
using Resturant.Models;

namespace Resturant
{
    class SelectSQL
    {
        public void SelectTypeRestaurants(string type)
        {
            using (var db = new I4DAB_HandIn2Context())
            {

            }
        }

        public void SelectRestaurantMenu(string address)
        {
            using (var db = new I4DAB_HandIn2Context())
            {
                foreach (var rest in db.Restaurant)
                {
                    if (rest.Address == address)
                    {
                        Console.WriteLine("Restaurant stjerner:{0:0.00}", ReviewAverage(address));
                        Console.WriteLine("Menu:");
                        foreach (var dish in rest.RestaurantDish)
                        {
                            Console.WriteLine("Type:{0}", dish.Dish.Type);
                            Console.WriteLine("Pris:{0:0.00}", dish.Dish.Price);

                          
                        }
                    }
                }
            }
        }


        //view 2. (restaurant addr) -> menu - dishes, price, avg rating
        public void SelectRestaurantMenu2(string address)
        {
            using (var db = new I4DAB_HandIn2Context())
            {
                var rest = db.Restaurant.Where(r => r.Address.Equals(address));
                Console.WriteLine("Menu for restaurant "+rest.First().Name+":");
                var dishesid = db.RestaurantDish.Where(r => r.Addresse.Equals(address));
                var dishes = from rd in dishesid select rd.Dish;
                
                foreach (var dish in dishes)
                {
                    Console.WriteLine("\t"+dish.Name);
                    Console.WriteLine("\t"+dish.Type);
                    Console.WriteLine("\t" + dish.Price+" kr.");

                    var reviews = db.Review.Where(r => r.DishId == dish.DishId);
                    Console.WriteLine("\t"+reviews.Average(r => r.Stars)+" stjerner");
                    Console.WriteLine();
                }

            }
        }
        double ReviewAverage(string address)
        {
            double average = 0;
            int? totalStars = 0;
            int starAmount = 0;

            using (var db = new I4DAB_HandIn2Context())
            {
                var reviewliste = db.Review.Where(r => r.AddresseNavigation.Address == address);
                foreach(var review in reviewliste)
                {
                   
                    totalStars += review.Stars;
                    starAmount++;
                }
            }

            average = (double)totalStars / starAmount;

            return average;
        }


        //view 1. (type) -> list all restaurants with give type and their average rating + latest 5 review text
        public void getAllWithType(string type)
        {
            using (var db = new I4DAB_HandIn2Context())
            {
                List<Restaurant> restlist = db.Restaurant.Where(t => t.Type.Equals(type)).ToList();
                Console.WriteLine("Restauranter af type "+type+":");
                foreach (var rest in restlist)
                {
                    Console.WriteLine(rest.Name);

                    var reviews = db.Review.Where(r => r.Addresse.Equals(rest.Address));
                    double? rating = (double?)reviews.Average(r => r.Stars);
                    
                    Console.WriteLine("\t Gennemsnit review: " + rating);
                    foreach (var review in reviews.Take(5))
                    {
                        Console.WriteLine("\tReview: "+review.Text);
                    }
                    Console.WriteLine("--------");
                }
            }
        }


        //View 3. (restaurant addr) -> information about guests reviews for dishes based on table
        public void getReviewsBasedOnTable(string addresse)
        {
            using (var db = new I4DAB_HandIn2Context())
            {
                var rest = db.Restaurant.Where(r => r.Address.Equals(addresse)).First();
                Console.WriteLine("Restaurant "+rest.Name+":");

                var tables = db.TableIns.Where(t => t.Addresse.Equals(addresse));

                foreach (var table in tables)
                {
                    Console.WriteLine("\tBord "+table.Number+":");

                    var guests = db.Guest.Where(g => g.TableId == table.TableId);
                    foreach (var guest in guests)
                    {
                        Console.WriteLine("\t\tGæst ved "+guest.Reservation+":");
                        Console.Write("\t\tHar spist ");

                        var dishnumbers = db.GuestDish.Where(d => d.GuestId == guest.GuestId);
                        var dishes = from dn in dishnumbers select dn.Dish;
                        foreach (var dish in dishes)
                        {
                            Console.Write(dish.Name+", ");
                        }
                        Console.WriteLine();

                        Console.WriteLine("\t\tReview: ");
                        if (db.Review.Where(r => r.ReviewId == guest.ReviewId).Any())
                        {
                            var review = db.Review.Where(r => r.ReviewId == guest.ReviewId).First();
                            Console.WriteLine("\t\t" + review.Text + ", " + review.Stars+" stjerner");
                        }
                        Console.WriteLine();

                    }
                }
            }
        }
    }
}
