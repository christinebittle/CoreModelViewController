using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;
using CoreModelViewController.Models;

namespace CoreModelViewController.Controllers
{
    // MVC Controller
    // produces the webpage response from an input request
    public class ChocolateController : Controller
    {
        // GET : localhost:xx/Chocolate/Welcome -> A webpage that welcomes the user to our valentines chocolate store
        public IActionResult Welcome()
        {
            // Direct to /Views/Chocolate/Welcome.cshtml
            return View();
        }

        // GET : localhost:xx/Chocolate/Order -> A webpage that allows the user to enter in their order information
        [HttpGet]
        public IActionResult Order()
        {
            // Direct to /Views/Chocolate/Order.cshtml
            return View();
        }

        // GET: /Chocolate/OrderHistory -> Produces a webpage that lists out three orders with different IDs
        public IActionResult OrderHistory()
        {
            

            ChocolateOrder Order1 = new ChocolateOrder();
            // am I getting or setting in these lines?
            // setting
            Order1.OrderId = 1;
            Order1.CustomerName = "Christine";
            Order1.OrderTotal = 10;

            ChocolateOrder Order2 = new ChocolateOrder();
            Order2.OrderId = 2;
            Order2.CustomerName = "Gary";
            Order2.OrderTotal = 20;

            ChocolateOrder Order3 = new ChocolateOrder();
            Order3.OrderId = 3;
            Order3.CustomerName = "Sean";
            Order3.OrderTotal = 15;

            List<ChocolateOrder> Orders = new List<ChocolateOrder>() { Order1, Order2, Order3};

            // Direct us to /Views/Chocolate/OrderHistory.cshtml
            return View(Orders);
        }

        // POST: localhost:xx/Chocolate/OrderSummary -> A webpage that summarizes the order information
        // HEADER: Content-Type: application/x-www-form-urlencoded
        // FORM DATA: ?CustomerName={CustomerName}&ChocolateBoxSize={ChocolateBoxSize}&ChocolateBoxColour={ChocolateBoxColour}
        [HttpPost]
        public IActionResult OrderSummary(string CustomerName, string ChocolateBoxSize, string ChocolateBoxColour)
        {
            Debug.WriteLine("The Customer Name is " + CustomerName);
            Debug.WriteLine("The Chocolate size is" + ChocolateBoxSize);
            Debug.WriteLine("The Box Colour is " + ChocolateBoxColour);

            ChocolateOrder NewOrder = new ChocolateOrder();

            NewOrder.OrderId = 100; //ideally set from a data source

            // How can I forward this information back to the webpage?
            NewOrder.CustomerName = CustomerName;
            NewOrder.BoxSize = ChocolateBoxSize;
            NewOrder.BoxColour = ChocolateBoxColour;

            // TODO: Get the order total
            // Use an IF statement on the Chocolate Size
            // And add HST 13%
            decimal SubTotal = 0;
            if (ChocolateBoxSize == "S")
            {
                SubTotal = 10M;

            }
            else if (ChocolateBoxSize == "M")
            {
                SubTotal = 15M;
            }
            else if (ChocolateBoxSize == "L")
            {
                SubTotal = 17M;
            }

            decimal HST = SubTotal * 0.13M;
            decimal OrderTotal = SubTotal + HST;

            Debug.WriteLine("HST is" + HST);
            Debug.WriteLine("Subtotal is" + SubTotal);
            Debug.WriteLine("Total is " + OrderTotal);

            NewOrder.TaxAmount = HST;
            NewOrder.TaxLabel = "HST";
            NewOrder.SubTotal = SubTotal;
            NewOrder.OrderTotal = OrderTotal;


            // Direct to /Views/Chocolate/OrderSummary.cshtml
            return View(NewOrder);
        }


        // GET : /Chocolate/Terms -> A webpage output for a terms and conditions page for our store
        public IActionResult Terms()
        {
            //
            int TermsVersion = 2;
            // How can we pass this information to the view?

            

            DateTime LastUpdated = DateTime.Parse("2025-02-16");
            

            List<string> Terms = new List<string>();
            Terms.Add("Storage of information");
            Terms.Add("Purchase receipts for chocolates");
            Terms.Add("Final Sale of chocolates");

            // use the store legal concept to pass information
            // from the controller to the view.
            // constructing a ChocolateLegal Object from the StoreLegal class
            StoreLegal ChocolateLegal = new StoreLegal();
            ChocolateLegal.Terms = Terms;
            ChocolateLegal.Version = TermsVersion;
            ChocolateLegal.LastUpdated = LastUpdated;

            // Directs to /Views/Chocolate/Terms.cshtml
            // The model is now passed to the View
            return View(ChocolateLegal);
        }
    }
}
