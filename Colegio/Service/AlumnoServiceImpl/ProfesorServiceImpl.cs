using Colegio.DataContext;
using Colegio.Model;

namespace Colegio.Service.AlumnoServiceImpl
{
    public class ProfesorServiceImpl : ProfesorService
    {
        
        private readonly ColegioContext _context;

        public ProfesorServiceImpl( ColegioContext context)
        {            
            _context = context;
        }

        public IEnumerable<Profesor> GetAllProfesores()
        {
            return _context.Profesor.ToList();
        }

        public Profesor GetProfesorById(int id)
        {
            var profesor = _context.Profesor.Find(id);
            if (profesor == null)
            {
                throw new Exception($"Profesor con ID {id} no encontrado.");
            }
            return profesor;
        }

        public void CreateProfesor(Profesor profesor)
        {
            if (profesor == null)
            {
                throw new ArgumentNullException(nameof(profesor));
            }
            _context.Profesor.Add(profesor);
            _context.SaveChanges();
        }

        public void UpdateProfesor(Profesor profesor)
        {
            

            _context.Profesor.Update(profesor);
            _context.SaveChanges();
        }

        public void DeleteProfesor(int id)
        {
            var profesor = _context.Profesor.Find(id);
            if (profesor == null)
            {
                throw new Exception($"Profesor con ID {id} no encontrado.");
            }

            _context.Profesor.Remove(profesor);
            _context.SaveChanges();
        }
    }
}
