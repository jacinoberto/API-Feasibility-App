using Application.CQRS.RegionConsultationCQRS.Commands;
using Application.CQRS.RegionConsultationCQRS.Queries;
using Application.DTOs.RegionConsultationDTO;
using Application.Interfaces;
using Application.Mappings;
using MediatR;

namespace Application.Services;

public class RegionConsultationServiceImpl(IMediator mediator) : IRegionConsultationService
{
    private readonly IMediator _mediator = mediator;
    
    public async Task CreateAllAsync(IEnumerable<CreateRegionConsultationDto> dtos)
    {
        foreach (var dto in dtos)
        {
            await _mediator.Send(new CreateRegionConsultationCommand(dto.CompanyId, dto.StateId));
        }
    }

    public async Task<IEnumerable<ReturnRegionConsultationDto>> GetByCompanyIdAsync(Guid companyId)
    {
        var list = await _mediator.Send(new ReturnRegionConsultationByCompanyIdQuery(companyId));
        return list.Select(rc => RegionConsultationMapper.MapToReturnRegionConsultationDto(rc)).ToList();
    }
}