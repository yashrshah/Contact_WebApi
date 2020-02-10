using System.Collections.Generic;
using System.Net;

namespace EHI.Entities.GenericResponses
{
    public class ListResponse<TModel> : IListResponse<TModel>
    {
        public HttpStatusCode HttpCode { get; set; }

        public string Message { get; set; }

        public bool IsError { get; set; }

        public IEnumerable<TModel> Model { get; set; }
    }
}
