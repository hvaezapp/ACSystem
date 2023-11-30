using ACSystem.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACSystem.Domain.Entity
{
    public class LetterAttach : BaseDomainEntity<long>
    {
        public string FileUrl { get; set; }
        public long LetterReferenceId { get; set; }
        public LetterReference LetterReference { get; set; }

        public LetterAttach() { }


        public LetterAttach(string fileUrl , long letterRefId)
        {
            FileUrl  = fileUrl;
            LetterReferenceId = letterRefId;
        }


        public void Edit(string fileUrl, long letterRefId)
        {
            FileUrl = fileUrl;
            LetterReferenceId = letterRefId;
        }




    }
}
