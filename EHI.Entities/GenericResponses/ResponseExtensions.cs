using System;
using System.Net;

namespace EHI.Entities.GenericResponses
{
    public static class ResponseExtensions
    {
        public static void SetError(this IResponse response, Exception ex)
        {
            response.IsError = true;
            response.HttpCode = HttpStatusCode.InternalServerError;
            if (ex as ApplicationException == null)
            {
                response.Message = "There was an internal error, please contact to technical support.";
            }
            else
            {
                response.Message = ex.Message;
            }
        }

        public static void SetResponse(this IResponse response, bool isError, string message, HttpStatusCode httpCode)
        {
            response.IsError = isError;
            response.HttpCode = httpCode;
            response.Message = message;
        }
    }
}