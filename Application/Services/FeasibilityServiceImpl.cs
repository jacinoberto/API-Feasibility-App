using Application.CQRS.AddressCQRS.Commands;
using Application.CQRS.AddressCQRS.Queries;
using Application.CQRS.CompanyOperatorCQRS.Queries;
using Application.CQRS.FeasibilityCQRS.Commands;
using Application.CQRS.FeasibilityCQRS.Queries;
using Application.CQRS.OperatorCQRS.Commands;
using Application.CQRS.OperatorCQRS.Queries;
using Application.CQRS.PlanObservationCQRS.Queries;
using Application.CQRS.StateCQRS.Queries;
using Application.CQRS.ViabilityRuleCQRS.Queries;
using Application.DTOs.FeasibilityDTO;
using Application.DTOs.ObservationDTO;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;

namespace Application.Services;

public class FeasibilityServiceImpl(IMediator mediator) : IFeasibilityService
{
    private readonly IMediator _mediator = mediator;
    
    public async Task CreateAsync(CreateFeasibilityDto dto)
    {
        var operatorExist = await _mediator.Send(new ReturnOperatorByNameQuery(dto.Operator)) ?? null;
        var state = await _mediator.Send(new ReturnStateByUfQuery(dto.State));
        // address = await _mediator.Send(new ReturnAddressByParametersQuery(dto.ZipCode, dto.City, dto.State)) ?? null;

        if (operatorExist is null) operatorExist = await _mediator.Send(new CreateOperatorCommand(dto.Operator));
        var address = await _mediator.Send(new CreateAddressCommand(state.Id, dto.ZipCode, dto.Street,
            dto.Number, dto.Area, dto.City));

        Console.WriteLine(operatorExist.Id + "," + address.Id);
        var teste = new CreateFeasibilityCommand(operatorExist.Id, address.Id);
        Console.WriteLine(teste.OperatorId + "," + teste.AddressId);
        
        await _mediator.Send(teste);
    }

    public async Task CreateAllAsync(IEnumerable<CreateFeasibilityDto> dtos)
    {
        foreach (var dto in dtos)
        {
            await CreateAsync(dto);
        }
    }
    
    public async Task<IEnumerable<ReturnFeasibilityDto>> GetByCityAndStateAsync(string city, string state, Guid companyId, Guid operatorId)
    {
        if (!await _mediator.Send(new ReturnCompanyOperatorQuery(companyId, operatorId)))
            throw new InternalErrorException("Sua empresa não foi vinculada a uma operadora.");

        ICollection<ReturnFeasibilityDto> dtos = [];
        
        if (await _mediator.Send(new ReturnFeasibilityByCityAndStateQuery(city, state, companyId, operatorId)))
        {
            var viabilityRules = await _mediator.Send(new ReturnViabilityRuleByCityAndStateQuery(city, state, companyId));

            foreach (var vr in viabilityRules)
            {
                var observations = await _mediator.Send(new ReturnPlanObservationByPlanIdQuery(vr.PlanId));
                var observationDto = observations.Select(
                    o => new ReturnObservationDto(o.Id, o.Observation.PlanObservation)).ToList();

                dtos.Add(new ReturnFeasibilityDto(vr.Id, vr.Plan.PlanName, vr.Plan.Internet.InternetSpeed + " " + vr.Plan.Internet.SpeedType,
                    vr.Plan.Value, observationDto));
            }

            return dtos;
        }

        throw new NotFoundException("Não há viabilidade");
    }
    
    public async Task<IEnumerable<ReturnFeasibilityDto>> GetByZipCodeAsync(string zipCode, Guid companyId, Guid operatorId)
    {
        if (await _mediator.Send(new ReturnFeasibilityByZipCodeQuery(zipCode, companyId, operatorId)))
        {
            var viabilityRules = await _mediator.Send(new ReturnViabilityRuleByZipCodeQuery(zipCode, companyId));
            
            ICollection<ReturnFeasibilityDto> dtos = [];
            foreach (var vr in viabilityRules)
            {
                var observations = await _mediator.Send(new ReturnPlanObservationByPlanIdQuery(vr.PlanId));
                var observationDto = observations.Select(
                    o => new ReturnObservationDto(o.Id, o.Observation.PlanObservation)).ToList();

                dtos.Add(new ReturnFeasibilityDto(vr.Id, vr.Plan.PlanName, vr.Plan.Internet.InternetSpeed + " " + vr.Plan.Internet.SpeedType,
                    vr.Plan.Value, observationDto));
            }

            return dtos;
        }

        throw new NotFoundException("Não há viabilidade");
    }
    
    public async Task<ICollection<ReturnFeasibilityDto>> GetByCityAsync(string city, Guid companyId, Guid operatorId)
    {
        if (await _mediator.Send(new ReturnFeasibilityByCityQuery(city, companyId, operatorId)))
        {
            var viabilityRules = await _mediator.Send(new ReturnViabilityRuleByCityQuery(city, companyId));
            
            ICollection<ReturnFeasibilityDto> dtos = [];
            foreach (var vr in viabilityRules)
            {
                var observations = await _mediator.Send(new ReturnPlanObservationByPlanIdQuery(vr.PlanId));
                var observationDto = observations.Select(
                    o => new ReturnObservationDto(o.Id, o.Observation.PlanObservation)).ToList();

                dtos.Add(new ReturnFeasibilityDto(vr.Id, vr.Plan.PlanName, vr.Plan.Internet.InternetSpeed + " " + vr.Plan.Internet.SpeedType,
                    vr.Plan.Value, observationDto));
            }

            return dtos;
        }

        throw new NotFoundException("Não há viabilidade");
    }
}