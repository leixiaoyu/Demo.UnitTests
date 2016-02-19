using System;
using System.Collections.Generic;
using System.Linq;
using Erpi.UnitTest.Demo.Refactored.Order;

namespace Erpi.UnitTest.Demo.Refactored.Translator
{
    public class WaiterToCashierTranslator : ITranslator<CashierOrder>
    {
        public CashierOrder Translate(CustomerOrder order)
        {
            var cashierOrder = new CashierOrder();
            var cashierOrderItems = new List<CashierOrderItem>();
            var incomingItems = order.Items.ToArray();
            foreach (var incomingItem in incomingItems)
            {
                var item = new CashierOrderItem { Id = Guid.NewGuid(), Name = incomingItem.Name, Type = incomingItem.Type };
                cashierOrderItems.Add(item);
            }

            cashierOrder.Items = cashierOrderItems;
            return cashierOrder;
        }
    }
}
