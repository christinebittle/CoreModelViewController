using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CoreModelViewController.Controllers
{
    public class CandyController : Controller
    {
        // GET : /Candy/Welcome -> A webpage that welcomes our user to the Halloween candy store
        [HttpGet]
        public IActionResult Welcome()
        {
            // Routes to /Views/Candy/Welcome.cshtml
            return View();
        }

        // GET : /Candy/Shop -> A webpage that asks the user what kind candy they want to order
        [HttpGet]
        public IActionResult Shop()
        {
            // Route to /Views/Candy/Shop.cshtml
            return View();
        }

        // POST: /Candy/Checkout
        // Header: Content-Type: application/x-www-form-urlencoded
        // FORM DATA: OrderAddress={OrderAddress}&CandyNumPieces={CandyNumPieces}&CandyType={CandyType} -> A checkout webpage
        [HttpPost]
        public IActionResult Checkout(string OrderAddress, int CandyNumPieces, string CandyType)
        {
            // Leverage debugging method to check if we receive the information
            Debug.WriteLine("The address is "+OrderAddress);
            Debug.WriteLine("The number of pieces of candy is " + CandyNumPieces);
            Debug.WriteLine("The candy type is "+CandyType);

            //ViewData to communicate information to the view as key value pairs
            ViewData["OrderAddress"] = OrderAddress;
            ViewData["CandyNumPieces"] = CandyNumPieces;
            ViewData["CandyType"] = CandyType;

            
            decimal PerPiece = 0m;

            if(CandyType== "Snackers")
            {
                PerPiece = 3m;

            } else if (CandyType== "KatKit")
            {
                PerPiece = 2.50m;

            } else if (CandyType== "Jupiters")
            {
                PerPiece = 2.75m;
            }

            decimal OrderTotal = Math.Round(CandyNumPieces * PerPiece,2);

            ViewData["OrderTotal"] = OrderTotal;

            // Route to /Views/Candy/Checkout.cshtml
            return View();
        }

    }
}
