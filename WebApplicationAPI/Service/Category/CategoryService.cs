
using WebApplicationAPI.Repository.Category;

namespace WebApplicationAPI.Service.Category
{
    public class CategoryService : ICategoryService
    {
        public ICategoryRepository Repository { get; set; }
        public CategoryService(ICategoryRepository categoryRepository)
        {
            Repository = categoryRepository;

        }
        public Task<Model.Category> create(Model.Category categoryDTO)
        {
            return Repository.AddAsync(categoryDTO);
        }

        public Task delete(int id)
        {
            return Repository.DeleteAsync(id);
        }

        public Task<IEnumerable<Model.Category>> getAllCategories()
        {
            return Repository.GetAllAsync();
        }

        public Task<Model.Category> GetById(int id)
        {
            return Repository.GetByIdAsync(id);
        }

        public Task<Model.Category> update(Model.Category updateCategoryDTO)
        {
            return Repository.UpdateAsync(updateCategoryDTO);
        }
    }
}
