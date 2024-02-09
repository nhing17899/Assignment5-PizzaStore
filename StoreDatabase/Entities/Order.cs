using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreDatabase.Entities
{
    [Table("Orders")]
    public class Order
    {
        public int OrderId { get; set; }
        [DisplayName("Order Date")]
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer? Customer { get; set; } = null;
        public virtual ICollection<OrderLineItem> OrderLineItems { get; set; } = new List<OrderLineItem>();

    }
}
