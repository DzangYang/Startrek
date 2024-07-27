namespace HR.Application.DTO.Requests;

public  sealed record CreateVacancyRequest(Guid PositionId, int Expetience, DateTime CreatedDate);