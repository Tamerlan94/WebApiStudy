using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Models.Entities;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public CitiesController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await _context.Cities.ToListAsync();
            return Ok(response);
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _context.Cities.FindAsync(id);

            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] City model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            _context.Cities.Add(model);   
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] City model)
        {
            if (model == null)
            {
                return BadRequest();
            }
            _context.Cities.Update(model);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        [Route("{Id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _context.Cities.FindAsync(id);

            if (response == null)
            {
                return NotFound();
            }
            _context.Cities.Remove(response);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
