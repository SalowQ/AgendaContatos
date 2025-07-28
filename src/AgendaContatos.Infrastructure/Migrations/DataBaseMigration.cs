using AgendaContatos.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AgendaContatos.Infrastructure.Migrations
{
    public class DataBaseMigration
    {
        public async static Task MigrateDatabase(IServiceProvider serviceProvider)
        {
            var dbContext = serviceProvider.GetRequiredService<AgendaContatosDbContext>();
            await dbContext.Database.MigrateAsync();
        }
    }
}
