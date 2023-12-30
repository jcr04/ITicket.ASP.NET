using ITicket.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ITicket.Infra.Data
{
    public class YourDbContext : DbContext
    {
        public YourDbContext(DbContextOptions<YourDbContext> options) : base(options)
        {
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Adicione configurações específicas do modelo, se necessário
        }
    }
}
