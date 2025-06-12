using WebApplicationAPI.Data;
using WebApplicationAPI.DTO;

namespace WebApplicationAPI.Repository.Product
{
    public class ProductRepository : IProductRepository
    {
        // immplementation function

        public ApplicationDbContext context;
        public ProductRepository(ApplicationDbContext _context)
        {
            context = _context;
        }
        public string create(Model.Product product)
        {
            try
            {  
                context.Products.Add(product);
                context.SaveChanges();
                return "Product created successfully";

            }
            catch (Exception ex) 
            { 
                return ex.Message;
            }
        }

        public string delete(int id)
        {
            var product = context.Products.Find(id);
            if (product == null) { 
                 throw new NotImplementedException();
            }
            context.Products.Remove(product);
            context.SaveChanges();
            return "Product removed successfully";
        }

        public List<Model.Product> getAll()
        {
            var products = context.Products.ToList();
            return products;
        }

        public void getById()
        {
            throw new NotImplementedException();
        }

        public Model.Product update(int id, Model.Product product)
        {
            var pro = context.Products.Find(id);
            if (pro == null || pro.Id != product.Id)
            {
                throw new Exception();
            }
                
            context.Products.Update(product);
            context.SaveChanges();
            return product;
            
        }
    }
}
