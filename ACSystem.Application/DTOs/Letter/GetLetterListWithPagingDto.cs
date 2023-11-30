using ACSystem.Application.DTOs.Letter;
using ACSystem.Application.DTOs.LetterType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACSystem.Application.DTOs.Letter
{
    public class GetLetterListWithPagingDto
    {
        public List<GetLetterInfoWithLetterNoteDto> list { get; set; }
        public int page { get; set; }


        public GetLetterListWithPagingDto()
        {
            list = new List<GetLetterInfoWithLetterNoteDto>();
        }
    }
}
