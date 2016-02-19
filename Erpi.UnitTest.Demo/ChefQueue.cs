using System.Collections.Generic;
using Erpi.UnitTest.Demo.Order;

namespace Erpi.UnitTest.Demo
{
    internal class ChefQueue
    {
        private static IList<ChefOrder> OrdersInWaiting{ get; set; }

        public static void Enqueue(ChefOrder order)
        {
            if (OrdersInWaiting == null)
            {
                OrdersInWaiting = new List<ChefOrder>();
            }
            OrdersInWaiting.Add(order);
        }
    }
}
