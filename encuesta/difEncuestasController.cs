using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using encuesta.Models;
//en esta parte podemos observar las respectivas partes del POST-GET-PUT-DELETE
//basicamente este es el controlador del api
namespace encuesta
{
    //colocamos la ruta de conexion con el api
    [Route("api/[controller]")]
    [ApiController]
    public class difEncuestasController : ControllerBase
    {
        //readonly indica que solo se puede asignar como parte de una misma clase 
        private readonly encuestaContext _context;

        public difEncuestasController(encuestaContext context)
        {
            _context = context;
        }

        // GET: api/difEncuestas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<difEncuestas>>> GetdifEncuestas()
        {
          if (_context.difEncuestas == null)
          {
              return NotFound();
          }
            return await _context.difEncuestas.ToListAsync();
        }

        // GET: api/difEncuestas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<difEncuestas>> GetdifEncuestas(long id)
        {
          if (_context.difEncuestas == null)
          {
              return NotFound();
          }
            var difEncuestas = await _context.difEncuestas.FindAsync(id);

            if (difEncuestas == null)
            {
                return NotFound();
            }

            return difEncuestas;
        }

        // PUT: api/difEncuestas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutdifEncuestas(long id, difEncuestas difEncuestas)
        {
            if (id != difEncuestas.IdEncuesta)
            {
                return BadRequest();
            }

            _context.Entry(difEncuestas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!difEncuestasExists(id))
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

        // POST: api/difEncuestas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<difEncuestas>> PostdifEncuestas(difEncuestas difEncuestas)
        {
          if (_context.difEncuestas == null)
          {
              return Problem("Entity set 'encuestaContext.difEncuestas'  is null.");
          }
            _context.difEncuestas.Add(difEncuestas);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetdifEncuestas", new { id = difEncuestas.Id }, difEncuestas);
            return CreatedAtAction(nameof(GetdifEncuestas), new { id = difEncuestas.IdEncuesta }, difEncuestas);
        }

        // DELETE: api/difEncuestas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletedifEncuestas(long id)
        {
            if (_context.difEncuestas == null)
            {
                return NotFound();
            }
            var difEncuestas = await _context.difEncuestas.FindAsync(id);
            if (difEncuestas == null)
            {
                return NotFound();
            }

            _context.difEncuestas.Remove(difEncuestas);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool difEncuestasExists(long id)
        {
            return (_context.difEncuestas?.Any(e => e.IdEncuesta == id)).GetValueOrDefault();
        }
    }
}
