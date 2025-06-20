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

        [HttpGet]
        public IActionResult Test()
        {
            // Direct to /Views/SummerStore/Test.cshtml
            return View();
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

            // send order information to /Checkout.cshtml
            // Temporary technique: ViewData
            ViewData["CustomerName"] = CustomerName;
            ViewData["NumPopscicles"] = NumPopscicles;
            ViewData["IceCreamFlavor"] = IceCreamFlavor;

            decimal PopscicleCost = 0.50M;

            // placeholder, we will compute the order total later
            decimal SubTotal = NumPopscicles * PopscicleCost;
            decimal TaxRate = 0.13M;
            decimal HstAmt = SubTotal * TaxRate;

            // todo: round and format currency
            ViewData["SubTotal"] = SubTotal;
            ViewData["HstAmt"] = HstAmt;
            ViewData["HstRate"] = "13%";
            ViewData["OrderTotal"] = SubTotal + HstAmt;



            // Directs to /Views/SummerStore/Checkout.cshtml
            return View();
        }

    }
}
