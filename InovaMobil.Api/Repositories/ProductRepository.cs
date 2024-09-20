using MySql.Data.MySqlClient;
using Dapper;
using System.Data;
using InovaMobil.Api.Domain;
using InovaMobil.Api.Repositories.Interfaces;
using MySqlX.XDevAPI.Common;

namespace InovaMobil.Api.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly string _connectionString;
        private readonly ILogger<ProductRepository> _logger;

        public ProductRepository(IConfiguration configuration, ILogger<ProductRepository> logger)
        {
            _connectionString = configuration.GetConnectionString("mysql");
            _logger = logger;
        }

        private IDbConnection CreateConnection()
        {
            return new MySqlConnection(_connectionString);
        }

        public async Task<ProductDto?> Create(ProductDto product)
        {
            try
            {
                using (var connection = CreateConnection())
                {
                    var result = await connection.ExecuteAsync(@"
                        INSERT INTO products (`Uuid`, `Name`, `Batery`, `image`, `status`)
                        VALUES (@Uuid, @Name, @Batery, @Image, @status)
                    ", new { product.Uuid, product.Name, product.Batery, product.Image, product.Status });
                }

                return product;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating product");
                throw;
            }
        }

        public async Task<IEnumerable<ProductDto>> Get()
        {
            try
            {
                using var connection = CreateConnection();
                var result = await connection.QueryAsync<ProductDto>(@"SELECT * FROM products");

                return result;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating product");
                throw;
            }
        }
    }
}

