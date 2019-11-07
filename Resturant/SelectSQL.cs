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
                        Console.WriteLine("Restaurant stars:{0:0.00}", ReviewAverage(address));
                        Console.WriteLine("Menu:");
                        foreach (var dish in rest.RestaurantDish)
                        {
                            Console.WriteLine("Type:{0}", dish.Dish.Type);
                            Console.WriteLine("Price:{0:0.00}", dish.Dish.Price);

                            var rest = db.Restaurant.Where(r => r.Address.Equals(address)).First();

                            foreach (var dish in rest.RestaurantDish)
                            {
                                Console.WriteLine("Type:{0}", dish.Dish.Type);
                                Console.WriteLine("Price:{0:0.00}", dish.Dish.Price);
                            }
                        }
                    }
                }
            }
        }


        //double ReviewAverage(string address)

        public void SelectRestaurantMenu2(string address)
        {
            using (var db = new I4DAB_HandIn2Context())
            {
                var rest = db.Restaurant.Where(r => r.Address.Equals(address));
                Console.WriteLine("Menu for restaurant "+rest.First().Name+":");
                //var rd = from redi in RestaurantDish
                //var rd = rest.RestaurantDish.Where(r => r.Addresse.Equals(address));
                var dishesid = db.RestaurantDish.Where(r => r.Addresse.Equals(address));
                var dishes = from rd in dishesid select rd.Dish;
                
                foreach (var dish in dishes)
                {
                    Console.WriteLine("\t"+dish.Name);
                    Console.WriteLine("\t"+dish.Type);
                    Console.WriteLine("\t" + dish.Price+" kr.");

                    var reviews = db.Review.Where(r => r.DishId == dish.DishId);
                    Console.WriteLine("\t"+reviews.Average(r => r.Stars)+" stjerner");
                    //foreach (var review in dish.Review)
                    //{
                    //    Console.WriteLine(review.DishId+" "+review.Stars);
                    //}

                    //Console.WriteLine("\t"+dish.Review.FirstOrDefault());

                    //Console.WriteLine("\t"+dish.Review.Average(r => r.Stars));

                    //var reviewsid = db.Dish.Where(r => r.ReviewId =)
                    //var reviews = from r in reviewsid select r.
                    //Console.WriteLine("\tGennemsnit rating: "+reviews.Average(s => s.Stars));
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


        public void getAllWithType(string type)
        {
            using (var db = new I4DAB_HandIn2Context())
            {
                List<Restaurant> restlist = db.Restaurant.Where(t => t.Type.Equals(type)).ToList();
                Console.WriteLine("Restaurants with type "+type+":");
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
                            Console.Write(dish.Type+", ");
                        }
                        Console.WriteLine();

                        Console.WriteLine("\t\tReview: ");
                        var review = db.Review.Where(r => r.ReviewId == guest.ReviewId).First();
                        Console.WriteLine("\t\t"+review.Text+", "+review.Stars);

                    }
                }
            }
        }
    }
}
