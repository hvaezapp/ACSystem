using ACSystem.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACSystem.Domain.Entity
{
    public class LetterReference : BaseDomainEntity<long>
    {
        // letter
        public long LetterId { get; set; }
        public Letter Letter { get; set; }


        // from Emp
        public long FromEmployeeId { get; set; }
        public Employee FromEmployee { get; set; }

        // to Emp
        public long ToEmployeeId { get; set; }
        public Employee ToEmployee { get; set; }

        public string ReplyText { get; set; }

        public ICollection<LetterAttach>  attaches { get; set; }

        public LetterReference()
        {
           attaches = new List<LetterAttach>();
        }


        public LetterReference(long letterId, long fromEmpId,
                        int toEmpId, string replyText
                        )
        {

            LetterId = letterId;
            FromEmployeeId = fromEmpId;
            ToEmployeeId = toEmpId;
            ReplyText = replyText;
           
            
        }


        public void Edit(long letterId, long fromEmpId,
                           int toEmpId, string replyText)
        {

            LetterId = letterId;
            FromEmployeeId = fromEmpId;
            ToEmployeeId = toEmpId;
            ReplyText = replyText;
           
        }


    }
}
