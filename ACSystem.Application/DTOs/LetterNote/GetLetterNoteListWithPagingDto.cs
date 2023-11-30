using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACSystem.Application.DTOs.LetterNote
{
    public class GetLetterNoteListWithPagingDto
    {
        public IEnumerable<GetLetterNoteDto> list { get; set; }
        public int page { get; set; }

        public GetLetterNoteListWithPagingDto()
        {
            list = new List<GetLetterNoteDto>();
        }
    }
}
