using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Resturant.Models;

namespace Resturant
{
    class Program
    {
        
        static void Main(string[] args)
        {

            I4DAB_HandIn2Context db = new I4DAB_HandIn2Context();
            var create = new InsertSQL(db);
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
                        Console.WriteLine("(a): Tilføj restaurant");
                        Console.WriteLine("(e): Vælg eksisterende restaurant");
                        Console.WriteLine("(r): Vis alle restauranter");
                        Console.WriteLine("(t): Vis alle restauranter af type");
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
                                        Console.WriteLine("Fejled save resturant");
                                        Console.WriteLine("Tryk enter for at forsætte");
                                        Console.ReadLine();
                                    }
                                    
                                    Console.WriteLine("Tilføjet. Tryk (i) for at tilføje en ny Restaurant");
                                } while (Console.ReadLine().Equals("i"));
                                break;
                            case "e":
                                Console.WriteLine("Skriv addresse for at vælge restaurant");
                                userAddresse = Console.ReadLine();
                                Console.WriteLine("Indlæser... \n");
                                try
                                {
                                    nyrest = selectspecific.getRestaurant(userAddresse);
                                    menu = "Resturant";
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("Fejlede Indlæser resturant");
                                    Console.WriteLine("Tryk enter for at forsætte");
                                    Console.ReadLine();
                                }
                                
                                break;

                            case "r":
                                Console.WriteLine("Indlæser... \n");
                                try
                                {
                                    selectAll.SelectAllResturant();
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("Fejlede Indlæser restaurant");
                                    Console.WriteLine("Tryk enter for at forsætte");
                                    Console.ReadLine();
                                }

                                Console.WriteLine("Tryk enter for at forsætte");
                                Console.ReadLine();
                                break;

                            case "x":
                                runner = false;
                                break;

                            case "t":
                                Console.WriteLine("Indlæser... \n");
                                try
                                {
                                    Console.Clear();
                                    selectAll.selectAllTypes();
                                    Console.Write("Skriv en type: ");
                                    string type = Console.ReadLine();
                                    select.getAllWithType(type);
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("Fejlede Indlæser restaurant");
                                    Console.WriteLine("Tryk enter for at forsætte");
                                    Console.ReadLine();
                                }
                                Console.WriteLine("Tryk enter for at forsætte");
                                Console.ReadLine();
                                break;
                            default:
                                Console.WriteLine("Forkert indtastning");
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
                                Console.WriteLine("På addressen: " + nyrest.Address.ToString());
                                Console.WriteLine("---------------------------------");
                                Console.WriteLine
                                    (
                                    "0: Tilbage til main menu" + "\n"+
                                    "1: Vis restaurantens menu" + "\n" +
                                    "2: Tilføj en dish" + "\n" +
                                    "3: Tilføj et review til en dish" + "\n" +
                                    "4: Få vist et review for en dish" + "\n" +
                                    "5: Adminstraterer restauranten"
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
                                        resturantMenu = "menuNewReview";
                                        break;

                                    case "4":
                                        resturantMenu = "menuShowReviews";
                                        break;

                                    case "5":
                                        resturantMenu = "menuAdmin";
                                        break;

                                    default:
                                        Console.WriteLine("Forkert indtastning");
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
                                        Console.WriteLine("Fejlede save dish");
                                        Console.WriteLine("Tryk enter for at forsætte");
                                        Console.ReadLine();
                                    }

