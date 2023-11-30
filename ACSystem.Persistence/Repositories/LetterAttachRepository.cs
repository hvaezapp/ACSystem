using ACSystem.Application.Contracts.Persistence;
using ACSystem.Domain.Entity;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace ACSystem.Persistence.Repositories
{
    public class LetterAttachRepository : GenericRepository<LetterAttach>, ILetterAttachRepository
    {
        private readonly ACSystemDbContext _dbContext;


        public LetterAttachRepository(ACSystemDbContext dbContext, IConfiguration configuration)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }


      
    }
}
