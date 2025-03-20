using Application.CQRS.CompanyCQRS.Commands;
using Application.CQRS.CompanyCQRS.Queries;
using Application.DTOs.CompanyDTOs;
using Application.Interfaces;
using Application.Mappings;
using MediatR;

namespace Application.Services;

public class CompanyServiceImpl(IMediator mediator) : ICompanyService
{
    private readonly IMediator _mediator = mediator;
    
    public async Task CreateAsync(CreateCompanyDto dto)
    {
       await _mediator.Send(new CreateCompanyCommand(dto.CompanyName, dto.CompanyCode, dto.ResponsibleContact, dto.FinancialContact,
            dto.ResponsibleEmail, dto.FinancialEmail));
    }

    public async Task<ReturnCompanyDto> GetByIdAsync(Guid id)
    {
        return CompanyMapper.MapToReturnCompanyDto(
            await _mediator.Send(new ReturnCompanyByIdQuery(id)));
    }
}