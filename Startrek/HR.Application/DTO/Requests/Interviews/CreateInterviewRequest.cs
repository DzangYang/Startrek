namespace HR.Application.DTO.Requests.Interviews;
public sealed record CreateInterviewRequest(
        Guid candidateId, bool conducted,
        DateTime dateOfEvent, string? comment, string? feedback, Guid authorId, Guid vacancyId);
