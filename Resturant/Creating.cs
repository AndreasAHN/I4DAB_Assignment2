using System;
using System.Collections.Generic;
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
                db.SaveChanges();
            }
        }

        public void addReview(int star, string text)
        {
            using (var db = new I4DAB_HandIn2Context())
            {
                var review = new Review();

            }
        }
    }
}
