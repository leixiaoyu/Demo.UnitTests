using System;
using System.Linq;
using Erpi.UnitTest.Demo.Order;

namespace Erpi.UnitTest.Demo.Actors
{
    public class Cashier
    {
        public string Name { get; set; }

        public Check GetCheck(CashierOrder order)
        {
            var random = new Random();
            var checkItems = order.Items.Select(x => new CheckItem { Id = x.Id, Name = x.Name, Price = ((decimal)random.Next(10000)) / 100, Type = x.Type }).ToList();
            var check = new Check {Items = checkItems, Total = checkItems.Sum(x => x.Price), RecommendedTips = checkItems.Sum(x => x.Price) * (decimal) 0.15};
            return check;
        }
    }
}
