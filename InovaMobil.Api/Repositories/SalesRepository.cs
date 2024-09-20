using MySql.Data.MySqlClient;
using Dapper;
using System.Data;
using InovaMobil.Api.Domain;
using InovaMobil.Api.Repositories.Interfaces;

namespace InovaMobil.Api.Repositories
{
    public class SalesRepository : ISaleRepository
    {
        private readonly string _connectionString;
        private readonly IProductRepository _productRepository;
        private readonly ILogger<SalesRepository> _logger;

        public SalesRepository(IConfiguration configuration, ILogger<SalesRepository> logger, IProductRepository productRepository)
        {
            _productRepository = productRepository;
            _connectionString = configuration.GetConnectionString("mysql");
            _logger = logger;
        }

        private IDbConnection CreateConnection()
        {
            return new MySqlConnection(_connectionString);
        }

        public async Task<SalesDto?> Create(SalesDto sales)
        {
            try
            {
                var condition = await _productRepository.GetWithUuid(sales.Id_Product);

                if (condition.Status == "alugado")
                {
                    return new SalesDto(){ Reason = "O produto já foi alugado"};
                }

                using (var connection = CreateConnection())
                {
                    var result = await connection.ExecuteAsync(@"
                        INSERT INTO sales (`id_client`, `id_product`)
                        VALUES (@IdClient, @IdProduct)
                    ", new { IdClient = sales.Id_Client, IdProduct = sales.Id_Product });

                    if(result > 0)
                    {
                        await _productRepository.ChangeStatus(sales.Id_Product, "alugado");
                    }
                }

                return sales;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating sales");
                throw;
            }
        }

        public async Task<IEnumerable<SalesDto>> Get()
        {
            try
            {
                using var connection = CreateConnection();
                var result = await connection.QueryAsync<SalesDto>(@"SELECT * FROM sales");

                return result;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating sales");
                throw;
            }
        }
    }
}

