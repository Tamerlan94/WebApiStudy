using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Models.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public QuestionsController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _context.Questions.ToListAsync();

            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Question model)
        {
            if(model == null)
            {
                return BadRequest();
            }

            _context.Questions.Add(model); 

            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
