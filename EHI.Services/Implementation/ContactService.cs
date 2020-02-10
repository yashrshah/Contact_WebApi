using AutoMapper;
using EHI.Data.DbModels;
using EHI.Data.GenericRepository;
using EHI.Entities.Constants;
using EHI.Entities.CustomEntities.Contact;
using EHI.Entities.GenericResponses;
using EHI.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace EHI.Services.Implementation
{
    public class ContactService : IContactService
    {
        private readonly IRepository<UserContact> _contactRepository;
        private readonly IMapper _mapper;

        public ContactService(IRepository<UserContact> contactRepository, IMapper mapper)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }

        public async Task<ISingleResponse<DtoContact>> AddContact(AddContact contactToAdd)
        {
            var response = new SingleResponse<DtoContact>();
            var contactDbModel = _mapper.Map<UserContact>(contactToAdd);
            contactDbModel.Status = true;
            await _contactRepository.AddAsync(contactDbModel);
            response.Model = _mapper.Map<DtoContact>(contactDbModel);
            response.SetResponse(false,HttpResponseMessages.DATA_ADD_SUCCESS, HttpStatusCode.OK);
            return response;
        }

        public async Task<ISingleResponse<DtoContact>> GetContact(int contactId)
        {
            var response = new SingleResponse<DtoContact>();
            var getContactByIdQuery = _contactRepository.GetAll().Where(x => x.Id == contactId);

            if (await getContactByIdQuery.AnyAsync())
            {
                response.Model = _mapper.Map<DtoContact>(await getContactByIdQuery.FirstOrDefaultAsync());
                response.SetResponse(false, HttpResponseMessages.DATA_FOUND_SUCCESS, HttpStatusCode.OK);
            }
            else
            {
                response.Model = null;
                response.SetResponse(false, HttpResponseMessages.NO_DATA_FOUND, HttpStatusCode.OK);
            }
            return response;
        }

        public async Task<IListResponse<DtoContact>> GetContacts()
        {
            var response = new ListResponse<DtoContact>();
            var getContacts = _contactRepository.GetAll();
            if (await getContacts.AnyAsync())
            {
                response.Model = _mapper.Map<List<DtoContact>>(await getContacts.ToListAsync());
                response.SetResponse(false, HttpResponseMessages.DATA_FOUND_SUCCESS, HttpStatusCode.OK);
            }
            else
            {
                response.Model = null;
                response.SetResponse(false, HttpResponseMessages.NO_DATA_FOUND, HttpStatusCode.OK);
            }
            return response;
        }

        public async Task<ISingleResponse<DtoContact>> InactiveContact(int contactId)
        {
            var response = new SingleResponse<DtoContact>();
            var contactDbModel = await _contactRepository.GetAll().Where(x => x.Id == contactId).FirstOrDefaultAsync();
            if (contactDbModel != null)
            {
                contactDbModel.Status = false;
                await _contactRepository.UpdateAsync(contactDbModel);
                response.Model = _mapper.Map<DtoContact>(contactDbModel);
                response.SetResponse(false, HttpResponseMessages.DATA_UPDATE_SUCCESS, HttpStatusCode.OK);
            }
            else
            {
                response.Model = null;
                response.SetResponse(true, HttpResponseMessages.NO_DATA_FOUND, HttpStatusCode.OK);
            }
            return response;
        }

        public async Task<ISingleResponse<DtoContact>> RemoveContact(int contactId)
        {
            var response = new SingleResponse<DtoContact>();
            var contactDbModel = await _contactRepository.GetAll().Where(x => x.Id == contactId).FirstOrDefaultAsync();
            if (contactDbModel != null)
            {
                await _contactRepository.DeleteAsync(contactDbModel);
                response.Model = _mapper.Map<DtoContact>(contactDbModel);
                response.SetResponse(false, HttpResponseMessages.DATA_DELETE_SUCCESS, HttpStatusCode.OK);
            }
            else
            {
                response.Model = null;
                response.SetResponse(true, HttpResponseMessages.NO_DATA_FOUND, HttpStatusCode.OK);
            }
            return response;
        }

        public async Task<ISingleResponse<DtoContact>> UpdateContact(int contactId, UpdateContact contactToUpdate)
        {
            var response = new SingleResponse<DtoContact>();
            var contactDbModel = await _contactRepository.GetAll().Where(x => x.Id == contactId).FirstOrDefaultAsync();
            if (contactDbModel != null)
            {
                contactDbModel = _mapper.Map(contactToUpdate, contactDbModel);
                await _contactRepository.UpdateAsync(contactDbModel);
                response.Model = _mapper.Map<DtoContact>(contactDbModel);
                response.SetResponse(false, HttpResponseMessages.DATA_UPDATE_SUCCESS, HttpStatusCode.OK);
            }
            else
            {
                response.Model = null;
                response.SetResponse(true, HttpResponseMessages.NO_DATA_FOUND, HttpStatusCode.OK);
            }
            return response;
        }
    }
}
