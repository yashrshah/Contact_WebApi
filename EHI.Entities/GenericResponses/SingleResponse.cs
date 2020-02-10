using System.Net;

namespace EHI.Entities.GenericResponses
{
    public class SingleResponse<TModel> : ISingleResponse<TModel> where TModel : new()
    {
        public SingleResponse()
        {
            Model = new TModel();
        }

        public HttpStatusCode HttpCode { get; set; }

        public string Message { get; set; }

        public bool IsError { get; set; }

        public TModel Model { get; set; }
    }
}
