using Microsoft.AspNetCore.Http;

public class MiddlewareForUseSessionVariables
{
    public IHttpContextAccessor _httpContextAccessor;

    public MiddlewareForUseSessionVariables(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public void MeuMetodo()
    {
        var session = _httpContextAccessor.HttpContext.Session;
    }
}
