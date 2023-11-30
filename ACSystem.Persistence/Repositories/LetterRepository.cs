using ACSystem.Application.Contracts.Persistence;
using ACSystem.Domain.Entity;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace ACSystem.Persistence.Repositories
{
    public class LetterRepository : GenericRepository<Letter>, ILetterRepository
    {
        private readonly ACSystemDbContext _dbContext;
     

        public LetterRepository(ACSystemDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

     
    }
}
