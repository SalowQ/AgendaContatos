using AgendaContatos.Domain.Entities;
using AgendaContatos.Domain.Services.LoggedUser;
using AgendaContatos.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace AgendaContatos.Infrastructure.Services
{
    internal class LoggedUser : ILoggedUser
    {
        private readonly AgendaContatosDbContext _dbContext;
        public LoggedUser(AgendaContatosDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<User> Get()
        {
            string token = "token";
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = tokenHandler.ReadJwtToken(token);
            var identifier = jwtSecurityToken.Claims.First(claim => claim.Type == ClaimTypes.Sid).Value;
            return await _dbContext.Users.AsNoTracking().FirstAsync(user => user.UserIdentifier == Guid.Parse(identifier));
        }
    }
}
