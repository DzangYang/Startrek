using HR.Domain.Enums;

namespace HR.Application.DTO.Requests.Candidates;
public sealed record GetCandidateByFilterRequest(Guid id, string LastName, string FirstName, string MiddleName, Gender Gender, DateTime BirthDay, DateTime CreatedDate, int Experience);
