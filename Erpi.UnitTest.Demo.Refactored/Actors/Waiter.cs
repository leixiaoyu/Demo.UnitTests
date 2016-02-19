using System;
using Erpi.UnitTest.Demo.Refactored.Order;
using Erpi.UnitTest.Demo.Refactored.Sender;
using Erpi.UnitTest.Demo.Refactored.Translator;
using Erpi.UnitTest.Demo.Refactored.Verifier;

namespace Erpi.UnitTest.Demo.Refactored.Actors
{
    // In fact, all private functions here can be put inside the public function directly 
    // since function separation here does not provide additional abstraction nor "cleanness".
    // As such, it is not unit test friendly since it has many assumptions on the external 
    // environment that is not exposed, like chef's queue connection.
    public class Waiter
    {
        #region Private Fields

        private readonly ITranslator<ChefOrder> _translatorToChef;
        private readonly ITranslator<CashierOrder> _translatorToCashier;
        private readonly IOrderSender<ChefOrder, bool> _chefOrderSender;
        private readonly IOrderSender<CashierOrder, Check> _cashierOrderSender;
        private readonly ITipVerifier _tipVerifier;

        #endregion

        public string Name { get; set; }

        // Dependency injection via constructor (the easiest path towards DI)
        // It is a good case of the single responsibility principle 
        public Waiter(ITranslator<ChefOrder> translatorToChef, ITranslator<CashierOrder> translatorToCashier, IOrderSender<ChefOrder, bool> chefOrderSender,
            IOrderSender<CashierOrder, Check> cashierOrderSender, ITipVerifier tipVerifier)
        {
            _translatorToChef = translatorToChef;
            _translatorToCashier = translatorToCashier;
            _chefOrderSender = chefOrderSender;
            _cashierOrderSender = cashierOrderSender;
            _tipVerifier = tipVerifier;
        }

        public Check PlaceOrder(CustomerOrder order)
        {
            var chefOrder = _translatorToChef.Translate(order);

            Console.WriteLine("  |  [x] Order has been translated into something that can be understood by chefs");
            if (_chefOrderSender.Send(chefOrder))
            {
                Console.WriteLine("  |  [x] Order has been sent to chef's queue successfully");
                
                // One downside of bundling all logics together is poor testability. For instance, we are not able 
                // to test what will happen to the "TranslateOrderToCashier" function with invalid order data, 
                // because more likely than not the invalid order will be captured by the "TranslateOrderToChef"
                // function

                var cashierOrder = _translatorToCashier.Translate(order);
                Console.WriteLine("  |  [x] Order has been translated into something that can be understood by cashiers");
                var check = _cashierOrderSender.Send(cashierOrder);
                Console.WriteLine("  |  [x] Order has been sent to cashier and check was returned");
                var correct = _tipVerifier.Verify(check.RecommendedTips);
                Console.WriteLine("  |  [x] Tip amount has been verified. Is it correct? {0}", correct.ToString().ToUpper());

                if (!correct)
                {
                    throw new OperationCanceledException("Com'on boss, even a cockroach has demands.");
                }
                return check;
            }
            return null;
        }
    }
}
