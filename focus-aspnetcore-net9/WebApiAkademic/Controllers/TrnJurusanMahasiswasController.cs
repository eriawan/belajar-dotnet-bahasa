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
    [Route("[controller]")]
    [ApiController]
    public class TrnJurusanMahasiswasController : ControllerBase, IEntityControllerInfo
    {
        private readonly AcademicRegistrationDbContext _context;

        #region IEntityControllerInfo Members
        public string FriendlyTableName => "Data mahasiswa dan jurusan yang diambil";
        public string FriendlyPKName => "Id/nomer unik mahasiswa dan jurusan yang diambil";

        #endregion

        public TrnJurusanMahasiswasController(AcademicRegistrationDbContext context)
        {
            _context = context;
        }

        // GET: api/TrnJurusanMahasiswas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TrnJurusanMahasiswa>>> GetTrnJurusanMahasiswas()
        {
            return await _context.TrnJurusanMahasiswas.ToListAsync();
        }

        // GET: api/TrnJurusanMahasiswas/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<TrnJurusanMahasiswa>> GetTrnJurusanMahasiswa(long id)
        {
            var trnJurusanMahasiswa = await _context.TrnJurusanMahasiswas.FindAsync(id);

            if (trnJurusanMahasiswa == null)
            {
                //return NotFound();
                return this.GenerateNotFoundForGetResult(id, HttpContext.TraceIdentifier);
            }

            return trnJurusanMahasiswa;
        }

        // PUT: api/TrnJurusanMahasiswas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrnJurusanMahasiswa(long id, TrnJurusanMahasiswa trnJurusanMahasiswa)
        {
            if (id != trnJurusanMahasiswa.JurusanMahasiswaId)
            {
                return BadRequest();
            }

            _context.Entry(trnJurusanMahasiswa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrnJurusanMahasiswaExists(id))
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

        // POST: api/TrnJurusanMahasiswas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public ObjectResult PostTrnJurusanMahasiswa(TrnJurusanMahasiswa trnJurusanMahasiswa)
        {
            if (TrnJurusanMahasiswaExists(trnJurusanMahasiswa.JurusanMahasiswaId))
            {
                return this.GenerateConflictResult(trnJurusanMahasiswa.JurusanMahasiswaId, HttpContext.TraceIdentifier);
            }
            try
            {
                _context.TrnJurusanMahasiswas.Add(trnJurusanMahasiswa);
                _context.SaveChanges();
                return CreatedAtAction("GetTrnJurusanMahasiswa", new { id = trnJurusanMahasiswa.JurusanMahasiswaId }, trnJurusanMahasiswa);
            }
            catch (DbUpdateException)
            {
                throw;
            }

        }

        // DELETE: api/TrnJurusanMahasiswas/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult DeleteTrnJurusanMahasiswa(long id)
        {
            var trnJurusanMahasiswa = _context.TrnJurusanMahasiswas.Find(id);
            if (trnJurusanMahasiswa == null)
            {
                return this.GenerateNotFoundForDeleteResult(id);
            }

            _context.TrnJurusanMahasiswas.Remove(trnJurusanMahasiswa);
            _context.SaveChanges();

            return NoContent();
        }

        private bool TrnJurusanMahasiswaExists(long id)
        {
            return _context.TrnJurusanMahasiswas.Any(e => e.JurusanMahasiswaId == id);
        }
    }
}