                                    Console.WriteLine("Skriv (j) for at tilføje endnu en dish. Ellers (n)");
                                    answerDish = Console.ReadLine();
                                }
                                resturantMenu = "mainMenu";
                                break;

                            case "menuShowMenu":
                                Console.WriteLine("Indlæser... \n");

                                try
                                { 
                                    select.SelectRestaurantMenu2(nyrest.Address);
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("Fejlede Indlæser menu");
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
                                    Console.Write("Skriv tekst ");
                                    string tekst = Console.ReadLine();
                                    Console.Write("Skriv antal stjerner ");
                                    int stars = int.Parse(Console.ReadLine());
                                    var review = new Review() { Text = tekst, Stars = stars };

                                    try
                                    { 
                                        create.addReview(ref review, ref nyrest, ref dish);
                                    }
                                    catch (Exception)
                                    {
                                        Console.WriteLine("Fejlede save review");
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
                                Console.WriteLine("Indlæser... \n");
                                
                                try
                                { 
                                    select.SelectRestaurantMenu2(nyrest.Address);
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("Fejlede Indlæser review");
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
                                        Console.WriteLine("På addressen: " + nyrest.Address.ToString());
                                        Console.WriteLine("---------------------------------");
                                        Console.WriteLine("Admin menu:");
                                        Console.WriteLine("---------------------------------");
                                        Console.WriteLine
                                            (
                                            "0: Tilbage til resturant menu" + "\n" +
                                            "1: Tilføj en person" + "\n" +
                                            "2: Vis personer" + "\n" +
                                            "3: Tilføj en waiter" + "\n" +
                                            "4: Vis en waiter" + "\n" +
                                            "5: Tilføj bord" + "\n" +
                                            "6: Vis borde" + "\n" +
                                            "7: Tilføj en guest" + "\n" +
                                            "8: Vis en guest" + "\n" +
                                            "9: Vis alle guests på restauranten"

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
                                            case "9":
                                                adminMenu = "ShowAllGuestsAtRestaurant";
                                                break;

                                            default:
                                                Console.WriteLine("Forkert indtastning");
                                                Console.WriteLine("Tryk enter for at forsætte");
                                                Console.ReadLine();
                                                break;
                                        }
                                        Console.Clear();

                                        break;

                                    case "addPerson":
                                        Console.WriteLine("Skriv navnet for personen:");
                                        string namePerson = Console.ReadLine();
                                        Person personBuf = new Person() { Name = namePerson };

                                        try
                                        {
                                            create.addPerson(ref personBuf);
                                        }
                                        catch (Exception)
                                        {
                                            Console.WriteLine("Fejlede save person");
                                            Console.WriteLine("Tryk enter for at forsætte");
                                            Console.ReadLine();
                                        }

                                        Console.WriteLine("Tryk enter for at forsætte");
                                        Console.ReadLine();
                                        adminMenu = "mainMenu";
                                        break;

                                    case "showPerson":
                                        //Console.WriteLine("Skriv id for personen:");
                                        //int idPerson = int.Parse(Console.ReadLine());
                                        
                                        try
                                        {
                                            selectAll.SelectAllPerson();
                                            //selectspecific.selectPerson(idPerson);
                                        }
                                        catch (Exception)
                                        {
                                            Console.WriteLine("Fejlede Indlæser person");
                                            Console.WriteLine("Tryk enter for at forsætte");
                                            Console.ReadLine();
                                        }

                                        Console.WriteLine("Tryk enter for at forsætte");
                                        Console.ReadLine();
                                        adminMenu = "mainMenu";
                                        break;

                                    case "addWaiter":
                                        Console.WriteLine("Skriv tjernerens salary:");
                                        int salaryWaiter = int.Parse(Console.ReadLine());
                                        Waiter waiterBuf = new Waiter() { Salary = salaryWaiter };

                                        selectAll.SelectAllPerson();

                                        Console.WriteLine("Skriv personens id, som tjerneren hører til :");
                                        int personWaiter = int.Parse(Console.ReadLine());

                                        try
                                        {
                                            Person personBuf2 = selectspecific.selectPerson(personWaiter);
                                            create.addWaiter(ref waiterBuf, ref personBuf2);
                                        }
                                        catch (Exception)
                                        {
                                            Console.WriteLine("Fejlede save waiter");
                                            Console.WriteLine("Tryk enter for at forsætte");
                                            Console.ReadLine();
                                        }

                                        Console.WriteLine("Tryk enter for at forsætte");
                                        Console.ReadLine();
                                        adminMenu = "mainMenu";
                                        break;

                                    case "showWaiter":
                                        selectAll.SelectAllPerson();

                                        Console.WriteLine("Skriv tjernerens person id:");
                                        int waiterPersonNr = int.Parse(Console.ReadLine());
                                        
                                        try
                                        {
                                            Person personBuf3 = selectspecific.selectPerson(waiterPersonNr);
                                            selectspecific.selectWaiter(personBuf3);
                                        }
                                        catch (Exception)
                                        {
                                            Console.WriteLine("Fejlede Indlæser watier");
                                            Console.WriteLine("Tryk enter for at forsætte");
                                            Console.ReadLine();
                                        }

                                        Console.WriteLine("Tryk enter for at forsætte");
                                        Console.ReadLine();
                                        adminMenu = "mainMenu";
                                        break;

                                    case "addTable":
                                        selectspecific.selectTableIns(nyrest);
                                        Console.WriteLine("Skriv nummeret bordet skal have:");
                                        int tableNr = int.Parse(Console.ReadLine());
                                        TableIns tableBuf = new TableIns() { Number = tableNr };

                                        selectAll.SelectAllPerson();

                                        Console.WriteLine("Skriv tjernerens person id:");
                                        int waiterPersonNr1 = int.Parse(Console.ReadLine());

                                        try
                                        {
                                            Person personBuf4 = selectspecific.selectPerson(waiterPersonNr1);
                                            var waiterBuf1 = selectspecific.selectWaiter(personBuf4);
                                            Waiter waiterBuf2 = waiterBuf1[0];
                                            create.addTable(ref tableBuf, ref nyrest, ref waiterBuf2);
                                        }
                                        catch (Exception)
                                        {
                                            Console.WriteLine("Fejlede save table");
                                            Console.WriteLine("Tryk enter for at forsætte");
                                            Console.ReadLine();
                                        }

                                        Console.WriteLine("Tryk enter for at forsætte");
                                        Console.ReadLine();
                                        adminMenu = "mainMenu";
                                        break;

                                    case "showTable":
                                        try
                                        {
                                            selectspecific.selectTableIns(nyrest);
                                        }
                                        catch (Exception)
                                        {
                                            Console.WriteLine("Fejlede Indlæser table");
                                            Console.WriteLine("Tryk enter for at forsætte");
                                            Console.ReadLine();
                                        }

                                        Console.WriteLine("Tryk enter for at forsætte");
                                        Console.ReadLine();
                                        adminMenu = "mainMenu";
                                        break;

                                    case "addGuest":
                                        //Console.WriteLine("Need implementation...");
                                        selectAll.SelectAllPerson();
                                        Console.WriteLine("Skriv personens navn");
                                        var pname = Console.ReadLine();

                                        var gperson = db.Person.Where(p => p.Name.Equals(pname)).FirstOrDefault();

                                        
                                        selectspecific.selectTableIns(nyrest);
                                        Console.WriteLine("Vælg bord id:");

                                        int tableid = int.Parse(Console.ReadLine());
                                        var table = db.TableIns.Where(t => t.TableId == tableid).FirstOrDefault();
                                        
                                        select.SelectRestaurantMenu2(nyrest.Address);

                                        var guest = new Guest() { Reservation = DateTime.Now };
                                        var dishes = new List<Dish>();
                                        do
                                        {
                                            Console.WriteLine("Skriv navn på valgte ret");
                                            var dishName = Console.ReadLine();
                                            dishes.Add(selectspecific.selectADishAtRestaurant(ref nyrest, dishName));
                                            
                                            Console.WriteLine("Vil du tilføje endnu en ret? Skriv (j) for ja; (n) for nej.");
                                        } while (Console.ReadLine().Equals("j"));

                                        Console.WriteLine("Skrive review tekst");
                                        var text = Console.ReadLine();

                                        Console.WriteLine("Skriv tal for antal stjerner (1-6)");
                                        int stars = int.Parse(Console.ReadLine());

                                        var review = new Review(){Text = text,Stars = stars};
                                        
                                        create.addReview(ref review, ref nyrest);

                                        create.addGuest(ref guest,ref gperson,ref table,ref review);

                                        foreach (var dish in dishes)
                                        {
                                            var dish_ = dish;
                                            create.addDishToGuest(ref dish_, ref guest);
                                        }
                                        
                                        //Console.WriteLine("Tryk enter for at forsætte");
                                        //Console.ReadLine();

                                        //Console.WriteLine("Skriv person id:");
                                        //int personNr2 = int.Parse(Console.ReadLine());

                                        //var guest = new Guest() { Reservation = DateTime.Now };

                                        //try
                                        //{
                                        //    Person personBuf5 = selectspecific.selectPerson(personNr2);
                                        //    Choose table
                                        //    Choose review
                                        //    create.addGuest();
                                        //}
                                        //catch (Exception)
                                        //{
                                        //    Console.WriteLine("Fejlede save guest");
                                        //    Console.WriteLine("Tryk enter for at forsætte");
                                        //    Console.ReadLine();
                                        //}

                                        Console.WriteLine("Tryk enter for at forsætte");
                                        Console.ReadLine();
                                        adminMenu = "mainMenu";
                                        break;

                                    case "showGuest":
                                        try
                                        {
                                            selectAll.SelectAllGuestFromRestaurant(nyrest.Address);

                                            Console.WriteLine("Skriv id for gæst");
                                            int guestID = int.Parse(Console.ReadLine());
                                            selectspecific.selectAGuest(guestID);
                                            //Review reviewBuf = selectspecific.selectReview(nyrest)[0];
                                            //TableIns tableInsbuf = selectspecific.selectTableIns(nyrest)[0];
                                            //selectspecific.selectGuest(reviewBuf, tableInsbuf);
                                            
                                        }
                                        catch (Exception)
                                        {
                                            Console.WriteLine("Fejlede Indlæser guest");
                                            Console.WriteLine("Tryk enter for at forsætte");
                                            Console.ReadLine();
                                        }

                                        Console.WriteLine("Tryk enter for at forsætte");
                                        Console.ReadLine();
                                        adminMenu = "mainMenu";
                                        break;

                                    case "ShowAllGuestsAtRestaurant":
                                        try
                                        {
                                            select.getReviewsBasedOnTable(nyrest.Address);
                                            //selectspecific.selectGuestsAtRestaurant(nyrest);
                                        }
                                        catch (Exception)
                                        {
                                            Console.WriteLine("Fejlede Indlæser guest");
                                            Console.WriteLine("Tryk enter for at forsætte");
                                            Console.ReadLine();
                                        }

                                        Console.WriteLine("Tryk enter for at forsætte");
                                        Console.ReadLine();
                                        adminMenu = "mainMenu";
                                        break;

                                }
                                break;

                            default:
                                Console.WriteLine("Forkert indtastning");
                                Console.WriteLine("Tryk enter for at forsætte");
                                Console.ReadLine();
                                break;
                        }
                        break;

                    default:
                        Console.WriteLine("Forkert indtastning");
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
