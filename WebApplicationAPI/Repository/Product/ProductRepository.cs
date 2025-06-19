using WebApplicationAPI.Data;
using WebApplicationAPI.DTO;

namespace WebApplicationAPI.Repository.Product
{
    public class ProductRepository : Repository<Model.Product> , IProductRepository
    {

        // immplementation function

        //public ApplicationDbContext context;
        public ProductRepository(ApplicationDbContext _context) : base(_context) { }
        
        // 

        public string create(Model.Product product)
        {
            try
            {  
                _context.Products.Add(product);
                _context.SaveChanges();
                return "Product created successfully";

            }
            catch (Exception ex) 
            { 
                return ex.Message;
            }
        }

        public string delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null) { 
                 throw new NotImplementedException();
            }
            _context.Products.Remove(product);
            _context.SaveChanges();
            return "Product removed successfully";
        }

        public List<Model.Product> getAll()
        {
            var products = _context.Products.ToList();
            return products;
        }

        public void getById()
        {
            throw new NotImplementedException();
        }

        public Model.Product update(int id, Model.Product product)
        {
            var pro = _context.Products.Find(id);
            if (pro == null || pro.Id != product.Id)
            {
                throw new Exception();
            }
                
            _context.Products.Update(product);
            _context.SaveChanges();
            return product;
            
        }
    }
}
