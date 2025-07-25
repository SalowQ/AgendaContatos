using AgendaContatos.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AgendaContatos.Infrastructure.DataAccess
{
    public class AgendaContatosDbContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=localhost;Database=agendacontatosdb;Uid=root;Pwd=@password123;";
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 11));
            optionsBuilder.UseMySql(connectionString, serverVersion);
        }
    }
}
