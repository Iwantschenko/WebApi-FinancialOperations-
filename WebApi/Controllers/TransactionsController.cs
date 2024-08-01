using BLL.Service;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;
using Models.Dto;
using Microsoft.EntityFrameworkCore;



namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly BaseService<TransactionsEntity, TransactionDto> _transactionService;
        public TransactionsController(BaseService<TransactionsEntity, TransactionDto> transactionService)
        {
            _transactionService = transactionService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var list = await _transactionService.GetAll();
            if (list != null)
            {
                return Ok(list);
            }
            return BadRequest();
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] TransactionDto dto)
        {
            if (ModelState.IsValid)
            {
                await _transactionService.Add(dto);
                return Ok("Successful add");
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var item = await _transactionService.GetByID(id);
            if (item != null)
            {
                return Ok(item);
            }
            return BadRequest("Not found");
        }


        [HttpPut("{Id:guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid Id, [FromBody] TransactionDto dto )
        {
            if (ModelState.IsValid)
            {
                _transactionService.Update(dto , Id);
                var result = await _transactionService.GetByID(Id);
                return Ok(result);
            }
            return BadRequest();

        }

        [HttpDelete("{Id:guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid Id)
        {
            var item = await _transactionService.GetByID(Id);
            if (item != null)
            {
                await _transactionService.Delete(Id);
                return Ok("Successful remove");
            }
            return BadRequest("Don`t remove");
        }
        
    }
}
