namespace HR.Application.DTO.Requests;

public sealed  record BindVacancyRequest(Guid VacancyId, Guid CandidateId);