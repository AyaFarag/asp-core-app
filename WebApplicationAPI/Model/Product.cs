using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationAPI.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int qty { get; set; }
        public float price { get; set; }

       // [ForeignKey("Category")]
       // public int category_id { get; set; }
       // [ForeignKey("category_id")]
       // public Category Category { get; set; }

    }
}
