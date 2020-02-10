using EHI.Application.Attributes;
using EHI.Application.Extensions;
using EHI.Entities.CustomEntities.Contact;
using EHI.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EHI.Application.Controllers
{
    [RouteController]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        protected IContactService contactService;

        public ContactsController(IContactService contactService)
        {
            this.contactService = contactService;
        }

        [HttpGet]
        public async Task<IActionResult> GetContacts()
        {
            var response = await contactService.GetContacts();
            return response.ToHttpResponse();
        }

        [HttpGet]
        [Route("{contactId:int}")]
        public async Task<IActionResult> GetContact(int contactId)
        {
            var response = await contactService.GetContact(contactId);
            return response.ToHttpResponse();
        }

        [HttpPost]
        public async Task<IActionResult> AddContact([FromBody]AddContact contactToAdd)
        {
            var response = await contactService.AddContact(contactToAdd);
            return response.ToHttpResponse();
        }

        [HttpPut]
        [Route("{contactId:int}")]
        public async Task<IActionResult> UpdateContact(int contactId,[FromBody]UpdateContact contactToUpdate)
        {
            var response = await contactService.UpdateContact(contactId, contactToUpdate);
            return response.ToHttpResponse();
        }

        [HttpDelete]
        [Route("{contactId:int}")]
        public async Task<IActionResult> DeleteContact(int contactId)
        {
            var response = await contactService.RemoveContact(contactId);
            return response.ToHttpResponse();
        }
        [HttpPatch]
        [Route("{contactId:int}")]
        public async Task<IActionResult> InactiveContact(int contactId)
        {
            var response = await contactService.InactiveContact(contactId);
            return response.ToHttpResponse();
        }

    }
}