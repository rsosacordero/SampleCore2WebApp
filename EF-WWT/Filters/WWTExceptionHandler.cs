using EF_WWT.Exceptions;
using System;

namespace EF_WWT.Filters
{
    public interface IWWTExceptionHandler
    {
        ApiError HandleException(Exception exc);
    }
    public class WWTExceptionHandler : IWWTExceptionHandler
    {
        public ApiError HandleException(Exception exc)
        {
            ApiError errorResponse = null; 
            if (exc is ResourceNotFoundException)
            {
                var rnfException = exc as ResourceNotFoundException;

                errorResponse = new ApiError(exc.Message, exc.InnerException?.StackTrace, System.Net.HttpStatusCode.NotFound); 
            }
            else
            {
                errorResponse = new ApiError("An unhandled error occurred.", null, System.Net.HttpStatusCode.InternalServerError);
            }
            return errorResponse; 
        }
    }
}
