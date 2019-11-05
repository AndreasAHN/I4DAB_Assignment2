using System;

namespace Resturant
{
    class Program
    {
        static void Main(string[] args)
        {
            SelectAllSQL selectAllSQL = new SelectAllSQL();
            var data = selectAllSQL.SelectAllResturant();
            Console.WriteLine(data[0].ToString());
        }
    }
}
