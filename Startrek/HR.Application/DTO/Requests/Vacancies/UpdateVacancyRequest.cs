namespace HR.Application.DTO.Requests;

public sealed record UpdateVacancyRequest(Guid Id, Guid PositionId, int Experience, DateTime CreatedDate);
