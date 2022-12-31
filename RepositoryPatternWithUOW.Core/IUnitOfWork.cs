using RepositoryPatternWithUOW.Core.Entities;
using RepositoryPatternWithUOW.Core.Repositories;

namespace RepositoryPatternWithUOW.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IBooksRepository Books { get; }
        //IBaseRepository<Author> Authors { get; }
        IBaseRepository<Author> Authors { get; }

        int Complete();
    }
}
