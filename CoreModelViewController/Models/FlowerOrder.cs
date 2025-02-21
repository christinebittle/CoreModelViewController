namespace CoreModelViewController.Models
{
    public class FlowerOrder
    {
        // What are pieces of information that describe a flower order?

        // order reference
        public int OrderId { get; set; }

        // The number of flowers
        public int NumFlowers { get; set; }
        
        // the address to send the flowers to
        public string DeliveryAddress { get; set; }

        // the flower type
        public string FlowerType { get; set; }

        // the subtotal of the order
        public decimal SubTotal { get; set; }

        // the tax amount of the order
        public decimal TaxAmount { get; set; }

        // the tax label of the order
        public string TaxLabel { get; set; }

        // the final amount
        public decimal OrderTotal { get; set; }
    }
}
