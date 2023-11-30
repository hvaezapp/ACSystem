using ACSystem.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACSystem.Domain.Entity
{
    public class LetterNote : BaseDomainEntity<long>
    {
        // letter
        public long LetterId { get; set; }
        public Letter Letter { get; set; }


        // employee
        public long EmployeeId { get; set; }
        public Employee Employee { get; set; }


        public string Description { get; set; }



        public LetterNote()
        {
            
        }


        public LetterNote(long letterId, 
                        long empId , 
                        string desc )
        {
            LetterId = letterId;
            EmployeeId = empId;
            Description = desc;
        }



        public void Edit(long letterId,
                   long empId,
                   string desc)
        {
            LetterId = letterId;
            EmployeeId = empId;
            Description = desc;
        }



    }
}
