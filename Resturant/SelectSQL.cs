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
                    double? rating = 0;
                    foreach (var review in reviews)
                    {
                        rating += review.Stars;
                    }

                    rating = rating / reviews.Count();
                    Console.WriteLine("\t Gennemsnit review: " + rating);
                    foreach (var review in reviews.Take(5))
                    {
                        Console.WriteLine("\tReview: "+review.Text);
                    }
                    Console.WriteLine("--------");
                }
            }
        }


        public void getReviewsBasedOnTable()
        {
            using (var db = new I4DAB_HandIn2Context())
            {

            }
        }
    }
}
