using HR.Domain.Entities;

namespace HR.Application.DTO.Responces.Interviews;

public sealed record GetInterviewsResponce(IEnumerable<Interview> Interviews);