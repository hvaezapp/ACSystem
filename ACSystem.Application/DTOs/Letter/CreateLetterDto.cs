using ACSystem.Domain.Entity;
using ACSystem.Infrastructure.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACSystem.Application.DTOs.Letter
{
    public class CreateLetterDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int LetterTypeId { get; set; }
        public long EmployeeId { get; set; }
     
       
    }
}
