﻿using DAMI_WEBAPI_PROYECTOFINAL.Contexts;
using DAMI_WEBAPI_PROYECTOFINAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DAMI_WEBAPI_PROYECTOFINAL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrestamoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PrestamoController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PrestamoModel model)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var prestamo = new PrestamoModel
                {
                    UserID = model.UserID,
                    FechaPrestamo = DateTime.Now,
                    DetallesPrestamos = new List<DetallePrestamoModel>()
                };

                foreach (var detalleModel in model.DetallesPrestamos)
                {
                    var detalle = new DetallePrestamoModel
                    {
                        LibroID = detalleModel.LibroID,
                        Prestamo = prestamo
                    };

                    prestamo.DetallesPrestamos.Add(detalle);
                }

                _context.Prestamos.Add(prestamo);
                await _context.SaveChangesAsync();

                await transaction.CommitAsync();

                return Ok(prestamo);

            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                return StatusCode(500, new { message = ex.ToString() });
            }

        }
    }
}