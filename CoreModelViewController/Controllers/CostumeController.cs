using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

using CoreModelViewController.Models;

namespace CoreModelViewController.Controllers
{
    public class CostumeController : Controller
    {
        // GET: /Costume/Welcome -> A webpage which welcomes the user to our costume store
        [HttpGet]
        public IActionResult Welcome()
        {
            // directs to /Views/Costume/Welcome.cshtml
            return View();
        }

        // GET : /Costume/Store -> A webpage which asks the user what kind of costume they want to buy
        [HttpGet]
        public IActionResult Store()
        {
            // directs to /Views/Costume/Store.cshtml
            return View();
        }

        // GET: /Costume/Orders -> A webpage which shows multiple costume orders
        [HttpGet]
        public IActionResult Orders()
        {
            //get some costume orders
            CostumeOrder Order1 = new CostumeOrder();
            Order1.CustomerName = "Christine";
            Order1.CostumeType = "Frakenstein";
            Order1.CostumeSize = "Adult";
            Order1.OrderTotal = 50;

            CostumeOrder Order2 = new CostumeOrder();
            Order2.CustomerName = "Gary";
            Order2.CostumeType = "Frozen";
            Order2.CostumeSize = "Kid";
            Order2.OrderTotal = 25;

            CostumeOrder Order3 = new CostumeOrder();
            Order3.CustomerName = "Sean";
            Order3.CostumeType = "Alien";
            Order3.CostumeSize = "Adult";
            Order3.OrderTotal = 75;

            List<CostumeOrder> Orders = new List<CostumeOrder>();
            Orders.Add(Order1);
            Orders.Add(Order2);
            Orders.Add(Order3);


            // directs to /Views/Costume/Orders.cshtml
            return View(Orders);
        }

        // POST: /Costume/OrderSummary
        // Header: Content-Type: application/x-www-form-urlencoded
        // FORM DATA: CustomerName={CustomerName}&CostumeType={CostumeType}&CostumeSize={CostumeSize}&OrderNote={OrderNote} -> A webpage which shows the order details
        [HttpPost]
        public IActionResult OrderSummary(string CustomerName, string CostumeType, string CostumeSize, string OrderNote)
        {
            //test that you have received the information
            Debug.WriteLine("The customer name is "+CustomerName);
            Debug.WriteLine("The Costume Type is " + CostumeType);
            Debug.WriteLine("The Size " + CostumeSize);

            //use ViewData to send information to the View
            // ViewData["CustomerName"] = CustomerName;
            // ViewData["CostumeType"] = CostumeType;
            // ViewData["CostumeSize"] = CostumeSize;

            CostumeOrder NewCostumeOrder = new CostumeOrder();
            NewCostumeOrder.CustomerName = CustomerName;
            NewCostumeOrder.CostumeType = CostumeType;
            NewCostumeOrder.CostumeSize = CostumeSize;
            NewCostumeOrder.OrderNote = OrderNote;


            //GOAL: define the idea of a CostumeOrder
            // once we have this definition, we will be able to use it across our project

            //todo: compute order total
            decimal VampirePrice = 50.99m;
            decimal GhostPrice = 30.99m;
            decimal CatPrice = 40.99m;

            decimal OrderTotal = 0m;

            if (CostumeType == "Vampire")
            {
                OrderTotal += VampirePrice;

            }else if( CostumeType == "Ghost")
            {

                OrderTotal += GhostPrice;

            }else if (CostumeType=="Cat")
            {
                OrderTotal += CatPrice;
            }

            if (CostumeSize == "Adult")
            {
                OrderTotal += 10;
            }

            //ViewData["OrderTotal"] = OrderTotal; 

            NewCostumeOrder.OrderTotal = OrderTotal;

            // directs to /Views/Costume/OrderSummary.cshtml
            // pass along a CostumeOrder object to View
            return View(NewCostumeOrder);
        }
    }
}
