using ACSystem.Domain.Entity;

namespace ACSystem.Application.Contracts.Persistence
{
    public interface ILetterTypeRepository : IGenericRepository<LetterType> , IDapperRepository<LetterType>
    {
    }
}
