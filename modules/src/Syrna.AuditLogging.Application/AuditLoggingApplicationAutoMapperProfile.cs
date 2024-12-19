using AutoMapper;
using Syrna.AuditLogging.Dtos;
using Volo.Abp.AuditLogging;

namespace Syrna.AuditLogging;

public class AuditLoggingApplicationAutoMapperProfile : Profile
{
    public AuditLoggingApplicationAutoMapperProfile()
    {
        CreateMap<AuditLog, AuditLogListDto>();
        CreateMap<AuditLogAction, AuditLogActionDetailDto>();
        CreateMap<AuditLog, AuditLogDetailDto>()
            .ForMember(entity => entity.Actions, opt => opt.MapFrom(src => src.Actions));
    }
}