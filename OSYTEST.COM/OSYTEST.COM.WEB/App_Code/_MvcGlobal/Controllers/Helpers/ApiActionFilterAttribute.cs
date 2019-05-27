using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

/// <summary>
/// Filter Attribute For ApiControllers
/// </summary>
public class ApiActionFilterAttribute : ActionFilterAttribute
{
    public override void OnActionExecuting(HttpActionContext actionContext)
    {
        // Validate referrer ( Source uri 가 .interpark.com 이 아닐 경우 동작하지 않음 )
        if (actionContext.Request.Headers.Referrer == null || actionContext.Request.Headers.Referrer.Host.ToLower().IndexOf(".thetravel.com") == -1)
            throw new System.MethodAccessException("This request is not granted");
    }

    public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
    {
        
    }
}