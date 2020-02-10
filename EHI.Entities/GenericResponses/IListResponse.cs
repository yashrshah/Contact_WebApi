using System.Collections.Generic;

namespace EHI.Entities.GenericResponses
{
    public interface IListResponse<TModel> : IResponse
    {
        IEnumerable<TModel> Model { get; set; }
    }
}
