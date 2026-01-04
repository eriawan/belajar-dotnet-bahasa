using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiAkademic.Data;
using WebApiAkademic.Data.POCO;
using WebApiAkademic.WebUtilities;

namespace WebApiAkademic.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MasterJurusansController : ControllerBase, IEntityControllerInfo
    {
        private readonly AcademicRegistrationDbContext _context;

        public string FriendlyTableName => "Master jurusan";

        public string FriendlyPKName => "Id jurusan";

        public MasterJurusansController(AcademicRegistrationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MasterJurusan>>> GetJurusans()
        {
            return await _context.Jurusans.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MasterJurusan>> GetMasterJurusan(int id)
        {
            var masterJurusan = await _context.Jurusans.FindAsync(id);

            if (masterJurusan == null)
            {
                return this.GenerateNotFoundForGetResult(id, HttpContext.TraceIdentifier);
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
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public ActionResult<MasterJurusan> PostMasterJurusan([FromBody] MasterJurusan masterJurusan)
        {
            if (MasterJurusanExists(masterJurusan.JurusanId))
            {
                //return Conflict();
                return this.GenerateConflictResult(masterJurusan.JurusanId, HttpContext.TraceIdentifier);
            }
            try
            {
                _context.Jurusans.Add(masterJurusan);
                _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw;
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
