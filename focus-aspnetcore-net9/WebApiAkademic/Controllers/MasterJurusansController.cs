using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiAkademic.Data;
using WebApiAkademic.Data.POCO;

namespace WebApiAkademic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterJurusansController : ControllerBase
    {
        private readonly AcademicRegistrationDbContext _context;

        public MasterJurusansController(AcademicRegistrationDbContext context)
        {
            _context = context;
        }

        // GET: api/MasterJurusans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MasterJurusan>>> GetJurusans()
        {
            return await _context.Jurusans.ToListAsync();
        }

        // GET: api/MasterJurusans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MasterJurusan>> GetMasterJurusan(int id)
        {
            var masterJurusan = await _context.Jurusans.FindAsync(id);

            if (masterJurusan == null)
            {
                return NotFound();
            }

            return masterJurusan;
        }

        // PUT: api/MasterJurusans/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMasterJurusan(int id, MasterJurusan masterJurusan)
        {
            if (id != masterJurusan.JurusanId)
            {
                return BadRequest();
            }

            _context.Entry(masterJurusan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MasterJurusanExists(id))
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

        // POST: api/MasterJurusans
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MasterJurusan>> PostMasterJurusan(MasterJurusan masterJurusan)
        {
            _context.Jurusans.Add(masterJurusan);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MasterJurusanExists(masterJurusan.JurusanId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMasterJurusan", new { id = masterJurusan.JurusanId }, masterJurusan);
        }

        // DELETE: api/MasterJurusans/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMasterJurusan(int id)
        {
            var masterJurusan = await _context.Jurusans.FindAsync(id);
            if (masterJurusan == null)
            {
                return NotFound();
            }

            _context.Jurusans.Remove(masterJurusan);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MasterJurusanExists(int id)
        {
            return _context.Jurusans.Any(e => e.JurusanId == id);
        }
    }
}
