using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;

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

        // POST: localhost:xx/Chocolate/OrderSummary -> A webpage that summarizes the order information
        // HEADER: Content-Type: application/x-www-form-urlencoded
        // FORM DATA: ?CustomerName={CustomerName}&ChocolateBoxSize={ChocolateBoxSize}&ChocolateBoxColour={ChocolateBoxColour}
        [HttpPost]
        public IActionResult OrderSummary(string CustomerName, string ChocolateBoxSize, string ChocolateBoxColour)
        {
            Debug.WriteLine("The Customer Name is " + CustomerName);
            Debug.WriteLine("The Chocolate size is" + ChocolateBoxSize);
            Debug.WriteLine("The Box Colour is " + ChocolateBoxColour);


            // How can I forward this information back to the webpage?
            ViewData["CustomerName"] = CustomerName;
            ViewData["ChocolateSize"] = ChocolateBoxSize;
            ViewData["ChocolateBoxColour"] = ChocolateBoxColour;

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

            ViewData["Tax"] = HST;
            ViewData["OrderSubTotal"] = SubTotal;
            ViewData["OrderTotal"] = OrderTotal;


            // Direct to /Views/Chocolate/OrderSummary.cshtml
            return View();
        }
    }
}
