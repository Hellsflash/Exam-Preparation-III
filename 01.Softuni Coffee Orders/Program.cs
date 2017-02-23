using System;
using System.Globalization;

namespace Tests
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var numberOfOrders = int.Parse(Console.ReadLine());
            decimal resultForOneOrder = 0.0M;
            decimal totalPrice = 0.0M;

            for (int i = 0; i < numberOfOrders; i++)
            {
                var capsulePrice = decimal.Parse(Console.ReadLine());
                var orderDate = DateTime.ParseExact(Console.ReadLine(), "d/M/yyyy", CultureInfo.InvariantCulture);
                var capsulesCount = decimal.Parse(Console.ReadLine());

                var daysInMonth = DateTime.DaysInMonth(orderDate.Year, orderDate.Month);

                resultForOneOrder = (daysInMonth * capsulesCount) * capsulePrice;

                totalPrice += resultForOneOrder;

                Console.WriteLine($"The price for the coffee is: ${resultForOneOrder:f2}");

            }

            Console.WriteLine($"Total: ${totalPrice:f2}");
        }
    }
}
