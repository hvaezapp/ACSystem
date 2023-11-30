using ACSystem.Application.DTOs.LetterType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACSystem.Application.DTOs.Employee
{
    public class GetEmployeeListWithPagingDto
    {
        public List<GetEmployeeDto> list { get; set; }
        public int page { get; set; }


        public GetEmployeeListWithPagingDto()
        {
            list = new List<GetEmployeeDto>();
        }
    }
}
