using ACSystem.Domain.Common;
using ACSystem.Infrastructure.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACSystem.Domain.Entity
{
    public class Letter : BaseDomainEntity<long>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int LetterTypeId { get; set; }
        public LetterType LetterType { get; set; }
        public long EmployeeId { get; set; }
        public Employee Employee { get; set; }
       
        public string Code { get; set; }
        public LetterStatus Status { get; set; }


        public ICollection<LetterNote> LetterNotes { get; set; }
        public ICollection<LetterReference> LetterReferences { get; set; }



        public Letter()
        {
            LetterNotes = new List<LetterNote>();
            LetterReferences = new List<LetterReference>();
        }


        public Letter(string title, string desc,
                        int letterTypeId, long createdByEmpId,
                         string code , 
                        LetterStatus status) : this()
        {

            Title = title;
            Description = desc;
            LetterTypeId = letterTypeId;
            EmployeeId = createdByEmpId;
           
            Status = status;
            Code = code;
        }


        public void Edit(string title, string desc,
                     int letterTypeId, long createdByEmpId,
                      string code ,
                     LetterStatus status)
        {

            Title = title;
            Description = desc;
            LetterTypeId = letterTypeId;
            EmployeeId = createdByEmpId;
           
            Status = status;
            Code = code;

        }



    }

   
}
