using Colegio.Model;
using Colegio.Service;
using Microsoft.AspNetCore.Mvc;

namespace Colegio.Controllers
{
    [Route("api/Profesor")]
    [ApiController]
    public class ProfesorController : ControllerBase
    {
        private readonly ProfesorService _profesorService; 

        public ProfesorController(ProfesorService profesorService)
        {
            _profesorService = profesorService;
        }

        
        [HttpPost]
        public IActionResult CrearProfesor(Profesor profesor)
        {
            if (profesor == null)
            {
                return BadRequest("Los datos del profesor son inválidos.");
            }

            try
            {
                _profesorService.CreateProfesor(profesor); 
                return Ok(profesor);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message, inner = ex.InnerException?.Message });
            }
        }

        
        [HttpGet]
        public ActionResult<IEnumerable<Profesor>> GetAllProfesores()
        {
            try
            {
                var profesores = _profesorService.GetAllProfesores(); 
                return Ok(profesores);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        
        [HttpGet("{id}")]
        public ActionResult<Profesor> GetProfesorById(int id)
        {
            try
            {
                var profesor = _profesorService.GetProfesorById(id);
                if (profesor == null)
                {
                    return NotFound($"Profesor con ID {id} no encontrado.");
                }

                return Ok(profesor);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        
        [HttpPut("{id}")]
        public IActionResult UpdateProfesor(int id, [FromBody] Profesor profesor)
        {
            if (id != profesor.Id)
            {
                return BadRequest("El ID del profesor no coincide con el parámetro de la URL.");
            }

            try
            {
                _profesorService.UpdateProfesor(profesor);
                return Ok(); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        
        [HttpDelete("{id}")]
        public IActionResult DeleteProfesor(int id)
        {
            try
            {
                var profesor = _profesorService.GetProfesorById(id);
                if (profesor == null)
                {
                    return NotFound($"Profesor con ID {id} no encontrado.");
                }

                _profesorService.DeleteProfesor(id);
                return Ok(); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
    }
}
