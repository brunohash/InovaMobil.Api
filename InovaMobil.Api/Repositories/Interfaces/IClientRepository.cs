using InovaMobil.Api.Domain;

namespace InovaMobil.Api.Repositories.Interfaces
{
    public interface IClientRepository
    {
        Task<ClientDto?> Create(ClientDto client);
        Task<IEnumerable<ClientDto>?> Get();
    }
}

