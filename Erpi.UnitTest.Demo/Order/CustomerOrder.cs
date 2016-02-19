using System.Collections.Generic;

namespace Erpi.UnitTest.Demo.Order
{
    public class CustomerOrder
    {
        public IEnumerable<CustomerOrderItem> Items { get; set; } 
    }

    public class CustomerOrderItem
    {
        public string Name { get; set; }
        public FoodType Type { get; set; }
    }
}
