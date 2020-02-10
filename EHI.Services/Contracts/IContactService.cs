using EHI.Entities.CustomEntities.Contact;
using EHI.Entities.GenericResponses;
using System.Threading.Tasks;

namespace EHI.Services.Contracts
{
    public interface IContactService
    {
        Task<IListResponse<DtoContact>> GetContacts();
        Task<ISingleResponse<DtoContact>> GetContact(int contactId);
        Task<ISingleResponse<DtoContact>> AddContact(AddContact contactToAdd);

        Task<ISingleResponse<DtoContact>> UpdateContact(int contactId,UpdateContact contactToUpdate);

        Task<ISingleResponse<DtoContact>> RemoveContact(int contactId);
        Task<ISingleResponse<DtoContact>> InactiveContact(int contactId);
    }
}
