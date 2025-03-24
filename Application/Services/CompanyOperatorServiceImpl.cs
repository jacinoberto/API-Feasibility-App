using Application.CQRS.CompanyOperatorCQRS.Commands;
using Application.CQRS.CompanyOperatorCQRS.Queries;
using Application.DTOs.CompanyOperatorDTOs;
using Application.Interfaces;
using Application.Mappings;
using MediatR;

namespace Application.Services;

public class CompanyOperatorServiceImpl(IMediator mediator) : ICompanyOperatorService
{
    private readonly IMediator _mediator = mediator;
    
    public async Task CreateAsync(CreateCompanyOperatorDto dto)
    {
        await _mediator.Send(new CreateCompanyOperatorCommand(dto.CompanyId, dto.OperatorId));
    }

    public async Task<IEnumerable<ReturnCompanyOperatorDto>> GetByCompanyIdAsync(Guid companyId)
    {
        var list = await _mediator.Send(new ReturnCompanyOperatorByCompanyIdQuery(companyId));
        return list.Select(co => CompanyOperatorMapper.MapToReturnCompanyOperatorDto(co)).ToList();
    }
}