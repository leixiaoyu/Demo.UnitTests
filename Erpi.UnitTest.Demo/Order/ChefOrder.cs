using System.Collections.Generic;

namespace Erpi.UnitTest.Demo.Order
{
    public class ChefOrder
    {
        public IEnumerable<ChefOrderItem> Items { get; set; } 
    }

    public class ChefOrderItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public FoodType Type { get; set; }
    }
}
