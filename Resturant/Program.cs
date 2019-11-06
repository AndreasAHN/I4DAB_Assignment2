using System;

namespace Resturant
{
    class Program
    {
        static void Main(string[] args)
        {

            var create = new CreateSQL();
            var selectAll = new SelectAllSQL();
            var select = new SelectSQL();

            var person = new Person(){Name = "Henrik"};
            var waiter = new Waiter() {Salary = 150};
            var table = new TableIns(){Number = 5};
            var guest = new Guest() {Reservation = DateTime.Now};
            var dish = new Dish() {Price = 40, Type = "Dessert"};

            var rest = new Restaurant(){Address = "Randersvej 6",Name = "Restaurant2",Type = "Buffet"};
            var review = new Review() {Text = "Det var ok", Stars = 3};

            create.addRestaurant(ref rest);
            selectAll.SelectAllResturant();

            create.addReview(ref review, ref rest);

            select.getAllWithType("Buffet");

            create.addPerson(ref person);
            create.addWaiter(ref waiter,ref person);
            create.addTable(ref table,ref rest,ref waiter);
            create.addGuest(ref guest,ref person,ref table,ref review);
            create.addDish(ref dish, ref review, ref rest,ref guest);


            Console.ReadLine();
            //SelectAllSQL selectAllSQL = new SelectAllSQL();
            //var data = selectAllSQL.SelectAllResturant();
            //Console.WriteLine(data[0].ToString());
        }
    }
}
