using ACSystem.Domain.Entity;

namespace ACSystem.Application.Contracts.Persistence
{
    public interface ILetterNoteRepository : IGenericRepository<LetterNote> , IDapperRepository<LetterNote>
    {
    }
}
