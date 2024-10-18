using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

using CoreModelViewController.Models;

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

        // GET: /Candy/Orders -> A webpage which shows multiple orders
        [HttpGet]
        public IActionResult Orders()
        {
            List<CandyOrder> Orders = new List<CandyOrder>();

            CandyOrder CandyOrder1 = new CandyOrder();
            CandyOrder1.OrderName = "Christine";
            CandyOrder1.CandyNumPieces = 2;
            CandyOrder1.CandyType = "KatKit";
            CandyOrder1.OrderTotal = 5;

            CandyOrder CandyOrder2 = new CandyOrder();
            CandyOrder2.OrderName = "Sean";
            CandyOrder2.CandyNumPieces = 1;
            CandyOrder2.CandyType = "Snackers";
            CandyOrder2.OrderTotal = 2;

            CandyOrder CandyOrder3 = new CandyOrder();
            CandyOrder3.OrderName = "Gary";
            CandyOrder3.CandyNumPieces = 10;
            CandyOrder3.CandyType = "Snackers";
            CandyOrder3.OrderTotal = 13;

            Orders.Add(CandyOrder1);

            Orders.Add(CandyOrder2);

            Orders.Add(CandyOrder3);

            // route to /Views/Candy/Orders.cshtml
            // providing a model of CandyOrders
            return View(Orders);
        }

        // POST: /Candy/Checkout
        // Header: Content-Type: application/x-www-form-urlencoded
        // FORM DATA: OrderAddress={OrderAddress}&CandyNumPieces={CandyNumPieces}&CandyType={CandyType} -> A checkout webpage
        [HttpPost]
        public IActionResult Checkout(string OrderAddress, int CandyNumPieces, string CandyType, string OrderName)
        {
            // Leverage debugging method to check if we receive the information
            Debug.WriteLine("The address is "+OrderAddress);
            Debug.WriteLine("The number of pieces of candy is " + CandyNumPieces);
            Debug.WriteLine("The candy type is "+CandyType);

            

            // GOAL: Use definition of "Candy Order" CandyOrder.cs
            // to send relevant information to the view
            CandyOrder NewCandyOrder = new CandyOrder();
            // NewCandyOrder is an object
            // set the properties for the NewCandyOrder
            NewCandyOrder.OrderAddress = OrderAddress;
            NewCandyOrder.CandyNumPieces = CandyNumPieces;
            NewCandyOrder.CandyType = CandyType;
            NewCandyOrder.OrderName = OrderName;

            
            
            
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
            NewCandyOrder.OrderTotal = OrderTotal;

            

            // Route to /Views/Candy/Checkout.cshtml
            // Pass along the structured information to the view
            return View(NewCandyOrder);
        }

    }
}
