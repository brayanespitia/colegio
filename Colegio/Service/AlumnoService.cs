using Colegio.Model;

namespace Colegio.Service
{
    public interface AlumnoService
    {
        void Add(Alumno alumno);
        Alumno GetById(int id);
        IEnumerable<Alumno> GetAll();
        void Update(Alumno alumno);
        void Delete(int id);
    }
}
