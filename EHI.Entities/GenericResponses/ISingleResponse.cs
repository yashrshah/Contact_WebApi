namespace EHI.Entities.GenericResponses
{
    public interface ISingleResponse<TModel> : IResponse
    {
        TModel Model { get; set; }
    }
}
