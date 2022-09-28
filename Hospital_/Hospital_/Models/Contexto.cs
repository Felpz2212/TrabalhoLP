using Microsoft.EntityFrameworkCore;

namespace Hospital_.Models
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) :
            base(options)
        { }

        public DbSet<Medico> medicos { get; set; }
        public DbSet<Paciente> pacientes { get; set; }
        public DbSet<Medicamento> medicamentos { get; set; }
        public DbSet<Consulta> consultas { get; set; }
    
    }
}
