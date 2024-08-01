﻿using Microsoft.AspNetCore.Mvc;
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
    [Route("api/[controller]")]
    public class OperationsController : Controller
    {
        private readonly BaseService<OperationTypeEntity, OperationTypeDto> _operationService;
        public OperationsController(BaseService<OperationTypeEntity, OperationTypeDto> baseService)
        {
            _operationService = baseService;
        }
        [HttpGet("GetAll")]
        public async Task< IActionResult> GetAll()
        {
            var item = await _operationService.GetAll();
            if (item != null)
            {
                return Ok(item);
            }
            return BadRequest();
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] OperationTypeDto item )
        {
            if (ModelState.IsValid)
            {
                await _operationService.Add(item);
                return Ok("Successful add");
            }
            return BadRequest();
        }
        [HttpGet("GetID/{Id}")]
        public async Task<IActionResult> GetId([FromRoute] Guid Id)
        {
            var item = await _operationService.GetByID(Id);
            if (item != null)
            {
                return Ok(item);
            }
            return BadRequest();
        }
        
        [HttpDelete("Delete/{Id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid Id)
        {
            var item = await _operationService.GetByID(Id);
            if (item != null) 
            {
                _operationService.RemoveEntity(item);
                return Ok("Successful remove");
            }
            return BadRequest("Don`t remove");
        }
        [HttpPut("Update/{Id}")]
        public IActionResult Update([FromRoute] Guid Id, [FromBody] OperationTypeDto operation)
        {
            if (ModelState.IsValid)
            {
                _operationService.Update(operation, Id);
                return Ok(_operationService.GetByID(Id));
            }
            return BadRequest();
        }
        
        
    }
}
