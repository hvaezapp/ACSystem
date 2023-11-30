using ACSystem.Application.Contracts.Persistence;
using ACSystem.Domain.Entity;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace ACSystem.Persistence.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        private readonly ACSystemDbContext _dbContext;
     

        public EmployeeRepository(ACSystemDbContext dbContext)
            : base(dbContext)
        {
            _dbContext = dbContext;
        }

     
    }
}
