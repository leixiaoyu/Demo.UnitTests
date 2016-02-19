using Erpi.UnitTest.Demo.Refactored.Order;

namespace Erpi.UnitTest.Demo.Refactored.Translator
{
    public interface ITranslator<T> where T : IOrder
    {
        T Translate(CustomerOrder order);
    }
}
