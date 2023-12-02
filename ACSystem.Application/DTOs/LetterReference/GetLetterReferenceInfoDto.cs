using ACSystem.Application.DTOs.Employee;
using ACSystem.Application.DTOs.Letter;
using ACSystem.Application.DTOs.LetterAttach;
using ACSystem.Application.DTOs.LetterNote;
using ACSystem.Application.Features.LetterReference.Handlers.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACSystem.Application.DTOs.LetterReference
{
    public class GetLetterReferenceInfoDto
    {
        public List<GetLetterAttahchInfoDto> Attaches { get; set; }

        public List<GetLetterNoteDto> LetterNotes { get; set; }

        public GetEmployeeDto FromEmployee { get; set; }

        public GetEmployeeDto ToEmployee { get; set; }

        public GetLetterDto letter { get; set; }

        public string ReplyText { get; set; }

        public DateTime CreateDateMl { get; set; }

        public string CreateDateSh { get; set; }

        public GetLetterReferenceInfoDto()
        {
            Attaches = new List<GetLetterAttahchInfoDto>();
            LetterNotes = new List<GetLetterNoteDto>();
        }
    }
}
