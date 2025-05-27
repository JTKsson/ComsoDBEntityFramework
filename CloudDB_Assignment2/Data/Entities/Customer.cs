using Newtonsoft.Json;

namespace CloudDB_Assignment2.Data.Entities
{
    public class Customer
    {
        [JsonProperty("id")]
        public string CustomerId { get; set; } = Guid.NewGuid().ToString(); // Ensure string
        public string FullName { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public SalesRep SalesRep { get; set; }
    }
}
