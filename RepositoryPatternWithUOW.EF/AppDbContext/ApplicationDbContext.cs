using Microsoft.EntityFrameworkCore;
using RepositoryPatternWithUOW.Core.Entities;

namespace RepositoryPatternWithUOW.EF.AppDbContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        DbSet<Author> Authors { get; set; }
        DbSet<Book> Books { get; set; }


    }
}
