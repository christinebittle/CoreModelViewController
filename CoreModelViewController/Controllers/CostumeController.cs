using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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

        // POST: /Costume/OrderSummary
        // Header: Content-Type: application/x-www-form-urlencoded
        // FORM DATA: CustomerName={CustomerName}&CostumeType={CostumeType}&CostumeSize={CostumeSize} -> A webpage which shows the order details
        [HttpPost]
        public IActionResult OrderSummary(string CustomerName, string CostumeType, string CostumeSize)
        {
            //test that you have received the information
            Debug.WriteLine("The customer name is "+CustomerName);
            Debug.WriteLine("The Costume Type is " + CostumeType);
            Debug.WriteLine("The Size " + CostumeSize);

            //use ViewData to send information to the View
            ViewData["CustomerName"] = CustomerName;
            ViewData["CostumeType"] = CostumeType;
            ViewData["CostumeSize"] = CostumeSize;

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

            ViewData["OrderTotal"] = OrderTotal; 

            // directs to /Views/Costume/OrderSummary.cshtml
            return View();
        }
    }
}
