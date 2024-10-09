using Colegio.Model;

namespace Colegio.Service
{
    public interface ProfesorService
    {
        void CreateProfesor(Profesor profesor);
        Profesor GetProfesorById(int id);
        IEnumerable<Profesor> GetAllProfesores();
        void UpdateProfesor(Profesor profesor);
        void DeleteProfesor(int id);
    }
}
