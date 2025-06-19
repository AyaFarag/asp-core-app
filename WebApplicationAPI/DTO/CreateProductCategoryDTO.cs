namespace WebApplicationAPI.DTO
{
    public class CreateProductCategoryDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int qty { get; set; }
        public float price { get; set; }

        public CreateCategoryDTO Category { get; set; }
    }


    public class CreateCategoryDTO
    {
        public string Name { get; set; }
        public string? ParentId { get; set; }
    }
}
