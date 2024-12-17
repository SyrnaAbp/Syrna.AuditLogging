using AutoMapper;

namespace Syrna.AuditLogging.Blazor
{
    public class AuditLoggingBlazorAutoMapperProfile : Profile
    {
        public AuditLoggingBlazorAutoMapperProfile()
        {
            /* You can configure your AutoMapper mapping configuration here.
             * Alternatively, you can split your mapping configurations
             * into multiple profile classes for a better organization. */
            //CreateMap<PrivateMessageDto, CreatePrivateMessageDto>().Ignore(x => x.ExtraProperties);
            //CreateMap<PrivateMessageDto, DetailsPrivateMessageViewModel>().Ignore(x => x.ExtraProperties);
            //CreateMap<CreatePrivateMessageViewModel, CreatePrivateMessageDto>().Ignore(x => x.ExtraProperties);
            //CreateMap<PrivateMessageDto, PrivateMessageViewModel>().Ignore(x => x.ExtraProperties);
        }
    }
}