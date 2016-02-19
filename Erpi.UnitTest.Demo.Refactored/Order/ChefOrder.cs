using System.Collections.Generic;

namespace Erpi.UnitTest.Demo.Refactored.Order
{
    public class ChefOrder : IOrder
    {
        public IEnumerable<ChefOrderItem> Items { get; set; } 
    }

    public class ChefOrderItem : IOrderItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public FoodType Type { get; set; }
    }
}
