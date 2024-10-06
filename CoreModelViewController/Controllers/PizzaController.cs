using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CoreModelViewController.Controllers
{
    public class PizzaController : Controller
    {
        // GET : /Pizza/Welcome
        public IActionResult Welcome()
        {
            // routes to /Views/Pizza/Welcome.cshtml
            return View();
        }

        // GET : /Pizza/Menu
        public IActionResult Menu()
        {
            // routes to /Views/Pizza/Menu.cshtml
            return View();
        }

        // POST: /Pizza/Order
        // Headers: "Content-Type: application/x-www-form-urlencoded"
        // Form Data:
        // CustomerName={CustomerName}&PizzaSize={PizzaSize}&PizzaToppings={PizzaTopping1}&PizzaToppings={PizzaTopping2}&OrderDrink=OrderDrink&OrderCode={OrderCode}
        [HttpPost]
        public IActionResult Order(string CustomerName, string PizzaSize, List<string> PizzaToppings, string OrderDrink, string OrderCode="")
        {
            Debug.WriteLine($"Customer Name {CustomerName}");
            Debug.WriteLine($"Pizza Size {PizzaSize}");
            Debug.WriteLine($"Toppings {PizzaToppings.Count()}");
            Debug.WriteLine($"Drink {OrderDrink}");
            Debug.WriteLine($"Order Code {OrderCode}");

            decimal OrderSubtotal = 0;

            // available pizza sizes
            Dictionary<string, decimal> AvailableSizes = new Dictionary<string, decimal>()
            {
                { "Small", 10.50M },
                { "Medium", 13.50M },
                { "Large", 15.50M }
            };
            // if the request received a valid size, add it to the order
            if (AvailableSizes.ContainsKey(PizzaSize))
            {
                OrderSubtotal += AvailableSizes[PizzaSize];
            }

            //Available toppings for a pizza
            Dictionary<string, decimal> AvailableToppings = new Dictionary<string, decimal>();
            AvailableToppings["Tomatoes"] = 0.50M;
            AvailableToppings["Broccoli"] = 0.50M;
            AvailableToppings["Pineapple"] = 0.50M;
            AvailableToppings["Green Beans"] = 0.50M;
            AvailableToppings["Ham"] = 1.50M;
            AvailableToppings["Salmon"] = 1.50M;
            AvailableToppings["Anchovies"] = 1.50M;
            AvailableToppings["Hot Sauce"] = 0.00M;

            foreach (string PizzaTopping in PizzaToppings)
            {
                //check each received topping
                if (AvailableToppings.ContainsKey(PizzaTopping))
                {
                    OrderSubtotal += AvailableToppings[PizzaTopping];
                }
            }

            //Note: what if we wanted to store discount codes differently?
            //i.e. an expiration
            Dictionary<string, int> ValidCodes = new Dictionary<string, int>();
            ValidCodes["YUMPIZZA"] = 10;
            ValidCodes["PIE4ME"] = 15;

            decimal PreDiscountSubtotal = OrderSubtotal;

            decimal TotalDiscount = 0M;
            // if the received discount code matches our valid codes
            if (ValidCodes.ContainsKey(OrderCode))
            {
                
                TotalDiscount = Math.Round((OrderSubtotal * (ValidCodes[OrderCode] / 100M)), 2);
                Debug.WriteLine("discount applied");
                Debug.WriteLine(TotalDiscount);
                Debug.WriteLine((ValidCodes[OrderCode] / 100M));
            }

            //note: apply discounts before tax
            //note: example is intended to be realistic, but does not necessarily reflect best practices for order / tax calculations.
            OrderSubtotal -= TotalDiscount;

            //What if we wanted to store taxes in a more structured way?
            //i.e. the pizza store existed in different provinces?
            string OrderTaxName = "HST";
            decimal TaxRate = 13;
            decimal OrderTaxAmt = Math.Round(OrderSubtotal * (TaxRate/100), 2);

            decimal OrderTotal = OrderSubtotal + OrderTaxAmt;

            ViewData["CustomerName"] = CustomerName;
            ViewData["PizzaSize"] = PizzaSize;
            ViewData["Toppings"] = PizzaToppings;
            ViewData["OrderDrink"] = OrderDrink;
            ViewData["OrderCode"] = OrderCode;
            ViewData["TotalDiscount"] = TotalDiscount;

            ViewData["PreDiscountSubtotal"] = PreDiscountSubtotal;
            ViewData["OrderSubTotal"] = OrderSubtotal;
            ViewData["OrderTaxName"] = OrderTaxName;
            ViewData["TaxRate"] = TaxRate;
            ViewData["OrderTaxAmt"] = OrderTaxAmt;
            ViewData["OrderTotal"] = OrderTotal;

            
            // routes to /Views/Pizza/Order.cshtml
            return View();
        }

    }
}
