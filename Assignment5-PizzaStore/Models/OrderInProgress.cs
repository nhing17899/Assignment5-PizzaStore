using StoreDatabase.Entities;

namespace Assignment5_PizzaStore.Models
{
    public class OrderInProgress
    {
        public Customer Customer { get; set; }
        public List<Product>? Products { get; set; }
        public Order? Order { get; set; }
    }
}
