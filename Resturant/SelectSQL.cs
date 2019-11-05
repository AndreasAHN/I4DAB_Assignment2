using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
                foreach(var rest in db.Restaurant)
                {
                    if(rest.Address == address)
                    {
                        Console.WriteLine("Restaurant stars:{0:0.00}", ReviewAverage(address));
                        Console.WriteLine("Menu:");
                        foreach(var dish in rest.RestaurantDish)
                        {
                            Console.WriteLine("Type:{0}",dish.Dish.Type);
                            Console.WriteLine("Price:{0:0.00}",dish.Dish.Price);
                        }
                    }
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
    }
}
