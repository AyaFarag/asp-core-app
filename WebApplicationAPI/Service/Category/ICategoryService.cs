namespace WebApplicationAPI.Service.Category
{
    public interface ICategoryService
    {
        Task<IEnumerable<Model.Category>> getAllCategories();

        Task<Model.Category> GetById(int id);

        Task<Model.Category> create(Model.Category categoryDTO);
        Task<Model.Category> update(Model.Category updateCategoryDTO);
        Task delete(int id);
    }
}
