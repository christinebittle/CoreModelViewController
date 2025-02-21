namespace CoreModelViewController.Models
{
    public class ChocolateOrder
    {
        // what pieces of information (fields) describe the chocolate order?

        // {get;set;} refers to HOW we get information, and how we set information
        // property accessor, it can be changed
        public int OrderId { get; set; }

        public string CustomerName { get; set; }

        public string BoxSize { get; set; }

        public string BoxColour { get; set; }

        public decimal SubTotal { get; set; }

        public decimal TaxAmount { get; set; }

        public string TaxLabel { get; set; }

        public decimal OrderTotal { get; set; }
    }
}
