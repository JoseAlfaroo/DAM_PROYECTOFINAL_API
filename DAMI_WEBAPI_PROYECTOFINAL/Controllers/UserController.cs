using DAMI_WEBAPI_PROYECTOFINAL.Contexts;
using DAMI_WEBAPI_PROYECTOFINAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DAMI_WEBAPI_PROYECTOFINAL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }


        [HttpGet("email")]
        public async Task<IActionResult> FindByEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return BadRequest("Email no valido");
            }

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);

            if (user == null)
            {
                return NotFound("No se encontró usuario por email");
            }

            return Ok(user);

        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserModel model)
        {
            if (model == null)
            {
                return BadRequest(new { message = "Error en registro." });
            }

            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == model.Email);

            if (existingUser != null)
            {
                return Conflict(new { message = "Correo ya registrado." });
            }

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(model.Password);

            var user = new UserModel
            {
                Nombres = model.Nombres,
                Apellidos = model.Apellidos,
                Email = model.Email,
                Password = hashedPassword
            };

            try
            {
                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                return Ok(new { message = "Usuario registrado correctamente" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            if (model == null)
            {
                return BadRequest(new { message = "Datos de inicio de sesión incorrectos." });
            }

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == model.Email);

            if (user == null)
            {
                return NotFound(new { message = "Correo electrónico o contraseña incorrectos." });
            }

            // Verificar la contraseña con BCrypt
            if (!BCrypt.Net.BCrypt.Verify(model.Password, user.Password))
            {
                return Unauthorized(new { message = "Correo electrónico o contraseña incorrectos." });
            }


            return Ok(new { message = "Inicio de sesión exitoso" , userId = user.UserID});
        }

    }


}
