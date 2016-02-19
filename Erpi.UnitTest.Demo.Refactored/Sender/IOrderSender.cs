using Erpi.UnitTest.Demo.Refactored.Order;

namespace Erpi.UnitTest.Demo.Refactored.Sender
{
    public interface IOrderSender<in T, out V> where T : IOrder
    {
        V Send(T order);
    }
}
