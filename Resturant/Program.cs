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
            Console.WriteLine("Velkommen til Restaurant adminstration.");
            Console.WriteLine("Tilføj Restuarant på (a) eller vælg eksiterende på (e)");

            selectAll.SelectAllResturant();
            String addresse = "";
            string us = Console.ReadLine();
            switch (us)
            {
                case "a":
                    do
                    {
                        Console.Write("Skriv navn: ");
                        string name = Console.ReadLine();
                        Console.Write("Skriv addresse: ");
                        addresse = Console.ReadLine();
                        Console.Write("Skriv type restaurant: ");
                        string type = Console.ReadLine();

                        var rest = new Restaurant() {Name = name, Address = addresse, Type = type};
                        create.addRestaurant(ref rest);

                        Console.WriteLine("Tilføjet. Tryk (i) for at tilføje ny Restaurant");
                    } while (Console.ReadLine().Equals("i"));
                    break;
                case "e":
                    break;
            }

            Console.WriteLine("Skriv addresse for at vælge resturant");
            string userAddresse = Console.ReadLine();

            var nyrest = selectspecific.getRestaurant(userAddresse);

            Console.WriteLine("Skriv (j) for at tilføje dish. Ellers (n)");
            while (Console.ReadLine().Equals("j"))
            {
                Console.Write("Skriv navn: ");
                string name = Console.ReadLine();

                Console.Write("Skriv pris i hele kroner: ");
                int pris = int.Parse(Console.ReadLine());

                Console.Write("Skriv type dish: ");
                string type = Console.ReadLine();

                var dish = new Dish() {Price = pris, Type = type, Name = name};

                create.addDish(ref dish,ref nyrest);
                Console.WriteLine("Skriv (j) for at tilføje endnu en dish. Ellers (n)");
            }
            Console.WriteLine("Vil du se menuen for restauranten. (j) for ja, og (n) for nej");
            if(Console.ReadLine().Equals("j"))
                select.SelectRestaurantMenu2(nyrest.Address);

            Console.WriteLine("Vil du tilføje");
            Console.ReadLine();

            Console.ReadLine();
            var person = new Person(){Name = "Henrik"};
            var waiter = new Waiter() {Salary = 150};
            var table = new TableIns(){Number = 7};
            var guest = new Guest() {Reservation = DateTime.Now};
            //var dish = new Dish() {Price = 40, Type = "Dessert",Name = "Lasagne"};

            //var rest = new Restaurant(){Address = "Randersvej 42",Name = "Restaurant2",Type = "Buffet"};
            //var rest = selectspecific.getRestaurant("Randersvej 42");
            var review = new Review() {Text = "Det var godt", Stars = 3};
            var review2 = new Review() { Text = "Det var ok", Stars = 2};

            //create.addRestaurant(ref rest);

            

            //create.addDish(ref dish, ref rest);
            //create.addReview(ref review, ref rest,ref dish);
            //create.addReview(ref review2, ref rest,ref dish);

            //select.getAllWithType("Buffet");

            //create.addPerson(ref person);
            //create.addWaiter(ref waiter,ref person);
            //create.addTable(ref table,ref rest,ref waiter);
            //create.addGuest(ref guest,ref person,ref table,ref review);
            

            select.getReviewsBasedOnTable("Randersvej 42");


            select.SelectRestaurantMenu2("Randersvej 42");
            Console.ReadLine();
            
            //SelectAllSQL selectAllSQL = new SelectAllSQL();
            //var data = selectAllSQL.SelectAllResturant();
            //Console.WriteLine(data[0].ToString());
        }



        public void test()
        {
            //var person = new Person() { Name = "Henrik" };
            //var waiter = new Waiter() { Salary = 150 };
            //var table = new TableIns() { Number = 7 };
            //var guest = new Guest() { Reservation = DateTime.Now };
            //var dish = new Dish() { Price = 40, Type = "Dessert", Name = "Lasagne" };

            ////var rest = new Restaurant(){Address = "Randersvej 42",Name = "Restaurant2",Type = "Buffet"};
            //var rest = selectspecific.getRestaurant("Randersvej 42");
            //var review = new Review() { Text = "Det var godt", Stars = 3 };
            //var review2 = new Review() { Text = "Det var ok", Stars = 2 };

            ////create.addRestaurant(ref rest);



            //create.addDish(ref dish, ref rest);
            //create.addReview(ref review, ref rest, ref dish);
            //create.addReview(ref review2, ref rest, ref dish);

            //select.getAllWithType("Buffet");

            //create.addPerson(ref person);
            //create.addWaiter(ref waiter, ref person);
            //create.addTable(ref table, ref rest, ref waiter);
            //create.addGuest(ref guest, ref person, ref table, ref review);


            //select.getReviewsBasedOnTable("Randersvej 42");


            //select.SelectRestaurantMenu2("Randersvej 42");
            //Console.ReadLine();

            //SelectAllSQL selectAllSQL = new SelectAllSQL();
            //var data = selectAllSQL.SelectAllResturant();
            //Console.WriteLine(data[0].ToString());
        }
    }
}
