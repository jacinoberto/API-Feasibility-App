using Application.CQRS.RegionConsultationCQRS.Queries;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.CQRS.RegionConsultationCQRS.Handle;

public class ReturnRegionConsultationByCompanyIdQueryHandle(IRegionConsultationRepository repository)
    : IRequestHandler<ReturnRegionConsultationByCompanyIdQuery, IEnumerable<RegionConsultation>>
{
    private readonly IRegionConsultationRepository _repository = repository;
    
    public async Task<IEnumerable<RegionConsultation>> Handle(ReturnRegionConsultationByCompanyIdQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetByCompanyIdAsync(request.CompanyId);
    }
}