using NLog;
using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;

/// <summary>
/// Error Handling For ApiControllers
/// </summary>
public class ApiGlobalExceptionHandler : ExceptionHandler
{
    public static Logger logger = LogManager.GetCurrentClassLogger();

    public override void Handle(ExceptionHandlerContext context)
    {
        if (context.Exception is ArgumentNullException)
        {
            // Return 400
            var result = new HttpResponseMessage(HttpStatusCode.BadRequest)
            {
                Content = new StringContent(context.Exception.Message),
                ReasonPhrase = "ArgumentNullException"
            };

            context.Result = new ArgumentNullResult(context.Request, result);
        }
        else if (context.Exception is MethodAccessException)
        {
            // Return 405 
            var result = new HttpResponseMessage(HttpStatusCode.MethodNotAllowed)
            {
                Content = new StringContent(context.Exception.Message),
                ReasonPhrase = "MethodAccessException"
            };

            context.Result = new DefaultResult(context.Request, result);
        }
        else
        {
            // Return 500
            var result = new HttpResponseMessage(HttpStatusCode.InternalServerError)
            {
                Content = new StringContent(context.Exception.Message),
                ReasonPhrase = "Exception"
            };

            context.Result = new DefaultResult(context.Request, result);
        }


        #region Register Log

        string url = context.Request.RequestUri.OriginalString;
        string controller = context.RequestContext.RouteData.Values["controller"].ToString();
        string action = context.RequestContext.RouteData.Values["action"] != null ? context.RequestContext.RouteData.Values["action"].ToString() : string.Empty;
        string method = context.Request.Method.ToString();
        string msg = context.Exception.Message;

        logger.Error(string.Format(@"
                < ApiController Error >
                [URL]           : {0}
                [Controller]    : {1}
                [Action]        : {2} 
                [ErrMsg]        : {3}"
        , url
        , controller
        , action
        , msg));

        #endregion / Register Log
    }

    public class ArgumentNullResult : IHttpActionResult
    {
        private HttpRequestMessage _request;
        private HttpResponseMessage _httpResponseMessage;


        public ArgumentNullResult(HttpRequestMessage request, HttpResponseMessage httpResponseMessage)
        {
            _request = request;
            _httpResponseMessage = httpResponseMessage;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(_httpResponseMessage);
        }
    }

    public class DefaultResult : IHttpActionResult
    {
        private HttpRequestMessage _request;
        private HttpResponseMessage _httpResponseMessage;


        public DefaultResult(HttpRequestMessage request, HttpResponseMessage httpResponseMessage)
        {
            _request = request;
            _httpResponseMessage = httpResponseMessage;
        }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(_httpResponseMessage);
        }
    }
}