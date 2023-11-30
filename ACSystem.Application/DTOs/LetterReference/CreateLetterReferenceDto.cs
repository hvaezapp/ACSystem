using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACSystem.Application.DTOs.LetterReference
{
    public class CreateLetterReferenceDto
    {
        public long LetterId { get; set; }
        public long FromEmployeeId { get; set; }
        public long ToEmployeeId { get; set; }
        public string ReplyText { get; set; }
        public IList<IFormFile> File { get; set; }



    }
}
