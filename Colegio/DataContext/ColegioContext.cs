using Colegio.Model;
using Microsoft.EntityFrameworkCore;

namespace Colegio.DataContext
{
    public class ColegioContext : DbContext
    {
        public ColegioContext(DbContextOptions<ColegioContext> options)
       : base(options)
        {
        }
        public DbSet<Alumno> Alumno { get; set; }
        public DbSet<Profesor> Profesor { get; set; }
        public DbSet<Grado> Grado { get; set; }
        public DbSet<AlumnoGrado> AlumnoGrado { get; set; }

        
    }
}
