namespace CoreModelViewController.Models
{
    public class StoreLegal
    {
        // We are using a model to describe the legal aspects of our online store

        // What describes the StoreLegal concept?

        // - Many Terms
        public List<string> Terms { get; set; }

        // Last Updated 
        public DateTime LastUpdated { get; set; }

        // Terms Version
        public int Version { get; set; }
        //..  More
    }
}
