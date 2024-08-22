
using BLL.Service;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.Xml;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly ReportService _reportService;
        public ReportController( ReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet("{date}")]
        public async Task<IActionResult> GetByDate([FromRoute] DateTime date)
        {
            var item = await _reportService.GetByDateAsync(date);
            if (item != null)
            {
                return Ok(item);
            }
            return BadRequest();
        }

        [HttpGet("{startDate}/{endDate}")]
        public async Task<IActionResult> GetRangeDate([FromRoute] DateTime startDate , [FromRoute] DateTime endDate)
        {
            var item = await _reportService.GetByDateRangeAsync(startDate, endDate);
            if (item != null)
            {
                return Ok(item);
            }             
            return BadRequest();
        }
    }
}
