using System;
using System.Collections.Generic;

namespace Erpi.UnitTest.Demo.Order
{
    public class CashierOrder
    {
        public IEnumerable<CashierOrderItem> Items { get; set; }
    }

    public class CashierOrderItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public FoodType Type { get; set; }
    }
}
