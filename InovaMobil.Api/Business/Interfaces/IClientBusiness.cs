using InovaMobil.Api.Domain;

namespace InovaMobil.Api.Business.Interfaces
{
    public interface IClientBusiness
    {
        Task<ClientDto>? CreateClient(ClientDto product);
    }
}

