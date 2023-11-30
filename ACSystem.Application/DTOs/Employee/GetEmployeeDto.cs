using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACSystem.Application.DTOs.Employee
{
    public record GetEmployeeDto(string FirstName, string LastName, string Email, string IdentityCode, int Id) : CreateEmployeeDto(FirstName, LastName, Email, IdentityCode);
}
