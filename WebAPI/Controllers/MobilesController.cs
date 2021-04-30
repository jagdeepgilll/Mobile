using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    //Api controller for Mobiles
    [Route("api/[controller]")]
    [ApiController]
    public class MobilesController : ControllerBase
    {
        private readonly WebAPI_DataContext _context;

        public MobilesController(WebAPI_DataContext context)
        {
            _context = context;
        }

        // GET: api/Mobiles
        // //Get all Mobiles using a linq query
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Mobile>>> GetMobile()
        {
            return await _context.Mobile.ToListAsync();
        }

        // GET: api/Mobiles/5
        //Gets  the Mobiles details using linq
        [HttpGet("{id}")]
        public async Task<ActionResult<Mobile>> GetMobile(int id)
        {
            var Mobile = await _context.Mobile.FindAsync(id);

            if (Mobile == null)
            {
                return NotFound();
            }

            return Mobile;
        }

        // PUT: api/Mobiles/5

        //Update Mobiles
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMobile(int id, Mobile Mobile)
        {
            if (id != Mobile.Id)
            {
                return BadRequest();
            }

            _context.Entry(Mobile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MobileExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Mobiles

        //Adds an Mobile
        [HttpPost]
        public async Task<ActionResult<Mobile>> PostMobile(Mobile Mobile)
        {
            _context.Mobile.Add(Mobile);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMobile", new { id = Mobile.Id }, Mobile);
        }

        // DELETE: api/Mobiles/5
        //Deletes the Mobile
        [HttpDelete("{id}")]
        public async Task<ActionResult<Mobile>> DeleteMobile(int id)
        {
            var Mobile = await _context.Mobile.FindAsync(id);
            if (Mobile == null)
            {
                return NotFound();
            }

            _context.Mobile.Remove(Mobile);
            await _context.SaveChangesAsync();

            return Mobile;
        }

        //Checks the Mobile using a lamda
        private bool MobileExists(int id)
        {
            return _context.Mobile.Any(e => e.Id == id);
        }
    }
}