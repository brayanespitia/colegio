using Colegio.DataContext;
using Colegio.Model;
using Colegio.Service;
using Microsoft.AspNetCore.Mvc;

namespace Colegio.Controllers
{
    [Route("api/AlumnoGrado")]
    [ApiController]
    public class AlumnoGradoController : ControllerBase 
    {
         private readonly ColegioContext _context;

        public AlumnoGradoController(ColegioContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public ActionResult<IEnumerable<AlumnoGrado>> GetAllAlumnoGrados()
        {
            try
            {
                var alumnoGrados = _context.AlumnoGrado.ToList();
                return Ok(alumnoGrados);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        
        [HttpGet("{id}")]
        public ActionResult<AlumnoGrado> GetAlumnoGradoById(int id)
        {
            try
            {
                var alumnoGrado = _context.AlumnoGrado.Find(id);
                if (alumnoGrado == null)
                {
                    return NotFound($"AlumnoGrado con ID {id} no encontrado.");
                }

                return Ok(alumnoGrado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        
        [HttpPost]
        public IActionResult CreateAlumnoGrado([FromBody] AlumnoGrado alumnoGrado)
        {
            try
            {
                _context.AlumnoGrado.Add(alumnoGrado);
                return CreatedAtAction(nameof(GetAlumnoGradoById), new { id = alumnoGrado.Id }, alumnoGrado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        
        [HttpPut("{id}")]
        public IActionResult UpdateAlumnoGrado(int id, [FromBody] AlumnoGrado alumnoGrado)
        {
            if (id != alumnoGrado.Id)
            {
                return BadRequest("El ID del AlumnoGrado no coincide con el parámetro de la URL.");
            }

            try
            {
                _context.AlumnoGrado.Update(alumnoGrado);
                return NoContent(); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        
        [HttpDelete("{id}")]
        public IActionResult DeleteAlumnoGrado(int id)
        {
            try
            {
                var alumnoGrado = _context.AlumnoGrado.Find(id);
                if (alumnoGrado == null)
                {
                    return NotFound($"AlumnoGrado con ID {id} no encontrado.");
                }

                _context.AlumnoGrado.Remove(alumnoGrado);
                return NoContent(); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
    }
}
