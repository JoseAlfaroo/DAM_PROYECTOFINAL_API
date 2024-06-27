using DAMI_WEBAPI_PROYECTOFINAL.Contexts;
using DAMI_WEBAPI_PROYECTOFINAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DAMI_WEBAPI_PROYECTOFINAL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LibroController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] string? buscar)
        {
            try
            {
                var query = _context.Libros.AsQueryable();

                if (!string.IsNullOrEmpty(buscar))
                {
                    query = query.Where(l => l.Titulo.Contains(buscar) || l.Autor.Contains(buscar));
                }

                var libros = await query.ToListAsync();
                return Ok(libros);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.ToString() });
            }

        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var libro = await _context.Libros.FindAsync(id);

                if (libro == null)
                {
                    return NotFound(new { message = "Libro no encontrado" });
                }

                return Ok(libro);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.ToString() });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] LibroModel model)
        {
            var manga = new LibroModel
            {
                Titulo = model.Titulo,
                Autor = model.Autor,
                Genero = model.Genero,
                Descripcion = model.Descripcion,
                Imagen = model.Imagen
            };

            try
            {
                _context.Libros.Add(manga);
                await _context.SaveChangesAsync();

                return Ok(model);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.ToString() });
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] LibroModel model)
        {
            try
            {
                var libro = await _context.Libros.FindAsync(id);

                if (libro == null)
                {
                    return NotFound(new { message = "Libro no encontrado" });
                }

                libro.Titulo = model.Titulo;
                libro.Autor = model.Autor;
                libro.Genero = model.Genero;
                libro.Descripcion = model.Descripcion;
                libro.Imagen = model.Imagen;

                _context.Libros.Update(libro);
                await _context.SaveChangesAsync();

                return Ok(model);


            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.ToString() });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var libro = await _context.Libros
                    .Include(l => l.DetallesPrestamos)
                    .FirstOrDefaultAsync(l => l.LibroID == id);

                if (libro == null)
                {
                    return NotFound(new { mensaje = "Libro no encontrado" });
                }

                _context.DetallesPrestamos.RemoveRange(libro.DetallesPrestamos);

                _context.Libros.Remove(libro);
                await _context.SaveChangesAsync();

                return Ok(new { message = "Libro eliminado correctamente" });

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.ToString() });
            }
        }
    }
}
