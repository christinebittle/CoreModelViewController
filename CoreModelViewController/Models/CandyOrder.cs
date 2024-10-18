namespace CoreModelViewController.Models
{
    public class CandyOrder
    {
        // We are describing the idea of a Candy Order

        // What pieces of information desribe a Candy Order?
        // (string) Address of Order

        public string OrderName { get; set; }

        public string OrderAddress { get; set; }
        // (string) Type of candy we want
        public string CandyType { get; set; }
        // (int) Qty of candy
        public int CandyNumPieces { get; set; }

        // (decimal) Order total
        public decimal OrderTotal { get; set; }

        //.. we can extend this later on with more information
        // eg. OrderTax
    }
}
