using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using WebApiAkademic.Data;
using WebApiAkademic.Data.POCO;
using WebApiAkademic.WebUtilities;

namespace WebApiAkademic.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MasterMahasiswasController : ControllerBase, IEntityControllerInfo
    {
        private readonly AcademicRegistrationDbContext _context;

        #region IEntityControllerInfo Members
        public string FriendlyTableName => "Master mahasiswa";
        public string FriendlyPKName => "Id/nomer urut mahasiswa";

        #endregion

        private readonly System.Threading.Lock _dbConcurrentLock = new();

        public MasterMahasiswasController(AcademicRegistrationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<MasterMahasiswa>>> GetMahasiswas()
        {
            return await _context.Mahasiswas.ToListAsync();
        }

        // GET: MasterMahasiswas/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<MasterMahasiswa>> GetMasterMahasiswa(long id)
        {
            var masterMahasiswa = await _context.Mahasiswas.FindAsync(id);

            if (masterMahasiswa == null)
            {
                //return NotFound();
                return this.GenerateNotFoundForGetResult(id, HttpContext.TraceIdentifier);
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
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public ObjectResult PostMasterMahasiswa([FromBody] MasterMahasiswa masterMahasiswa)
        {
            ObjectResult resultResponse = new CreatedResult();
            if (MasterMahasiswaExists(masterMahasiswa.MahasiswaId))
            {
                //return Conflict();
                return this.GenerateConflictResult(masterMahasiswa.MahasiswaId, HttpContext.TraceIdentifier);
            }
            try
            {
                _context.Mahasiswas.Add(masterMahasiswa);
                _context.SaveChanges();
                resultResponse = CreatedAtAction("GetMasterMahasiswa", new { id = masterMahasiswa.MahasiswaId }, masterMahasiswa);
                return resultResponse;
            }
            catch (DbUpdateException)
            {
                throw;
            }
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
