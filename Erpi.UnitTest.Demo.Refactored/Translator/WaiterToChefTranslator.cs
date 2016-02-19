using System.Collections.Generic;
using System.Linq;
using Erpi.UnitTest.Demo.Refactored.Order;

namespace Erpi.UnitTest.Demo.Refactored.Translator
{
    public class WaiterToChefTranslator : ITranslator<ChefOrder>
    {
        public ChefOrder Translate(CustomerOrder order)
        {
            var chefOrder = new ChefOrder();
            var chefOrderItems = new List<ChefOrderItem>();
            var incomingItems = order.Items.ToArray();
            for (int i = 0; i < incomingItems.Length; i++)
            {
                var item = new ChefOrderItem { Id = i, Name = incomingItems[i].Name, Type = incomingItems[i].Type };
                chefOrderItems.Add(item);
            }

            chefOrder.Items = chefOrderItems;
            return chefOrder;
        }
    }
}
