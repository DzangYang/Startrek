using HR.Domain.Enums;

namespace HR.Domain;
public sealed record CandidateFilter(
    string? LastName, string? FirstName, string? MiddleName, Gender? Gender, DateTime? BirthDay, DateTime? CreatedDate, int? Experience);

