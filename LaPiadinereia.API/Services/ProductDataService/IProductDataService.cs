using LaPiadinereia.API.Dtos;
using LaPiadinereia.API.Models;

namespace LaPiadinereia.API.Services.ProductDataService
{
    public interface IProductDataService
    {
        IEnumerable<Product> GetProducts();
        bool DeleteProduct(Product product);
    }
}
