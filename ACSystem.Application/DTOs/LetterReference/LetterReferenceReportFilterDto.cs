using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACSystem.Application.DTOs.LetterReference
{
    public class LetterReferenceReportFilterDto
    {
        public string Title { get; set; }
        public string SenderEmail { get; set; }
        public string SenderIdCode { get; set; }
        public string SenderName { get; set; }
        public string Code { get; set; }
        public string Date { get; set; }
    }
}
