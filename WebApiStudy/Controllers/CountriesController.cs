using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Models.Entities;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ApplicationContext _context;

        public CountriesController(ApplicationContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var respone = await _context.Countries.Include(c => c.Cities).ToListAsync();
            return Ok(respone);
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _context.Countries.Include(c => c.Cities).FirstOrDefaultAsync(x => x.Id == id);

            if (response == null)
            {
                return NotFound();
            }
            return Ok(response);
        }

        //[HttpPost]
        //public async Task<IActionResult> Post([FromBody]Country model)
        //{
        //    if (model == null)
        //    {
        //        return BadRequest();
        //    }
        //    _context.Countries.Add(model);
        //    await _context.SaveChangesAsync();
        //    return Ok();
        //}

        [HttpPost]
        public async Task<IActionResult> PostWithCities([FromBody] Country country)
        {
            if (country == null)
            {
                return BadRequest();
            }
            _context.Countries.Add(country);
            _context.Cities.AddRange(country.Cities);

            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Country model)
        {
            if (model == null)
            {
                return BadRequest();
            }      
            _context.Countries.Update(model);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete]
        [Route("{Id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _context.Countries.FindAsync(id);

            if (response == null)
            {
                return NotFound();
            }
            _context.Countries.Remove(response);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
