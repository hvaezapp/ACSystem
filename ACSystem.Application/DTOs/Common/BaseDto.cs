using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACSystem.Application.DTOs.Common
{
    public class BaseDto<T>
    {
        public T Id { get; set; }
    }
}
