using Colegio.Model;
using Colegio.Service;
using Microsoft.AspNetCore.Mvc;

namespace Colegio.Controllers
{
    [Route("api/Alumno")]
    [ApiController]
    public class AlumnoController : ControllerBase
    {

        private readonly AlumnoService _alumnoService;

        public AlumnoController(AlumnoService alumnoService)
        {
            _alumnoService = alumnoService;
        }

        [HttpPost]
        public IActionResult CrearAlumno(Alumno alumno)
        {
            if (alumno == null)
            {
                return BadRequest("Los datos de la persona son inválidos.");
            }

            try
            {
                _alumnoService.Add(alumno);

                return Ok(alumno);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message, inner = ex.InnerException?.Message });
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<Alumno>> GetAllAlumnos()
        {
            try
            {
                var alumnos = _alumnoService.GetAll();
                return Ok(alumnos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        
        [HttpGet("{id}")]
        public ActionResult<Alumno> GetAlumnoById(int id)
        {
            try
            {
                var alumno = _alumnoService.GetById(id);
                if (alumno == null)
                {
                    return NotFound($"Alumno con ID {id} no encontrado.");
                }

                return Ok(alumno);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        
        [HttpPut("{id}")]
        public IActionResult UpdateAlumno(int id, [FromBody] Alumno alumno)
        {
            if (id != alumno.Id)
            {
                return BadRequest("El ID del alumno no coincide con el parámetro de la URL.");
            }

            try
            {
                _alumnoService.Update(alumno); 
                return Ok(); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        
        [HttpDelete("{id}")]
        public IActionResult DeleteAlumno(int id)
        {
            try
            {
                var alumno = _alumnoService.GetById(id); 
                if (alumno == null)
                {
                    return NotFound($"Alumno con ID {id} no encontrado.");
                }

                _alumnoService.Delete(id); 
                return NoContent(); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
    }
}
