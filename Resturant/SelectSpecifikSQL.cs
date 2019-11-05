﻿using System;
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
            List<Review> dataReviews = selectAllSQL.SelectAllReview();
            List<Review> dataOutPut = new List<Review>();
            for (int i = 0; i < dataReviews.Count; i++)
            {
                if(dataReviews[i].Addresse == resturant.Address)
                {
                    dataOutPut.Add(dataReviews[i]);
                    Console.WriteLine(dataReviews[i].ToString());
                }
            }
            
            return dataOutPut;
        }

        
        public List<TableIns> selectTableIns(Restaurant resturant)
        {
            List<TableIns> dataTableIns = selectAllSQL.SelectAllTable();
            List<TableIns> dataOutPut = new List<TableIns>();
            for (int i = 0; i < dataTableIns.Count; i++)
            {
                if (dataTableIns[i].Addresse == resturant.Address)
                {
                    dataOutPut.Add(dataTableIns[i]);
                    Console.WriteLine(dataTableIns[i].ToString());
                }
            }

            return dataOutPut;
        }


        public List<Person> selectPerson(Restaurant resturant)
        {
            List<Person> dataPerson = selectAllSQL.SelectAllPerson();
            List<Person> dataOutPut = new List<Person>();
            for (int i = 0; i < dataPerson.Count; i++)
            {
                if (dataPerson[i].Addresse == resturant.Address)
                {
                    dataOutPut.Add(dataPerson[i]);
                    Console.WriteLine(dataPerson[i].ToString());
                }
            }

            return dataOutPut;
        }
    }
}
