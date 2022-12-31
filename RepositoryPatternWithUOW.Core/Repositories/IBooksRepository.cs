using RepositoryPatternWithUOW.Core.Entities;

namespace RepositoryPatternWithUOW.Core.Repositories
{
    public interface IBooksRepository : IBaseRepository<Book>
    {
        IEnumerable<Book> SpecialMethod();

    }
}
