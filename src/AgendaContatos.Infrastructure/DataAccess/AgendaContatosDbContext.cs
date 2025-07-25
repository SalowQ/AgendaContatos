using AgendaContatos.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AgendaContatos.Infrastructure.DataAccess
{
    internal class AgendaContatosDbContext : DbContext
    {
        public AgendaContatosDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Contact> Contacts { get; set; }
    }
}
