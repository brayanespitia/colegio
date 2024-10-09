using Colegio.DataContext;
using Colegio.Model;

namespace Colegio.Service.AlumnoServiceImpl
{
    public class AlumnoServiceImpl : AlumnoService
    {
        
        private readonly ColegioContext _context;

        public AlumnoServiceImpl( ColegioContext context)
        {            
            _context = context;
        }

        public void Add(Alumno alumno)
        {
            Alumno nuevoAlumno = new Alumno
            {
                Id = alumno.Id,
                Nombre = alumno.Nombre,
                Apellidos = alumno.Apellidos,
                FechaNacimiento = alumno.FechaNacimiento,
                Genero = alumno.Genero,
            };
            _context.Alumno.Add(nuevoAlumno);
            _context.SaveChanges();

        }

        public Alumno GetById(int id)
        {
            return _context.Alumno.Find(id);
        }

        public IEnumerable<Alumno> GetAll()
        {
            return _context.Alumno.ToList();
        }

        public void Update(Alumno alumno)
        {
            _context.Alumno.Update(alumno);
            _context.SaveChanges();

        }

        public void Delete(int id)
        {
            var alumno = _context.Alumno.Find(id);
            if (alumno != null)
            {
                _context.Alumno.Remove(alumno);
                _context.SaveChanges();
            }
        }


    }
}
