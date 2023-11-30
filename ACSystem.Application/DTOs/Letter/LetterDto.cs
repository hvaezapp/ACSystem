using ACSystem.Application.DTOs.Common;
using ACSystem.Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACSystem.Application.DTOs.Letter
{
    public class LetterDto : BaseDto<long>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int LetterTypeId { get; set; }
        public long CreatedByEmpId { get; set; }
        public string Code { get; set; }
        public LetterStatus Status { get; set; }
    }
}
