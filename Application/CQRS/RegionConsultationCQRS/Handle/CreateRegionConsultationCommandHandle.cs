using Application.CQRS.RegionConsultationCQRS.Commands;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.CQRS.RegionConsultationCQRS.Handle;

public class CreateRegionConsultationCommandHandle(IRegionConsultationRepository repository) : IRequestHandler<CreateRegionConsultationCommand, RegionConsultation>
{
    private readonly IRegionConsultationRepository _repository = repository;
    
    public async Task<RegionConsultation> Handle(CreateRegionConsultationCommand request, CancellationToken cancellationToken)
    {
        return await _repository.CreateAsync(new RegionConsultation(request.CompanyId, request.StateId));
    }
}