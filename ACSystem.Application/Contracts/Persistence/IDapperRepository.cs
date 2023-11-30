using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACSystem.Application.Contracts.Persistence
{
    public interface IDapperRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllWithPagingWithDapper(int skip , int take , CancellationToken cancellationToken);
    }
}
