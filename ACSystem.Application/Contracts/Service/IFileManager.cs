using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACSystem.Application.Contracts.Service
{
    public interface IFileManager
    {
        Task<List<string>> Save(IEnumerable<IFormFile> files , CancellationToken cancellationToken);
    }
}
