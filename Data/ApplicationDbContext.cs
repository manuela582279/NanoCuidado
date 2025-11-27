using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NanoCuidado.Models;

namespace NanoCuidado.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Consulta> Consultas { get; set; }
        public DbSet<Exame> Exames { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Paciente> Pacientes { get; set; }
        public DbSet<Tratamento> Tratamentos { get; set; }

    }
}
