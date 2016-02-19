using Erpi.UnitTest.Demo.Refactored.Actors;
using Erpi.UnitTest.Demo.Refactored.Order;

namespace Erpi.UnitTest.Demo.Refactored.Sender
{
    // Please regard the Cashier as external source, which the waiter has no control over
    public class CashierOrderSender : IOrderSender<CashierOrder, Check>
    {
        public Check Send(CashierOrder order)
        {
            // Think of this step as finding the cashier named Earl for the order
            var cashier = new Cashier { Name = "Earl" };
            var check = cashier.GetCheck(order);
            return check;
        }
    }
}
