using AgendaContatos.Domain.Security.Tokens;

namespace AgendaContatos.Api.Token
{
    public class HttpContextTokenValue : ITokenProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public HttpContextTokenValue(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public string TokenOnRequest()
        {
            var authorization = _httpContextAccessor.HttpContext!.Request.Headers.Authorization.ToString();
            return authorization.StartsWith("Bearer ") 
                ? authorization.Substring("Bearer ".Length).Trim() 
                : string.Empty;
        }
    }
}
