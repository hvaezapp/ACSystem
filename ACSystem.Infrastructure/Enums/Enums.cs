using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ACSystem.Infrastructure.Enums
{
    public enum LetterStatus
    {
        [Display(Name = "باز")]
        Open,
        [Display(Name = "بسته")]
        Close,
        [Display(Name = "ارجاع")]
        Referring
    }
}
