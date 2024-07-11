using Microsoft.AspNetCore.Mvc;
using BLL.Service;
using Microsoft.OpenApi.Models;
using Models.Entities;
using Models.Dto;
using Azure.Messaging;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.AspNetCore.StaticFiles;
namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OperationController : Controller
    {
        private readonly BaseService<OperationTypeEntity, OperationTypeDto> _operationService;
        public OperationController(BaseService<OperationTypeEntity, OperationTypeDto> baseService)
        {
            _operationService = baseService;
        }

        [HttpGet("Id")]
        public IActionResult GetId([FromBody] Guid Id)
        {
            var item = _operationService.GetByID(Id).Result;
            if (item != null)
            {
                return Ok(item);
            }
            return BadRequest();
        }
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var item = _operationService.GetAll().Result;
            if (item != null)
            {
                return Ok(item);
            }
            return BadRequest();
        }
        [HttpPost("Create")] 
        public IActionResult Create([FromBody] OperationTypeDto item)
        {
            if (item != null)
            {
                _operationService.Add(item);
                return Ok("Successful add");
            }
            return BadRequest();
        }

        [HttpDelete("Delete")]
        public IActionResult Delete([FromBody] Guid Id)
        {
            var item = _operationService.GetByID(Id).Result;
            if (item != null) 
            {
                _operationService.RemoveEntity(item);
                return Ok("Successful remove");
            }
            return BadRequest("Don`t remove");
        }
        [HttpPut("Update")]
        public IActionResult Update([FromRoute] Guid Id, [FromBody] OperationTypeDto operation)
        {
           
            return BadRequest();
        }
        
        
    }
}
