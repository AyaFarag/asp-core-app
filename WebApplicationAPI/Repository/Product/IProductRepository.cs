namespace WebApplicationAPI.Repository.Product
{
    public interface IProductRepository
    {
        // definition functions

        public string create(Model.Product product);
        public Model.Product update(int id , Model.Product product);
        public string delete(int id);
        public List<Model.Product> getAll();
        public void getById();

    }
}
