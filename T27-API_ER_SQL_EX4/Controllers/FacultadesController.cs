﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using T27_API_ER_SQL_EX4.Model;

namespace T27_API_ER_SQL_EX4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacultadesController : ControllerBase
    {
        private readonly APIContext _context;

        public FacultadesController(APIContext context)
        {
            _context = context;
        }

        // GET: api/Facultades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Facultad>>> GetFacultades()
        {
            return await _context.Facultades.ToListAsync();
        }

        // GET: api/Facultades/5
        [HttpGet("{Codigo}")]
        public async Task<ActionResult<Facultad>> GetFacultad(int id)
        {
            var facultad = await _context.Facultades.FindAsync(id);

            if (facultad == null)
            {
                return NotFound();
            }

            return facultad;
        }

        // PUT: api/Facultades/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{Codigo}")]
        public async Task<IActionResult> PutFacultad(int id, Facultad facultad)
        {
            if (id != facultad.Codigo)
            {
                return BadRequest();
            }

            _context.Entry(facultad).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FacultadExists(id))
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

        // POST: api/Facultades
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Facultad>> PostFacultad(Facultad facultad)
        {
            _context.Facultades.Add(facultad);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFacultad", new { id = facultad.Codigo }, facultad);
        }

        // DELETE: api/Facultades/5
        [HttpDelete("{Codigo}")]
        public async Task<ActionResult<Facultad>> DeleteFacultad(int id)
        {
            var facultad = await _context.Facultades.FindAsync(id);
            if (facultad == null)
            {
                return NotFound();
            }

            _context.Facultades.Remove(facultad);
            await _context.SaveChangesAsync();

            return facultad;
        }

        private bool FacultadExists(int id)
        {
            return _context.Facultades.Any(e => e.Codigo == id);
        }
    }
}
