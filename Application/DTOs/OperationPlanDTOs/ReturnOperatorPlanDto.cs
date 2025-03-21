namespace Application.DTOs.OperationPlanDTOs;

public record ReturnOperatorPlanDto(
    Guid Id,
    string Operator,
    string Plan,
    string Internet,
    decimal Value
    );