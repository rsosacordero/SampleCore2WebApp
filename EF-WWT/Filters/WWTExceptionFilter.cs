using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EF_WWT.Filters
{
    public class WWTExceptionFilter : IExceptionFilter
    {
        private readonly IWWTExceptionHandler _handler;
        public WWTExceptionFilter(IWWTExceptionHandler handler)
        {
            _handler = handler;
        }

        public void OnException(ExceptionContext context)
        {
            var response = _handler.HandleException(context.Exception);

            context.ExceptionHandled = true;

            context.HttpContext.Response.StatusCode = (int)response.StatusCode;

            context.Result = new JsonResult(new { Message = response.Message });


        }
    }
}
