using InovaMobil.Api.Domain;

namespace InovaMobil.Api.Business.Interfaces
{
    public interface IProductBusiness
    {
        Task<ProductDto>? CreateProduct(ProductDto product);
    }
}

