using Microsoft.AspNetCore.Mvc;
using WebAPI.Data.Dtos;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsController : ControllerBase
    {
        private AuthorsService _authorsService;
        public AuthorsController(AuthorsService authorsService)
        {
            _authorsService = authorsService;
        }


        [HttpPost]
        [Route("add")]
        public IActionResult Add(AuthorCreateDto model)
        {
            _authorsService.Add(model);
            return Ok(model);
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var datas = _authorsService.GetAll();
            return Ok(datas);
        }
        
        [HttpGet("getById")]
        public IActionResult GetById(int id)
        {
            var data = _authorsService.GetById(id);
            return Ok(data);
        }
        
    }
}
