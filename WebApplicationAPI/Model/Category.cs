using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationAPI.Model
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Category> subCategory { get; set; }

        public int ParentId { get; set; }
        [ForeignKey("ParentId")]
        public Category ParentCategory { get; set; }
        public ICollection<Product> products { get; set; }
    }
}
