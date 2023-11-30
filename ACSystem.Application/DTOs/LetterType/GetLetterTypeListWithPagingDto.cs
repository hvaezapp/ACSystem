using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACSystem.Application.DTOs.LetterType
{
    public class GetLetterTypeListWithPagingDto
    {
        public List<GetLetterTypeDto>  list { get; set; }
        public int page { get; set; }


        public GetLetterTypeListWithPagingDto()
        {
            list = new List<GetLetterTypeDto>();
        }
    }
}
