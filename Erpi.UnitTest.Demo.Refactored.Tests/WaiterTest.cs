using System.Collections.Generic;
using Erpi.UnitTest.Demo.Refactored.Actors;
using Erpi.UnitTest.Demo.Refactored.Order;
using Erpi.UnitTest.Demo.Refactored.Sender;
using Erpi.UnitTest.Demo.Refactored.Translator;
using Erpi.UnitTest.Demo.Refactored.Verifier;
using Moq;
using NUnit.Framework;

namespace Erpi.UnitTest.Demo.Refactored.Tests
{
    [TestFixture]
    public class WaiterTest
    {
        private Waiter _waiter;
        private Mock<ITranslator<ChefOrder>> _chefOrderTranslator;
        private Mock<ITranslator<CashierOrder>> _cashierOrderTranslator;
        private Mock<IOrderSender<ChefOrder, bool>> _chefOrderSender;
        private Mock<IOrderSender<CashierOrder, Check>> _cashierOrderSender;
        private Mock<ITipVerifier> _tipVerifier;
            
        [SetUp]
        public void Init()
        {
            _chefOrderTranslator = new Mock<ITranslator<ChefOrder>>();
            _cashierOrderTranslator = new Mock<ITranslator<CashierOrder>>();
            _chefOrderSender = new Mock<IOrderSender<ChefOrder, bool>>();
            _cashierOrderSender = new Mock<IOrderSender<CashierOrder, Check>>();
            _tipVerifier = new Mock<ITipVerifier>();

            _chefOrderTranslator.Setup(x => x.Translate(It.IsAny<CustomerOrder>())).Returns(new ChefOrder());
            _cashierOrderTranslator.Setup(x => x.Translate(It.IsAny<CustomerOrder>())).Returns(new CashierOrder());
            _chefOrderSender.Setup(x => x.Send(It.IsAny<ChefOrder>())).Returns(true);
            _cashierOrderSender.Setup(x => x.Send(It.IsAny<CashierOrder>())).Returns(new Check());
            _tipVerifier.Setup(x => x.Verify(It.IsAny<decimal>())).Returns(true);

            _waiter = new Waiter(_chefOrderTranslator.Object, _cashierOrderTranslator.Object, _chefOrderSender.Object, _cashierOrderSender.Object,
                _tipVerifier.Object);
        }

        [Test]
        public void WaiterSuccessfullyProcessOrder()
        {
            var order = new CustomerOrder
            {
                Items =
                    new List<CustomerOrderItem>
                    {
                        new CustomerOrderItem {Name = "American Burger", Type = FoodType.Entree},
                        new CustomerOrderItem {Name = "Diet Coke", Type = FoodType.Drink},
                        new CustomerOrderItem {Name = "Spring Roll", Type = FoodType.Appetizer},
                        new CustomerOrderItem {Name = "Chocolate Icecream", Type = FoodType.Dessert}
                    }
            };
            var check = _waiter.PlaceOrder(order);

            Assert.IsNotNull(check);

            _chefOrderSender.Verify(x => x.Send(It.IsAny<ChefOrder>()), Times.Once);
            _cashierOrderSender.Verify(x => x.Send(It.IsAny<CashierOrder>()), Times.Once);
            _chefOrderSender.Verify(x => x.Send(It.IsAny<ChefOrder>()), Times.Once);
            _cashierOrderSender.Verify(x => x.Send(It.IsAny<CashierOrder>()), Times.Once);
            _tipVerifier.Verify(x => x.Verify(It.IsAny<decimal>()), Times.Once);

            // The following verify will fail because the input 0.01 never happened
            // _tipVerifier.Verify(x => x.Verify(It.Is<decimal>(d => d == (decimal) 0.01)), Times.Once);
        }
    }
}
