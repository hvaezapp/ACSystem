using ACSystem.Application.DTOs.Common;
using ACSystem.Application.DTOs.Employee;
using ACSystem.Application.DTOs.LetterNote;
using ACSystem.Application.DTOs.LetterType;
using ACSystem.Application.Features.LetterType.Requests.Queries;
using ACSystem.Infrastructure.Enums;
using ACSystem.Infrastructure.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACSystem.Application.DTOs.Letter
{
    public class GetLetterDto : BaseDto<long>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public GetEmployeeDto Employee { get; set; }
        public long EmployeeId { get; set; }
        public GetLetterTypeDto LetterType { get; set; }
        public int LetterTypeId { get; set; }
        public string  Code { get; set; }
        public LetterStatus Status { get; set; }
        public string StatusText { get; set; }


        public GetLetterDto()
        {
            StatusText = this.Status.ToDisplay();
        }
    }


    public class GetLetterInfoWithLetterNoteDto : GetLetterDto
    {
    
        public IEnumerable<GetLetterNoteDto> LetterNotes { get; set; }
        public GetLetterInfoWithLetterNoteDto()
        {
            LetterNotes = new List<GetLetterNoteDto>();
        }
    }

}
