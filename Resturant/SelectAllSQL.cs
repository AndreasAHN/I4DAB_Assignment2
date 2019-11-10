using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Internal;
using Microsoft.EntityFrameworkCore.Scaffolding.Internal;
using Resturant.Models;

namespace Resturant
{
    public class SelectAllSQL
    {
        public SelectAllSQL()
        {

        }

        public List<Restaurant> SelectAllResturant()
        {
            using(var db = new I4DAB_HandIn2Context())
            {
                var resturants = db.Restaurant.ToList();
                foreach (var rest in resturants)
                {
                    Console.WriteLine(rest.Name);
                    Console.WriteLine("Type: "+rest.Type);
                    Console.WriteLine("Addresse: "+rest.Address);
                    Console.WriteLine();
                }
                return resturants.ToList();
            }
        }

        
        public List<Review> SelectAllReview()
        {
            using (var db = new I4DAB_HandIn2Context())
            {
                var review = db.Review.ToList();

                return review;
            }
        }

        public List<Dish> SelectAllDish()
        {
            using (var db = new I4DAB_HandIn2Context())
            {
                var dish = db.Dish.ToList();

                return dish.ToList();
            }
        }

        public List<Guest> SelectAllGuestFromRestaurant(string addresse)
        {
            using (var db = new I4DAB_HandIn2Context())
            {
                Console.WriteLine("Gæster på bordene i restauranten:");
                var tables = db.TableIns.Where(t => t.Addresse.Equals(addresse));

                var guestsCollection = from t in tables select t.Guest;

                foreach (var guests in guestsCollection)
                {
                    foreach (var guest in guests)
                    {
                        Console.WriteLine("ID: "+guest.GuestId);
                        var person = db.Person.Where(p => p.PersonId == guest.FkPersonId).First();
                        Console.WriteLine("Navn: "+person.Name);

                        var dishnumbers = db.GuestDish.Where(d => d.GuestId == guest.GuestId);
                        var dishes = from dn in dishnumbers select dn.Dish;
                        Console.WriteLine("Spiste retter:");
                        foreach (var dish in dishes)
                        {
                            Console.WriteLine("\tNavn: "+dish.Name);
                            Console.WriteLine("\tPris: " + dish.Price);
                            Console.WriteLine("\tType: " + dish.Type);
                            Console.WriteLine("-----------------");
                        }

                        if (db.Review.Where(r => r.ReviewId == guest.ReviewId).Any())
                        {
                            var review = db.Review.Where(r => r.ReviewId == guest.ReviewId).First();
                            Console.WriteLine("Review: "+review.Text);
                            Console.WriteLine("Stjerner: "+review.Stars);
                            Console.WriteLine();
                        }

                        Console.WriteLine();
                    }
                }
                return null;
            }
        }

        public List<Person> SelectAllPerson()
        {
            using (var db = new I4DAB_HandIn2Context())
            {
                var persons = db.Person.ToList();

                Console.WriteLine("Tilgængelige personer:");

                foreach (var person in persons)
                {
                    Console.Write("Navn: ");
                    Console.WriteLine(person.Name);
                    Console.Write("ID: ");
                    Console.WriteLine(person.PersonId);
                    if (db.Waiter.Where(w => w.PersonId == person.PersonId).Any())
                        Console.WriteLine("Er waiter");
                    if(db.Guest.Where(g => g.FkPersonId == person.PersonId).Any())
                        Console.WriteLine("Er gæst");
                    Console.WriteLine();
                }
                
                Console.WriteLine();

                return persons.ToList();
            }
        }

        public List<Waiter> ReadWaiter()
        {
            using (var db = new I4DAB_HandIn2Context())
            {
                var waiters = db.Waiter.ToList();
                Console.WriteLine("Waiters:");
                foreach (var waiter in waiters)
                {
                    Console.WriteLine("ID: "+waiter.WaiterId);
                    Console.WriteLine("Navn: "+waiter.Person.Name);
                    Console.WriteLine("Løn: "+waiter.Salary);
                    Console.WriteLine();
                }
                return waiters;
            }
        }

        public List<TableIns> SelectAllTable()
        {
            using (var db = new I4DAB_HandIn2Context())
            {
                var tableIns = db.TableIns.ToList();

                return tableIns.ToList();
            }
        }

        public void selectAllTypes()
        {
            using (var db = new I4DAB_HandIn2Context())
            {
                Console.WriteLine("Restauranters typer:");
                var rests = db.Restaurant.Select(r => r.Type).Distinct().ToList();
                foreach (var rest in rests)
                {
                    Console.WriteLine("\t"+rest);
                }
                Console.WriteLine();
            }
            
        }
        public void SelectAllTabletoRestaurant(string addresse)
        {
            using (var db = new I4DAB_HandIn2Context())
            {
                var rest = db.Restaurant.Where(r => r.Address.Equals(addresse)).First();
                Console.WriteLine("Borde for restaurant "+rest.Name);

                foreach (var table in rest.TableIns)
                {
                    Console.WriteLine("Bord nr. "+table.Number);
                }
                Console.WriteLine();
            }
        }

        public List<WaiterTableIns> SelectAllWaiterTablelns()
        {
            using (var db = new I4DAB_HandIn2Context())
            {
                var waiterTableIns = db.WaiterTableIns.ToList();

                return waiterTableIns.ToList();
            }
        }
    }
}
