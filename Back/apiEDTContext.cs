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

        public DbSet<Matiere> Matiere { get; set; }
        public DbSet<Period> Period { get; set; }
        public DbSet<Uemodule> Uemodule { get; set; }

        public DbSet<EdtItem> EdtItem { get; set; }
    }
}