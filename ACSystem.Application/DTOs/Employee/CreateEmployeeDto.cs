using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACSystem.Application.DTOs.Employee
{
    public record CreateEmployeeDto(string FirstName, string LastName, string Email, string IdentityCode);
}
