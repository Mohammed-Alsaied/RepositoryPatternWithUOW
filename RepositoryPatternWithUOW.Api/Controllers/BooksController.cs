using Microsoft.AspNetCore.Mvc;
using RepositoryPatternWithUOW.Core;
using RepositoryPatternWithUOW.Core.Consts;
using RepositoryPatternWithUOW.Core.Entities;

namespace RepositoryPatternWithUOW.Api.Controllers
{
    [Route("api/Books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        //private readonly IBaseRepository<Book> _bookrRepository;

        //public BooksController(IBaseRepository<Book> bookRepository)
        //{
        //    _bookrRepository = bookRepository;
        //}
        private readonly IUnitOfWork _unitOfWork;

        public BooksController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public IActionResult GetById()
        {
            return Ok(_unitOfWork.Books.GetById(1));
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_unitOfWork.Books.GetAll());
        }

        [HttpGet("GetByName")]
        public IActionResult GetByName()
        {
            return Ok(_unitOfWork.Books.Find(b => b.Title == "New Book", new[] { "Author" }));
        }

        [HttpGet("GetAllWithAuthors")]
        public IActionResult GetAllWithAuthors()
        {
            return Ok(_unitOfWork.Books.FindAll(b => b.Title.Contains("New Book"), new[] { "Author" }));
        }

        [HttpGet("GetOrdered")]
        public IActionResult GetOrdered()
        {
            return Ok(_unitOfWork.Books.FindAll(b => b.Title.Contains("New Book"), null, null, b => b.Id, OrderBy.Descending));
        }

        [HttpGet("AddOne")]
        public IActionResult AddOne()
        {
            var book = _unitOfWork.Books.Add(new Book { Title = "Test 4", AuthorId = 1 });
            _unitOfWork.Complete();
            return Ok(book);
        }
    }
}
