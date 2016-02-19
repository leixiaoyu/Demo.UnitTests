using System;
using Erpi.UnitTest.Demo.Refactored.Order;

namespace Erpi.UnitTest.Demo.Refactored.Sender
{
    // Please regard the ChefQueue is something that waiters have no control over
    // The only thing a waiter can do is to put an order onto the queue
    public class ChefOrderSender : IOrderSender<ChefOrder, bool>
    {
        public bool Send(ChefOrder order)
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
    }
}
