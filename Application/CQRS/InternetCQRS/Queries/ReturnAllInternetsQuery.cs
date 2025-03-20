using Domain.Entities;
using MediatR;

namespace Application.CQRS.InternetCQRS.Queries;

public class ReturnAllInternetsQuery() : IRequest<IEnumerable<Internet>>
{
    
}