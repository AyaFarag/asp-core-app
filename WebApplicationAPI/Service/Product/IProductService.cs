using WebApplicationAPI.DTO;
using WebApplicationAPI.Model;

namespace WebApplicationAPI.Service.Product
{
    public interface IProductService
    {
        public string createProduct(CreateProductCategoryDTO Produvctdto);
        public List<ProductResponseDTO> getAllProducts();

        public ProductResponseDTO updateProduct(int id, UpdateProductDTO dto);
        public string deleteProduct(int id);
    }
}
