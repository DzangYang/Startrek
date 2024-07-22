namespace HR.Application.DTO.Requests.Interviews;
public sealed record CancelInterviewRequest(Guid id, string motive);
