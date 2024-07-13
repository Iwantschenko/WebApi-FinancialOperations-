
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
        public IActionResult GetByDate([FromRoute] DateTime date)
        {
            if (ModelState.IsValid)
            {
                return Ok(_reportService.GetByDate(date));
            }
            return BadRequest();
        }
        [HttpGet]
        public IActionResult GetRangeDate([FromQuery] DateTime startDate , [FromQuery] DateTime endDate)
        {
            if (ModelState.IsValid)
            {
                return Ok(_reportService.GetbyDateRange(startDate , endDate));
            }
            return BadRequest();
        }
    }
}
