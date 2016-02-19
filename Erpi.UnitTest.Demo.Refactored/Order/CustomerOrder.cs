using System.Collections.Generic;

namespace Erpi.UnitTest.Demo.Refactored.Order
{
    public class CustomerOrder : IOrder
    {
        public IEnumerable<CustomerOrderItem> Items { get; set; }
    }

    public class CustomerOrderItem : IOrderItem
    {
        public string Name { get; set; }
        public FoodType Type { get; set; }
    }
}
