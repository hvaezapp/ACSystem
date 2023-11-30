using ACSystem.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACSystem.Application.DTOs.LetterType
{
    public class GetLetterTypeDto : BaseDto<int>
    {
        public string Title { get; set; }
    }
}
