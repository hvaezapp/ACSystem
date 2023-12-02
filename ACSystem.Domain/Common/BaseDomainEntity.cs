using ACSystem.Infrastructure.Utilities;
using System.ComponentModel.DataAnnotations;

namespace ACSystem.Domain.Common
{
    public abstract class BaseDomainEntity<T> where T : struct
    {
        //[Key]
        public T Id { get; set; }
        public DateTime CreateDateMl { get; set; }
        public string CreateDateSh { get; set; }
        public bool IsDeleted { get; set; }


        public BaseDomainEntity()
        {
            IsDeleted = false;
            CreateDateMl = DateTime.Now;
            CreateDateSh = DateAndTimeShamsi.DateTimeShamsi();
        }


        public void Delete()
        {
            IsDeleted = true;
        }


    }
}
