using WebApplicationAPI.Data;

namespace WebApplicationAPI.Repository.Category
{
    public class CategoryRepository : Repository<Model.Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
