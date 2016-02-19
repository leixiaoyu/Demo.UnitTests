using System;
using System.Collections.Generic;

namespace Erpi.UnitTest.Demo.Refactored.Order
{
    public class CashierOrder : IOrder
    {
        public IEnumerable<CashierOrderItem> Items { get; set; }
    }

    public class CashierOrderItem : IOrderItem
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public FoodType Type { get; set; }
    }
}
