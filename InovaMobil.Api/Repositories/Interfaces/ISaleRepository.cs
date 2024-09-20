using InovaMobil.Api.Domain;

namespace InovaMobil.Api.Repositories.Interfaces
{
    public interface ISaleRepository
    {
        Task<SalesDto?> Create(SalesDto product);
        Task<IEnumerable<SalesDto>?> Get();
    }
}

