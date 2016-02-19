## Scenario

It is a program that models "waiter" in a restaurant, derived from [the robo-restaurant case](http://vistawiki.vistaprint.net/wiki/Robot_restaurant_interview_question). In this restaurant, no customer dines in. All customers are expected to get the check right after their orders are placed.

Customer orders will come in as arguments in the Main function. Orders from customers will come in a JSON format and all information will be English characters. Unfortunately, chefs and cashiers do not understand orders from customers. Chefs use integers to identify different dishes while cashiers have implemented a system that uses GUID to track orders and their prices.

To communicate with chefs, waiters have to put translated orders on sticky notes and put them on a queue. (just like a list of notes hanging above the kitchen window). After sometimes, waiters would be notified ("DING") when foods are ready. In the meantime, waiter should serve other customers.

To communicate with cashiers, waiters can directly hand over the translated orders (in sticky notes as well). Cashiers are super efficient in this place so waiters normally will wait for the check to come back before leaving. More importantly, waiters want to verify the amount of "recommended tips" on the check is correct. After all, it's been a long day.


## Simple system flow

 1. Customers place an order (`CustomerOrder`);
 2. A waiter translates the order into the one that can be understood by chefs (`ChefOrder`);
 3. Hand off `ChefOrder` to a queue;
 4. The waiter translates the order into the one that can be understood by cashiers (`CashierOrder`);
 5. Hand off and wait for cashiers to finish processing the order;