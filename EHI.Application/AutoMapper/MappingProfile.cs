using AutoMapper;
using EHI.Data.DbModels;
using EHI.Entities.CustomEntities.Contact;

namespace EHI.Application.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<UserContact, DtoContact>()
                .ForMember(dest => dest.ContactId, opt => opt.MapFrom(src => src.Id))
             .ForMember(dest => dest.Active, opt => opt.MapFrom(src => src.Status));

            CreateMap<AddContact, UserContact>();


            CreateMap<UpdateContact, UserContact>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Active))
             .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
