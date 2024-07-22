namespace HR.Application.DTO.Requests.Offers;

public sealed record CreateOfferRequest(
    Guid InterviewId,
    Guid VacancyId,
    string Description);
