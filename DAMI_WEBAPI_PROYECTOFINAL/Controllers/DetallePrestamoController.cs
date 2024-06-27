using DAMI_WEBAPI_PROYECTOFINAL.Contexts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DAMI_WEBAPI_PROYECTOFINAL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetallePrestamoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DetallePrestamoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var detallePrestamo = await _context.DetallesPrestamos.ToListAsync();
                return Ok(detallePrestamo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.ToString() });
            }

        }

        [HttpGet("VerDetallesPorPrestamo/{id}")]
        public async Task<IActionResult> GetAllDetallesByPrestamoId(int id)
        {

            try
            {
                var detallesPrestamo = await _context.DetallesPrestamos.Where(dp => dp.PrestamoID == id).ToListAsync();

                if (detallesPrestamo == null || detallesPrestamo.Count == 0)
                {
                    return NotFound(new { message = "No se encontró tal prestamo ni sus detalles." });
                }

                return Ok(detallesPrestamo);

            }

            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.ToString() });
            }
        }

        [HttpGet("VerDetalle/{id}")]
        public async Task<IActionResult> GetDetallesByPrestamoId(int id)
        {

            try
            {
                var detallePrestamo = await _context.DetallesPrestamos.FindAsync(id);

                if (detallePrestamo == null)
                {
                    return NotFound(new { message = "Detalle de prestamo no encontrado" });
                }

                return Ok(detallePrestamo);

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.ToString() });
            }
        }
    }
}
