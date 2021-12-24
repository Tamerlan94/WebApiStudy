using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Models.Entities;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommonsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public CommonsController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Common model)
        {
            if(model == null)
            {
                return BadRequest();
            }

            _context.Commons.Add(model);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
