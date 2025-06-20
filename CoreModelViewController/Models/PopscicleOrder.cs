namespace CoreModelViewController.Models
{
    public class PopscicleOrder
    {
        // We are going to describe a popscicle order

        // What describes our order?

        // customer name
        public string CustomerName { get; set; }

        // number of popscicles
        public int PopscicleAmt { get; set; }

        public decimal PopscicleCost { get; set; }

        // popscicle flavor
        public string PopscicleFlavor { get; set; }

        // order subtotal
        public decimal OrderSubtotal
        { 
            get { return PopscicleAmt * PopscicleCost; }
        }

        public decimal OrderTaxRate { get; set; }

        // order tax amount
        public decimal OrderTaxAmt
        { 
            get { return OrderSubtotal * OrderTaxRate; } 
        }

        // order tax label
        public string OrderTaxLabel { get; set; }

        // order total
        public decimal OrderTotal
        {
            get { return OrderSubtotal + OrderTaxAmt; }
        }

    }
}
