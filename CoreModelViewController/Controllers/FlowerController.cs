using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

using CoreModelViewController.Models;

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

        // GET : localhost:xx/Flower/Terms -> A webpage that shows the terms and conditions for the flower order
        public IActionResult Terms()
        {
            // Some kind of way to send information from the Controller to the View
            int Version = 6;
            DateTime LastUpdated = DateTime.Parse("2024-12-20");
            List<string> Terms = new List<string>();
            Terms.Add("Can return within 24 hours");
            Terms.Add("Storing Customer information for orders");
            Terms.Add("Storing Invoice information for orders");

            // We want to represent the idea of legal information for our store

            StoreLegal FlowerLegal = new StoreLegal();
            FlowerLegal.Version = Version;
            FlowerLegal.LastUpdated = LastUpdated;
            FlowerLegal.Terms = Terms;


            // Direct to /Views/Flower/Terms.cshtml
            return View(FlowerLegal);
        }


        // GET : localhost:xx/Flower/OrderHistory -> A webpage which displays three orders
        public IActionResult OrderHistory()
        {
            FlowerOrder Order1 = new FlowerOrder();
            Order1.OrderId = 50;
            Order1.OrderTotal = 100;
            Order1.DeliveryAddress = "101 Test drive";

            FlowerOrder Order2 = new FlowerOrder();
            Order2.OrderId = 51;
            Order2.OrderTotal = 40;
            Order2.DeliveryAddress = "140 Test drive";

            List<FlowerOrder> Orders = new List<FlowerOrder>() { Order1, Order2 };

            return View(Orders);
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

            // calculate the order total
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

            // pass that information along to the view
            FlowerOrder Order = new FlowerOrder();

            Order.DeliveryAddress = OrderAddress;
            Order.NumFlowers = NumFlowers;
            Order.FlowerType = FlowerType;

            Order.SubTotal = Math.Round(SubTotal, 2);
            Order.TaxAmount = Math.Round(Tax,2);
            Order.TaxLabel = "HST";
            Order.OrderTotal = Math.Round(OrderTotal,2);

            // Direct to /Views/Flower/OrderSummary.cshtml
            return View(Order);
        }

    }
}
