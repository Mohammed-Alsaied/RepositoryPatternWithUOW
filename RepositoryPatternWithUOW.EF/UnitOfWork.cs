using RepositoryPatternWithUOW.Core;
using RepositoryPatternWithUOW.Core.Entities;
using RepositoryPatternWithUOW.Core.Repositories;
using RepositoryPatternWithUOW.EF.AppDbContext;
using RepositoryPatternWithUOW.EF.Repositories;

namespace RepositoryPatternWithUOW.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        //public IBaseRepository<Book> Books { get; private set; }
        public IBooksRepository Books { get; private set; }
        public IBaseRepository<Author> Authors { get; private set; }
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Books = new BooksRepository(_context);
            Authors = new BaseRepository<Author>(_context);
        }



        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
