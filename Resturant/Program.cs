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

            var rest = new Restaurant(){Address = "Finlandsgade 2",Name = "Flammen",Type = "Buffet"};
            var review = new Review() {Text = "Det var fint", Stars = 5};

            create.addRestaurant(ref rest);
            selectAll.SelectAllResturant();

            create.addReview(ref review, ref rest);
            select.getAllWithType("Buffet");
            //SelectAllSQL selectAllSQL = new SelectAllSQL();
            //var data = selectAllSQL.SelectAllResturant();
            //Console.WriteLine(data[0].ToString());
        }
    }
}
