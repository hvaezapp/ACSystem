using ACSystem.Application.Features.LetterReference.Handlers.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACSystem.Application.DTOs.LetterReference
{
    public class GetLetterReferencesListWithPagingDto
    {
        public List<GetLetterReferenceInfoDto> list { get; set; }

        public int page { get; set; }

        public GetLetterReferencesListWithPagingDto()
        {
            list = new List<GetLetterReferenceInfoDto>();
        }

       
    }
}
