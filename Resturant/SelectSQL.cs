using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Xml;
using Microsoft.EntityFrameworkCore.Internal;

namespace Resturant
{
    class SelectSQL
    {
        public void SelectAllRestaurant()
        {
            using (var db = new I4DAB_HandIn2Context())
            {
                foreach (var rest in db.Restaurant)
                {
                    Console.WriteLine(rest.Address);
                }
            }
        }

        public void SelectTypeRestaurants()
        {
            using (var db = new I4DAB_HandIn2Context())
            {

            }
        }

        public void SelectRestaurantMenu(string address)
        {
            using (var db = new I4DAB_HandIn2Context())
            {
                foreach(var rest in db.Restaurant)
                {
                    if(rest.Address == address)
                    {
                        foreach(var dish in rest.RestaurantDish)
                        {
                            Console.WriteLine("Type:{0}",dish.Dish.Type);
                            Console.WriteLine("Price:{0:0.00}",dish.Dish.Price);

                        }
                    }
                }
            }
        }

        double ReviewAverage()
        {
            double average = 0;


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
