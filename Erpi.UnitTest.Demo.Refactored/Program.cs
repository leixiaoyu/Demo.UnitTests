using System;
using System.Collections.Generic;
using Erpi.UnitTest.Demo.Refactored.Actors;
using Erpi.UnitTest.Demo.Refactored.Order;
using Erpi.UnitTest.Demo.Refactored.Sender;
using Erpi.UnitTest.Demo.Refactored.Translator;
using Erpi.UnitTest.Demo.Refactored.Verifier;

namespace Erpi.UnitTest.Demo.Refactored
{
    // With dependence injection, the program obeys single responsibility principle, 
    // making it easier to be tested. In fact, almost all codes, expect the ones in 
    // this Program class, can be tested on unit test level. It eliminates the needs 
    // for complex integration level testing. 
    class Program
    {
        // Scenario:
        // 
        // It is a program that models "waiter" in a restaurant. Waiters in this place
        // has to take orders from customers via arguments in the Main function. Orders 
        // from customers will come in a JSON format and all information will be English
        // characters. Unfortunately, chefs and cashiers do not understand orders from 
        // customers. Chefs use integers to identify different dishes while cashiers have 
        // implemented a system that uses GUID to track orders and their prices.
        //
        // To communicate with chefs, waiters have to put translated orders on sticky
        // notes and put them on a queue. (just like a list of notes hanging above the 
        // kitchen window). After sometimes, waiters would be notified ("DING") when 
        // foods are ready. In the meantime, waiter should serve other customers.
        //
        // To communicate with cashiers, waiters can directly hand over the translated 
        // orders (in sticky notes as well). Cashiers are super efficient in this place 
        // so waiters normally will wait for the check to come back before leaving. 
        // More importantly, waiters want to verify the amount of "recommended tips" 
        // on the check is correct. After all, it's been a long day.

        static void Main(string[] args)
        {
            var translatorToChef = new WaiterToChefTranslator();
            var translatorToCashier = new WaiterToCashierTranslator();
            var chefOrderSender = new ChefOrderSender();
            var cashierOrderSender = new CashierOrderSender();
            var tipVerifier = new MinTipVerifier();

            var waiter = new Waiter(translatorToChef, translatorToCashier, chefOrderSender, cashierOrderSender, tipVerifier) {Name = "Robert K. Greenleaf"};

            Console.WriteLine(" [x] Hello, I am Robert G., your personal healthcare companion.");

            var customerOrder = new CustomerOrder
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

            Console.WriteLine(" [x] I have got your order and will place it in. Enjoy!");

            var check = waiter.PlaceOrder(customerOrder);

            Console.WriteLine(" [x] Have a good day. Total amount: {0}; tips: {1}.\n", check.Total, check.RecommendedTips);
            Console.WriteLine("====== ****************************** ======");
            Console.WriteLine(" [x] Press any key to exit...");
            Console.ReadKey();
        }
    }
}
