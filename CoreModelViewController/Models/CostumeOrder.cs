namespace CoreModelViewController.Models
{
    public class CostumeOrder
    {
        // This class represents a single costume order
        // What are pieces of information that describe our order?

        // (string) CustomerName
        public string CustomerName { get; set; }
        // (string) CostumeType
        public string CostumeType { get; set; }
        // (string) CostumeSize
        public string CostumeSize { get; set; }
        // (decimal) OrderTotal
        public decimal OrderTotal { get; set; }

        public string OrderNote { get; set; }

        // (DateTime) OrderDate

        // .. We may want to extend this with more information

    }
}
