using ACSystem.Application.Contracts.Persistence;
using ACSystem.Domain.Entity;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace ACSystem.Persistence.Repositories
{
    public class LetterTypeRepository : GenericRepository<LetterType>, ILetterTypeRepository
    {
        private readonly ACSystemDbContext _dbContext;
        private readonly IConfiguration _configuration;
        private IDbConnection _db;

        public LetterTypeRepository(ACSystemDbContext dbContext, IConfiguration configuration)
            : base(dbContext)
        {
            _dbContext = dbContext;
            _configuration = configuration;
            _db = new SqlConnection(_configuration.GetConnectionString("ACSystemConnectionString"));
        }


        public async Task<IEnumerable<LetterType>> GetAllWithPagingWithDapper(int skip, int take, CancellationToken cancellationToken)
        {
            try
            {
                string getAllCityQuery = $"SELECT * FROM LetterType ORDER BY Id OFFSET {skip} ROWS FETCH NEXT {take} ROWS ONLY";
                return await _db.QueryAsync<LetterType>(getAllCityQuery);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
