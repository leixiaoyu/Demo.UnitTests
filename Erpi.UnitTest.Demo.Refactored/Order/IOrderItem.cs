namespace Erpi.UnitTest.Demo.Refactored.Order
{
    public interface IOrderItem
    {
        string Name { get; set; }
        FoodType Type { get; set; }
    }
}
