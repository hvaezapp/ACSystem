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
            CreateDateSh = "1402/02/02"; // test
        }


        public void Delete()
        {
            IsDeleted = true;
        }


    }
}
