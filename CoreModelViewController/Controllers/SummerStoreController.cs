using CoreModelViewController.Models;
using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;

namespace CoreModelViewController.Controllers
{
    public class SummerStoreController : Controller
    {

        // GET: /SummerStore/Welcome ->
        // RESPONSE HEADER:
        // Content-Type: text/html
        // RESPONSE BODY:
        // HTML text that welcomes the user to the summer store
        [HttpGet]
        public IActionResult Welcome()
        {
            // Direct to /Views/SummerStore/Welcome.cshtml
            return View();
        }

        // GET: /SummerStore/Order -> 
        // produce an output of a web page that asks the user what they want to buy
        [HttpGet]
        public IActionResult Order()
        {
            // Direct to /Views/SummerStore/Order.cshtml
            return View();
        }

        // purpose: show multiple orders for an admin panel
        [HttpGet]
        public IActionResult AdminOrders()
        {
            PopscicleOrder Order1 = new PopscicleOrder();
            Order1.CustomerName = "Christine";
            Order1.PopscicleFlavor = "O";
            Order1.PopscicleCost = 0.5M;
            Order1.PopscicleAmt = 5;
           
            Order1.OrderTaxRate = 0.13M;
            Order1.OrderTaxLabel = "HST";
            

            PopscicleOrder Order2 = new PopscicleOrder();
            Order2.CustomerName = "Sean";
            Order2.PopscicleFlavor = "C";
            Order2.PopscicleCost = 0.5M;
            Order2.PopscicleAmt = 10;
            
            Order2.OrderTaxRate = 0.13M;
            Order2.OrderTaxLabel = "HST";
           

            PopscicleOrder Order3 = new PopscicleOrder();
            Order3.CustomerName = "Bernie";
            Order3.PopscicleFlavor = "S";
            Order3.PopscicleCost = 0.5M;
            Order3.PopscicleAmt = 3;
            
            Order3.OrderTaxRate = 0.13M;
            Order3.OrderTaxLabel = "HST";
            

            List<PopscicleOrder> Orders = new List<PopscicleOrder>();
            Orders.Add(Order1); // Christine's order
            Orders.Add(Order2); // Sean's Order
            Orders.Add(Order3); // Bernie's Order

            // Direct to /Views/SummerStore/Order.cshtml
            return View(Orders);
        }




        // POST: /SummerStore/Checkout
        // Content-Type: application/x-www-form-urlencoded
        // DATA: CustomerName={CustomerName}&NumPopscicles={NumPopscicles}&IceCreamFlavor={IceCreamFlavor} ->
        // A webpage indicating an order summary
        [HttpPost]
        public IActionResult Checkout(string CustomerName, int NumPopscicles, string IceCreamFlavor)
        {
            Debug.WriteLine("I have received data from a POST request");
            Debug.WriteLine(CustomerName);
            Debug.WriteLine(NumPopscicles);
            Debug.WriteLine(IceCreamFlavor);

            // start to use a model to represent the popscicle order
            PopscicleOrder NewOrder = new PopscicleOrder();
            NewOrder.CustomerName = CustomerName;
            NewOrder.PopscicleFlavor = IceCreamFlavor;
            NewOrder.PopscicleCost = 0.5M;
            NewOrder.PopscicleAmt = NumPopscicles;
            
            NewOrder.OrderTaxRate = 0.13M;
            NewOrder.OrderTaxLabel = "HST";
            

            // Directs to /Views/SummerStore/Checkout.cshtml with NewOrder Object
            return View(NewOrder);
        }

    }
}
