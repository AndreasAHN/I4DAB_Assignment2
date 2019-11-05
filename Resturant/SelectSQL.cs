using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
