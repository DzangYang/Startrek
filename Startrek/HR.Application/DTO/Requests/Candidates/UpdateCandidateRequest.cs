using HR.Domain.Enums;

namespace HR.Application.DTO.Requests.Candidates;

public sealed record UpdateCandidateRequest(Guid Id, string LastName,
    string MiddleName, string FirstName, Gender Gender, int Experience,
    DateTime CreatedDate, DateTime BirthDay);
