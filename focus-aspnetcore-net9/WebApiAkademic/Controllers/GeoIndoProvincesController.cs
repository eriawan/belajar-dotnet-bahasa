using System;
using System.Collections.Generic;
using System.Data.Common;
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
    public class GeoIndoProvincesController : ControllerBase, IEntityControllerInfo
    {
        private readonly AcademicRegistrationDbContext _context;

        public string FriendlyTableName => "Master nama propinsi";

        public string FriendlyPKName => "Id propinsi";

        public GeoIndoProvincesController(AcademicRegistrationDbContext context)
        {
            _context = context;
        }

        // GET: api/GeoIndoProvinces
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<GeoIndoProvince>>> GetGeoIndoProvinces()
        {
            return await _context.GeoIndoProvinces.ToListAsync();
        }

        // GET: api/GeoIndoProvinces/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<GeoIndoProvince>> GetGeoIndoProvince(int id)
        {
            var geoIndoProvince = await _context.GeoIndoProvinces.FindAsync(id);

            if (geoIndoProvince == null)
            {
                //return NotFound();
                return this.GenerateNotFoundForGetResult(id, HttpContext.TraceIdentifier);
            }

            return geoIndoProvince;
        }

        // PUT: api/GeoIndoProvinces/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutGeoIndoProvince(int id, GeoIndoProvince geoIndoProvince)
        {
            if (id != geoIndoProvince.ProvinceId)
            {
                return BadRequest();
            }

            _context.Entry(geoIndoProvince).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GeoIndoProvinceExists(id))
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

        // POST: api/GeoIndoProvinces
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<ActionResult<GeoIndoProvince>> PostGeoIndoProvince(GeoIndoProvince geoIndoProvince)
        {
            var id = geoIndoProvince.ProvinceId;
            if (GeoIndoProvinceExists(id))
            {
                return this.GenerateConflictResult(id, HttpContext.TraceIdentifier);
            }
            try
            {
                _context.GeoIndoProvinces.Add(geoIndoProvince);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                throw;
            }

            return CreatedAtAction("GetGeoIndoProvince", new { id = geoIndoProvince.ProvinceId }, geoIndoProvince);
        }

        // DELETE: api/GeoIndoProvinces/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteGeoIndoProvince(int id)
        {
            var geoIndoProvince = await _context.GeoIndoProvinces.FindAsync(id);
            if (geoIndoProvince == null)
            {
                return this.GenerateNotFoundForDeleteResult(id);
            }
            _context.GeoIndoProvinces.Remove(geoIndoProvince);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GeoIndoProvinceExists(int id)
        {
            return _context.GeoIndoProvinces.Any(e => e.ProvinceId == id);
        }
    }
}
