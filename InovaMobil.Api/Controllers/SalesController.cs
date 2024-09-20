using InovaMobil.Api.Domain;
using InovaMobil.Api.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InovaMobil.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class SalesController : ControllerBase
{
    private readonly ISaleRepository _salesRepository;

    public SalesController(ISaleRepository saleRepository)
    {
        _salesRepository = saleRepository;
    }

    [HttpPost]
    public async Task<IActionResult> Post(SalesDto sales)
    {
        var result = await _salesRepository.Create(sales);

        if (!string.IsNullOrEmpty(result.Reason))
        {
            return BadRequest(new { message = result.Reason });
        }

        if (result == null)
        {
            return BadRequest(new { message = "Não foi possível realizar a criação do cliente" });
        }

        return Ok(new { message = $"Cliente criado com sucesso - {result}" });
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _salesRepository.Get();

        return Ok(result);
    }
}

