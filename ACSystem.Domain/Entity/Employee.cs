using ACSystem.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACSystem.Domain.Entity
{
    public class Employee : BaseDomainEntity<long>
    {
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string IdentityCode { get; set; }


        public ICollection<Letter> Letters { get; set; }
        public ICollection<LetterNote> LetterNotes { get; set; }

        [NotMapped]
        public ICollection<LetterReference> LetterReferences { get; set; }



        public Employee()
        {
            Letters = new List<Letter>();
            LetterNotes = new List<LetterNote>();
            LetterReferences = new List<LetterReference>();
        }


        public Employee(string fName , string lName  ,
                         string email , string idCode):this()
        {
            
            FirstName = fName;
            LastName = lName; 
            Email = email;
            IdentityCode = idCode;

        }


        public void Edit(string fName, string lName,
            string email, string idCode)
        {

            FirstName = fName;
            LastName = lName;
            Email = email;
            IdentityCode = idCode;

        }


        public override string ToString()
        {
            return $" {FirstName} {LastName} ";
        }


        




    }
}
