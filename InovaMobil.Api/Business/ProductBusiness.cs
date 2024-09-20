using InovaMobil.Api.Business.Interfaces;
using InovaMobil.Api.Domain;
using InovaMobil.Api.Repositories.Interfaces;

namespace InovaMobil.Api.Business
{
    public class ProductBusiness : IProductBusiness
    {
        public IProductRepository _productRepository;

        public ProductBusiness(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ProductDto>? CreateProduct(ProductDto product)
        {
            var result = await _productRepository.Create(product);

            if(result != null)
            {
                return result;
            }

            return new ProductDto();
        }
    }
}

