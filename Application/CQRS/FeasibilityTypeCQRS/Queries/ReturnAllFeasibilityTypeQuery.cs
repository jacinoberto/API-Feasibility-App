using Domain.Entities;
using MediatR;

namespace Application.CQRS.FeasibilityTypeCQRS.Queries;

public class ReturnAllFeasibilityTypeQuery : IRequest<IEnumerable<FeasibilityType>> {}