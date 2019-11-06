using System;
using Resturant.Models;

namespace Resturant
{
    class Program
    {
        
        static void Main(string[] args)
        {
            I4DAB_HandIn2Context db = new I4DAB_HandIn2Context();
            var create = new CreateSQL(db);
            var selectAll = new SelectAllSQL();
            var select = new SelectSQL();
            var selectspecific = new SelectSpecifikSQL(db);
            var person = new Person(){Name = "Henrik"};
            var waiter = new Waiter() {Salary = 150};
            var table = new TableIns(){Number = 7};
            var guest = new Guest() {Reservation = DateTime.Now};
            var dish = new Dish() {Price = 40, Type = "Dessert",Name = "Lasagne"};

            //var rest = new Restaurant(){Address = "Randersvej 42",Name = "Restaurant2",Type = "Buffet"};
            var rest = selectspecific.getRestaurant("Randersvej 42");
            var review = new Review() {Text = "Det var godt", Stars = 3};
            var review2 = new Review() { Text = "Det var ok", Stars = 2};

            //create.addRestaurant(ref rest);

            selectAll.SelectAllResturant();

            create.addDish(ref dish, ref rest);
            create.addReview(ref review, ref rest,ref dish);
            create.addReview(ref review2, ref rest,ref dish);

            select.getAllWithType("Buffet");

            create.addPerson(ref person);
            create.addWaiter(ref waiter,ref person);
            create.addTable(ref table,ref rest,ref waiter);
            create.addGuest(ref guest,ref person,ref table,ref review);
            

            select.getReviewsBasedOnTable("Randersvej 42");


            select.SelectRestaurantMenu2("Randersvej 42");
            Console.ReadLine();
            
            //SelectAllSQL selectAllSQL = new SelectAllSQL();
            //var data = selectAllSQL.SelectAllResturant();
            //Console.WriteLine(data[0].ToString());
        }
    }
}
