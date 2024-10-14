namespace CoreModelViewController.Models
{
    public class PizzaOrder
    {

        // This model defines a Pizza Order!
        // The class is Pizza Order, which defines what information a Pizza Order should have.
        // It can enforce the definitions through property accessors (getters and setters)
        // When we have the information we need, we can create an instance of the Pizza Order class as an object.
        // Inside the class, each piece of information is a field.
        // The means to access (get) or modify (set) field values are done through properties.
        // Properties are external (public) while fields are internal (private)

        // our private representation of the Customer's Name.
        private string? _customerName { get; set; }

        // its public property accessor
        public string? CustomerName
        {
            get { return _customerName; }
            set { _customerName = value; }
        }

        // non-accessible outside this file
        private DateTime _orderDate;

        // read-only (no set method)
        // get property accessor can be changed without modifying the underlying _orderDate property
        public string OrderDate
        {
            get { return _orderDate.ToString("yyyy-MM-dd HH:mm:ss"); }
        }

        // {get;set;} is shorthand "auto implemented property"
        public string? PizzaSize { get; set; }
        public List<String>? PizzaToppings { get; set; }
        public string? OrderDrink { get; set; }

        public decimal? OrderPreTotal { get; set; }

        public string? OrderCode { get; set; }

        public decimal? OrderDiscountTotal { get; set; }

        public decimal? OrderSubTotal { get; set; }

        public string? OrderTaxName { get; set; }

        public decimal OrderTaxRate { get; set; }

        public decimal OrderTaxAmt { get; set; }

        public decimal? OrderTotal { get; set; }


        // This is a constructor function
        // It runs whenever the Pizza Order is initialized as an object
        // We are using this to automatically record an Order Date when a new Order is created
        public PizzaOrder()
        {
            _orderDate = DateTime.Now;
        }
    }
}
