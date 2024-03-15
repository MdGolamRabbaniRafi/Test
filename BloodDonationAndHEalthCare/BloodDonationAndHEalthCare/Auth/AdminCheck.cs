using BLL.Services;
using System.Net;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Net.Http;

public class AdminCheck : AuthorizationFilterAttribute
{
    public override void OnAuthorization(HttpActionContext actionContext)
    {
        var token = actionContext.Request.Headers.Authorization;
        var data = AuthService.isTokenAdminValid(token.ToString());
        if (!data)
        {
            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized, new { Message = "Unauthorized" });
        }
        base.OnAuthorization(actionContext);
    }
}
