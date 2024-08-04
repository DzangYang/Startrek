namespace HR.Application.DTO.Requests;

public sealed record UpdateVacancyRequest(Guid PositionId, int Experience);
