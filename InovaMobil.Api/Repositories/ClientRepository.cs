using MySql.Data.MySqlClient;
using Dapper;
using System.Data;
using InovaMobil.Api.Domain;
using InovaMobil.Api.Repositories.Interfaces;

namespace InovaMobil.Api.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly string _connectionString;
        private readonly ILogger<ClientRepository> _logger;

        public ClientRepository(IConfiguration configuration, ILogger<ClientRepository> logger)
        {
            _connectionString = configuration.GetConnectionString("mysql");
            _logger = logger;
        }

        private IDbConnection CreateConnection()
        {
            return new MySqlConnection(_connectionString);
        }

        public async Task<ClientDto?> Create(ClientDto client)
        {
            try
            {
                var existingClient = await GetWithEmail(client.Email);

                if (existingClient != null)
                {
                    _logger.LogWarning("Client with email {Email} already exists.", client.Email);
                    return null; 
                }

                using (var connection = CreateConnection())
                {
                    var result = await connection.ExecuteAsync(@"
                        INSERT INTO client (`Uuid`, `Name`, `Email`, `DocumentType`, `Document`, `AreaCode`, `Number`, `Status`)
                        VALUES (@Uuid, @Name, @Email, @DocumentType, @Document, @AreaCode, @Number, @Status)
                    ", new
                            {
                                client.Uuid,
                                client.Name,
                                client.Email,
                                client.DocumentType,
                                client.Document,
                                client.AreaCode,
                                client.Number,
                                client.Status
                            });
                        }

                return client;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while creating product");
                throw;
            }
        }

        public async Task<IEnumerable<ClientDto>> Get()
        {
            try
            {
                using var connection = CreateConnection();
                var result = await connection.QueryAsync<ClientDto>(@"SELECT * FROM client");

                return result;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "An error occurred while geting client");
                throw;
            }
        }

        public async Task<ClientDto> GetWithEmail(string email)
        {
            try
            {
                using var connection = CreateConnection();

                var query = @"SELECT * FROM client WHERE Email = @email";

                var result = await connection.QueryFirstOrDefaultAsync<ClientDto>(query, new { email });

                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while geting client");
                throw;
            }
        }
    }
}

