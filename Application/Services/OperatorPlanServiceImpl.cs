using Application.CQRS.OperatorCQRS.Commands;
using Application.CQRS.OperatorCQRS.Queries;
using Application.CQRS.OperatorPlanCQRS.Commands;
using Application.CQRS.OperatorPlanCQRS.Queries;
using Application.CQRS.PlanCQRS.Commands;
using Application.DTOs.OperationPlanDTOs;
using Application.Interfaces;
using Application.Mappings;
using MediatR;

namespace Application.Services;

public class OperatorPlanServiceImpl(IMediator mediator) : IOperatorPlanService
{
    private readonly IMediator _mediator = mediator;
    
    public async Task CreateAsync(CreateOperatorPlanDto dto)
    {
        // Busca a operadora pelo nome informado
        var operatorExist = await _mediator.Send(new ReturnOperatorByNameQuery(dto.Operator.OperatorName));
        
        /*
         * Se uma operadora for retornada ela é vinculada aos planos, caso contrário é realizado o cadastro de uma nova
         * operadora e vinculo entre os planos.
         */
        if (operatorExist is not null)
        {
            var planResult = await _mediator.Send(new CreatePlanCommand(dto.Plan.InternetId, dto.Plan.PlanName,
                dto.Plan.Value));
            
            await _mediator.Send(new CreateOperatorPlanCommand(operatorExist.Id, planResult.Id));
            
        }
        else
        {
            var operatorResult = await _mediator.Send(new CreateOperatorCommand(dto.Operator.OperatorName));
            var planResult = await _mediator.Send(new CreatePlanCommand(dto.Plan.InternetId, dto.Plan.PlanName,
                dto.Plan.Value));
            
            await _mediator.Send(new CreateOperatorPlanCommand(operatorResult.Id, planResult.Id));
        }
    }

    public async Task<IEnumerable<ReturnOperatorPlanDto>> GetPlansByOperatorIdAsync(Guid operatorId)
    {
        var list = await _mediator.Send(new ReturnOperatorPlanByOperatorIdQuery(operatorId));
        return list.Select(op => OperatorPlanMapper.MapToReturnOperatorPlanDto(op)).ToList();
    }
}