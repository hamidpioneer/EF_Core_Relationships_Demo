using Microsoft.AspNetCore.Mvc;
using WebAPI.Data;
using WebAPI.Data.Dtos;
using WebAPI.Data.Models;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PublishersController : ControllerBase
    {
        private PublishersService _publishersService;
        public PublishersController(PublishersService booksServcie)
        {
            _publishersService = booksServcie;
        }


        [HttpPost]
        [Route("add")]
        public IActionResult Add(PublisherCreateDto model)
        {
            _publishersService.Add(model);
            return Ok(model);
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var datas = _publishersService.GetAll();
            return Ok(datas);
        }
        
    }
}
