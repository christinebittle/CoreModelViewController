using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CoreModelViewController.Controllers
{
    public class FlowerController : Controller
    {
        // GET: localhost:xx/Flower/Welcome -> A webpage that welcomes the user to our flower store
        public IActionResult Welcome()
        {
            // Direct to /Views/Flower/Welcome.cshtml
            return View();
        }

        // GET : localhost:xx/Flower/Order -> A webpage that asks the user what kinds of flowers they want to buy
        public IActionResult Order()
        {
            // Direct to /Views/Flower/Order.cshtml
            return View();
        }

        // POST: localhost:xx/Flower/OrderSummary
        // HEADER: Content-Type: application/x-www-form-urlencoded
        // FORM DATA: OrderAddr={OrderAddr}&NumFlowers={NumFlowers}&FlowerType={FlowerType}
        [HttpPost]
        public IActionResult OrderSummary(string OrderAddress, int NumFlowers, string FlowerType)
        {
            // TODO: Build view of order summary

            // TODO: Confirm we received the data
            Debug.WriteLine("The address is " + OrderAddress);
            Debug.WriteLine("The number of flowers is "+NumFlowers);
            Debug.WriteLine("The type of flower is "+FlowerType);

            // TODO: calculate the order total
            decimal SubTotal = 0;
            decimal PerFlowerAmount = 0;
            if (FlowerType == "Roses")
            {
                PerFlowerAmount = 4.00M;
            }
            else if (FlowerType == "Tulips")
            {
                PerFlowerAmount = 3.50M;

            } else if (FlowerType=="Sunflowers")
            {
                PerFlowerAmount = 6.00M;
            }
            SubTotal = PerFlowerAmount * NumFlowers;
            decimal Tax = SubTotal * 0.13M; // HST
            decimal OrderTotal = SubTotal + Tax;

            // TODO: pass that information along to the view
            ViewData["OrderAddress"] = OrderAddress;
            ViewData["NumFlowers"] = NumFlowers;
            ViewData["FlowerType"] = FlowerType;

            ViewData["SubTotal"] = Math.Round(SubTotal, 2);
            ViewData["Tax"] = Math.Round(Tax,2);
            ViewData["OrderTotal"] = Math.Round(OrderTotal,2);

            // Direct to /Views/Flower/OrderSummary.cshtml
            return View();
        }

    }
}
