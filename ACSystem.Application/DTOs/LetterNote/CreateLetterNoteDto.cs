using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACSystem.Application.DTOs.LetterNote
{
    public class CreateLetterNoteDto
    {
        public int LetterId { get; set; }
        public long EmployeeId { get; set; }
        public string Description { get; set; }
    }
}
