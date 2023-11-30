using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACSystem.Application.DTOs.LetterNote
{
    public class GetLetterNoteDto : CreateLetterNoteDto
    {
        public long Id { get; set; }
    }
}
