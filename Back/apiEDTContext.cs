using Microsoft.EntityFrameworkCore;
using apiEDT.Back.Models;


namespace apiEDT.Back
{
    public class apiEDTContext : DbContext
    {
        public apiEDTContext(DbContextOptions<apiEDTContext> options)
            : base(options)
        {
        }

        public DbSet<Matiere> Matieres { get; set; }
        public DbSet<Period> Periods { get; set; }
        public DbSet<Uemodule> Uemodules { get; set; }
    }
}