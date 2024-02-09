using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreDatabase.Entities
{
    [Table("Products")]
    public class Product
    {
        public int ProductId { get; set; }
        [DisplayName("Product Name")]
        public string? ProductName { get; set; }
        [DisplayName("Product Price")]
        public float ProductPrice { get; set; }
    }
}
