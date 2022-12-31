using RepositoryPatternWithUOW.Core.Entities;
using RepositoryPatternWithUOW.Core.Repositories;
using RepositoryPatternWithUOW.EF.AppDbContext;

namespace RepositoryPatternWithUOW.EF.Repositories
{
    public class BooksRepository : BaseRepository<Book>, IBooksRepository
    {
        public BooksRepository(ApplicationDbContext context) : base(context)
        {
        }

        public IEnumerable<Book> SpecialMethod()
        {
            throw new NotImplementedException();
        }
    }
}
