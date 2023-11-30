using ACSystem.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACSystem.Domain.Entity
{
    public class LetterType : BaseDomainEntity<int>
    {
        public string Title { get; set; }

        public ICollection<Letter> Letters { get; set; }



        public LetterType()
        {
            Letters = new List<Letter>();
        }


        public LetterType(string title) : this()
        {
            Title = title;
        }


        public void Edit(string title)
        {
            Title = title;
        }



      
      

    }
}
