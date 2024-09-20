using InovaMobil.Api.Business.Interfaces;
using InovaMobil.Api.Domain;
using InovaMobil.Api.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InovaMobil.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ClientController : ControllerBase
{
    private readonly IClientBusiness _clientBusiness;
    private readonly IClientRepository _clientRepository;

    public ClientController(IClientBusiness clientBusiness, IClientRepository clientRepository)
    {
        _clientBusiness = clientBusiness;
        _clientRepository = clientRepository;
    }

    [HttpPost]
    public async Task<IActionResult> Post(ClientDto client)
    {
        if (string.IsNullOrEmpty(client.Name))
        {
            return BadRequest("O nome do cliente precisa ser preenchido");
        }

        var result = await _clientBusiness.CreateClient(client);

        if (result == null || string.IsNullOrEmpty(result.Name))
        {
            return BadRequest("Não foi possível realizar a criação do cliente");
        }

        return Ok($"Cliente criado com sucesso - {result}");
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _clientRepository.Get();

        return Ok(result);
    }
}

