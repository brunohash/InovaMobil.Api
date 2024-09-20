using InovaMobil.Api.Business.Interfaces;
using InovaMobil.Api.Domain;
using InovaMobil.Api.Repositories.Interfaces;

namespace InovaMobil.Api.Business
{
    public class ClientBusiness : IClientBusiness
    {
        public IClientRepository _clientRepository;

        public ClientBusiness(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<ClientDto>? CreateClient(ClientDto client)
        {
            var result = await _clientRepository.Create(client);

            if (result != null)
            {
                return result;
            }

            return new ClientDto();
        }
    }
}

