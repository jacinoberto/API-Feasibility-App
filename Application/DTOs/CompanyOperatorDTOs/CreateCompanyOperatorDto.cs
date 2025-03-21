namespace Application.DTOs.CompanyOperatorDTOs;

public record CreateCompanyOperatorDto(
    Guid CompanyId,
    Guid OperatorId
    );