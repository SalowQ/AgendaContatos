using AgendaContatos.Domain.Entities;
using AgendaContatos.Domain.Security.Tokens;
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
        private readonly ITokenProvider _tokenProvider;
        public LoggedUser(AgendaContatosDbContext dbContext, ITokenProvider tokenProvider)
        {
            _dbContext = dbContext;
            _tokenProvider = tokenProvider;
        }
        public async Task<User> Get()
        {
            string token = _tokenProvider.TokenOnRequest();
            var tokenHandler = new JwtSecurityTokenHandler();
            var jwtSecurityToken = tokenHandler.ReadJwtToken(token);
            var identifier = jwtSecurityToken.Claims.First(claim => claim.Type == ClaimTypes.Sid).Value;
            return await _dbContext.Users.AsNoTracking().FirstAsync(user => user.UserIdentifier == Guid.Parse(identifier));
        }
    }
}
