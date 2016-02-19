using System;
using System.Collections.Generic;
using System.Linq;
using Erpi.UnitTest.Demo.Order;

namespace Erpi.UnitTest.Demo.Actors
{
    // In fact, all private functions here can be put inside the public function directly 
    // since function separation here does not provide additional abstraction nor "cleanness".
    // As such, it is not unit test friendly since it has many assumptions on the external 
    // environment that is not exposed, like chef's queue connection.
    public class Waiter
    {
        public string Name { get; set; }

        public Check PlaceOrder(CustomerOrder order)
        {
            var chefOrder = TranslateOrderToChef(order);

            Console.WriteLine("  |  [x] Order has been translated into something that can be understood by chefs");
            if (SendOrderToChefQueue(chefOrder))
            {
                Console.WriteLine("  |  [x] Order has been sent to chef's queue successfully");
                
                // One downside of bundling all logics together is poor testability. For instance, we are not able 
                // to test what will happen to the "TranslateOrderToCashier" function with invalid order data, 
                // because more likely than not the invalid order will be captured by the "TranslateOrderToChef"
                // function

                var cashierOrder = TranslateOrderToCashier(order);
                Console.WriteLine("  |  [x] Order has been translated into something that can be understood by cashiers");
                var check = SendOrderToCashier(cashierOrder);
                Console.WriteLine("  |  [x] Order has been sent to cashier and check was returned");
                var correct = HasCorrectTipAmount(check);
                Console.WriteLine("  |  [x] Tip amount has been verified. Is it correct? {0}", correct.ToString().ToUpper());

                if (!correct)
                {
                    throw new OperationCanceledException("Com'on boss, even a cockroach has demands.");
                }
                return check;
            }
            return null;
        }

        // The translate logic is pretty straightforward in this example
        // But please imaging this goes crazy
        private ChefOrder TranslateOrderToChef(CustomerOrder order)
        {
            var chefOrder = new ChefOrder();
            var chefOrderItems = new List<ChefOrderItem>();
            var incomingItems = order.Items.ToArray();
            for (int i = 0; i < incomingItems.Length; i++)
            {
                var item = new ChefOrderItem {Id = i, Name = incomingItems[i].Name, Type = incomingItems[i].Type};
                chefOrderItems.Add(item);
            }

            chefOrder.Items = chefOrderItems;
            return chefOrder;
        }

        // The translate logic is pretty straightforward in this example
        // But please imaging this goes crazy
        private CashierOrder TranslateOrderToCashier(CustomerOrder order)
        {
            var cashierOrder = new CashierOrder();
            var cashierOrderItems = new List<CashierOrderItem>();
            var incomingItems = order.Items.ToArray();
            foreach (var incomingItem in incomingItems)
            {
                var item = new CashierOrderItem {Id = Guid.NewGuid(), Name = incomingItem.Name, Type = incomingItem.Type};
                cashierOrderItems.Add(item);
            }

            cashierOrder.Items = cashierOrderItems;
            return cashierOrder;
        }

        // Please regard the ChefQueue is something that waiters have no control over
        // The only thing a waiter can do is to put an order onto the queue
        private bool SendOrderToChefQueue(ChefOrder order)
        {
            try
            {
                ChefQueue.Enqueue(order);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        // Please regard the Cashier as external source, which the waiter has no control over
        private Check SendOrderToCashier(CashierOrder order)
        {
            // Think of this step as finding the cashier named Earl for the order
            var cashier = new Cashier { Name = "Earl" };
            var check = cashier.GetCheck(order);
            return check;
        }

        // The waiter should be happy about whatever he/she can get if there is any. 
        // "Beg, people!" says Stowie.
        private bool HasCorrectTipAmount(Check check)
        {
            var tip = check.RecommendedTips;
            return tip > 0;
        }
    }
}
