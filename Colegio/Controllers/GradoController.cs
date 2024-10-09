using Colegio.DataContext;
using Colegio.Model;
using Microsoft.AspNetCore.Mvc;

namespace Colegio.Controllers
{
    [Route("api/Grado")]
    [ApiController]
    public class GradoController : ControllerBase
    {
        private readonly ColegioContext _context;

        public GradoController(ColegioContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public ActionResult<IEnumerable<Grado>> GetAllGrados()
        {
            try
            {
                var grados = _context.Grado.ToList();
                return Ok(grados);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        
        [HttpGet("{id}")]
        public ActionResult<Grado> GetGradoById(int id)
        {
            try
            {
                var grado = _context.Grado.Find(id);
                if (grado == null)
                {
                    return NotFound($"Grado con ID {id} no encontrado.");
                }

                return Ok(grado);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        
        [HttpPost]
        public IActionResult CreateGrado([FromBody] Grado grado)
        {
            try
            {
                _context.Grado.Add(grado);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        
        [HttpPut("{id}")]
        public IActionResult UpdateGrado(int id, [FromBody] Grado grado)
        {
            if (id != grado.Id)
            {
                return BadRequest("El ID del grado no coincide con el parámetro de la URL.");
            }

            try
            {
                _context.Grado.Update(grado);
                return NoContent(); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }

        
        [HttpDelete("{id}")]
        public IActionResult DeleteGrado(int id)
        {
            try
            {
                var grado = _context.Grado.Find(id);
                if (grado == null)
                {
                    return NotFound($"Grado con ID {id} no encontrado.");
                }

                _context.Grado.Remove(grado);
                return NoContent(); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }
    }
}
