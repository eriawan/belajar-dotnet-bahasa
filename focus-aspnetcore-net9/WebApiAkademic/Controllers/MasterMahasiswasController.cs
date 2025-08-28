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
    public class MasterMahasiswasController : ControllerBase
    {
        private readonly AcademicRegistrationDbContext _context;

        public MasterMahasiswasController(AcademicRegistrationDbContext context)
        {
            _context = context;
        }

        // GET: api/MasterMahasiswas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MasterMahasiswa>>> GetMahasiswas()
        {
            return await _context.Mahasiswas.ToListAsync();
        }

        // GET: api/MasterMahasiswas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MasterMahasiswa>> GetMasterMahasiswa(long id)
        {
            var masterMahasiswa = await _context.Mahasiswas.FindAsync(id);

            if (masterMahasiswa == null)
            {
                return NotFound();
            }

            return masterMahasiswa;
        }

        // PUT: api/MasterMahasiswas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMasterMahasiswa(long id, MasterMahasiswa masterMahasiswa)
        {
            if (id != masterMahasiswa.MahasiswaId)
            {
                return BadRequest();
            }

            _context.Entry(masterMahasiswa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MasterMahasiswaExists(id))
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

        // POST: api/MasterMahasiswas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MasterMahasiswa>> PostMasterMahasiswa(MasterMahasiswa masterMahasiswa)
        {
            _context.Mahasiswas.Add(masterMahasiswa);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MasterMahasiswaExists(masterMahasiswa.MahasiswaId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMasterMahasiswa", new { id = masterMahasiswa.MahasiswaId }, masterMahasiswa);
        }

        // DELETE: api/MasterMahasiswas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMasterMahasiswa(long id)
        {
            var masterMahasiswa = await _context.Mahasiswas.FindAsync(id);
            if (masterMahasiswa == null)
            {
                return NotFound();
            }

            _context.Mahasiswas.Remove(masterMahasiswa);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MasterMahasiswaExists(long id)
        {
            return _context.Mahasiswas.Any(e => e.MahasiswaId == id);
        }
    }
}
