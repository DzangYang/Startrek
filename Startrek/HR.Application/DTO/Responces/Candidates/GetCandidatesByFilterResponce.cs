using HR.Domain.Entities;

namespace HR.Application.DTO.Responces.Candidates;
public sealed record GetCandidatesByFilterResponce(List<Candidate> candidates);

