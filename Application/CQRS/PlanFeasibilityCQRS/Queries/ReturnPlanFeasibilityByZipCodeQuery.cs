﻿using Domain.Entities;
using MediatR;

namespace Application.CQRS.PlanFeasibilityCQRS.Queries;

public class ReturnPlanFeasibilityByZipCodeQuery(Guid companyId, Guid operatorId, string zipCode) : IRequest<PlanFeasibility>
{
    public Guid CompanyId { get; set; } = companyId;
    public Guid OperatorId { get; set; } = operatorId;
    public string ZipCode { get; set; } = zipCode;
}