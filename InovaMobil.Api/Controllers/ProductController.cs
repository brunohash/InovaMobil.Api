using InovaMobil.Api.Business;
using InovaMobil.Api.Business.Interfaces;
using InovaMobil.Api.Domain;
using InovaMobil.Api.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InovaMobil.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductBusiness _productBusiness;
    private readonly IProductRepository _productRepository;

    public ProductController(IProductBusiness productBusiness, IProductRepository productRepository)
    {
        _productBusiness = productBusiness;
        _productRepository = productRepository;
    }

    [HttpPost]
    public async Task<IActionResult> Post(ProductDto product)
    {
        if(string.IsNullOrEmpty(product.Name))
        {
            return BadRequest(new { message = "O nome do produto precisa ser preenchido" });
        }

        var result = await _productBusiness.CreateProduct(product);

        if(result == null || string.IsNullOrEmpty(result.Name))
        {
            return BadRequest(new { message = "Não foi possível realizar a criação do produto" });
    }

        return Ok(new { message = $"Produto criado com sucesso - {result}"});
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _productRepository.Get();

        return Ok(result);
    }
}

