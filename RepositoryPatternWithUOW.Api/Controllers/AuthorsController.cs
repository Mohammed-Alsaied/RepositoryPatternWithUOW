using Microsoft.AspNetCore.Mvc;
using RepositoryPatternWithUOW.Core;

namespace RepositoryPatternWithUOW.Api.Controllers
{
    [Route("api/Authors")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        //private readonly IBaseRepository<Author> _authorRepository;

        //public AuthorsController(IBaseRepository<Author> authorRepository)
        //{
        //    _authorRepository = authorRepository;
        //}
        private readonly IUnitOfWork _unitOfWork;

        public AuthorsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpGet]
        public IActionResult GetById()
        {
            return Ok(_unitOfWork.Authors.GetById(1));
        }
        [HttpGet("GetByIdAsync")]
        public async Task<IActionResult> GetByIdAsync()
        {
            return Ok(await _unitOfWork.Authors.GetByIdAsync(1));
        }
    }
}
