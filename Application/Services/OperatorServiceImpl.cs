using Application.CQRS.OperatorCQRS;
using Application.CQRS.OperatorCQRS.Commands;
using Application.CQRS.OperatorCQRS.Queries;
using Application.DTOs.OperatorDTOs;
using Application.DTOs.PlanDTOs;
using Application.Interfaces;
using Application.Mappings;
using MediatR;

namespace Application.Services;

public class OperatorServiceImpl(IMediator mediator) : IOperatorService
{
    private readonly IMediator _mediator = mediator;
    
    public async Task CreateOperatorAsync(CreateOperatorDto dto)
    {
        await _mediator.Send(new CreateOperatorCommand(dto.OperatorName));
    }

    public async Task<ReturnOperatorDto> GetByIdAsync(Guid id)
    {
        return OperatorMapper.MapToReturnOperatorDto(
            await _mediator.Send(new ReturnOperatorByIdQuery(id)));
    }

    public async Task<IEnumerable<ReturnOperatorDto>> GetAllAsync()
    {
        var operators = await _mediator.Send(new ReturnAllOperatorQuery());
        
        return operators
            .Select(o => new ReturnOperatorDto(o.Id, o.OperatorName))
            .ToList();
    }
}