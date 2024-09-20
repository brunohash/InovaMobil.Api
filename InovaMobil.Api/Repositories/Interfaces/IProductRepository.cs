using InovaMobil.Api.Domain;

namespace InovaMobil.Api.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<ProductDto?> Create(ProductDto product);
        Task<IEnumerable<ProductDto>?> Get();
    }
}

