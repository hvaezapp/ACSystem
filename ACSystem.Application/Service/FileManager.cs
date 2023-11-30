using ACSystem.Application.Contracts.Service;
using ACSystem.Infrastructure.Utilities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACSystem.Application.Service
{
    public class FileManager : IFileManager
    {
        private readonly IHostingEnvironment _environment;

        public FileManager(IHostingEnvironment environment)
        {
            _environment = environment;
        }

        public async Task<List<string>> Save(IEnumerable<IFormFile> files, CancellationToken cancellationToken)
        {
            List<string> fileNames = new List<string>();
            try
            {
                var path = _environment.ContentRootPath + "\\uploads\\letter\\";

                foreach (var file in files)
                {
                    if (file != null && file.Length > 0)
                    {
                        string filename = AppUtility.GetGuid() + Path.GetExtension(file.FileName);
                        string filePath = Path.Combine(path, filename);
                        using (Stream fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(fileStream, cancellationToken);
                            fileNames.Add(filename);
                        }

                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            return fileNames;
        }
    }
}
