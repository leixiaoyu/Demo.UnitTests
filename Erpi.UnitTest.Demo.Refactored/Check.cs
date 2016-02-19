using System;
using System.Collections.Generic;

namespace Erpi.UnitTest.Demo.Refactored
{
    public class Check
    {
        public decimal Total { get; set; }
        public decimal RecommendedTips { get; set; }
        public IEnumerable<CheckItem> Items { get; set; }
    }

    public class CheckItem
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public FoodType Type { get; set; }

        public decimal Price { get; set; }
    }
}
