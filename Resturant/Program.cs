using System;
using System.Linq;
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

            string menu = "mainMenu";
            string resturantMenu = "mainMenu";
            string adminMenu = "mainMenu";

            string userAddresse;
            Restaurant nyrest = new Restaurant();

            bool runner = true;
            while (runner)
            {
                switch (menu)
                {
                    case "mainMenu": // Main menu
                        Console.Clear();
                        Console.WriteLine("Velkommen til Restaurant adminstration.");
                        Console.WriteLine("---------------------------------");
                        Console.WriteLine("(a): Tilføj Restuarant på");
                        Console.WriteLine("(e): Vælg eksiterende på");
                        Console.WriteLine("(r): Vis alle resturanter");
                        Console.WriteLine("(x): Exit program");
                        Console.WriteLine("---------------------------------");

                        string us = Console.ReadLine();

                        Console.Clear();

                        String addresse = "";
                        
                        switch (us)
                        {
                            case "a":
                                do
                                {
                                    Console.Clear();
                                    Console.Write("Skriv navn: ");
                                    string name = Console.ReadLine();
                                    Console.Write("Skriv addresse: ");
                                    addresse = Console.ReadLine();
                                    Console.Write("Skriv type restaurant: ");
                                    string type = Console.ReadLine();

                                    var rest = new Restaurant() { Name = name, Address = addresse, Type = type };
                                    try
                                    {
                                        create.addRestaurant(ref rest);
                                    }
                                    catch (Exception)
                                    {
                                        Console.WriteLine("Failed save resturant");
                                        Console.WriteLine("Tryk enter for at forsætte");
                                        Console.ReadLine();
                                    }
                                    
                                    Console.WriteLine("Tilføjet. Tryk (i) for at tilføje ny Restaurant");
                                } while (Console.ReadLine().Equals("i"));
                                break;
                            case "e":
                                Console.WriteLine("Skriv addresse for at vælge resturant");
                                userAddresse = Console.ReadLine();
                                Console.WriteLine("Loading... \n");
                                try
                                {
                                    nyrest = selectspecific.getRestaurant(userAddresse);
                                    menu = "Resturant";
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("Failed loading resturant");
                                    Console.WriteLine("Tryk enter for at forsætte");
                                    Console.ReadLine();
                                }
                                
                                break;

                            case "r":
                                Console.WriteLine("Loading... \n");
                                try
                                {
                                    selectAll.SelectAllResturant();
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("Failed loading resturant");
                                    Console.WriteLine("Tryk enter for at forsætte");
                                    Console.ReadLine();
                                }

                                Console.WriteLine("Tryk enter for at forsætte");
                                Console.ReadLine();
                                break;

                            case "x":
                                runner = false;
                                break;

                            default:
                                Console.WriteLine("Wrong input");
                                Console.WriteLine("Tryk enter for at forsætte");
                                Console.ReadLine();
                                break;
                        }
                        break;

                    case "Resturant":
                        switch (resturantMenu)
                        { 
                            case "mainMenu":
                                Console.Clear();
                                Console.WriteLine("Velkommen til: " + nyrest.Name.ToString());
                                Console.WriteLine("På addressen: " + nyrest.Name.ToString());
                                Console.WriteLine("---------------------------------");
                                Console.WriteLine
                                    (
                                    "0: Tilbage til main menu" + "\n"+
                                    "1: Vis resturantens menu" + "\n" +
                                    "2: Tilføj en dish" + "\n" +
                                    "3: Tilføj et rewiew til en dish" + "\n" +
                                    "4: Få vist et review for en dish" + "\n" +
                                    "5: Adminstraterer resturanten"
                                    );
                                Console.WriteLine("---------------------------------");
                                string menuInput = Console.ReadLine();
                                    
                                switch (menuInput)
                                {
                                    case "0":
                                        menu = "mainMenu";
                                        break;

                                    case "1":
                                        resturantMenu = "menuShowMenu";
                                        break;

                                    case "2":
                                        resturantMenu = "menuNewDish";
                                        break;

                                    case "3":
                                        resturantMenu = "menuShowReviews";
                                        break;

                                    case "4":
                                        resturantMenu = "menuShowReviews";
                                        break;

                                    case "5":
                                        resturantMenu = "menuAdmin";
                                        break;

                                    default:
                                        Console.WriteLine("Wrong input");
                                        Console.WriteLine("Tryk enter for at forsætte");
                                        Console.ReadLine();
                                        break;
                                }
                                Console.Clear();
                                break;

                            case "menuNewDish":
                                string answerDish = "j";
                                while (answerDish.Equals("j"))
                                {
                                    Console.Write("Skriv navn: ");
                                    string name = Console.ReadLine();

                                    Console.Write("Skriv pris i hele kroner: ");
                                    int pris = int.Parse(Console.ReadLine());

                                    Console.Write("Skriv type dish: ");
                                    string type = Console.ReadLine();

                                    var dish = new Dish() { Price = pris, Type = type, Name = name };
                                    try 
                                    { 
                                        create.addDish(ref dish, ref nyrest);
                                    }
                                    catch (Exception)
                                    {
                                        Console.WriteLine("Failed save dish");
                                        Console.WriteLine("Tryk enter for at forsætte");
                                        Console.ReadLine();
                                    }

                                    Console.WriteLine("Skriv (j) for at tilføje endnu en dish. Ellers (n)");
                                    answerDish = Console.ReadLine();
                                }
                                resturantMenu = "mainMenu";
                                break;

                            case "menuShowMenu":
                                Console.WriteLine("Loading... \n");

                                try
                                { 
                                    select.SelectRestaurantMenu2(nyrest.Address);
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("Failed loading menu");
                                    Console.WriteLine("Tryk enter for at forsætte");
                                    Console.ReadLine();
                                }

                                Console.WriteLine("Tryk enter for at forsætte");
                                Console.ReadLine();
                                resturantMenu = "mainMenu";
                                break;

                            case "menuNewReview":
                                string answerReview = "j";
                                while (answerReview.Equals("j"))
                                {
                                    select.SelectRestaurantMenu2(nyrest.Address);
                                    Console.WriteLine("Skriv navn på dish");
                                    string name = Console.ReadLine();
                                    var dish = db.Dish.Where(d => d.Name.Equals(name)).FirstOrDefault();
                                    Console.WriteLine("Udført");
                                    Console.Write("Skriv tekst");
                                    string tekst = Console.ReadLine();
                                    Console.Write("Skriv antal stjerner");
                                    int stars = int.Parse(Console.ReadLine());
                                    var review = new Review() { Text = tekst, Stars = stars };

                                    try
                                    { 
                                        create.addReview(ref review, ref nyrest, ref dish);
                                    }
                                    catch (Exception)
                                    {
                                        Console.WriteLine("Failed save review");
                                        Console.WriteLine("Tryk enter for at forsætte");
                                        Console.ReadLine();
                                    }

                                    Console.WriteLine("Fuldført");
                                    Console.WriteLine("Vil du skrive nyt review? (j) for ja, og (n) for nej");
                                    answerReview = Console.ReadLine();
                                }
                                resturantMenu = "mainMenu";
                                break;

                            case "menuShowReviews":
                                Console.WriteLine("Loading... \n");
                                
                                try
                                { 
                                    select.SelectRestaurantMenu2(nyrest.Address);
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("Failed loading review");
                                    Console.WriteLine("Tryk enter for at forsætte");
                                    Console.ReadLine();
                                }

                                Console.WriteLine("Tryk enter for at forsætte");
                                Console.ReadLine();
                                resturantMenu = "mainMenu";
                                break;

                            case "menuAdmin":
                                switch (adminMenu)
                                {
                                    case "mainMenu":
                                        Console.Clear();
                                        Console.WriteLine("Velkommen til: " + nyrest.Name.ToString());
                                        Console.WriteLine("På addressen: " + nyrest.Name.ToString());
                                        Console.WriteLine("---------------------------------");
                                        Console.WriteLine("Admin menu:");
                                        Console.WriteLine("---------------------------------");
                                        Console.WriteLine
                                            (
                                            "0: Tilbage til resturant menu" + "\n" +
                                            "1: Tilføj en person" + "\n" +
                                            "2: Vis en person" + "\n" +
                                            "3: Tilføj en waiter" + "\n" +
                                            "4: Vis en waiter" + "\n" +
                                            "5: Tilføj bord" + "\n" +
                                            "6: Vis et bord" + "\n" +
                                            "7: Tilføj en guest" + "\n" +
                                            "8: Vis en guest"
                                            );
                                        Console.WriteLine("---------------------------------");
                                        string menuAdminInput = Console.ReadLine();

                                        switch (menuAdminInput)
                                        {
                                            case "0":
                                                resturantMenu = "mainMenu";
                                                break;

                                            case "1":
                                                adminMenu = "addPerson";
                                                break;

                                            case "2":
                                                adminMenu = "showPerson";
                                                break;

                                            case "3":
                                                adminMenu = "addWaiter";
                                                break;

                                            case "4":
                                                adminMenu = "showWaiter";
                                                break;

                                            case "5":
                                                adminMenu = "addTable";
                                                break;

                                            case "6":
                                                adminMenu = "showTable";
                                                break;

                                            case "7":
                                                adminMenu = "addGuest";
                                                break;

                                            case "8":
                                                adminMenu = "showGuest";
                                                break;

                                            default:
                                                Console.WriteLine("Wrong input");
                                                Console.WriteLine("Tryk enter for at forsætte");
                                                Console.ReadLine();
                                                break;
                                        }
                                        Console.Clear();

                                        break;

                                    case "addPerson":
                                        var person = new Person() { Name = "Henrik" };
                                        break;

                                    case "showPerson":
                                        int id = 0;
                                        selectspecific.selectPerson(id);
                                        break;

                                    case "addWaiter":
                                        var waiter = new Waiter() { Salary = 150 };
                                        break;

                                    case "showWaiter":
                                        int idPerson = 0;
                                        Person personBuf = selectspecific.selectPerson(idPerson);
                                        selectspecific.selectWaiter(personBuf);
                                        break;

                                    case "addTable":
                                        var table = new TableIns() { Number = 7 };
                                        break;

                                    case "showTable":
                                        selectspecific.selectTableIns(nyrest);
                                        break;

                                    case "addGuest":
                                        var guest = new Guest() { Reservation = DateTime.Now };
                                        break;

                                    case "showGuest":
                                        //selectspecific.selectGuest();
                                        break;
                                }
                                break;

                            default:
                                Console.WriteLine("Wrong input");
                                Console.WriteLine("Tryk enter for at forsætte");
                                Console.ReadLine();
                                break;
                        }
                        break;

                    default:
                        Console.WriteLine("Wrong input");
                        menu = "mainMenu";
                        Console.WriteLine("Tryk enter for at forsætte");
                        Console.ReadLine();
                        break;
                }
            }





            


            //////////////////Menu : 

            

            

            //Console.ReadLine();

            //var dish = new Dish() {Price = 40, Type = "Dessert",Name = "Lasagne"};

            //var rest = new Restaurant(){Address = "Randersvej 42",Name = "Restaurant2",Type = "Buffet"};
            //var rest = selectspecific.getRestaurant("Randersvej 42");
            //var review = new Review() {Text = "Det var godt", Stars = 3};
            //var review2 = new Review() { Text = "Det var ok", Stars = 2};

            //create.addRestaurant(ref rest);

            

            //create.addDish(ref dish, ref rest);
            //create.addReview(ref review, ref rest,ref dish);
            //create.addReview(ref review2, ref rest,ref dish);

            //select.getAllWithType("Buffet");

            //create.addPerson(ref person);
            //create.addWaiter(ref waiter,ref person);
            //create.addTable(ref table,ref rest,ref waiter);
            //create.addGuest(ref guest,ref person,ref table,ref review);
            

            //select.getReviewsBasedOnTable("Randersvej 42");


            //select.SelectRestaurantMenu2("Randersvej 42");
            //Console.ReadLine();
            
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
