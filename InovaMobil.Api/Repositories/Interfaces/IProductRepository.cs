using InovaMobil.Api.Domain;

namespace InovaMobil.Api.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<ProductDto?> Create(ProductDto product);
        Task<IEnumerable<ProductDto>?> Get();
        Task ChangeStatus(string id, string status);
        Task<ProductDto> GetWithUuid(string id);
    }
}

