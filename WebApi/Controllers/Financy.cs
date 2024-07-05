using DAL.DB;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Financy : Controller
    {
        private readonly DataBaseContext _dataBaseContext;
        public Financy(DataBaseContext context)
        { 
            _dataBaseContext = context;
        }    
        [HttpGet]
        public IActionResult Geter() 
        {
            return Ok();
        }

    }
}
