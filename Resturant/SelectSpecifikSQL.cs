using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Resturant
{
    class SelectSpecifikSQL
    {
        public SelectAllSQL selectAllSQL;

        SelectSpecifikSQL()
        {
            selectAllSQL = new SelectAllSQL();
        }

        public List<Review> selectReview(Restaurant resturant)
        {
            //List<Review> dataReviews = selectAllSQL.SelectAllReview();
            List<Review> dataOutPut;// = new List<Review>();
            //for (int i = 0; i < dataReviews.Count; i++)
            //{
            //    if(dataReviews[i].Addresse == resturant.Address)
            //    {
            //        dataOutPut.Add(dataReviews[i]);
            //        Console.WriteLine(dataReviews[i].ToString());
            //    }
            //}

            using (var db = new I4DAB_HandIn2Context())
            {
                dataOutPut = db.Review.Where(reviewOut => reviewOut.Addresse.StartsWith(resturant.Address)).ToList();
            }

            for (int i = 0; i < dataOutPut.Count; i++)
            {
                Console.WriteLine(dataOutPut[i].ToString());
            }

            return dataOutPut;
        }


        public List<TableIns> selectTableIns(Restaurant resturant)
        {
            List<TableIns> dataOutPut;

            using (var db = new I4DAB_HandIn2Context())
            {
                dataOutPut = db.TableIns.Where(reviewOut => reviewOut.Addresse.StartsWith(resturant.Address)).ToList();
            }

            for (int i = 0; i < dataOutPut.Count; i++)
            {
                Console.WriteLine(dataOutPut[i].ToString());
            }

            return dataOutPut;
        }


        public Person selectPerson(int id)
        {
            List<Person> dataOutPut = new List<Person>();

            using (var db = new I4DAB_HandIn2Context())
            {
                //dataOutPut = from item in db.Person where item.PersonId == id select item.PersonId;
                dataOutPut = db.Person.Where(personOut => personOut.PersonId == id).ToList(); //.Select(personOut => personOut.PersonId)
            }

            Console.WriteLine(dataOutPut[0].ToString());

            return dataOutPut[0];
        }


        public List<Waiter> selectWaiter(Person person)
        {
            List<Waiter> dataOutPut = new List<Waiter>();

            using (var db = new I4DAB_HandIn2Context())
            {
                dataOutPut = db.Waiter.Where(waiterOut => waiterOut.PersonId == person.PersonId).ToList();//.Select(personOut => personOut.PersonId).ToList();
            }

            for (int i = 0; i < dataOutPut.Count; i++)
            {
                Console.WriteLine(dataOutPut[i].ToString());
            }

            return dataOutPut;
        }


        public List<WaiterTableIns> selectWaiterTableIns(Waiter waiter, TableIns tableIns)
        {
            List<WaiterTableIns> dataOutPut = new List<WaiterTableIns>();

            using (var db = new I4DAB_HandIn2Context())
            {
                dataOutPut = db.WaiterTableIns.Where(waiterTableInsOut => ((waiterTableInsOut.WaiterId == waiter.WaiterId) && (waiterTableInsOut.TableId == tableIns.TableId))).ToList();
            }

            Console.WriteLine(dataOutPut.ToString());

            return dataOutPut;
        }
    }
}
