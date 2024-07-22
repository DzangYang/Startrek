using FluentValidation;
using HR.Application.Abstractions;
using HR.Application.DTO.Requests.Interviews;
using HR.Application.DTO.Responces.Interviews;
using HR.Application.FluentValidationServices;
using HR.Domain.Entities;
using HR.Domain.Repositories;

namespace HR.Application.Services;
public class InterviewService(IInterviewRepository interviewRepository) : IInterviewService
{
    /// <summary>
    /// Отменить интервью
    /// </summary>
    /// <exception cref="NotImplementedException"></exception>
    public void CancelInterview(CancelInterviewRequest request)
    {
        interviewRepository.CancelInterview(request.id, request.motive);
    }

    /// <summary>
    /// Перенести интервью
    /// </summary>
    /// <exception cref="NotImplementedException"></exception>
    public void RelocateInterview(RelocateInterviewRequest request)
    {
        interviewRepository.RelocateInterview(request.id, request.dateOfEvent);
    }

    /// <summary>
    /// Провести интервью
    /// </summary>
    /// <param name="request"></param>
    public void ConductInterview(ConductTheInterviewRequest request)
    {
        interviewRepository.ConductInterviewByCandidateId(request.id);
    }

    public CreateInterviewResponce Create(CreateInterviewRequest request)
    {
        var validator = new CreateInterviewValidator();
        var results = validator.Validate(request);
        if (!results.IsValid)
            validator.ValidateAndThrow(request);

        var interview = new Interview()
        {
            Id = Guid.NewGuid(),
            CandidateId = request.candidateId,
            AuthorId = request.authorId,
            Comment = request.comment,
            Feedback = request.feedback,
            VacancyId = request.vacancyId,
            Conducted = request.conducted,
            DateOfEvent = request.dateOfEvent,
        };

        interviewRepository.Add(interview);

        return new CreateInterviewResponce(interview.Id);
    }

    
}
